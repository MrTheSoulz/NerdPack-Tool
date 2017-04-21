using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Security.Principal;
using System.Windows.Forms;

namespace NerdPackToolBox
{
    public partial class mainframe
    {

        string exePath = Application.StartupPath;
        string remoteVer = "https://raw.githubusercontent.com/MrTheSoulz/NerdPack-Tool/master/Version.txt";
        string remoteZip = "https://github.com/MrTheSoulz/NerdPack-Tool/raw/master/NeP-ToolBox_Release.zip";
        string RemoteData = "https://raw.githubusercontent.com/MrTheSoulz/NerdPack-Tool/master/NEP-DB.xml";
        float CurrentVersion;

        public void WriteToFile(string pFolderPath, string toWrite)
        {
            // if the version file Exists (user has one) remove it.
            if (File.Exists(pFolderPath))
            {
                File.Delete(pFolderPath);
            }
            // add a version file
            using (StreamWriter file = new StreamWriter(pFolderPath, true))
            {
                file.WriteLine(toWrite);
            }
        }

        // delete folder
        public void DeleteRecursiveFolder(string pFolderPath)
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

        public void BackUpFolder(string pFolderPath, string name)
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

        public void CheckSelfUpdates()
        {
            Program.AllocConsole();
            bool weAdmin = IsUserAdministrator();
            WriteToConsole("Running as Admin: " + weAdmin);
            bool debugger = Debugger.IsAttached;
            WriteToConsole("Attached debugger: " + debugger);
            float rVersion = 0;
            // Read remote version
            try
            {
                WebClient client = new WebClient();
                Stream stream = client.OpenRead(remoteVer);
                StreamReader reader = new StreamReader(stream);
                rVersion = int.Parse(reader.ReadLine());
            }
            catch { }
            //read local version
            try
            {
                CurrentVersion = int.Parse(File.ReadAllText(exePath + "\\Version.txt"));
            }
            catch { }
            // Are we updated?
            if (CurrentVersion < rVersion && !debugger)
            {
                WriteToConsole("Found Update (" + rVersion + "), downloadig:");
                {
                    WebClient Client = new WebClient();
                    Client.DownloadFile(remoteZip, exePath + "\\NerdPack_ToolBox_Update.zip");
                }
                WriteToConsole("This will now close, extras:");
                WriteToConsole(exePath + "\\NerdPack_ToolBox_Update.zip");
                WriteToConsole("Closing in 5 seconds...");
                System.Threading.Thread.Sleep(5000);
                ExitTool();
            }
            else
            {
                WriteToConsole("No Update found...");
            }
            System.Threading.Thread.Sleep(2000);
            Program.FreeConsole();
        }

        // Write to console
        public void WriteToConsole(string text)
        {
            Console.Write(text + "\r\n");
            Console.ResetColor();
        }

        // Write to console
        public void WriteToLog(string text)
        {
            LOG_DATA.Rows.Add(text);
            LOG_DATA.Refresh();
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
            return isAdmin;
        }

        public string FindWoW()
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
                        return regKey.GetValue("InstallLocation").ToString();
                    }
                }
                catch { }
            }
            return "WARNING: Cannot find your WoW location!";
        }

        public void ExitTool()
        {
            if (Application.MessageLoop)
            {
                // WinForms app
                Application.Exit();
            }
            else
            {
                // Console app
                Environment.Exit(1);
            }
        }

    }
}
