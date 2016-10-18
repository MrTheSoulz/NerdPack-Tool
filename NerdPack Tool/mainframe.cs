using Microsoft.Win32;
using Octokit;
using System;
using System.Security.Principal;
using System.Windows.Forms;
using Octokit.Internal;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Xml;
using System.Runtime.InteropServices;
using System.Net;
using System.ComponentModel;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class mainframe : Form
    {

        static InMemoryCredentialStore credentials = new InMemoryCredentialStore(new Credentials("30056b2d3c0ae1b13319d6aa8d997e5ffc9cfcec"));
        static GitHubClient client = new GitHubClient(new ProductHeaderValue("NerdPack-Tool"), credentials);

        string exePath = System.Windows.Forms.Application.StartupPath;
        string remoteVer = "https://dl.dropboxusercontent.com/u/101560647/NerdPack/Version.txt";
        string remoteZip = "https://dl.dropboxusercontent.com/u/101560647/NerdPack/NerdPack_ToolBox.zip";

        // console stuff
        [DllImport("kernel32.dll")]
        public static extern bool AllocConsole();
        [DllImport("kernel32.dll")]
        public static extern bool FreeConsole();

        // START
        public mainframe()
        {
            AllocConsole();
            // check if running as admin
            IsUserAdministrator();
            //Check for updates
            CheckSelfUpdates();
            //starting....
            InitializeComponent();
            // These need to be saved and then loaded on launch
            // Maybe save to a xml file?
            PROTECTED_CHECK.Checked = true;
            BACKUPS_CHECK.Checked = true;
            CORE_R_COMBO.SelectedItem = "Beta";
            WoW_Launch_Combo.SelectedItem = "wow-64.exe";
            // Find WoW
            FindWoW();
            // Run our init stuff
            GetCoreInfo();
            BuildToolData();
            //TEMP DISABLED
            CORE_R_COMBO.Enabled = false;
        }

        private void FindWoW()
        {
            var pKey = Registry.LocalMachine.OpenSubKey(@"Software\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall");
            string[] nameList = pKey.GetSubKeyNames();
            for (int i = 0; i < nameList.Length; i++)
            {
                RegistryKey regKey = pKey.OpenSubKey(nameList[i]);
                try
                {
                    if (regKey.GetValue("DisplayName").ToString() == "World of Warcraft")
                    {
                        LOC_INPUT.Text = regKey.GetValue("InstallLocation").ToString();
                    }
                }
                catch { }
            }
        }

        private void CheckSelfUpdates()
        {
            int cVersion = 0;
            int rVersion = 0;
            // Read remove version
            try
            {
                WebClient client = new WebClient();
                Stream stream = client.OpenRead(remoteVer);
                StreamReader reader = new StreamReader(stream);
                string output = reader.ReadLine();
                rVersion = int.Parse(output);
            }
            catch { }
            // Read local version
            try
            {
                if (File.Exists(exePath + "\\Version.txt"))
                {
                    string ouput = File.ReadAllText(exePath + "\\Version.txt");
                    cVersion = int.Parse(ouput);
                }
            }
            catch { }
            // Are we updated?
            if (cVersion < rVersion && !Debugger.IsAttached)
            {
                WriteToConsole("Found Update, downloadig:");
                {
                    WebClient Client = new WebClient();
                    Client.DownloadFile(remoteZip, exePath + "\\NerdPack_ToolBox_Update.zip");
                }
                ExitTool();
            }
            else
            {
                WriteToConsole("No Update found...");
            }

        }

        public void ExitTool()
        {
            if (System.Windows.Forms.Application.MessageLoop)
            {
                // WinForms app
                System.Windows.Forms.Application.Exit();
            }
            else
            {
                // Console app
                Environment.Exit(1);
            }
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
            }
            catch
            {
                UPDATED_TEXT.Text = "UNAVAILABLE";
                STARS_TEXT.Text = "UNAVAILABLE";
                FORKS_TEXT.Text = "UNAVAILABLE";
            }
        }

        // Launch WoW button
        private void WriteToConsole(string text)
        {
            Console.Write(text + "\r\n");
            Console.ResetColor();
        }

        // Launch WoW button
        private void LAUNCH_BT_Click(object sender, EventArgs e)
        {
            Process.Start(LOC_INPUT.Text + "\\" + WoW_Launch_Combo.Text);
        }

        // Install / Update Button
        private void INSTALL_BT_Click(object sender, EventArgs e)
        {

            // Core
            DownloadAddon("MrTheSoulz", "NerdPack");
            // Protected
            if (PROTECTED_CHECK.Checked)
            {
                DownloadAddon("MrTheSoulz", "NerdPack-Protected");
            }
            // Combat Routines
            foreach (DataGridViewRow row in CR_DATA.Rows)
            {
                if ((Boolean)row.Cells["CheckBox"].Value == true)
                {
                    string owner = (string)row.Cells["OWNER"].Value;
                    string repo = (string)row.Cells["REPO"].Value;
                    DownloadAddon(owner, repo);
                }
            }
            // Modules
            foreach (DataGridViewRow row in MOD_DATA.Rows)
            {
                if ((Boolean)row.Cells["dataGridViewCheckBoxColumn1"].Value == true)
                {
                    string owner = (string)row.Cells["dataGridViewTextBoxColumn4"].Value;
                    string repo = (string)row.Cells["dataGridViewTextBoxColumn5"].Value;
                    DownloadAddon(owner, repo);
                }
            }

        }

        //Refresh Button (Refresh data)
        private void REFRESH_BT_Click(object sender, EventArgs e)
        {
            GetCoreInfo();
            BuildToolData();
        }

        //check if admin
        public bool IsUserAdministrator()
        {
            bool isAdmin = false;
            try
            {
                WindowsIdentity user = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(user);
                isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            catch { }
            WriteToConsole("Running as Admin: " + isAdmin);
            return isAdmin;
        }

        // Download
        private void DownloadAddon(string owner, string _repo)
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.WorkerReportsProgress = true;
            bw.DoWork += new DoWorkEventHandler(
            async delegate (object o, DoWorkEventArgs args)
            {
                BackgroundWorker b = o as BackgroundWorker;
                b.ReportProgress(100);
                // get repo info
                var repo = await client.Repository.Get(owner, _repo);
                string name = repo.Name;
                string uri = repo.HtmlUrl;
                string fileName = name + ".zip";
                string tPath = LOC_INPUT.Text + "\\Interface\\AddOns\\" + name;
                string text = "0.0";
                try
                {
                    // check if we need to update
                    if (File.Exists(tPath + "\\Version.txt"))
                    {
                        text = File.ReadAllText(tPath + "\\Version.txt");
                    }
                    // Update IF needed
                    if (!text.Contains(repo.PushedAt.ToString()))
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        WriteToConsole("Found update for: " + name);
                        //delete the old folder if any
                        if (Directory.Exists(tPath))
                        {
                            // make a backup
                            if (BACKUPS_CHECK.Checked)
                            {
                                BackUpFolder(tPath, name);
                            }
                            DeleteRecursiveFolder(tPath); ;
                        }
                        // Download using lib2Sharp
                        LibGit2Sharp.Repository.Clone(repo.CloneUrl, tPath);
                        // Add or version file
                        AddVersionFile(tPath, repo.PushedAt.ToString());
                        WriteToConsole("Done with:" + name);
                    }
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    WriteToConsole("FAILED TO INSTALL: " + name);
                }
            });

            bw.ProgressChanged += new ProgressChangedEventHandler(
            delegate (object o, ProgressChangedEventArgs args)
            {
                progressBar1.Value = args.ProgressPercentage;
            });
            bw.RunWorkerAsync();
        }

        private void AddVersionFile(string pFolderPath, string toWrite)
        {
            // if the version file Exists (user has one) remove it.
            if (File.Exists(pFolderPath + "//Version.txt"))
            {
                File.Delete(pFolderPath + "//Version.txt");
            }
            // add a version file
            using (StreamWriter file = new StreamWriter(pFolderPath + "//Version.txt", true))
            {
                file.WriteLine(toWrite);
            }
        }

        // delete folder
        private void DeleteRecursiveFolder(string pFolderPath)
        {
            foreach (string Folder in Directory.GetDirectories(pFolderPath))
            {
                DeleteRecursiveFolder(Folder);
            }
            foreach (string file in Directory.GetFiles(pFolderPath))
            {
                var pPath = Path.Combine(pFolderPath, file);
                FileInfo fi = new FileInfo(pPath);
                File.SetAttributes(pPath, FileAttributes.Normal);
                File.Delete(file);
            }
            Directory.Delete(pFolderPath);
        }

        private void BackUpFolder(string pFolderPath, string name)
        {
            string timestamp = "";
            // Build the time
            string FU = "" + DateTime.Now;
            char[] delimiterChars = { '/', ':' };
            string[] words = FU.Split(delimiterChars);
            foreach (string s in words) { timestamp = timestamp + s; }
            // create the backup folder if dosent exist
            if (!Directory.Exists(exePath + "\\Backups"))
            {
                Directory.CreateDirectory(exePath + "\\Backups");
            }
            ZipFile.CreateFromDirectory(pFolderPath, exePath + "\\Backups\\" + name + " - " + timestamp + ".zip");
        }

        private async void BuildToolData()
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
                xdcDocument.Load("https://dl.dropboxusercontent.com/u/101560647/NerdPack/NeP_Toolbox.xml");
                XmlElement xelRoot = xdcDocument.DocumentElement;
                XmlNodeList xnlNodes = xelRoot.SelectNodes("/ToolboxData/CombatRoutines/Button");
                foreach (XmlNode xndNode in xnlNodes)
                {
                    string Owner = xndNode["Owner"].InnerText;
                    string Repo = xndNode["Repo"].InnerText;

                    var repo = await client.Repository.Get(Owner, Repo);
                    var installed = false;
                    // Check if we have it installed
                    if (File.Exists(LOC_INPUT.Text + "\\Interface\\AddOns\\" + repo.Name + "\\Version.txt"))
                    {
                        installed = true;
                    }
                    CR_DATA.Rows.Add(installed, repo.Name, repo.Description, repo.StargazersCount, Owner, Repo);
                }
                XmlElement xelRoot2 = xdcDocument.DocumentElement;
                XmlNodeList xnlNodes2 = xelRoot2.SelectNodes("/ToolboxData/Plugins/Button");
                foreach (XmlNode xndNode in xnlNodes2)
                {
                    string Owner = xndNode["Owner"].InnerText;
                    string Repo = xndNode["Repo"].InnerText;
                    var repo = await client.Repository.Get(Owner, Repo);
                    var installed = false;
                    // Check if we have it installed
                    if (File.Exists(LOC_INPUT.Text + "\\Interface\\AddOns\\" + repo.Name + "\\Version.txt"))
                    {
                        installed = true;
                    }
                    MOD_DATA.Rows.Add(installed, repo.Name, repo.Description, repo.StargazersCount, Owner, Repo);
                }
            }
            catch { }
        }
    }
}