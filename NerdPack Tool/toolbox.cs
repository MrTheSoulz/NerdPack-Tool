using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing;

namespace NerdPackToolBox
{
    public partial class mainframe : Form
    {

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
            LAUNCH_WOW64.Enabled = Environment.Is64BitOperatingSystem;
            CORE_R_COMBO.SelectedItem = "Beta";
            // Find WoW
            LOC_INPUT.Text = FindWoW();
            // Run our init stuff
            GetCoreInfo();
            BuildToolData();
            //TEMP DISABLED
            CORE_R_COMBO.Enabled = false;

            LOG_DATA.Columns["DATA"].DefaultCellStyle.ForeColor = Color.WhiteSmoke;
            LOG_DATA.Columns["DATA"].DefaultCellStyle.BackColor = Color.Black;
        }

        // Launch WoW32 button
        private void LAUNCH_WOW32_Click(object sender, EventArgs e)
        {
            Process.Start(LOC_INPUT.Text + "\\WoW.exe");
        }

        // Launch WoW64 button
        private void LAUNCH_WOW64_Click(object sender, EventArgs e)
        {
            Process.Start(LOC_INPUT.Text + "\\WoW64.exe");
        }

        // Install / Update Button
        private void INSTALL_BT_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab("LOGTAB");
            LOG_DATA.Rows.Clear();
            LOG_DATA.Refresh();
            LOG_DATA.Enabled = true;
            UpdateAddonsAsync();
        }

        //Refresh Button (Refresh data)
        private void REFRESH_BT_Click(object sender, EventArgs e)
        {
            GetCoreInfo();
            BuildToolData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    LOC_INPUT.Text = folderDialog.SelectedPath;
                }
            }
        }
        private void DONATE_BT_Click(object sender, EventArgs e)
        {
            Process.Start("http://goo.gl/yrctPO");
        }

        private void DISCORD_BT_Click(object sender, EventArgs e)
        {
            Process.Start("https://discord.gg/XtSZbjM");
        }

        private void WIKI_BT_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/MrTheSoulz/NerdPack-Tool/wiki");
        }
    }
}