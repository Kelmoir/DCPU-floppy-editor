namespace DCPU_floppy_editor
{
    partial class NewItemWizard
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
            this.gbNewName = new System.Windows.Forms.GroupBox();
            this.tbNewName = new System.Windows.Forms.TextBox();
            this.gbNewExtension = new System.Windows.Forms.GroupBox();
            this.tbNewExtension = new System.Windows.Forms.TextBox();
            this.btCreate = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.gbFlags = new System.Windows.Forms.GroupBox();
            this.cbSystemFile = new System.Windows.Forms.CheckBox();
            this.cbExecutable = new System.Windows.Forms.CheckBox();
            this.cbHidden = new System.Windows.Forms.CheckBox();
            this.cbReadOnly = new System.Windows.Forms.CheckBox();
            this.cbArchive = new System.Windows.Forms.CheckBox();
            this.btReadFile = new System.Windows.Forms.Button();
            this.gbNewName.SuspendLayout();
            this.gbNewExtension.SuspendLayout();
            this.gbFlags.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbNewName
            // 
            this.gbNewName.Controls.Add(this.tbNewName);
            this.gbNewName.Location = new System.Drawing.Point(12, 12);
            this.gbNewName.Name = "gbNewName";
            this.gbNewName.Size = new System.Drawing.Size(115, 46);
            this.gbNewName.TabIndex = 0;
            this.gbNewName.TabStop = false;
            this.gbNewName.Text = "Name (max 8 chars)";
            // 
            // tbNewName
            // 
            this.tbNewName.Location = new System.Drawing.Point(6, 19);
            this.tbNewName.Name = "tbNewName";
            this.tbNewName.Size = new System.Drawing.Size(100, 20);
            this.tbNewName.TabIndex = 1;
            // 
            // gbNewExtension
            // 
            this.gbNewExtension.Controls.Add(this.tbNewExtension);
            this.gbNewExtension.Location = new System.Drawing.Point(133, 12);
            this.gbNewExtension.Name = "gbNewExtension";
            this.gbNewExtension.Size = new System.Drawing.Size(112, 46);
            this.gbNewExtension.TabIndex = 2;
            this.gbNewExtension.TabStop = false;
            this.gbNewExtension.Text = "Extension (3 chars)";
            // 
            // tbNewExtension
            // 
            this.tbNewExtension.Location = new System.Drawing.Point(6, 19);
            this.tbNewExtension.Name = "tbNewExtension";
            this.tbNewExtension.Size = new System.Drawing.Size(100, 20);
            this.tbNewExtension.TabIndex = 1;
            // 
            // btCreate
            // 
            this.btCreate.Location = new System.Drawing.Point(251, 12);
            this.btCreate.Name = "btCreate";
            this.btCreate.Size = new System.Drawing.Size(83, 39);
            this.btCreate.TabIndex = 3;
            this.btCreate.Text = "Create";
            this.btCreate.UseVisualStyleBackColor = true;
            this.btCreate.Click += new System.EventHandler(this.btCreate_Click);
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(251, 61);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(83, 39);
            this.btCancel.TabIndex = 4;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // gbFlags
            // 
            this.gbFlags.Controls.Add(this.cbSystemFile);
            this.gbFlags.Controls.Add(this.cbExecutable);
            this.gbFlags.Controls.Add(this.cbHidden);
            this.gbFlags.Controls.Add(this.cbReadOnly);
            this.gbFlags.Controls.Add(this.cbArchive);
            this.gbFlags.Location = new System.Drawing.Point(12, 64);
            this.gbFlags.Name = "gbFlags";
            this.gbFlags.Size = new System.Drawing.Size(233, 88);
            this.gbFlags.TabIndex = 5;
            this.gbFlags.TabStop = false;
            this.gbFlags.Text = "Flags";
            // 
            // cbSystemFile
            // 
            this.cbSystemFile.AutoSize = true;
            this.cbSystemFile.Location = new System.Drawing.Point(6, 65);
            this.cbSystemFile.Name = "cbSystemFile";
            this.cbSystemFile.Size = new System.Drawing.Size(76, 17);
            this.cbSystemFile.TabIndex = 9;
            this.cbSystemFile.Text = "System file";
            this.cbSystemFile.UseVisualStyleBackColor = true;
            // 
            // cbExecutable
            // 
            this.cbExecutable.AutoSize = true;
            this.cbExecutable.Location = new System.Drawing.Point(127, 42);
            this.cbExecutable.Name = "cbExecutable";
            this.cbExecutable.Size = new System.Drawing.Size(79, 17);
            this.cbExecutable.TabIndex = 8;
            this.cbExecutable.Text = "Executable";
            this.cbExecutable.UseVisualStyleBackColor = true;
            // 
            // cbHidden
            // 
            this.cbHidden.AutoSize = true;
            this.cbHidden.Location = new System.Drawing.Point(127, 19);
            this.cbHidden.Name = "cbHidden";
            this.cbHidden.Size = new System.Drawing.Size(60, 17);
            this.cbHidden.TabIndex = 6;
            this.cbHidden.Text = "Hidden";
            this.cbHidden.UseVisualStyleBackColor = true;
            // 
            // cbReadOnly
            // 
            this.cbReadOnly.AutoSize = true;
            this.cbReadOnly.Location = new System.Drawing.Point(6, 42);
            this.cbReadOnly.Name = "cbReadOnly";
            this.cbReadOnly.Size = new System.Drawing.Size(74, 17);
            this.cbReadOnly.TabIndex = 7;
            this.cbReadOnly.Text = "Read only";
            this.cbReadOnly.UseVisualStyleBackColor = true;
            // 
            // cbArchive
            // 
            this.cbArchive.AutoSize = true;
            this.cbArchive.Location = new System.Drawing.Point(6, 19);
            this.cbArchive.Name = "cbArchive";
            this.cbArchive.Size = new System.Drawing.Size(62, 17);
            this.cbArchive.TabIndex = 6;
            this.cbArchive.Text = "Archive";
            this.cbArchive.UseVisualStyleBackColor = true;
            // 
            // btReadFile
            // 
            this.btReadFile.Location = new System.Drawing.Point(251, 113);
            this.btReadFile.Name = "btReadFile";
            this.btReadFile.Size = new System.Drawing.Size(83, 39);
            this.btReadFile.TabIndex = 6;
            this.btReadFile.Text = "Read File";
            this.btReadFile.UseVisualStyleBackColor = true;
            this.btReadFile.Click += new System.EventHandler(this.btReadFile_Click);
            // 
            // NewItemWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 156);
            this.Controls.Add(this.btReadFile);
            this.Controls.Add(this.gbFlags);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btCreate);
            this.Controls.Add(this.gbNewExtension);
            this.Controls.Add(this.gbNewName);
            this.Name = "NewItemWizard";
            this.Text = "NewItemWizard";
            this.gbNewName.ResumeLayout(false);
            this.gbNewName.PerformLayout();
            this.gbNewExtension.ResumeLayout(false);
            this.gbNewExtension.PerformLayout();
            this.gbFlags.ResumeLayout(false);
            this.gbFlags.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbNewName;
        private System.Windows.Forms.TextBox tbNewName;
        private System.Windows.Forms.GroupBox gbNewExtension;
        private System.Windows.Forms.TextBox tbNewExtension;
        private System.Windows.Forms.Button btCreate;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.GroupBox gbFlags;
        private System.Windows.Forms.CheckBox cbHidden;
        private System.Windows.Forms.CheckBox cbReadOnly;
        private System.Windows.Forms.CheckBox cbArchive;
        private System.Windows.Forms.CheckBox cbExecutable;
        private System.Windows.Forms.CheckBox cbSystemFile;
        private System.Windows.Forms.Button btReadFile;

    }
}