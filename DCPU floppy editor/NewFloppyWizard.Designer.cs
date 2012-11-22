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
            this.SuspendLayout();
            // 
            // btAddBootloader
            // 
            this.btAddBootloader.Location = new System.Drawing.Point(12, 12);
            this.btAddBootloader.Name = "btAddBootloader";
            this.btAddBootloader.Size = new System.Drawing.Size(101, 35);
            this.btAddBootloader.TabIndex = 0;
            this.btAddBootloader.Text = "Add bootloader";
            this.btAddBootloader.UseVisualStyleBackColor = true;
            this.btAddBootloader.Click += new System.EventHandler(this.btAddBootloader_Click);
            // 
            // btAddKernel
            // 
            this.btAddKernel.Location = new System.Drawing.Point(12, 53);
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
            this.lbBootloaderStatus.Location = new System.Drawing.Point(119, 23);
            this.lbBootloaderStatus.Name = "lbBootloaderStatus";
            this.lbBootloaderStatus.Size = new System.Drawing.Size(148, 13);
            this.lbBootloaderStatus.TabIndex = 2;
            this.lbBootloaderStatus.Text = "bootloader status: none found";
            // 
            // lbKernelStatus
            // 
            this.lbKernelStatus.AutoSize = true;
            this.lbKernelStatus.Location = new System.Drawing.Point(119, 63);
            this.lbKernelStatus.Name = "lbKernelStatus";
            this.lbKernelStatus.Size = new System.Drawing.Size(130, 13);
            this.lbKernelStatus.TabIndex = 3;
            this.lbKernelStatus.Text = "Kernel Status: none found";
            // 
            // btCreateFloppy
            // 
            this.btCreateFloppy.Location = new System.Drawing.Point(12, 91);
            this.btCreateFloppy.Name = "btCreateFloppy";
            this.btCreateFloppy.Size = new System.Drawing.Size(255, 47);
            this.btCreateFloppy.TabIndex = 4;
            this.btCreateFloppy.Text = "Create floppy";
            this.btCreateFloppy.UseVisualStyleBackColor = true;
            this.btCreateFloppy.Visible = false;
            this.btCreateFloppy.Click += new System.EventHandler(this.btCreateFloppy_Click);
            // 
            // NewFloppyWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 151);
            this.Controls.Add(this.btCreateFloppy);
            this.Controls.Add(this.lbKernelStatus);
            this.Controls.Add(this.lbBootloaderStatus);
            this.Controls.Add(this.btAddKernel);
            this.Controls.Add(this.btAddBootloader);
            this.Name = "NewFloppyWizard";
            this.Text = "NewFloppyWizard";
            this.Shown += new System.EventHandler(this.NewFloppyWizard_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btAddBootloader;
        private System.Windows.Forms.Button btAddKernel;
        private System.Windows.Forms.Label lbBootloaderStatus;
        private System.Windows.Forms.Label lbKernelStatus;
        private System.Windows.Forms.Button btCreateFloppy;
    }
}