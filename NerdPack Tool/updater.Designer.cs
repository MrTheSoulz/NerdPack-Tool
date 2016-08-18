namespace WindowsFormsApplication1
{
    partial class updater
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(updater));
            this.UPDATER_DATA = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UPDATE_BT = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.UPDATER_DATA)).BeginInit();
            this.SuspendLayout();
            // 
            // UPDATER_DATA
            // 
            this.UPDATER_DATA.AllowUserToAddRows = false;
            this.UPDATER_DATA.AllowUserToDeleteRows = false;
            this.UPDATER_DATA.AllowUserToResizeColumns = false;
            this.UPDATER_DATA.AllowUserToResizeRows = false;
            this.UPDATER_DATA.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.UPDATER_DATA.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.UPDATER_DATA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UPDATER_DATA.ColumnHeadersVisible = false;
            this.UPDATER_DATA.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.UPDATER_DATA.EnableHeadersVisualStyles = false;
            this.UPDATER_DATA.GridColor = System.Drawing.Color.Gray;
            this.UPDATER_DATA.Location = new System.Drawing.Point(0, 0);
            this.UPDATER_DATA.Name = "UPDATER_DATA";
            this.UPDATER_DATA.ReadOnly = true;
            this.UPDATER_DATA.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.UPDATER_DATA.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.UPDATER_DATA.RowHeadersVisible = false;
            this.UPDATER_DATA.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.UPDATER_DATA.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.UPDATER_DATA.Size = new System.Drawing.Size(284, 235);
            this.UPDATER_DATA.TabIndex = 1;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // UPDATE_BT
            // 
            this.UPDATE_BT.Location = new System.Drawing.Point(0, 233);
            this.UPDATE_BT.Name = "UPDATE_BT";
            this.UPDATE_BT.Size = new System.Drawing.Size(284, 29);
            this.UPDATE_BT.TabIndex = 2;
            this.UPDATE_BT.Text = "Update";
            this.UPDATE_BT.UseVisualStyleBackColor = true;
            // 
            // updater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.UPDATE_BT);
            this.Controls.Add(this.UPDATER_DATA);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "updater";
            this.Text = "Updater";
            ((System.ComponentModel.ISupportInitialize)(this.UPDATER_DATA)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView UPDATER_DATA;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Button UPDATE_BT;
    }
}