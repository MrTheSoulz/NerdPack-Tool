using Octokit;
using Octokit.Internal;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace NerdPackToolBox
{
    public partial class mainframe
    {

        static InMemoryCredentialStore credentials = new InMemoryCredentialStore(new Credentials("30056b2d3c0ae1b13319d6aa8d997e5ffc9cfcec"));
        static GitHubClient client = new GitHubClient(new ProductHeaderValue("NerdPack-Tool"), credentials);

        private int _CountTotal()
        {
            int tcount = 0;
            foreach (DataGridViewRow row in CR_DATA.Rows)
                if ((Boolean)row.Cells["CheckBox"].Value == true)
                    tcount++;
            foreach (DataGridViewRow row in MOD_DATA.Rows)
                if ((Boolean)row.Cells["dataGridViewCheckBoxColumn1"].Value == true)
                    tcount++;
            if (PROTECTED_CHECK.Checked)
                tcount++;
            return tcount + 1;
        }

        public async void UpdateAddonsAsync()
        {
            int tcount = _CountTotal();
            int current = 0;

            // Core
            await DownloadAddon("MrTheSoulz", "NerdPack");
            current++;
            progressBar1.Value = (current / tcount) * 100;

            // Protected
            if (PROTECTED_CHECK.Checked)
                await DownloadAddon("MrTheSoulz", "NerdPack-Protected");
            current++;
            progressBar1.Value = (current / tcount) * 100;

            // Combat Routines
            foreach (DataGridViewRow row in CR_DATA.Rows)
                if ((Boolean)row.Cells["CheckBox"].Value == true)
                {
                    string owner = (string)row.Cells["OWNER"].Value;
                    string repo = (string)row.Cells["REPO"].Value;
                    await DownloadAddon(owner, repo);
                    current++;
                    progressBar1.Value = (current / tcount) * 100;
                }

            // Modules
            foreach (DataGridViewRow row in MOD_DATA.Rows)
                if ((Boolean)row.Cells["dataGridViewCheckBoxColumn1"].Value == true)
                {
                    string owner = (string)row.Cells["dataGridViewTextBoxColumn4"].Value;
                    string repo = (string)row.Cells["dataGridViewTextBoxColumn5"].Value;
                    await DownloadAddon(owner, repo);
                    current++;
                    progressBar1.Value = (current / tcount) * 100;
                }
        }

        // Download
        public async Task DownloadAddon(string owner, string _repo)
        {
            var repo = await client.Repository.Get(owner, _repo);
            string name = repo.Name;
            string uri = repo.HtmlUrl;
            string fileName = name + ".zip";
            string tPath = LOC_INPUT.Text + (legacyCB.Checked ? "" : "\\_retail_") + "\\Interface\\AddOns\\" + name;
            string text = "0.0";
            try
            {
                // check if we need to update
                if (File.Exists(tPath + "\\Version.txt"))
                    text = File.ReadAllText(tPath + "\\Version.txt");

                // Update IF needed
                if (!text.Contains(repo.PushedAt.ToString()))
                {
                    WriteToLog("Found update for: " + name);
                    //delete the old folder if any
                    if (Directory.Exists(tPath))
                    {
                        // make a backup
                        if (BACKUPS_CHECK.Checked)
                            await BackUpFolder(tPath, name);

                        await DeleteRecursiveFolder(tPath); ;
                    }
                    // Download using lib2Sharp
                    WriteToLog("Downloading " + name);
                    await Task.Run(() => LibGit2Sharp.Repository.Clone(repo.CloneUrl, tPath));
                    // Add or version file
                    await WriteToFile(tPath + "//Version.txt", repo.PushedAt.ToString());
                    WriteToLog("Done with:" + name);
                }
                else
                    WriteToLog(name + " Is Up-to-date!");
            }
            catch
            {
                WriteToLog("Error while " + name);
            }
        }

        //Build Core Info
        public async void GetCoreInfo()
        {
            try
            {
                var repo = await client.Repository.Get("MrTheSoulz", "NerdPack");
                UPDATED_TEXT.Text = "" + repo.PushedAt;
                STARS_TEXT.Text = "" + repo.StargazersCount;
                FORKS_TEXT.Text = "" + repo.ForksCount;
                GIT_BT.Click += (sender, args) =>
                Process.Start("" + repo.HtmlUrl + "/issues");
            }
            catch
            {
                UPDATED_TEXT.Text = "UNAVAILABLE";
                STARS_TEXT.Text = "UNAVAILABLE";
                FORKS_TEXT.Text = "UNAVAILABLE";
            }
        }

        private async 
        Task
Build_CRAsync(string Owner, string Repo)
        {
            try
            {
                var repo = await client.Repository.Get(Owner, Repo);
                var installed = File.Exists(LOC_INPUT.Text + "\\Interface\\AddOns\\" + repo.Name + "\\Version.txt");
                CR_DATA.Rows.Add(installed, repo.Name, repo.Description, repo.StargazersCount, Owner, Repo, repo.UpdatedAt);
            }
            catch
            {
                WriteToLog("ERROR: CR " + Owner + "/" + Repo + " is missing!");
            }
        }

        private async 
        Task
Build_NodulesAsync(string Owner, string Repo)
        {
            try
            {
                var repo = await client.Repository.Get(Owner, Repo);
                bool installed = File.Exists(LOC_INPUT.Text + "\\Interface\\AddOns\\" + repo.Name + "\\Version.txt");
                MOD_DATA.Rows.Add(installed, repo.Name, repo.Description, repo.StargazersCount, Owner, Repo, repo.UpdatedAt);
            }
            catch
            {
                WriteToLog("ERROR: Module " + Owner + "/" + Repo + " is missing!");
            }
        }

        public async void BuildToolData()
        {
            CR_DATA.Rows.Clear();
            CR_DATA.Refresh();
            CR_DATA.Enabled = true;
            MOD_DATA.Rows.Clear();
            MOD_DATA.Refresh();
            MOD_DATA.Enabled = true;
            try
            {
                XmlDocument xdcDocument = new XmlDocument();
                xdcDocument.Load(RemoteData); //found in tools.cs

                //Routines
                XmlElement xelRoot = xdcDocument.DocumentElement;
                XmlNodeList xnlNodes = xelRoot.SelectNodes("/ToolboxData/CombatRoutines/Button");
                foreach (XmlNode xndNode in xnlNodes)
                {
                    string Owner = xndNode["Owner"].InnerText;
                    string Repo = xndNode["Repo"].InnerText;
                    await Build_CRAsync(Owner, Repo);
                }

                // Modules
                xnlNodes = xelRoot.SelectNodes("/ToolboxData/Plugins/Button");
                foreach (XmlNode xndNode in xnlNodes)
                {
                    string Owner = xndNode["Owner"].InnerText;
                    string Repo = xndNode["Repo"].InnerText;
                    await Build_NodulesAsync(Owner, Repo);
                }
            }
            catch
            {
                WriteToLog("ERROR: ´failed to load DB xml from " + RemoteData);
            }
        }

    }
}
