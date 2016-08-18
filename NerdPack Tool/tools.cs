using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace WindowsFormsApplication1
{

    public partial class mainframe
    {
        // Download
        private async void Download(string owner, string _repo)
        {
            // Progress bar
            IProgress<int> progress = new Progress<int>(value => { progressBar1.Value = value; });
            await Task.Run(() =>
            {
                for (int i = 0; i <= 100; i++)
                    progress.Report(i);
            });
            try
            {
                ThreadPool.QueueUserWorkItem(async delegate {
                    var repo = await client.Repository.Get(owner, _repo);
                    string name = repo.Name;
                    string uri = repo.HtmlUrl;
                    string fileName = name + ".zip";
                    string exePath = Application.StartupPath;
                    string oPath = exePath + "\\" + name;
                    string tPath = LOC_INPUT.Text + "\\" + name;
                    string zPath = LOC_INPUT.Text;
                    //Create a backup
                    if (BACKUPS_CHECK.Checked && Directory.Exists(tPath))
                    {
                        BackupFile(tPath, name);
                    }

                    LibGit2Sharp.Repository.Clone(repo.CloneUrl, tPath);
                    // add a version file
                    WriteToFile(tPath + "//Version.txt", repo.PushedAt.ToString());
                }, null);

            }
            catch { }
        }

        // Zip a File
        private void BackupFile(string start, string name)
        {
            string exePath = System.Windows.Forms.Application.StartupPath;
            string timestamp = "";
            {// Build the fkng time
                string FU = "" + DateTime.Now;
                char[] delimiterChars = { '/', ':' };
                string[] words = FU.Split(delimiterChars);
                foreach (string s in words) { timestamp = timestamp + s; }
            }
            // create the backup folder if dosent exist
            if (!Directory.Exists(exePath + "\\Backups"))
            {
                Directory.CreateDirectory(exePath + "\\Backups");
            }
            ZipFile.CreateFromDirectory(start, exePath + "\\Backups\\" + name + " - " + timestamp + ".zip");
            //delete shit
            string[] allFileNames = Directory.GetFiles(start, "*.*", SearchOption.AllDirectories);
            foreach (string filename in allFileNames)
            {
                FileAttributes attr = File.GetAttributes(filename);
                File.SetAttributes(filename, attr & ~FileAttributes.ReadOnly);
            }
            Directory.Delete(start, true);
        }

        // Write to file
        private void WriteToFile(string fileLoc, string toWrite)
        {
            // if the file Exists (user has one) remove it.
            if (File.Exists(fileLoc))
            {
                File.Delete(fileLoc);
            }
            using (StreamWriter file = new StreamWriter(fileLoc, true))
            {
                file.WriteLine(toWrite);
            }
        }

        // Check if should be updated
        private async void CheckForUpDate(string owner, string _repo)
        {
            try
            {
                // get the github info
                var repo = await client.Repository.Get(owner, _repo);
                string tPath = LOC_INPUT.Text + "\\" + repo.Name;
                string text = "0.0";
                if (File.Exists(tPath + "\\Version.txt"))
                {
                    text = File.ReadAllText(tPath + "\\Version.txt");
                }
                if (!text.Contains(repo.PushedAt.ToString()))
                {
                    Download(owner, _repo);
                }
            }
            catch { }
        }

        // Build the CR list
        private async void BuildCombatRoutines()
        {
            CR_DATA.Rows.Clear();
            CR_DATA.Refresh();
            CR_DATA.Enabled = true;
            try
            {
                XmlDocument xdcDocument = new XmlDocument();
                xdcDocument.Load("https://dl.dropboxusercontent.com/u/101560647/NerdPack/NeP_Updater_CRData.xml");
                XmlElement xelRoot = xdcDocument.DocumentElement;
                XmlNodeList xnlNodes = xelRoot.SelectNodes("/ArrayOfButtons/Button");

                foreach (XmlNode xndNode in xnlNodes)
                {
                    string Owner = xndNode["Owner"].InnerText;
                    string Repo = xndNode["Repo"].InnerText;
                    try
                    {
                        var repo = await client.Repository.Get(Owner, Repo);
                        var installed = false;
                        // Check if we have it installed
                        if (File.Exists(LOC_INPUT.Text + "\\" + repo.Name + "\\Version.txt"))
                        {
                            installed = true;
                        }
                        CR_DATA.Rows.Add(installed, repo.Name, repo.Description, repo.StargazersCount, Owner, Repo);
                    }
                    catch { }
                }
            }
            catch { }
        }

        //Build the modules list
        private async void BuildModules()
        {
            MOD_DATA.Rows.Clear();
            MOD_DATA.Refresh();
            MOD_DATA.Enabled = true;
            try
            {
                XmlDocument xdcDocument = new XmlDocument();
                xdcDocument.Load("https://dl.dropboxusercontent.com/u/101560647/NerdPack/NeP_Updater_MODData.xml");
                XmlElement xelRoot = xdcDocument.DocumentElement;
                XmlNodeList xnlNodes = xelRoot.SelectNodes("/ArrayOfButtons/Button");

                foreach (XmlNode xndNode in xnlNodes)
                {
                    string Owner = xndNode["Owner"].InnerText;
                    string Repo = xndNode["Repo"].InnerText;
                    try
                    {
                        var repo = await client.Repository.Get(Owner, Repo);
                        var installed = false;
                        // Check if we have it installed
                        if (File.Exists(LOC_INPUT.Text + "\\" + repo.Name + "\\Version.txt"))
                        {
                            installed = true;
                        }
                        MOD_DATA.Rows.Add(installed, repo.Name, repo.Description, repo.StargazersCount, Owner, Repo);
                    }
                    catch { }
                }
            }
            catch { }
        }

        // Updates the Selected CRs
        public void UpdateCrs()
        {
            List<String> selected = new List<String>();
            foreach (DataGridViewRow row in CR_DATA.Rows)
            {
                if ((Boolean)row.Cells["CheckBox"].Value == true)
                {
                    string owner = (string)row.Cells["OWNER"].Value;
                    string repo = (string)row.Cells["REPO"].Value;
                    CheckForUpDate(owner, repo);
                }
            }
        }

        // Updates the Selected Modules
        public void UpdateMods()
        {
            List<String> selected = new List<String>();
            foreach (DataGridViewRow row in MOD_DATA.Rows)
            {
                if ((Boolean)row.Cells["dataGridViewCheckBoxColumn1"].Value == true)
                {
                    string owner = (string)row.Cells["dataGridViewTextBoxColumn4"].Value;
                    string repo = (string)row.Cells["dataGridViewTextBoxColumn5"].Value;
                    CheckForUpDate(owner, repo);
                }
            }
        }
    }
}