namespace DCPU_floppy_editor
{
    partial class mainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.NewFloppyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openFloppyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveFloppyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tvFileExplorer = new System.Windows.Forms.TreeView();
			this.cbEndian = new System.Windows.Forms.ComboBox();
			this.Endianess = new System.Windows.Forms.GroupBox();
			this.btAddFile = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.tbDeviceID = new System.Windows.Forms.TextBox();
			this.tbManufacturerID = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.tbExtention = new System.Windows.Forms.TextBox();
			this.tbFileName = new System.Windows.Forms.TextBox();
			this.menuStrip1.SuspendLayout();
			this.Endianess.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1182, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewFloppyToolStripMenuItem,
            this.openFloppyToolStripMenuItem,
            this.saveFloppyToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// NewFloppyToolStripMenuItem
			// 
			this.NewFloppyToolStripMenuItem.Name = "NewFloppyToolStripMenuItem";
			this.NewFloppyToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.NewFloppyToolStripMenuItem.Text = " New Floppy";
			this.NewFloppyToolStripMenuItem.Click += new System.EventHandler(this.NewFloppyToolStripMenuItem_Click);
			// 
			// openFloppyToolStripMenuItem
			// 
			this.openFloppyToolStripMenuItem.Name = "openFloppyToolStripMenuItem";
			this.openFloppyToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.openFloppyToolStripMenuItem.Text = "Open Floppy";
			// 
			// saveFloppyToolStripMenuItem
			// 
			this.saveFloppyToolStripMenuItem.Name = "saveFloppyToolStripMenuItem";
			this.saveFloppyToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.saveFloppyToolStripMenuItem.Text = "Save Floppy";
			this.saveFloppyToolStripMenuItem.Click += new System.EventHandler(this.saveFloppyToolStripMenuItem_Click);
			// 
			// tvFileExplorer
			// 
			this.tvFileExplorer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tvFileExplorer.Location = new System.Drawing.Point(266, 27);
			this.tvFileExplorer.Name = "tvFileExplorer";
			this.tvFileExplorer.Size = new System.Drawing.Size(359, 642);
			this.tvFileExplorer.TabIndex = 1;
			// 
			// cbEndian
			// 
			this.cbEndian.FormattingEnabled = true;
			this.cbEndian.Items.AddRange(new object[] {
            "little Endian",
            "big Endian"});
			this.cbEndian.Location = new System.Drawing.Point(15, 19);
			this.cbEndian.Name = "cbEndian";
			this.cbEndian.Size = new System.Drawing.Size(121, 21);
			this.cbEndian.TabIndex = 2;
			// 
			// Endianess
			// 
			this.Endianess.Controls.Add(this.cbEndian);
			this.Endianess.Location = new System.Drawing.Point(12, 609);
			this.Endianess.Name = "Endianess";
			this.Endianess.Size = new System.Drawing.Size(149, 49);
			this.Endianess.TabIndex = 3;
			this.Endianess.TabStop = false;
			this.Endianess.Text = "Endian type";
			// 
			// btAddFile
			// 
			this.btAddFile.Location = new System.Drawing.Point(12, 27);
			this.btAddFile.Name = "btAddFile";
			this.btAddFile.Size = new System.Drawing.Size(121, 37);
			this.btAddFile.TabIndex = 4;
			this.btAddFile.Text = "Add file to floppy";
			this.btAddFile.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(139, 27);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(121, 37);
			this.button1.TabIndex = 5;
			this.button1.Text = "Remove file from floppy";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.groupBox2);
			this.groupBox1.Location = new System.Drawing.Point(12, 70);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(248, 338);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Attributes";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.tbDeviceID);
			this.groupBox2.Controls.Add(this.tbManufacturerID);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.tbExtention);
			this.groupBox2.Controls.Add(this.tbFileName);
			this.groupBox2.Location = new System.Drawing.Point(6, 19);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(200, 104);
			this.groupBox2.TabIndex = 0;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Name";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(113, 62);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(42, 13);
			this.label4.TabIndex = 1;
			this.label4.Text = "dev ID:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 62);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(44, 13);
			this.label3.TabIndex = 1;
			this.label3.Text = "man ID:";
			// 
			// tbDeviceID
			// 
			this.tbDeviceID.Location = new System.Drawing.Point(108, 78);
			this.tbDeviceID.Name = "tbDeviceID";
			this.tbDeviceID.Size = new System.Drawing.Size(83, 20);
			this.tbDeviceID.TabIndex = 2;
			// 
			// tbManufacturerID
			// 
			this.tbManufacturerID.Location = new System.Drawing.Point(6, 78);
			this.tbManufacturerID.Name = "tbManufacturerID";
			this.tbManufacturerID.Size = new System.Drawing.Size(83, 20);
			this.tbManufacturerID.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 42);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(86, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "In case of driver:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(105, 23);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(11, 15);
			this.label1.TabIndex = 1;
			this.label1.Text = ".";
			// 
			// tbExtention
			// 
			this.tbExtention.Location = new System.Drawing.Point(116, 19);
			this.tbExtention.Name = "tbExtention";
			this.tbExtention.Size = new System.Drawing.Size(37, 20);
			this.tbExtention.TabIndex = 1;
			// 
			// tbFileName
			// 
			this.tbFileName.Location = new System.Drawing.Point(6, 19);
			this.tbFileName.Name = "tbFileName";
			this.tbFileName.Size = new System.Drawing.Size(100, 20);
			this.tbFileName.TabIndex = 1;
			// 
			// mainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1182, 670);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.btAddFile);
			this.Controls.Add(this.Endianess);
			this.Controls.Add(this.tvFileExplorer);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "mainForm";
			this.Text = "Form1";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.Endianess.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFloppyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveFloppyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewFloppyToolStripMenuItem;
        private System.Windows.Forms.TreeView tvFileExplorer;
        private System.Windows.Forms.GroupBox Endianess;
        private System.Windows.Forms.Button btAddFile;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbFileName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbExtention;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbDeviceID;
        private System.Windows.Forms.TextBox tbManufacturerID;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.ComboBox cbEndian;
    }
}

