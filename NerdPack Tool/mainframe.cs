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

        static InMemoryCredentialStore credentials = new InMemoryCredentialStore(new Credentials("30056b2d3c0ae1b13319d6aa8d997e5ffc9cfcec"));
        static GitHubClient client = new GitHubClient(new ProductHeaderValue("NerdPack-Tool"), credentials);
        string exePath = System.Windows.Forms.Application.StartupPath;

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
            WoW_Launch_Combo.SelectedItem = "wow-64.exe";
            LOC_INPUT.Text = GetWoWLoc() + "\\Interface\\AddOns";
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
        private void LAUNCH_BT_Click(object sender, EventArgs e)
        {
            Process.Start(GetWoWLoc() + "\\" + WoW_Launch_Combo.Text);
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
        private async void DownloadAddon(string owner, string _repo)
        {
            AllocConsole();
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
            string tPath = LOC_INPUT.Text + "\\" + name;
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
                    Console.Write("Found update for: " + name + ".\r\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    //delete the old folder if any
                    if (Directory.Exists(tPath))
                    {
                        // make a backup
                        if (BACKUPS_CHECK.Checked)
                        {
                            BackUpFoler(tPath, name);
                        }
                        DeleteRecursiveFolder(tPath); ;
                        Console.Write("Done Deleting.\r\n");
                    }
                    // Download using lib2Sharp
                    Console.Write("Downloading\r\n");
                    LibGit2Sharp.Repository.Clone(repo.CloneUrl, tPath);
                    // Add or version file
                    AddVersionFile(tPath, repo.PushedAt.ToString());
                    Console.Write("Done with:" + name + "\r\n");
                }
                else
                {
                    Console.Write(name + " is already updated, skipping.\r\n");
                }
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("FAILED TO INSTALL: " + name + "\r\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        private void AddVersionFile(string pFolderPath, string toWrite)
        {
            // if the version file Exists (user has one) remove it.
            if (File.Exists(pFolderPath + "//Version.txt"))
            {
                Console.Write("Found a unwanted version file, removing it.\r\n");
                File.Delete(pFolderPath + "//Version.txt");
            }
            // add a version file
            using (StreamWriter file = new StreamWriter(pFolderPath + "//Version.txt", true))
            {
                Console.Write("Creating our version file.\r\n");
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
            Console.Write("Creating a backup\r\n");
            string timestamp = "";
            // Build the time
            string FU = "" + DateTime.Now;
            char[] delimiterChars = { '/', ':' };
            string[] words = FU.Split(delimiterChars);
            foreach (string s in words) { timestamp = timestamp + s; }
            // create the backup folder if dosent exist
            if (!Directory.Exists(exePath + "\\Backups"))
            {
                Console.Write("Didn't find a backup folder, creating one.\r\n");
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
