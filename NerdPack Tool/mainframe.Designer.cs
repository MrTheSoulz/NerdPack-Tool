namespace WindowsFormsApplication1
{
    partial class mainframe
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainframe));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.CORE_TAB = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.LAUNCH_BT = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LOC_INPUT = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.GIT_BT = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.UPDATED_TEXT = new System.Windows.Forms.TextBox();
            this.STARS_TEXT = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.FORKS_TEXT = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PROTECTED_CHECK = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CORE_R_COMBO = new System.Windows.Forms.ComboBox();
            this.CR_Tab = new System.Windows.Forms.TabPage();
            this.CONSOLE_Tab = new System.Windows.Forms.TabPage();
            this.CONSOLE_DATA = new System.Windows.Forms.DataGridView();
            this.Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.INSTALL_BT = new System.Windows.Forms.Button();
            this.CR_DATA = new System.Windows.Forms.DataGridView();
            this.CheckBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Addon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Starts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.CORE_TAB.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.CR_Tab.SuspendLayout();
            this.CONSOLE_Tab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CONSOLE_DATA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CR_DATA)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.CORE_TAB);
            this.tabControl1.Controls.Add(this.CR_Tab);
            this.tabControl1.Controls.Add(this.CONSOLE_Tab);
            this.tabControl1.Location = new System.Drawing.Point(0, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 362);
            this.tabControl1.TabIndex = 0;
            // 
            // CORE_TAB
            // 
            this.CORE_TAB.BackColor = System.Drawing.Color.White;
            this.CORE_TAB.BackgroundImage = global::NerdPackToolBox.Properties.Resources.NEPlogo;
            this.CORE_TAB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.CORE_TAB.Controls.Add(this.groupBox3);
            this.CORE_TAB.Controls.Add(this.groupBox2);
            this.CORE_TAB.Controls.Add(this.groupBox1);
            this.CORE_TAB.Location = new System.Drawing.Point(4, 22);
            this.CORE_TAB.Name = "CORE_TAB";
            this.CORE_TAB.Padding = new System.Windows.Forms.Padding(3);
            this.CORE_TAB.Size = new System.Drawing.Size(792, 336);
            this.CORE_TAB.TabIndex = 0;
            this.CORE_TAB.Text = "Core";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.LAUNCH_BT);
            this.groupBox3.Location = new System.Drawing.Point(585, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 280);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "World of Warcraft Info";
            // 
            // LAUNCH_BT
            // 
            this.LAUNCH_BT.Location = new System.Drawing.Point(6, 251);
            this.LAUNCH_BT.Name = "LAUNCH_BT";
            this.LAUNCH_BT.Size = new System.Drawing.Size(188, 23);
            this.LAUNCH_BT.TabIndex = 0;
            this.LAUNCH_BT.Text = "Launch Word of Warcraft";
            this.LAUNCH_BT.UseVisualStyleBackColor = true;
            this.LAUNCH_BT.Click += new System.EventHandler(this.LAUNCH_BT_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.LOC_INPUT);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(4, 290);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(782, 40);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "World of Warcarft Location:";
            // 
            // LOC_INPUT
            // 
            this.LOC_INPUT.Location = new System.Drawing.Point(10, 16);
            this.LOC_INPUT.Name = "LOC_INPUT";
            this.LOC_INPUT.Size = new System.Drawing.Size(766, 20);
            this.LOC_INPUT.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.GIT_BT);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.PROTECTED_CHECK);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.CORE_R_COMBO);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(205, 192);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "NerdPack\'s Core Settings";
            // 
            // GIT_BT
            // 
            this.GIT_BT.Location = new System.Drawing.Point(10, 163);
            this.GIT_BT.Name = "GIT_BT";
            this.GIT_BT.Size = new System.Drawing.Size(184, 23);
            this.GIT_BT.TabIndex = 4;
            this.GIT_BT.Text = "Report Issues";
            this.GIT_BT.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.UPDATED_TEXT);
            this.groupBox4.Controls.Add(this.STARS_TEXT);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.FORKS_TEXT);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Location = new System.Drawing.Point(10, 66);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(184, 94);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Core Information";
            // 
            // UPDATED_TEXT
            // 
            this.UPDATED_TEXT.Location = new System.Drawing.Point(52, 61);
            this.UPDATED_TEXT.Name = "UPDATED_TEXT";
            this.UPDATED_TEXT.ReadOnly = true;
            this.UPDATED_TEXT.Size = new System.Drawing.Size(128, 20);
            this.UPDATED_TEXT.TabIndex = 7;
            // 
            // STARS_TEXT
            // 
            this.STARS_TEXT.Location = new System.Drawing.Point(52, 40);
            this.STARS_TEXT.Name = "STARS_TEXT";
            this.STARS_TEXT.ReadOnly = true;
            this.STARS_TEXT.Size = new System.Drawing.Size(128, 20);
            this.STARS_TEXT.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Updated:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Stars:";
            // 
            // FORKS_TEXT
            // 
            this.FORKS_TEXT.Location = new System.Drawing.Point(52, 19);
            this.FORKS_TEXT.Name = "FORKS_TEXT";
            this.FORKS_TEXT.ReadOnly = true;
            this.FORKS_TEXT.Size = new System.Drawing.Size(128, 20);
            this.FORKS_TEXT.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Forks:";
            // 
            // PROTECTED_CHECK
            // 
            this.PROTECTED_CHECK.AutoSize = true;
            this.PROTECTED_CHECK.Location = new System.Drawing.Point(62, 46);
            this.PROTECTED_CHECK.Name = "PROTECTED_CHECK";
            this.PROTECTED_CHECK.Size = new System.Drawing.Size(132, 17);
            this.PROTECTED_CHECK.TabIndex = 2;
            this.PROTECTED_CHECK.Text = "Use Protected Module";
            this.PROTECTED_CHECK.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Release:";
            // 
            // CORE_R_COMBO
            // 
            this.CORE_R_COMBO.FormattingEnabled = true;
            this.CORE_R_COMBO.Items.AddRange(new object[] {
            "Release",
            "Beta"});
            this.CORE_R_COMBO.Location = new System.Drawing.Point(62, 19);
            this.CORE_R_COMBO.Name = "CORE_R_COMBO";
            this.CORE_R_COMBO.Size = new System.Drawing.Size(132, 21);
            this.CORE_R_COMBO.TabIndex = 0;
            // 
            // CR_Tab
            // 
            this.CR_Tab.Controls.Add(this.CR_DATA);
            this.CR_Tab.Location = new System.Drawing.Point(4, 22);
            this.CR_Tab.Name = "CR_Tab";
            this.CR_Tab.Padding = new System.Windows.Forms.Padding(3);
            this.CR_Tab.Size = new System.Drawing.Size(792, 336);
            this.CR_Tab.TabIndex = 1;
            this.CR_Tab.Text = "Combat Routines";
            this.CR_Tab.UseVisualStyleBackColor = true;
            // 
            // CONSOLE_Tab
            // 
            this.CONSOLE_Tab.Controls.Add(this.CONSOLE_DATA);
            this.CONSOLE_Tab.Location = new System.Drawing.Point(4, 22);
            this.CONSOLE_Tab.Name = "CONSOLE_Tab";
            this.CONSOLE_Tab.Size = new System.Drawing.Size(792, 336);
            this.CONSOLE_Tab.TabIndex = 2;
            this.CONSOLE_Tab.Text = "Console";
            this.CONSOLE_Tab.UseVisualStyleBackColor = true;
            // 
            // CONSOLE_DATA
            // 
            this.CONSOLE_DATA.AllowUserToAddRows = false;
            this.CONSOLE_DATA.AllowUserToDeleteRows = false;
            this.CONSOLE_DATA.AllowUserToResizeColumns = false;
            this.CONSOLE_DATA.AllowUserToResizeRows = false;
            this.CONSOLE_DATA.BackgroundColor = System.Drawing.Color.Black;
            this.CONSOLE_DATA.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.CONSOLE_DATA.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.CONSOLE_DATA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CONSOLE_DATA.ColumnHeadersVisible = false;
            this.CONSOLE_DATA.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Data});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.CONSOLE_DATA.DefaultCellStyle = dataGridViewCellStyle2;
            this.CONSOLE_DATA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CONSOLE_DATA.Enabled = false;
            this.CONSOLE_DATA.EnableHeadersVisualStyles = false;
            this.CONSOLE_DATA.Location = new System.Drawing.Point(0, 0);
            this.CONSOLE_DATA.Name = "CONSOLE_DATA";
            this.CONSOLE_DATA.ReadOnly = true;
            this.CONSOLE_DATA.RowHeadersVisible = false;
            this.CONSOLE_DATA.Size = new System.Drawing.Size(792, 336);
            this.CONSOLE_DATA.TabIndex = 0;
            // 
            // Data
            // 
            this.Data.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Data.HeaderText = "Data";
            this.Data.Name = "Data";
            this.Data.ReadOnly = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(0, 370);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(613, 23);
            this.progressBar1.TabIndex = 1;
            // 
            // INSTALL_BT
            // 
            this.INSTALL_BT.Location = new System.Drawing.Point(612, 369);
            this.INSTALL_BT.Name = "INSTALL_BT";
            this.INSTALL_BT.Size = new System.Drawing.Size(184, 24);
            this.INSTALL_BT.TabIndex = 2;
            this.INSTALL_BT.Text = "INSTALL/UPDATE";
            this.INSTALL_BT.UseVisualStyleBackColor = true;
            this.INSTALL_BT.Click += new System.EventHandler(this.INSTALL_BT_Click);
            // 
            // CR_DATA
            // 
            this.CR_DATA.AllowUserToAddRows = false;
            this.CR_DATA.AllowUserToDeleteRows = false;
            this.CR_DATA.AllowUserToResizeColumns = false;
            this.CR_DATA.AllowUserToResizeRows = false;
            this.CR_DATA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CR_DATA.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CheckBox,
            this.Addon,
            this.Description,
            this.Starts});
            this.CR_DATA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CR_DATA.Location = new System.Drawing.Point(3, 3);
            this.CR_DATA.Name = "CR_DATA";
            this.CR_DATA.RowHeadersVisible = false;
            this.CR_DATA.Size = new System.Drawing.Size(786, 330);
            this.CR_DATA.TabIndex = 0;
            // 
            // CheckBox
            // 
            this.CheckBox.HeaderText = "X";
            this.CheckBox.Name = "CheckBox";
            this.CheckBox.Width = 25;
            // 
            // Addon
            // 
            this.Addon.HeaderText = "Addon";
            this.Addon.Name = "Addon";
            this.Addon.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Addon.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Addon.Width = 200;
            // 
            // Description
            // 
            this.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            // 
            // Starts
            // 
            this.Starts.HeaderText = "Stars";
            this.Starts.Name = "Starts";
            this.Starts.Width = 50;
            // 
            // mainframe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 394);
            this.Controls.Add(this.INSTALL_BT);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "mainframe";
            this.Text = "NerdPack ToolBox";
            this.tabControl1.ResumeLayout(false);
            this.CORE_TAB.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.CR_Tab.ResumeLayout(false);
            this.CONSOLE_Tab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CONSOLE_DATA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CR_DATA)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage CORE_TAB;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox LOC_INPUT;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox PROTECTED_CHECK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CORE_R_COMBO;
        private System.Windows.Forms.TabPage CR_Tab;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button INSTALL_BT;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button LAUNCH_BT;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox FORKS_TEXT;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox UPDATED_TEXT;
        private System.Windows.Forms.TextBox STARS_TEXT;
        private System.Windows.Forms.Button GIT_BT;
        private System.Windows.Forms.TabPage CONSOLE_Tab;
        private System.Windows.Forms.DataGridView CONSOLE_DATA;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data;
        private System.Windows.Forms.DataGridView CR_DATA;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn Addon;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Starts;
    }
}

