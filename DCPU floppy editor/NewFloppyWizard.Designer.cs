namespace DCPU_floppy_editor
{
    partial class NewFloppyWizard
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
            this.btAddBootloader = new System.Windows.Forms.Button();
            this.btAddKernel = new System.Windows.Forms.Button();
            this.lbBootloaderStatus = new System.Windows.Forms.Label();
            this.lbKernelStatus = new System.Windows.Forms.Label();
            this.btCreateFloppy = new System.Windows.Forms.Button();
            this.gbBootableFloppy = new System.Windows.Forms.GroupBox();
            this.gbFloppyType = new System.Windows.Forms.GroupBox();
            this.btBootableFloppy = new System.Windows.Forms.Button();
            this.btNonBootableFloppy = new System.Windows.Forms.Button();
            this.gbNonBootFloppy = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbNumSectors = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbMediaName = new System.Windows.Forms.TextBox();
            this.btCreateNonBootFloppy = new System.Windows.Forms.Button();
            this.gbBootableFloppy.SuspendLayout();
            this.gbFloppyType.SuspendLayout();
            this.gbNonBootFloppy.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btAddBootloader
            // 
            this.btAddBootloader.Location = new System.Drawing.Point(6, 19);
            this.btAddBootloader.Name = "btAddBootloader";
            this.btAddBootloader.Size = new System.Drawing.Size(101, 35);
            this.btAddBootloader.TabIndex = 0;
            this.btAddBootloader.Text = "Add bootloader";
            this.btAddBootloader.UseVisualStyleBackColor = true;
            this.btAddBootloader.Click += new System.EventHandler(this.btAddBootloader_Click);
            // 
            // btAddKernel
            // 
            this.btAddKernel.Location = new System.Drawing.Point(6, 60);
            this.btAddKernel.Name = "btAddKernel";
            this.btAddKernel.Size = new System.Drawing.Size(101, 32);
            this.btAddKernel.TabIndex = 1;
            this.btAddKernel.Text = "Add kernel";
            this.btAddKernel.UseVisualStyleBackColor = true;
            this.btAddKernel.Click += new System.EventHandler(this.btAddKernel_Click);
            // 
            // lbBootloaderStatus
            // 
            this.lbBootloaderStatus.AutoSize = true;
            this.lbBootloaderStatus.Location = new System.Drawing.Point(113, 30);
            this.lbBootloaderStatus.Name = "lbBootloaderStatus";
            this.lbBootloaderStatus.Size = new System.Drawing.Size(148, 13);
            this.lbBootloaderStatus.TabIndex = 2;
            this.lbBootloaderStatus.Text = "bootloader status: none found";
            // 
            // lbKernelStatus
            // 
            this.lbKernelStatus.AutoSize = true;
            this.lbKernelStatus.Location = new System.Drawing.Point(113, 70);
            this.lbKernelStatus.Name = "lbKernelStatus";
            this.lbKernelStatus.Size = new System.Drawing.Size(130, 13);
            this.lbKernelStatus.TabIndex = 3;
            this.lbKernelStatus.Text = "Kernel Status: none found";
            // 
            // btCreateFloppy
            // 
            this.btCreateFloppy.Location = new System.Drawing.Point(6, 98);
            this.btCreateFloppy.Name = "btCreateFloppy";
            this.btCreateFloppy.Size = new System.Drawing.Size(255, 47);
            this.btCreateFloppy.TabIndex = 4;
            this.btCreateFloppy.Text = "Create floppy";
            this.btCreateFloppy.UseVisualStyleBackColor = true;
            this.btCreateFloppy.Visible = false;
            this.btCreateFloppy.Click += new System.EventHandler(this.btCreateFloppy_Click);
            // 
            // gbBootableFloppy
            // 
            this.gbBootableFloppy.Controls.Add(this.btAddBootloader);
            this.gbBootableFloppy.Controls.Add(this.btCreateFloppy);
            this.gbBootableFloppy.Controls.Add(this.btAddKernel);
            this.gbBootableFloppy.Controls.Add(this.lbKernelStatus);
            this.gbBootableFloppy.Controls.Add(this.lbBootloaderStatus);
            this.gbBootableFloppy.Location = new System.Drawing.Point(276, 159);
            this.gbBootableFloppy.Name = "gbBootableFloppy";
            this.gbBootableFloppy.Size = new System.Drawing.Size(269, 151);
            this.gbBootableFloppy.TabIndex = 5;
            this.gbBootableFloppy.TabStop = false;
            this.gbBootableFloppy.Text = "Creating a bootable floppy";
            this.gbBootableFloppy.Visible = false;
            // 
            // gbFloppyType
            // 
            this.gbFloppyType.Controls.Add(this.btBootableFloppy);
            this.gbFloppyType.Controls.Add(this.btNonBootableFloppy);
            this.gbFloppyType.Location = new System.Drawing.Point(1, 2);
            this.gbFloppyType.Name = "gbFloppyType";
            this.gbFloppyType.Size = new System.Drawing.Size(269, 151);
            this.gbFloppyType.TabIndex = 6;
            this.gbFloppyType.TabStop = false;
            this.gbFloppyType.Text = "What type of floppy to create?";
            // 
            // btBootableFloppy
            // 
            this.btBootableFloppy.Location = new System.Drawing.Point(6, 59);
            this.btBootableFloppy.Name = "btBootableFloppy";
            this.btBootableFloppy.Size = new System.Drawing.Size(101, 35);
            this.btBootableFloppy.TabIndex = 0;
            this.btBootableFloppy.Text = "Bootable floppy";
            this.btBootableFloppy.UseVisualStyleBackColor = true;
            this.btBootableFloppy.Click += new System.EventHandler(this.btBootableFloppy_Click);
            // 
            // btNonBootableFloppy
            // 
            this.btNonBootableFloppy.Location = new System.Drawing.Point(162, 60);
            this.btNonBootableFloppy.Name = "btNonBootableFloppy";
            this.btNonBootableFloppy.Size = new System.Drawing.Size(101, 35);
            this.btNonBootableFloppy.TabIndex = 1;
            this.btNonBootableFloppy.Text = "Non bootable floppy";
            this.btNonBootableFloppy.UseVisualStyleBackColor = true;
            this.btNonBootableFloppy.Click += new System.EventHandler(this.btNonBootableFloppy_Click);
            // 
            // gbNonBootFloppy
            // 
            this.gbNonBootFloppy.Controls.Add(this.groupBox2);
            this.gbNonBootFloppy.Controls.Add(this.groupBox1);
            this.gbNonBootFloppy.Controls.Add(this.btCreateNonBootFloppy);
            this.gbNonBootFloppy.Location = new System.Drawing.Point(1, 159);
            this.gbNonBootFloppy.Name = "gbNonBootFloppy";
            this.gbNonBootFloppy.Size = new System.Drawing.Size(269, 151);
            this.gbNonBootFloppy.TabIndex = 7;
            this.gbNonBootFloppy.TabStop = false;
            this.gbNonBootFloppy.Text = "Creating a non bootable floppy";
            this.gbNonBootFloppy.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbNumSectors);
            this.groupBox2.Location = new System.Drawing.Point(147, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(114, 46);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Number of sectors";
            // 
            // tbNumSectors
            // 
            this.tbNumSectors.Location = new System.Drawing.Point(6, 19);
            this.tbNumSectors.Name = "tbNumSectors";
            this.tbNumSectors.ReadOnly = true;
            this.tbNumSectors.Size = new System.Drawing.Size(101, 20);
            this.tbNumSectors.TabIndex = 8;
            this.tbNumSectors.Text = "1440";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbMediaName);
            this.groupBox1.Location = new System.Drawing.Point(11, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(114, 46);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Media Name";
            // 
            // tbMediaName
            // 
            this.tbMediaName.Location = new System.Drawing.Point(6, 19);
            this.tbMediaName.Name = "tbMediaName";
            this.tbMediaName.Size = new System.Drawing.Size(101, 20);
            this.tbMediaName.TabIndex = 8;
            this.tbMediaName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbMediaName_KeyPress);
            // 
            // btCreateNonBootFloppy
            // 
            this.btCreateNonBootFloppy.Location = new System.Drawing.Point(6, 98);
            this.btCreateNonBootFloppy.Name = "btCreateNonBootFloppy";
            this.btCreateNonBootFloppy.Size = new System.Drawing.Size(255, 47);
            this.btCreateNonBootFloppy.TabIndex = 4;
            this.btCreateNonBootFloppy.Text = "Create floppy";
            this.btCreateNonBootFloppy.UseVisualStyleBackColor = true;
            this.btCreateNonBootFloppy.Click += new System.EventHandler(this.btCreateNonBootFloppy_Click);
            // 
            // NewFloppyWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 312);
            this.Controls.Add(this.gbNonBootFloppy);
            this.Controls.Add(this.gbFloppyType);
            this.Controls.Add(this.gbBootableFloppy);
            this.Name = "NewFloppyWizard";
            this.Text = "New floppy";
            this.Shown += new System.EventHandler(this.NewFloppyWizard_Shown);
            this.gbBootableFloppy.ResumeLayout(false);
            this.gbBootableFloppy.PerformLayout();
            this.gbFloppyType.ResumeLayout(false);
            this.gbNonBootFloppy.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btAddBootloader;
        private System.Windows.Forms.Button btAddKernel;
        private System.Windows.Forms.Label lbBootloaderStatus;
        private System.Windows.Forms.Label lbKernelStatus;
        private System.Windows.Forms.Button btCreateFloppy;
        private System.Windows.Forms.GroupBox gbBootableFloppy;
        private System.Windows.Forms.GroupBox gbFloppyType;
        private System.Windows.Forms.Button btBootableFloppy;
        private System.Windows.Forms.Button btNonBootableFloppy;
        private System.Windows.Forms.GroupBox gbNonBootFloppy;
        private System.Windows.Forms.Button btCreateNonBootFloppy;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbMediaName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbNumSectors;
    }
}