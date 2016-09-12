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
            BuildCombatRoutines();
            BuildModules();
            //TEMP DISABLED
            CORE_R_COMBO.Enabled = false;
        }

        private void FindWoW()
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

        // Updates the core and protected
        public void UpdateCore()
        {
            DownloadAddon("MrTheSoulz", "NerdPack");
            if (PROTECTED_CHECK.Checked)
            {
                DownloadAddon("MrTheSoulz", "NerdPack-Protected");
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
        private async void DownloadAddon(string owner, string _repo)
        {
            // Progress bar
            IProgress<int> progress = new Progress<int>(value => { progressBar1.Value = value; });
            await Task.Run(() =>
            {
                for (int i = 0; i <= 100; i++)
                    progress.Report(i);
            });
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
                            BackUpFoler(tPath, name);
                        }
                        DeleteRecursiveFolder(tPath); ;
                        WriteToConsole("Done Deleting.");
                    }
                    // Download using lib2Sharp
                    WriteToConsole("Downloading");
                    LibGit2Sharp.Repository.Clone(repo.CloneUrl, tPath);
                    // Add or version file
                    AddVersionFile(tPath, repo.PushedAt.ToString());
                    WriteToConsole("Done with:" + name);
                }
                else
                {
                    WriteToConsole(name + " is already updated, skipping.");
                }
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                WriteToConsole("FAILED TO INSTALL: " + name);
            }
        }

        private void AddVersionFile(string pFolderPath, string toWrite)
        {
            // if the version file Exists (user has one) remove it.
            if (File.Exists(pFolderPath + "//Version.txt"))
            {
                WriteToConsole("Found a unwanted version file, removing it.");
                File.Delete(pFolderPath + "//Version.txt");
            }
            // add a version file
            using (StreamWriter file = new StreamWriter(pFolderPath + "//Version.txt", true))
            {
                WriteToConsole("Creating our version file.");
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

        private void BackUpFoler(string pFolderPath, string name)
        {
            WriteToConsole("Creating a backup");
            string timestamp = "";
            // Build the time
            string FU = "" + DateTime.Now;
            char[] delimiterChars = { '/', ':' };
            string[] words = FU.Split(delimiterChars);
            foreach (string s in words) { timestamp = timestamp + s; }
            // create the backup folder if dosent exist
            if (!Directory.Exists(exePath + "\\Backups"))
            {
                WriteToConsole("Didn't find a backup folder, creating one.");
                Directory.CreateDirectory(exePath + "\\Backups");
            }
            ZipFile.CreateFromDirectory(pFolderPath, exePath + "\\Backups\\" + name + " - " + timestamp + ".zip");
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
                xdcDocument.Load("https://dl.dropboxusercontent.com/u/101560647/NerdPack/NeP_Toolbox.xml");
                XmlElement xelRoot = xdcDocument.DocumentElement;
                XmlNodeList xnlNodes = xelRoot.SelectNodes("/ToolboxData/CombatRoutines/Button");
                foreach (XmlNode xndNode in xnlNodes)
                {
                    string Owner = xndNode["Owner"].InnerText;
                    string Repo = xndNode["Repo"].InnerText;
                    try
                    {
                        var repo = await client.Repository.Get(Owner, Repo);
                        var installed = false;
                        // Check if we have it installed
                        if (File.Exists(LOC_INPUT.Text + "\\Interface\\AddOns\\" + repo.Name + "\\Version.txt"))
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
                xdcDocument.Load("https://dl.dropboxusercontent.com/u/101560647/NerdPack/NeP_Toolbox.xml");
                XmlElement xelRoot = xdcDocument.DocumentElement;
                XmlNodeList xnlNodes = xelRoot.SelectNodes("/ToolboxData/Plugins/Button");
                foreach (XmlNode xndNode in xnlNodes)
                {
                    string Owner = xndNode["Owner"].InnerText;
                    string Repo = xndNode["Repo"].InnerText;
                    try
                    {
                        var repo = await client.Repository.Get(Owner, Repo);
                        var installed = false;
                        // Check if we have it installed
                        if (File.Exists(LOC_INPUT.Text + "\\Interface\\AddOns\\" + repo.Name + "\\Version.txt"))
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
            foreach (DataGridViewRow row in CR_DATA.Rows)
            {
                if ((Boolean)row.Cells["CheckBox"].Value == true)
                {
                    string owner = (string)row.Cells["OWNER"].Value;
                    string repo = (string)row.Cells["REPO"].Value;
                    DownloadAddon(owner, repo);
                }
            }
        }

        // Updates the Selected Modules
        public void UpdateMods()
        {
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

    }
}