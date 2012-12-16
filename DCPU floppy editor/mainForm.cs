using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DCPU_floppy_editor
{
    public partial class mainForm : Form
    {

        internal cFloppy Floppy;
        bool FloppyChanged = false;
        cFileSystem FileSystem;


        public mainForm()
        {
            InitializeComponent();
            cbEndian.SelectedIndex = 1;         //Organic outputs big Endian
			Floppy = new cFloppy(0);
			FileSystem = new cFileSystem(DiskType.NonBootable, Floppy);
        }

        private void NewFloppyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Floppy = new cFloppy(1440);
			FileSystem = new cFileSystem(DiskType.Bootable, Floppy);
            NewFloppyWizard Wizard = new NewFloppyWizard(this);
			if (Wizard.ShowDialog() == DialogResult.OK)
			{
				if (FileSystem.FAT.InitFat())
				{
					FloppyChanged = true;
                    UpdateDirectoryView();
				}
				else
				{
					MessageBox.Show("Failed to generate the Floppy");
					Floppy = new cFloppy(0);							//make sure, nothing happens
					FileSystem = new cFileSystem(DiskType.NonBootable, Floppy);
				}
			}
        }

		private void saveFloppyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Floppy.Save(cbEndian.SelectedIndex);
		}

        private void UpdateDirectoryView()
        {
            tbWorkDir.Text = FileSystem.GetPathToWorkingDirectoryString();
            lbItemsInWorkingDir.Items.Clear();
            List<string> ListOfItems = FileSystem.GetListOfEntrysInWorkingDirectory();
            foreach (string Item in ListOfItems)
                lbItemsInWorkingDir.Items.Add(Item);
        }

        private void btAddDirectory_Click(object sender, EventArgs e)
        {
            NewItemWizard Wiz = new NewItemWizard(true, cbEndian.SelectedIndex);
            if (Wiz.ShowDialog() == DialogResult.OK)
            {
                FileSystem.CreateNewDirectory(Wiz.NewItem);
                UpdateDirectoryView();
            }

        }

        private void btAddFile_Click(object sender, EventArgs e)
        {
            NewItemWizard Wiz = new NewItemWizard(false, cbEndian.SelectedIndex);
            if (Wiz.ShowDialog() == DialogResult.OK)
            {
                FileSystem.CreateNewDirectory(Wiz.NewItem);
                UpdateDirectoryView();
            }
        }

        private void lbItemsInWorkingDir_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbItemsInWorkingDir.SelectedIndex > -1)
            {
                cFileSystemItem Temp = FileSystem.GetItemByIndex(lbItemsInWorkingDir.SelectedIndex);
                tbDeviceID.Text = Temp.Metadata.GetDevIDstring();
                tbExtention.Text = Temp.Metadata.GetExtention();
                tbFileName.Text = Temp.Metadata.GetName();
                tbManufacturerID.Text = Temp.Metadata.GetManIDstring();
            }
            else
            {
                tbDeviceID.Text = "";
                tbExtention.Text = "";
                tbFileName.Text = "";
                tbManufacturerID.Text = "";
            }
        }

        private void lbItemsInWorkingDir_DoubleClick(object sender, EventArgs e)
        {
            if (lbItemsInWorkingDir.SelectedIndex > -1)
            {
                FileSystem.ChangeDirectory(lbItemsInWorkingDir.SelectedIndex);
                UpdateDirectoryView();
            }
        }

    }
}
