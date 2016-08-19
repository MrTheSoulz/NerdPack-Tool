using Microsoft.Win32;
using Octokit;
using System;
using System.Security.Principal;
using System.Windows.Forms;
using Octokit.Internal;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Xml;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace WindowsFormsApplication1
{
    public partial class mainframe : Form
    {

        static InMemoryCredentialStore credentials = new InMemoryCredentialStore(new Octokit.Credentials("30056b2d3c0ae1b13319d6aa8d997e5ffc9cfcec"));
        static GitHubClient client = new GitHubClient(new ProductHeaderValue("NerdPack-Tool"), credentials);
        string exePath = System.Windows.Forms.Application.StartupPath;

        // console stuff
        [DllImport("kernel32.dll")]
        public static extern bool AllocConsole();
        [DllImport("kernel32.dll")]
        public static extern bool FreeConsole();

        // START
        public mainframe()
        {
            // check if running as admin
            IsUserAdministrator();
            //starting....
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
            Download("MrTheSoulz", "NerdPack");
            if (PROTECTED_CHECK.Checked)
            {
                Download("MrTheSoulz", "NerdPack-Protected");
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
                    Process.Start("" + repo.HtmlUrl + "/issues");
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
            Process.Start(GetWoWLoc()+"\\wow-64.exe");
        }

        // Install / Update Button
        private void INSTALL_BT_Click(object sender, EventArgs e)
        {
            UpdateCore();
            UpdateCrs();
            UpdateMods();
        }

        //Refresh Button (Refresh data)
        private void REFRESH_BT_Click(object sender, EventArgs e)
        {
            GetCoreInfo();
            BuildCombatRoutines();
            BuildModules();
        }

        //check if admin
        public bool IsUserAdministrator()
        {
            bool isAdmin;
            try
            {
                WindowsIdentity user = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(user);
                isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            catch (UnauthorizedAccessException)
            {
                isAdmin = false;
            }
            catch (Exception)
            {
                isAdmin = false;
            }
            return isAdmin;
        }

        // Download
        private async void Download(string owner, string _repo)
        {
            AllocConsole();
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
                    // get repo info
                    var repo = await client.Repository.Get(owner, _repo);
                    string name = repo.Name;
                    string uri = repo.HtmlUrl;
                    string fileName = name + ".zip";
                    string oPath = exePath + "\\" + name;
                    string tPath = LOC_INPUT.Text + "\\" + name;
                    string zPath = LOC_INPUT.Text;
                    string text = "0.0";
                    // check if we need to update
                    if (File.Exists(tPath + "\\Version.txt")) {
                        text = File.ReadAllText(tPath + "\\Version.txt");
                    }
                    // Update IF needed
                    if (!text.Contains(repo.PushedAt.ToString())) {
                        Console.Write("Found update for: "+name+".\r\n");
                        //delete the old folder if any
                        if (Directory.Exists(tPath)) {
                            // make a backup
                            if (BACKUPS_CHECK.Checked) {
                                Console.Write("Creating a backup\r\n");
                                string timestamp = "";
                                // Build the time
                                string FU = "" + DateTime.Now;
                                char[] delimiterChars = { '/', ':' };
                                string[] words = FU.Split(delimiterChars);
                                foreach (string s in words) { timestamp = timestamp + s; }
                                // create the backup folder if dosent exist
                                if (!Directory.Exists(exePath + "\\Backups")) {
                                    Console.Write("Didn't find a backup folder, creating one.\r\n");
                                    Directory.CreateDirectory(exePath + "\\Backups");
                                }
                                ZipFile.CreateFromDirectory(tPath, exePath + "\\Backups\\" + name + " - " + timestamp + ".zip");
                            }
                            //delete shit
                            Console.Write("Deleting old stuff.\r\n");
                            string[] allFileNames = Directory.GetFiles(tPath, "*.*", SearchOption.AllDirectories);
                            foreach (string filename in allFileNames) {
                                FileAttributes attr = File.GetAttributes(filename);
                                File.SetAttributes(filename, attr & ~FileAttributes.ReadOnly);
                            }
                            Directory.Delete(tPath, true);
                        }
                        // Download using lib2Sharp
                        Console.Write("Downloading\r\n");
                        LibGit2Sharp.Repository.Clone(repo.CloneUrl, tPath);
                        // if the version file Exists (user has one) remove it.
                        if (File.Exists(tPath + "//Version.txt")) {
                            Console.Write("Found a unwanted version file, removing it.\r\n");
                            File.Delete(tPath + "//Version.txt");
                        }
                        // add a version file
                        using (StreamWriter file = new StreamWriter(tPath + "//Version.txt", true)) {
                            Console.Write("Creating our version file.\r\n");
                            file.WriteLine(repo.PushedAt.ToString());
                        } 
                    } else {
                        Console.Write(name + " ins already updated, skipping.\r\n");
                    }
                }, null);
            }
            catch { }
        }

        // Build the CR list
        private async void BuildCombatRoutines()
        {
            CR_DATA.Rows.Clear();
            CR_DATA.Refresh();
            CR_DATA.Enabled = true;
            try {
                XmlDocument xdcDocument = new XmlDocument();
                xdcDocument.Load("https://dl.dropboxusercontent.com/u/101560647/NerdPack/NeP_Updater_CRData.xml");
                XmlElement xelRoot = xdcDocument.DocumentElement;
                XmlNodeList xnlNodes = xelRoot.SelectNodes("/ArrayOfButtons/Button");
                foreach (XmlNode xndNode in xnlNodes) {
                    string Owner = xndNode["Owner"].InnerText;
                    string Repo = xndNode["Repo"].InnerText;
                    try {
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
        private async void BuildModules() {
            MOD_DATA.Rows.Clear();
            MOD_DATA.Refresh();
            MOD_DATA.Enabled = true;
            try {
                XmlDocument xdcDocument = new XmlDocument();
                xdcDocument.Load("https://dl.dropboxusercontent.com/u/101560647/NerdPack/NeP_Updater_MODData.xml");
                XmlElement xelRoot = xdcDocument.DocumentElement;
                XmlNodeList xnlNodes = xelRoot.SelectNodes("/ArrayOfButtons/Button");
                foreach (XmlNode xndNode in xnlNodes) {
                    string Owner = xndNode["Owner"].InnerText;
                    string Repo = xndNode["Repo"].InnerText;
                    try {
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
            foreach (DataGridViewRow row in CR_DATA.Rows) {
                if ((Boolean)row.Cells["CheckBox"].Value == true) {
                    string owner = (string)row.Cells["OWNER"].Value;
                    string repo = (string)row.Cells["REPO"].Value;
                    Download(owner, repo);
                }
            }
        }

        // Updates the Selected Modules
        public void UpdateMods()
        {
            List<String> selected = new List<String>();
            foreach (DataGridViewRow row in MOD_DATA.Rows) {
                if ((Boolean)row.Cells["dataGridViewCheckBoxColumn1"].Value == true) {
                    string owner = (string)row.Cells["dataGridViewTextBoxColumn4"].Value;
                    string repo = (string)row.Cells["dataGridViewTextBoxColumn5"].Value;
                    Download(owner, repo);
                }
            }
        }

    }
}
