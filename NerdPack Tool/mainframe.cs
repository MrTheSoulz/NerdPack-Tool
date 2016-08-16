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
            UpdateCore();
            //TEMP DISABLED
            CORE_R_COMBO.Enabled = false;
        }

        public void UpdateCore()
        {
            // We need to check for versions before downloading and installing
            Download("MrTheSoulz", "NerdPack");
            // if PROTECTED_CHECK.Checked, update it aswell
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
            MessageBox.Show("TO BE DONE...");
        }

        // Download
        private async void Download(string owner, string _repo)
        {
            // get the github info
            var client = new GitHubClient(new ProductHeaderValue(_repo));
            var repo = await client.Repository.Get(owner, _repo);
            var name = repo.Name;
            var uri = repo.HtmlUrl;
            MessageBox.Show(name);
            string fileName = name + ".zip";
            string exePath = System.Windows.Forms.Application.StartupPath;
            string oPath = exePath + "\\" + name;
            string tPath = LOC_INPUT.Text + "\\Test";
            // Download and save it into the current exe folder.
            WebClient myWebClient = new WebClient();
            myWebClient.DownloadFile(uri, fileName);
            // TODO: Create a backup
            // Extract the zip
            ZipFile.ExtractToDirectory(oPath + ".zip", tPath);
            // rename the folder (remove -master)
            Directory.Move(tPath + "\\" + name + "-master", tPath + "\\" + name);
            // TODO: Finally we need to delete the temp zip
        }
    }
}
