using Microsoft.Win32;
using Octokit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;
using System.Threading;
using System.Xml;

namespace WindowsFormsApplication1
{
    public partial class mainframe : Form
    {
        // START
        public mainframe()
        {
            InitializeComponent();
            CORE_R_COMBO.SelectedItem = "Beta";
            LOC_INPUT.Text = GetWoWLoc()+"\\Interface\\AddOns";
            PROTECTED_CHECK.Checked = true;
            GetCoreInfo();
            BuildCombatRoutines();
            //TEMP DISABLED
            CORE_R_COMBO.Enabled = false;
        }


        public void UpdateCore()
        {
            CheckForUpDate("MrTheSoulz", "NerdPack");
            if (PROTECTED_CHECK.Checked)
            {
                CheckForUpDate("MrTheSoulz", "NerdPack-Protected");
            }
        }

        // GET WoW Location
        private string GetWoWLoc()
        {
            var pKey = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall");
            string[] nameList = pKey.GetSubKeyNames();
            for (int i = 0; i < nameList.Length; i++)
            {
                RegistryKey regKey = pKey.OpenSubKey(nameList[i]);
                try
                {
                    if (regKey.GetValue("DisplayName").ToString() == "World of Warcraft")
                    {
                        return regKey.GetValue("InstallLocation").ToString();
                    }
                }
                catch { }
            }
            return "NOT FOUND!";
        }

        //Build Core Info
        private async void GetCoreInfo()
        {
            try
            {
                var client = new GitHubClient(new ProductHeaderValue("NerdPack"));
                var repo = await client.Repository.Get("MrTheSoulz", "NerdPack");
                UPDATED_TEXT.Text = "" + repo.PushedAt;
                STARS_TEXT.Text = "" + repo.StargazersCount;
                FORKS_TEXT.Text = "" + repo.ForksCount;
                GIT_BT.Click += (sender, args) =>
                {
                    System.Diagnostics.Process.Start("" + repo.HtmlUrl + "/issues");
                };
            } catch {
                UPDATED_TEXT.Text = "UNAVAILABLE";
                STARS_TEXT.Text = "UNAVAILABLE";
                FORKS_TEXT.Text = "UNAVAILABLE";
            }
        }

        // Launch WoW button
        private void LAUNCH_BT_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(GetWoWLoc()+"\\wow-64.exe");
        }

        // Install / Update Button
        private void INSTALL_BT_Click(object sender, EventArgs e)
        {
            UpdateCore();
            UpdateCrs();
        }

        // Download
        private async void Download(string owner, string _repo)
        {
            IProgress<int> progress = new Progress<int>(value => { progressBar1.Value = value; });
            await Task.Run(() =>
            {
                for (int i = 0; i <= 100; i++)
                    progress.Report(i);
            });
            // get the github info
            var client = new GitHubClient(new ProductHeaderValue(_repo));
            var repo = await client.Repository.Get(owner, _repo);
            string name = repo.Name;
            string uri = repo.HtmlUrl;
            string fileName = name + ".zip";
            string exePath = System.Windows.Forms.Application.StartupPath;
            string oPath = exePath + "\\" + name;
            string tPath = LOC_INPUT.Text + "\\" + name;
            string zPath = LOC_INPUT.Text ;
            // Build the fkng time
            string FU = "" + DateTime.Now;
            char[] delimiterChars = { '/', ':'};
            string[] words = FU.Split(delimiterChars);
            string timestamp = "";
            foreach (string s in words){timestamp = timestamp + s;}
            // Download and save it into the current exe folder.
            CONSOLE_DATA.Rows.Add("- Downloading: " + name);
            WebClient myWebClient = new WebClient();
            myWebClient.DownloadFile(uri + "/archive/master.zip", fileName);
            //Create a backup
            if (Directory.Exists(tPath)) {
                // create the backup folder if dosent exist
                if (!Directory.Exists(exePath+"\\Backups"))
                {
                    Directory.CreateDirectory(exePath + "\\Backups");
                }
                CONSOLE_DATA.Rows.Add("-- Creating a backup ...");
                ZipFile.CreateFromDirectory(tPath, exePath + "\\Backups\\"+ name + " - " + timestamp + ".zip");
                Directory.Delete(tPath, true);
            }
            // Extract the zip
            CONSOLE_DATA.Rows.Add("-- Extracting ...");
            ZipFile.ExtractToDirectory(oPath + ".zip", zPath);
            // rename the folder (remove -master)
            CONSOLE_DATA.Rows.Add("-- Moving to: "+ tPath);
            Directory.Move(tPath + "-master", tPath);
            // delete the temp zip
            CONSOLE_DATA.Rows.Add("-- Deleting temp. zip");
            File.Delete(exePath + "\\" + fileName);
            // add a version file
            CONSOLE_DATA.Rows.Add("-- Adding a version file...");
            if (!File.Exists(tPath + "//Version.txt"))
            {
                using (StreamWriter file = new StreamWriter(tPath + "//Version.txt", true))
                {
                    file.WriteLine(repo.PushedAt);
                }
            }
        }

        // Check if should be updated
        private async void CheckForUpDate(string owner, string _repo)
        {
            try
            {
                // get the github info
                var client = new GitHubClient(new ProductHeaderValue(_repo));
                var repo = await client.Repository.Get(owner, _repo);
                string name = repo.Name;
                string tPath = LOC_INPUT.Text + "\\" + name;
                string text = "0.0";
                if (File.Exists(tPath + "\\Version.txt"))
                {
                    text = File.ReadAllText(tPath + "\\Version.txt");
                }
                if (!text.Contains("" + repo.PushedAt))
                {
                    CONSOLE_DATA.Rows.Add("Found update for :" + repo.Name);
                    Download(owner, _repo);
                }
                else
                {
                    CONSOLE_DATA.Rows.Add(repo.Name + " is already updated");
                }
            }
            catch
            {
                MessageBox.Show("Sorry but the servers are unavailable right now, try again later...");
            }
        }

        private async void BuildCombatRoutines()
        {
            try
            {
                XmlDocument xdcDocument = new XmlDocument();
                xdcDocument.Load("https://dl.dropboxusercontent.com/u/101560647/NerdPack/NeP_Updater_Data.xml");
                XmlElement xelRoot = xdcDocument.DocumentElement;
                XmlNodeList xnlNodes = xelRoot.SelectNodes("/ArrayOfButtons/Button");

                foreach (XmlNode xndNode in xnlNodes)
                {
                    string Owner = xndNode["Owner"].InnerText;
                    string Repo = xndNode["Repo"].InnerText;
                    try
                    {
                        var client = new GitHubClient(new ProductHeaderValue(Owner));
                        var repo = await client.Repository.Get(Owner, Repo);
                        var installed = false;
                        // Check if we have it installed
                        if (File.Exists(LOC_INPUT.Text+"\\"+repo.Name+"\\Version.txt"))
                        {
                            installed = true;
                        }
                        CR_DATA.Rows.Add(installed, repo.Name, repo.Description, repo.StargazersCount, Owner, Repo);
                    }
                    catch {
                        CR_DATA.Rows.Add(false, "UNAVAILABLE", "Something is wrong...", 0, "", "");
                        CR_DATA.Enabled = false;
                    }
                }
            }
            catch {
                CR_DATA.Rows.Add(false, "UNAVAILABLE", "THE XML IS BROKEN!!!", 0, "", "");
                CR_DATA.Enabled = false;
            }
        }

        // Updates the Selected CRs
        private void UpdateCrs()
        {
            foreach (DataGridViewRow row in CR_DATA.Rows)
            {
                var oCell = row.Cells["CheckBox"] as DataGridViewCheckBoxCell;
                bool bChecked = (null != oCell && null != oCell.Value && true == (bool)oCell.Value);
                if (true == bChecked)
                {
                    var owner = row.Cells["OWNER"].Value as DataGridViewTextBoxCell;
                    var repo = row.Cells["REPO"].Value as DataGridViewTextBoxCell;
                    MessageBox.Show(""+owner, ""+repo);
                }
            }
        }

    }
}
