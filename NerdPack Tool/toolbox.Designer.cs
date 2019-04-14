﻿namespace NerdPackToolBox
{
    public partial class mainframe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainframe));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.CORE_TAB = new System.Windows.Forms.TabPage();
            this.DONATE_BT = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.LAUNCH_WOW64 = new System.Windows.Forms.Button();
            this.LAUNCH_WOW32 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.LOC_INPUT = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.WIKI_BT = new System.Windows.Forms.Button();
            this.DISCORD_BT = new System.Windows.Forms.Button();
            this.BACKUPS_CHECK = new System.Windows.Forms.CheckBox();
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
            this.CR_DATA = new System.Windows.Forms.DataGridView();
            this.CheckBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Addon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Starts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OWNER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REPO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MODULES_TAB = new System.Windows.Forms.TabPage();
            this.MOD_DATA = new System.Windows.Forms.DataGridView();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdatedMod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LOGTAB = new System.Windows.Forms.TabPage();
            this.LOG_DATA = new System.Windows.Forms.DataGridView();
            this.DATA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.INSTALL_BT = new System.Windows.Forms.Button();
            this.REFRESH_BT = new System.Windows.Forms.Button();
            this.legacyCB = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.CORE_TAB.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.CR_Tab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CR_DATA)).BeginInit();
            this.MODULES_TAB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MOD_DATA)).BeginInit();
            this.LOGTAB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LOG_DATA)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.CORE_TAB);
            this.tabControl1.Controls.Add(this.CR_Tab);
            this.tabControl1.Controls.Add(this.MODULES_TAB);
            this.tabControl1.Controls.Add(this.LOGTAB);
            this.tabControl1.Location = new System.Drawing.Point(0, 3);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 361);
            this.tabControl1.TabIndex = 0;
            // 
            // CORE_TAB
            // 
            this.CORE_TAB.BackColor = System.Drawing.Color.White;
            this.CORE_TAB.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CORE_TAB.BackgroundImage")));
            this.CORE_TAB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.CORE_TAB.Controls.Add(this.DONATE_BT);
            this.CORE_TAB.Controls.Add(this.groupBox3);
            this.CORE_TAB.Controls.Add(this.groupBox2);
            this.CORE_TAB.Controls.Add(this.groupBox1);
            this.CORE_TAB.Location = new System.Drawing.Point(4, 22);
            this.CORE_TAB.Name = "CORE_TAB";
            this.CORE_TAB.Padding = new System.Windows.Forms.Padding(3);
            this.CORE_TAB.Size = new System.Drawing.Size(792, 335);
            this.CORE_TAB.TabIndex = 0;
            this.CORE_TAB.Text = "Core";
            // 
            // DONATE_BT
            // 
            this.DONATE_BT.Image = global::NerdPackToolBox.Properties.Resources.paypal1;
            this.DONATE_BT.Location = new System.Drawing.Point(631, 208);
            this.DONATE_BT.Name = "DONATE_BT";
            this.DONATE_BT.Size = new System.Drawing.Size(152, 76);
            this.DONATE_BT.TabIndex = 3;
            this.DONATE_BT.UseVisualStyleBackColor = true;
            this.DONATE_BT.Click += new System.EventHandler(this.DONATE_BT_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.legacyCB);
            this.groupBox3.Controls.Add(this.LAUNCH_WOW64);
            this.groupBox3.Controls.Add(this.LAUNCH_WOW32);
            this.groupBox3.Location = new System.Drawing.Point(589, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 98);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "World of Warcraft";
            // 
            // LAUNCH_WOW64
            // 
            this.LAUNCH_WOW64.Location = new System.Drawing.Point(6, 45);
            this.LAUNCH_WOW64.Name = "LAUNCH_WOW64";
            this.LAUNCH_WOW64.Size = new System.Drawing.Size(188, 23);
            this.LAUNCH_WOW64.TabIndex = 1;
            this.LAUNCH_WOW64.Text = "Launch Word of Warcraft (x64)";
            this.LAUNCH_WOW64.UseVisualStyleBackColor = true;
            this.LAUNCH_WOW64.Click += new System.EventHandler(this.LAUNCH_WOW64_Click);
            // 
            // LAUNCH_WOW32
            // 
            this.LAUNCH_WOW32.Location = new System.Drawing.Point(6, 19);
            this.LAUNCH_WOW32.Name = "LAUNCH_WOW32";
            this.LAUNCH_WOW32.Size = new System.Drawing.Size(188, 23);
            this.LAUNCH_WOW32.TabIndex = 0;
            this.LAUNCH_WOW32.Text = "Launch Word of Warcraft (x86)";
            this.LAUNCH_WOW32.UseVisualStyleBackColor = true;
            this.LAUNCH_WOW32.Click += new System.EventHandler(this.LAUNCH_WOW32_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.LOC_INPUT);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(4, 290);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(782, 40);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "World of Warcarft Location:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(643, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 24);
            this.button1.TabIndex = 1;
            this.button1.Text = "Browse";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // LOC_INPUT
            // 
            this.LOC_INPUT.Location = new System.Drawing.Point(10, 13);
            this.LOC_INPUT.Name = "LOC_INPUT";
            this.LOC_INPUT.Size = new System.Drawing.Size(630, 20);
            this.LOC_INPUT.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.WIKI_BT);
            this.groupBox1.Controls.Add(this.DISCORD_BT);
            this.groupBox1.Controls.Add(this.BACKUPS_CHECK);
            this.groupBox1.Controls.Add(this.GIT_BT);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.PROTECTED_CHECK);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.CORE_R_COMBO);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(205, 280);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "NerdPack\'s Core Settings";
            // 
            // WIKI_BT
            // 
            this.WIKI_BT.Location = new System.Drawing.Point(6, 223);
            this.WIKI_BT.Name = "WIKI_BT";
            this.WIKI_BT.Size = new System.Drawing.Size(184, 23);
            this.WIKI_BT.TabIndex = 5;
            this.WIKI_BT.Text = "Documentation (WIKI)";
            this.WIKI_BT.UseVisualStyleBackColor = true;
            this.WIKI_BT.Click += new System.EventHandler(this.WIKI_BT_Click);
            // 
            // DISCORD_BT
            // 
            this.DISCORD_BT.Location = new System.Drawing.Point(6, 246);
            this.DISCORD_BT.Name = "DISCORD_BT";
            this.DISCORD_BT.Size = new System.Drawing.Size(184, 23);
            this.DISCORD_BT.TabIndex = 4;
            this.DISCORD_BT.Text = "Join Discord Chat";
            this.DISCORD_BT.UseVisualStyleBackColor = true;
            this.DISCORD_BT.Click += new System.EventHandler(this.DISCORD_BT_Click);
            // 
            // BACKUPS_CHECK
            // 
            this.BACKUPS_CHECK.AutoSize = true;
            this.BACKUPS_CHECK.BackColor = System.Drawing.Color.Transparent;
            this.BACKUPS_CHECK.Location = new System.Drawing.Point(62, 57);
            this.BACKUPS_CHECK.Name = "BACKUPS_CHECK";
            this.BACKUPS_CHECK.Size = new System.Drawing.Size(102, 17);
            this.BACKUPS_CHECK.TabIndex = 0;
            this.BACKUPS_CHECK.Text = "Create Backups";
            this.BACKUPS_CHECK.UseVisualStyleBackColor = false;
            // 
            // GIT_BT
            // 
            this.GIT_BT.Location = new System.Drawing.Point(6, 199);
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
            this.groupBox4.Location = new System.Drawing.Point(10, 78);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(184, 118);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Core Information";
            // 
            // UPDATED_TEXT
            // 
            this.UPDATED_TEXT.Location = new System.Drawing.Point(6, 92);
            this.UPDATED_TEXT.Name = "UPDATED_TEXT";
            this.UPDATED_TEXT.ReadOnly = true;
            this.UPDATED_TEXT.Size = new System.Drawing.Size(174, 20);
            this.UPDATED_TEXT.TabIndex = 7;
            // 
            // STARS_TEXT
            // 
            this.STARS_TEXT.Location = new System.Drawing.Point(52, 52);
            this.STARS_TEXT.Name = "STARS_TEXT";
            this.STARS_TEXT.ReadOnly = true;
            this.STARS_TEXT.Size = new System.Drawing.Size(128, 20);
            this.STARS_TEXT.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Last Updated:";
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
            this.FORKS_TEXT.Location = new System.Drawing.Point(52, 31);
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
            this.PROTECTED_CHECK.Location = new System.Drawing.Point(62, 43);
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
            this.CORE_R_COMBO.Size = new System.Drawing.Size(128, 21);
            this.CORE_R_COMBO.TabIndex = 0;
            // 
            // CR_Tab
            // 
            this.CR_Tab.Controls.Add(this.CR_DATA);
            this.CR_Tab.Location = new System.Drawing.Point(4, 22);
            this.CR_Tab.Margin = new System.Windows.Forms.Padding(0);
            this.CR_Tab.Name = "CR_Tab";
            this.CR_Tab.Size = new System.Drawing.Size(792, 335);
            this.CR_Tab.TabIndex = 1;
            this.CR_Tab.Text = "Combat Routines";
            this.CR_Tab.UseVisualStyleBackColor = true;
            // 
            // CR_DATA
            // 
            this.CR_DATA.AllowUserToAddRows = false;
            this.CR_DATA.AllowUserToDeleteRows = false;
            this.CR_DATA.AllowUserToResizeColumns = false;
            this.CR_DATA.AllowUserToResizeRows = false;
            this.CR_DATA.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.CR_DATA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CR_DATA.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CheckBox,
            this.Addon,
            this.Description,
            this.Starts,
            this.OWNER,
            this.REPO,
            this.LastUpdated});
            this.CR_DATA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CR_DATA.Location = new System.Drawing.Point(0, 0);
            this.CR_DATA.Name = "CR_DATA";
            this.CR_DATA.RowHeadersVisible = false;
            this.CR_DATA.Size = new System.Drawing.Size(792, 335);
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
            // OWNER
            // 
            this.OWNER.HeaderText = "OWNER";
            this.OWNER.Name = "OWNER";
            this.OWNER.Visible = false;
            // 
            // REPO
            // 
            this.REPO.HeaderText = "REPO";
            this.REPO.Name = "REPO";
            this.REPO.Visible = false;
            // 
            // LastUpdated
            // 
            this.LastUpdated.HeaderText = "Last Updated";
            this.LastUpdated.Name = "LastUpdated";
            this.LastUpdated.ReadOnly = true;
            // 
            // MODULES_TAB
            // 
            this.MODULES_TAB.Controls.Add(this.MOD_DATA);
            this.MODULES_TAB.Location = new System.Drawing.Point(4, 22);
            this.MODULES_TAB.Name = "MODULES_TAB";
            this.MODULES_TAB.Size = new System.Drawing.Size(792, 335);
            this.MODULES_TAB.TabIndex = 3;
            this.MODULES_TAB.Text = "Modules";
            this.MODULES_TAB.UseVisualStyleBackColor = true;
            // 
            // MOD_DATA
            // 
            this.MOD_DATA.AllowUserToAddRows = false;
            this.MOD_DATA.AllowUserToDeleteRows = false;
            this.MOD_DATA.AllowUserToResizeColumns = false;
            this.MOD_DATA.AllowUserToResizeRows = false;
            this.MOD_DATA.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.MOD_DATA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MOD_DATA.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.LastUpdatedMod});
            this.MOD_DATA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MOD_DATA.Location = new System.Drawing.Point(0, 0);
            this.MOD_DATA.Name = "MOD_DATA";
            this.MOD_DATA.RowHeadersVisible = false;
            this.MOD_DATA.Size = new System.Drawing.Size(792, 335);
            this.MOD_DATA.TabIndex = 1;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.HeaderText = "X";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Width = 25;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Addon";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 200;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.HeaderText = "Description";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Stars";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 50;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "OWNER";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "REPO";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // LastUpdatedMod
            // 
            this.LastUpdatedMod.HeaderText = "Last Updated";
            this.LastUpdatedMod.Name = "LastUpdatedMod";
            this.LastUpdatedMod.ReadOnly = true;
            // 
            // LOGTAB
            // 
            this.LOGTAB.Controls.Add(this.LOG_DATA);
            this.LOGTAB.Location = new System.Drawing.Point(4, 22);
            this.LOGTAB.Name = "LOGTAB";
            this.LOGTAB.Size = new System.Drawing.Size(792, 335);
            this.LOGTAB.TabIndex = 5;
            this.LOGTAB.Text = "Log";
            this.LOGTAB.UseVisualStyleBackColor = true;
            // 
            // LOG_DATA
            // 
            this.LOG_DATA.AllowUserToAddRows = false;
            this.LOG_DATA.AllowUserToDeleteRows = false;
            this.LOG_DATA.AllowUserToResizeColumns = false;
            this.LOG_DATA.AllowUserToResizeRows = false;
            this.LOG_DATA.BackgroundColor = System.Drawing.Color.Black;
            this.LOG_DATA.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.LOG_DATA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LOG_DATA.ColumnHeadersVisible = false;
            this.LOG_DATA.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DATA});
            this.LOG_DATA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LOG_DATA.EnableHeadersVisualStyles = false;
            this.LOG_DATA.GridColor = System.Drawing.Color.Black;
            this.LOG_DATA.Location = new System.Drawing.Point(0, 0);
            this.LOG_DATA.MultiSelect = false;
            this.LOG_DATA.Name = "LOG_DATA";
            this.LOG_DATA.ReadOnly = true;
            this.LOG_DATA.RowHeadersVisible = false;
            this.LOG_DATA.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.LOG_DATA.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.LOG_DATA.ShowCellToolTips = false;
            this.LOG_DATA.ShowEditingIcon = false;
            this.LOG_DATA.Size = new System.Drawing.Size(792, 335);
            this.LOG_DATA.TabIndex = 1;
            this.LOG_DATA.TabStop = false;
            // 
            // DATA
            // 
            this.DATA.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DATA.HeaderText = "Description";
            this.DATA.Name = "DATA";
            this.DATA.ReadOnly = true;
            this.DATA.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // progressBar1
            // 
            this.progressBar1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.progressBar1.Location = new System.Drawing.Point(0, 370);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(609, 25);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 1;
            // 
            // INSTALL_BT
            // 
            this.INSTALL_BT.Location = new System.Drawing.Point(609, 369);
            this.INSTALL_BT.Name = "INSTALL_BT";
            this.INSTALL_BT.Size = new System.Drawing.Size(165, 25);
            this.INSTALL_BT.TabIndex = 2;
            this.INSTALL_BT.Text = "INSTALL/UPDATE";
            this.INSTALL_BT.UseVisualStyleBackColor = true;
            this.INSTALL_BT.Click += new System.EventHandler(this.INSTALL_BT_Click);
            // 
            // REFRESH_BT
            // 
            this.REFRESH_BT.BackgroundImage = global::NerdPackToolBox.Properties.Resources.refresh;
            this.REFRESH_BT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.REFRESH_BT.Location = new System.Drawing.Point(773, 369);
            this.REFRESH_BT.Name = "REFRESH_BT";
            this.REFRESH_BT.Size = new System.Drawing.Size(25, 25);
            this.REFRESH_BT.TabIndex = 3;
            this.REFRESH_BT.UseVisualStyleBackColor = true;
            this.REFRESH_BT.Click += new System.EventHandler(this.REFRESH_BT_Click);
            // 
            // legacyCB
            // 
            this.legacyCB.AutoSize = true;
            this.legacyCB.Location = new System.Drawing.Point(6, 74);
            this.legacyCB.Name = "legacyCB";
            this.legacyCB.Size = new System.Drawing.Size(134, 17);
            this.legacyCB.TabIndex = 2;
            this.legacyCB.Text = "Legacy Support (< 8.0)";
            this.legacyCB.UseVisualStyleBackColor = true;
            // 
            // mainframe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 394);
            this.Controls.Add(this.REFRESH_BT);
            this.Controls.Add(this.INSTALL_BT);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "mainframe";
            this.Text = "NerdPack ToolBox";
            this.tabControl1.ResumeLayout(false);
            this.CORE_TAB.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.CR_Tab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CR_DATA)).EndInit();
            this.MODULES_TAB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MOD_DATA)).EndInit();
            this.LOGTAB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LOG_DATA)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TabControl tabControl1;
        public System.Windows.Forms.TabPage CORE_TAB;
        public System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.TextBox LOC_INPUT;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.CheckBox PROTECTED_CHECK;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox CORE_R_COMBO;
        public System.Windows.Forms.ProgressBar progressBar1;
        public System.Windows.Forms.Button INSTALL_BT;
        public System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.Button LAUNCH_WOW32;
        public System.Windows.Forms.GroupBox groupBox4;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox FORKS_TEXT;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox UPDATED_TEXT;
        public System.Windows.Forms.TextBox STARS_TEXT;
        public System.Windows.Forms.Button GIT_BT;
        public System.Windows.Forms.Button REFRESH_BT;
        public System.Windows.Forms.CheckBox BACKUPS_CHECK;
        public System.Windows.Forms.TabPage MODULES_TAB;
        public System.Windows.Forms.DataGridView MOD_DATA;
        public System.Windows.Forms.TabPage CR_Tab;
        public System.Windows.Forms.DataGridView CR_DATA;
        private System.Windows.Forms.TabPage LOGTAB;
        public System.Windows.Forms.DataGridView LOG_DATA;
        private System.Windows.Forms.DataGridViewTextBoxColumn DATA;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.Button LAUNCH_WOW64;
        private System.Windows.Forms.Button DONATE_BT;
        private System.Windows.Forms.Button DISCORD_BT;
        private System.Windows.Forms.Button WIKI_BT;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn Addon;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Starts;
        private System.Windows.Forms.DataGridViewTextBoxColumn OWNER;
        private System.Windows.Forms.DataGridViewTextBoxColumn REPO;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdated;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdatedMod;
        private System.Windows.Forms.CheckBox legacyCB;
    }
}

