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
            var client = new GitHubClient(new ProductHeaderValue("NerdPack"));
            var repo = await client.Repository.Get("MrTheSoulz", "NerdPack");
            UPDATED_TEXT.Text = ""+repo.PushedAt;
            STARS_TEXT.Text = ""+repo.StargazersCount;
            FORKS_TEXT.Text = ""+repo.ForksCount;
            GIT_BT.Click += (sender, args) =>
            {
                System.Diagnostics.Process.Start("" + repo.HtmlUrl+ "/issues");
            };
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
        }

        // Download
        private async void Download(string owner, string _repo)
        {
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
            WebClient myWebClient = new WebClient();
            myWebClient.DownloadFile(uri + "/archive/master.zip", fileName);
            //Create a backup
            if (Directory.Exists(tPath)) {
                // create the backup folder if dosent exist
                if (!Directory.Exists(exePath+"\\Backups"))
                {
                    Directory.CreateDirectory(exePath + "\\Backups");
                }
                ZipFile.CreateFromDirectory(tPath, exePath + "\\Backups\\"+ name + " - " + timestamp + ".zip");
                Directory.Delete(tPath, true);
            }
            // Extract the zip
            ZipFile.ExtractToDirectory(oPath + ".zip", zPath);
            // rename the folder (remove -master)
            Directory.Move(tPath + "-master", tPath);
            // delete the temp zip
            File.Delete(exePath + "\\" + fileName);
            // add a version file
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
                MessageBox.Show("found update for :" +  repo.Name);
                Download(owner, _repo);
            }
        }

    }
}
