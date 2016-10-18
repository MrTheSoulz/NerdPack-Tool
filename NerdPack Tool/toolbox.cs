using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace NerdPackToolBox
{
    public partial class mainframe : Form
    {

        // console stuff
        [DllImport("kernel32.dll")]
        public static extern bool AllocConsole();
        [DllImport("kernel32.dll")]
        public static extern bool FreeConsole();

        // START
        public mainframe()
        {
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
            LOC_INPUT.Text = FindWoW();
            // Run our init stuff
            GetCoreInfo();
            BuildToolData();
            //TEMP DISABLED
            CORE_R_COMBO.Enabled = false;
        }

        // Launch WoW button
        private void LAUNCH_BT_Click(object sender, EventArgs e)
        {
            Process.Start(LOC_INPUT.Text + "\\" + WoW_Launch_Combo.Text);
        }

        // Install / Update Button
        private void INSTALL_BT_Click(object sender, EventArgs e)
        {
            
            UpdateAddons();
        }

        //Refresh Button (Refresh data)
        private void REFRESH_BT_Click(object sender, EventArgs e)
        {
            GetCoreInfo();
            BuildToolData();
        }


    }
}