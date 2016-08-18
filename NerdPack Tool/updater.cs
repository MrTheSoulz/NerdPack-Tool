using System.Threading;
using System.Windows.Forms;
using WindowsFormsApplication1;

namespace NerdPackToolBox
{
    public partial class updater : Form
    {
        public updater()
        {
            InitializeComponent();
            this.UPDATER_DATA.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            CheckUpdates();
        }

        private void CheckUpdates()
        {
            bool newUpdates = false;
            if (!newUpdates) 
            {
                mainframe frm = new mainframe();
                frm.Show();
                Hide();
            }
            else
            {
                UPDATER_DATA.Rows.Add("Found a new update!");
            }
            
        }
    }
}
