using System.IO;
using System.Net;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class updater : Form
    {

        string exePath = Application.StartupPath;
        bool newUpdates = false;
        int cVersion = 0;
        int rVersion = 0;
        string remoteVer = "https://dl.dropboxusercontent.com/u/101560647/NerdPack/Version.txt";
        string remoteZip = "https://dl.dropboxusercontent.com/u/101560647/NerdPack/NerdPack_ToolBox.zip";

        public updater()
        {
            InitializeComponent();
            this.UPDATER_DATA.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            CheckUpdates();
            Update();
        }

        private void CheckUpdates()
        {
            // Get remove version
            try
            {
                WebClient client = new WebClient();
                Stream stream = client.OpenRead(remoteVer);
                StreamReader reader = new StreamReader(stream);
                string output = reader.ReadLine();
                rVersion = int.Parse(output);
            } catch {}
            // Read local version
            try
            {
                if (File.Exists(exePath + "\\Version.txt")) {
                    string ouput = File.ReadAllText(exePath + "\\Version.txt");
                    cVersion = int.Parse(ouput);
                }
            } catch { }
            // Are we updated?
            if (cVersion < rVersion)
            {
                newUpdates = true;
            }
        }

        private new void Update()
        {
            // Are we in a debugger?
            if (System.Diagnostics.Debugger.IsAttached)
            {
                UPDATER_DATA.Rows.Add("Found a Debugger ");
                newUpdates = false;
            }
            // We dont have updates
            if (!newUpdates)
            {
                UPDATER_DATA.Rows.Add("No updates available");
                UPDATER_DATA.Rows.Add("Current : "+cVersion);
                UPDATE_BT.Text = "Close";
                UPDATE_BT.Click += (sender, args) =>
                {
                    mainframe frm = new mainframe();
                    frm.Show();
                    frm.Closed += (s, args2) => this.Close(); // This is used to close all forms
                    Hide();
                };
                // we have updates
            }
            else
            {
                UPDATER_DATA.Rows.Add("Found Update: " + rVersion);
                UPDATER_DATA.Rows.Add("Current : " + cVersion);
                UPDATE_BT.Click += (sender, args) =>
                {
                    UPDATER_DATA.Rows.Add("Downloading...");
                    WebClient Client = new WebClient();
                    Client.DownloadFile(remoteZip, exePath + "\\NerdPack_ToolBox_Update.zip");
                    UPDATER_DATA.Rows.Add("Done downloading");
                    UPDATER_DATA.Rows.Add("Please extract:");
                    UPDATER_DATA.Rows.Add("NerdPack_ToolBox_Update.zip");
                };
            }
        }

    }
}
