using Microsoft.Win32;
using Octokit;
using System;
using System.Security.Principal;
using System.Windows.Forms;
using Octokit.Internal;

namespace WindowsFormsApplication1
{
    public partial class mainframe : Form
    {

        static InMemoryCredentialStore credentials = new InMemoryCredentialStore(new Octokit.Credentials("30056b2d3c0ae1b13319d6aa8d997e5ffc9cfcec"));
        static GitHubClient client = new GitHubClient(new ProductHeaderValue("NerdPack-Tool"), credentials);

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
    }
}
