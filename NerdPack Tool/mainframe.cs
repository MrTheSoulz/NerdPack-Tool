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
using Octokit.Reactive;
using Octokit.Internal;
using LibGit2Sharp;

namespace WindowsFormsApplication1
{
    public partial class mainframe : Form
    {

        static InMemoryCredentialStore credentials = new InMemoryCredentialStore(new Octokit.Credentials("30056b2d3c0ae1b13319d6aa8d997e5ffc9cfcec"));
        static GitHubClient client = new GitHubClient(new ProductHeaderValue("NerdPack-Tool"), credentials);

        // START
        public mainframe()
        {
            InitializeComponent();
            // These need to be saved and then loaded on launch
            // Maybe save to a xml file?
            PROTECTED_CHECK.Checked = true;
            BACKUPS_CHECK.Checked = true;
            CORE_R_COMBO.SelectedItem = "Beta";
            LOC_INPUT.Text = GetWoWLoc()+"\\Interface\\AddOns";
            // Run our init stuff
            GetCoreInfo();
            BuildCombatRoutines();
            BuildModules();
            //TEMP DISABLED
            CORE_R_COMBO.Enabled = false;
        }

        // Updates the core and protected
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
            UpdateMods();
        }

        // Download
        private async void Download(string owner, string _repo)
        {
            try
            {
                // Progress bar
                IProgress<int> progress = new Progress<int>(value => { progressBar1.Value = value; });
                await Task.Run(() =>
                {
                    for (int i = 0; i <= 100; i++)
                        progress.Report(i);
                });
                var repo = await client.Repository.Get(owner, _repo);
                string name = repo.Name;
                string uri = repo.HtmlUrl;
                string fileName = name + ".zip";
                string exePath = System.Windows.Forms.Application.StartupPath;
                string oPath = exePath + "\\" + name;
                string tPath = LOC_INPUT.Text + "\\" + name;
                string zPath = LOC_INPUT.Text;
                //Create a backup
                if (BACKUPS_CHECK.Checked && Directory.Exists(tPath))
                {
                    BackupFile(tPath, name);
                }
                // Download file
                LibGit2Sharp.Repository.Clone(repo.CloneUrl, tPath);
                // add a version file
                WriteToFile(tPath + "//Version.txt", repo.PushedAt.ToString());
            }
            catch{}
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
            //if (!Directory.Exists(exePath + "\\Backups"))
            //  {
            //        Directory.CreateDirectory(exePath + "\\Backups");
            //      }
            //        CONSOLE_DATA.Rows.Add("-- Creating a backup of: " + start);
            //          ZipFile.CreateFromDirectory(start, exePath + "\\Backups\\" + name + " - " + timestamp + ".zip");
            //            Directory.Delete(start, true);
            // Keeping this here for now.....
            if (!Directory.Exists(exePath + "\\Backups"))
            {
                // create the backup folder if dosent exist
                if (!Directory.Exists(exePath + "\\Backups"))
                {
                    Directory.CreateDirectory(exePath + "\\Backups");
                }
                CONSOLE_DATA.Rows.Add("-- Creating a backup ...");
                ZipFile.CreateFromDirectory(start, exePath + "\\Backups\\" + name + " - " + timestamp + ".zip");
                //delete shit
                string[] allFileNames = System.IO.Directory.GetFiles(start, "*.*", System.IO.SearchOption.AllDirectories);
                foreach (string filename in allFileNames)
                {
                    FileAttributes attr = File.GetAttributes(filename);
                    File.SetAttributes(filename, attr & ~FileAttributes.ReadOnly);
                }
                Directory.Delete(start, true);
            }
        }

        // Write to file
        private void WriteToFile(string fileLoc, string toWrite)
        {
            CONSOLE_DATA.Rows.Add("-- Adding a version file to:"+ fileLoc);
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
                MessageBox.Show(text+ " - "+ repo.PushedAt.ToString());
                if (!text.Contains(repo.PushedAt.ToString()))
                {
                    CONSOLE_DATA.Rows.Add("Found update for :" + repo.Name);
                    Download(owner, _repo);
                }
            }
            catch{}
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
                    catch {}
                }
            }
            catch {}
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
                    catch {}
                }
            }
            catch {}
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

        //Refresh Button (Refresh data)
        private void REFRESH_BT_Click(object sender, EventArgs e)
        {
            GetCoreInfo();
            BuildCombatRoutines();
            BuildModules();
        }
    }
}
