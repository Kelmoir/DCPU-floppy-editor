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
            this.cbEndian = new System.Windows.Forms.ComboBox();
            this.Endianess = new System.Windows.Forms.GroupBox();
            this.btAddFile = new System.Windows.Forms.Button();
            this.btRemoveItem = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btChangeFile = new System.Windows.Forms.Button();
            this.btSaveName = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cbArchive = new System.Windows.Forms.CheckBox();
            this.cbExecutable = new System.Windows.Forms.CheckBox();
            this.cbSystemFile = new System.Windows.Forms.CheckBox();
            this.cbHidden = new System.Windows.Forms.CheckBox();
            this.cbReadOnly = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbDot = new System.Windows.Forms.Label();
            this.tbExtention = new System.Windows.Forms.TextBox();
            this.tbFileName = new System.Windows.Forms.TextBox();
            this.btAddDirectory = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgItemsInWorkingDir = new System.Windows.Forms.DataGridView();
            this.tbWorkDir = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lbSectorsUsed = new System.Windows.Forms.Label();
            this.pbMemoryUsage = new System.Windows.Forms.ProgressBar();
            this.menuStrip1.SuspendLayout();
            this.Endianess.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgItemsInWorkingDir)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(628, 24);
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
            this.NewFloppyToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.NewFloppyToolStripMenuItem.Text = " New Floppy";
            this.NewFloppyToolStripMenuItem.Click += new System.EventHandler(this.NewFloppyToolStripMenuItem_Click);
            // 
            // openFloppyToolStripMenuItem
            // 
            this.openFloppyToolStripMenuItem.Name = "openFloppyToolStripMenuItem";
            this.openFloppyToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.openFloppyToolStripMenuItem.Text = "Open Floppy";
            this.openFloppyToolStripMenuItem.Click += new System.EventHandler(this.openFloppyToolStripMenuItem_Click);
            // 
            // saveFloppyToolStripMenuItem
            // 
            this.saveFloppyToolStripMenuItem.Name = "saveFloppyToolStripMenuItem";
            this.saveFloppyToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.saveFloppyToolStripMenuItem.Text = "Save Floppy";
            this.saveFloppyToolStripMenuItem.Click += new System.EventHandler(this.saveFloppyToolStripMenuItem_Click);
            // 
            // cbEndian
            // 
            this.cbEndian.FormattingEnabled = true;
            this.cbEndian.Items.AddRange(new object[] {
            "little Endian",
            "big Endian"});
            this.cbEndian.Location = new System.Drawing.Point(12, 14);
            this.cbEndian.Name = "cbEndian";
            this.cbEndian.Size = new System.Drawing.Size(121, 21);
            this.cbEndian.TabIndex = 2;
            // 
            // Endianess
            // 
            this.Endianess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Endianess.Controls.Add(this.cbEndian);
            this.Endianess.Location = new System.Drawing.Point(12, 521);
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
            this.btAddFile.Click += new System.EventHandler(this.btAddFile_Click);
            // 
            // btRemoveItem
            // 
            this.btRemoveItem.Location = new System.Drawing.Point(139, 27);
            this.btRemoveItem.Name = "btRemoveItem";
            this.btRemoveItem.Size = new System.Drawing.Size(121, 37);
            this.btRemoveItem.TabIndex = 5;
            this.btRemoveItem.Text = "Remove selected entry from floppy";
            this.btRemoveItem.UseVisualStyleBackColor = true;
            this.btRemoveItem.Click += new System.EventHandler(this.btRemoveEntry_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btChangeFile);
            this.groupBox1.Controls.Add(this.btSaveName);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(12, 130);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(248, 210);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Attributes";
            // 
            // btChangeFile
            // 
            this.btChangeFile.Location = new System.Drawing.Point(127, 162);
            this.btChangeFile.Name = "btChangeFile";
            this.btChangeFile.Size = new System.Drawing.Size(112, 37);
            this.btChangeFile.TabIndex = 11;
            this.btChangeFile.Text = "Change file";
            this.btChangeFile.UseVisualStyleBackColor = true;
            this.btChangeFile.Click += new System.EventHandler(this.btChangeFile_Click);
            // 
            // btSaveName
            // 
            this.btSaveName.Location = new System.Drawing.Point(9, 162);
            this.btSaveName.Name = "btSaveName";
            this.btSaveName.Size = new System.Drawing.Size(112, 37);
            this.btSaveName.TabIndex = 10;
            this.btSaveName.Text = "Save changes to name and flags";
            this.btSaveName.UseVisualStyleBackColor = true;
            this.btSaveName.Click += new System.EventHandler(this.btSaveName_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cbArchive);
            this.groupBox5.Controls.Add(this.cbExecutable);
            this.groupBox5.Controls.Add(this.cbSystemFile);
            this.groupBox5.Controls.Add(this.cbHidden);
            this.groupBox5.Controls.Add(this.cbReadOnly);
            this.groupBox5.Location = new System.Drawing.Point(9, 70);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(233, 86);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Flags";
            // 
            // cbArchive
            // 
            this.cbArchive.AutoSize = true;
            this.cbArchive.Location = new System.Drawing.Point(6, 65);
            this.cbArchive.Name = "cbArchive";
            this.cbArchive.Size = new System.Drawing.Size(62, 17);
            this.cbArchive.TabIndex = 16;
            this.cbArchive.Text = "Archive";
            this.cbArchive.UseVisualStyleBackColor = true;
            // 
            // cbExecutable
            // 
            this.cbExecutable.AutoSize = true;
            this.cbExecutable.Location = new System.Drawing.Point(122, 42);
            this.cbExecutable.Name = "cbExecutable";
            this.cbExecutable.Size = new System.Drawing.Size(79, 17);
            this.cbExecutable.TabIndex = 15;
            this.cbExecutable.Text = "Executable";
            this.cbExecutable.UseVisualStyleBackColor = true;
            // 
            // cbSystemFile
            // 
            this.cbSystemFile.AutoSize = true;
            this.cbSystemFile.Location = new System.Drawing.Point(122, 19);
            this.cbSystemFile.Name = "cbSystemFile";
            this.cbSystemFile.Size = new System.Drawing.Size(76, 17);
            this.cbSystemFile.TabIndex = 14;
            this.cbSystemFile.Text = "System file";
            this.cbSystemFile.UseVisualStyleBackColor = true;
            // 
            // cbHidden
            // 
            this.cbHidden.AutoSize = true;
            this.cbHidden.Location = new System.Drawing.Point(6, 42);
            this.cbHidden.Name = "cbHidden";
            this.cbHidden.Size = new System.Drawing.Size(60, 17);
            this.cbHidden.TabIndex = 13;
            this.cbHidden.Text = "Hidden";
            this.cbHidden.UseVisualStyleBackColor = true;
            // 
            // cbReadOnly
            // 
            this.cbReadOnly.AutoSize = true;
            this.cbReadOnly.Location = new System.Drawing.Point(6, 19);
            this.cbReadOnly.Name = "cbReadOnly";
            this.cbReadOnly.Size = new System.Drawing.Size(74, 17);
            this.cbReadOnly.TabIndex = 12;
            this.cbReadOnly.Text = "Read only";
            this.cbReadOnly.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbDot);
            this.groupBox2.Controls.Add(this.tbExtention);
            this.groupBox2.Controls.Add(this.tbFileName);
            this.groupBox2.Location = new System.Drawing.Point(9, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(233, 45);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Name";
            // 
            // lbDot
            // 
            this.lbDot.AutoSize = true;
            this.lbDot.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDot.Location = new System.Drawing.Point(112, 21);
            this.lbDot.Name = "lbDot";
            this.lbDot.Size = new System.Drawing.Size(11, 15);
            this.lbDot.TabIndex = 1;
            this.lbDot.Text = ".";
            // 
            // tbExtention
            // 
            this.tbExtention.Location = new System.Drawing.Point(122, 19);
            this.tbExtention.Name = "tbExtention";
            this.tbExtention.Size = new System.Drawing.Size(48, 20);
            this.tbExtention.TabIndex = 1;
            // 
            // tbFileName
            // 
            this.tbFileName.Location = new System.Drawing.Point(6, 19);
            this.tbFileName.Name = "tbFileName";
            this.tbFileName.Size = new System.Drawing.Size(100, 20);
            this.tbFileName.TabIndex = 1;
            // 
            // btAddDirectory
            // 
            this.btAddDirectory.Location = new System.Drawing.Point(12, 70);
            this.btAddDirectory.Name = "btAddDirectory";
            this.btAddDirectory.Size = new System.Drawing.Size(121, 37);
            this.btAddDirectory.TabIndex = 7;
            this.btAddDirectory.Text = "Add directory";
            this.btAddDirectory.UseVisualStyleBackColor = true;
            this.btAddDirectory.Click += new System.EventHandler(this.btAddDirectory_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dgItemsInWorkingDir);
            this.groupBox3.Controls.Add(this.tbWorkDir);
            this.groupBox3.Location = new System.Drawing.Point(266, 27);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(357, 543);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "File System view";
            // 
            // dgItemsInWorkingDir
            // 
            this.dgItemsInWorkingDir.AllowUserToAddRows = false;
            this.dgItemsInWorkingDir.AllowUserToDeleteRows = false;
            this.dgItemsInWorkingDir.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgItemsInWorkingDir.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgItemsInWorkingDir.Location = new System.Drawing.Point(6, 43);
            this.dgItemsInWorkingDir.MultiSelect = false;
            this.dgItemsInWorkingDir.Name = "dgItemsInWorkingDir";
            this.dgItemsInWorkingDir.ReadOnly = true;
            this.dgItemsInWorkingDir.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgItemsInWorkingDir.Size = new System.Drawing.Size(345, 494);
            this.dgItemsInWorkingDir.TabIndex = 10;
            this.dgItemsInWorkingDir.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgItemsInWorkingDir_MouseDoubleClick);
            this.dgItemsInWorkingDir.SelectionChanged += new System.EventHandler(this.dgItemsInWorkingDir_SelectionChanged);
            // 
            // tbWorkDir
            // 
            this.tbWorkDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbWorkDir.Location = new System.Drawing.Point(6, 17);
            this.tbWorkDir.Name = "tbWorkDir";
            this.tbWorkDir.ReadOnly = true;
            this.tbWorkDir.Size = new System.Drawing.Size(345, 20);
            this.tbWorkDir.TabIndex = 9;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox4.Controls.Add(this.lbSectorsUsed);
            this.groupBox4.Controls.Add(this.pbMemoryUsage);
            this.groupBox4.Location = new System.Drawing.Point(12, 453);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(248, 62);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Memory usage";
            // 
            // lbSectorsUsed
            // 
            this.lbSectorsUsed.AutoSize = true;
            this.lbSectorsUsed.Location = new System.Drawing.Point(6, 45);
            this.lbSectorsUsed.Name = "lbSectorsUsed";
            this.lbSectorsUsed.Size = new System.Drawing.Size(51, 13);
            this.lbSectorsUsed.TabIndex = 2;
            this.lbSectorsUsed.Text = "unknown";
            // 
            // pbMemoryUsage
            // 
            this.pbMemoryUsage.Location = new System.Drawing.Point(6, 19);
            this.pbMemoryUsage.Name = "pbMemoryUsage";
            this.pbMemoryUsage.Size = new System.Drawing.Size(236, 23);
            this.pbMemoryUsage.TabIndex = 0;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 582);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.Endianess);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btAddDirectory);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btRemoveItem);
            this.Controls.Add(this.btAddFile);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "mainForm";
            this.Text = "DCPU floppy editor";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.Endianess.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgItemsInWorkingDir)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFloppyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveFloppyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewFloppyToolStripMenuItem;
        private System.Windows.Forms.GroupBox Endianess;
        private System.Windows.Forms.Button btAddFile;
        private System.Windows.Forms.Button btRemoveItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbFileName;
        private System.Windows.Forms.Label lbDot;
        private System.Windows.Forms.TextBox tbExtention;
        internal System.Windows.Forms.ComboBox cbEndian;
        private System.Windows.Forms.Button btAddDirectory;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tbWorkDir;
        private System.Windows.Forms.DataGridView dgItemsInWorkingDir;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ProgressBar pbMemoryUsage;
        private System.Windows.Forms.Label lbSectorsUsed;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btChangeFile;
        private System.Windows.Forms.Button btSaveName;
        private System.Windows.Forms.CheckBox cbExecutable;
        private System.Windows.Forms.CheckBox cbSystemFile;
        private System.Windows.Forms.CheckBox cbHidden;
        private System.Windows.Forms.CheckBox cbReadOnly;
        private System.Windows.Forms.CheckBox cbArchive;
    }
}

