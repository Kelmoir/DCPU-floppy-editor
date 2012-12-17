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
        DataTable ItemsInWorkingDirectory;
        int LastSelectedIndex;


        public mainForm()
        {
            InitializeComponent();
            cbEndian.SelectedIndex = 1;         //Organic outputs big Endian
			Floppy = new cFloppy(0);
			FileSystem = new cFileSystem(DiskType.NonBootable, Floppy);
            ItemsInWorkingDirectory = new DataTable();
            dgItemsInWorkingDir.DataSource = ItemsInWorkingDirectory;
            LastSelectedIndex = -1;
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
                UpdateDiskUsage();
			}
        }

		private void saveFloppyToolStripMenuItem_Click(object sender, EventArgs e)
		{
            if (FileSystem.ConvertToBinary())
            {
                Floppy.Save(cbEndian.SelectedIndex);
            }
		}

        private void UpdateDirectoryView()
        {
            ClearFileInfos();
            tbWorkDir.Text = FileSystem.GetPathToWorkingDirectoryString();
            ItemsInWorkingDirectory.Dispose();
            ItemsInWorkingDirectory = new DataTable();
            dgItemsInWorkingDir.DataSource = ItemsInWorkingDirectory;
            ItemsInWorkingDirectory.Columns.Add("Name", typeof(string));
            dgItemsInWorkingDir.Columns["Name"].Width = 100;
            ItemsInWorkingDirectory.Columns.Add("Extention", typeof(string));
            dgItemsInWorkingDir.Columns["Extention"].Width = 55;
            ItemsInWorkingDirectory.Columns.Add("Flags", typeof(string));
            dgItemsInWorkingDir.Columns["Flags"].Width = 50;
            ItemsInWorkingDirectory.Columns.Add("Index", typeof(int));
            dgItemsInWorkingDir.Columns["Index"].Width = 50;
            for (int i = 0; i < FileSystem.GetNumItemsInWorkingDirectory(); i++)
            {
                DataRow Temp = ItemsInWorkingDirectory.NewRow();
                cFileSystemItem Item = FileSystem.GetItemByIndex(i);
                Temp["Name"] = Item.Metadata.GetName();
                Temp["Extention"] = Item.Metadata.GetExtention();
                Temp["Flags"] = Item.Metadata.GetFlagsString();
                Temp["Index"] = i;
                ItemsInWorkingDirectory.Rows.Add(Temp);
            }

        }

        private void btAddDirectory_Click(object sender, EventArgs e)
        {
            NewItemWizard Wiz = new NewItemWizard(true, cbEndian.SelectedIndex);
            if (Wiz.ShowDialog() == DialogResult.OK)
            {
                FileSystem.CreateNewDirectory(Wiz.NewItem);
                UpdateDirectoryView();
                FloppyChanged = true;
                UpdateDiskUsage();
            }

        }

        private void UpdateDiskUsage()
        {
            try
            {
                int UsedSectors = FileSystem.GetSizeInSectors(Floppy.Sectors[0].Memory.Length);
                lbSectorsUsed.Text = UsedSectors.ToString() + "/" + Floppy.Sectors.Length + " sectors used";
                pbMemoryUsage.Value = UsedSectors * 100 / Floppy.Sectors.Length;
            }
            catch
            {
                pbMemoryUsage.Value = 0;
                lbSectorsUsed.Text = "unknown";
            }
        }

        private void btAddFile_Click(object sender, EventArgs e)
        {
            NewItemWizard Wiz = new NewItemWizard(false, cbEndian.SelectedIndex);
            if (Wiz.ShowDialog() == DialogResult.OK)
            {
                FileSystem.CreateNewDirectory(Wiz.NewItem);
                UpdateDirectoryView();
                FloppyChanged = true;
                UpdateDiskUsage();
            }
        }

        private void btRemoveEntry_Click(object sender, EventArgs e)
        {
            if (dgItemsInWorkingDir.SelectedRows[0].Index > -1)
            {
                FileSystem.RemoveDirTableEntry((int)dgItemsInWorkingDir.Rows[dgItemsInWorkingDir.SelectedRows[0].Index].Cells["Index"].Value);
                UpdateDirectoryView();
                FloppyChanged = true;
                UpdateDiskUsage();
            }
        }

        private void dgItemsInWorkingDir_SelectionChanged(object sender, EventArgs e)
        {
            if (dgItemsInWorkingDir.SelectedRows.Count > 0)
            {
                if (dgItemsInWorkingDir.SelectedRows[0].Index > -1)
                {
                    {
                        cFileSystemItem Temp = FileSystem.GetItemByIndex((int)dgItemsInWorkingDir.Rows[dgItemsInWorkingDir.SelectedRows[0].Index].Cells["Index"].Value);
                        tbDeviceID.Text = Temp.Metadata.GetDevIDstring();
                        tbExtention.Text = Temp.Metadata.GetExtention();
                        tbFileName.Text = Temp.Metadata.GetName();
                        tbManufacturerID.Text = Temp.Metadata.GetManIDstring();
                    }
                }
                else
                {
                    ClearFileInfos();
                }
                LastSelectedIndex = dgItemsInWorkingDir.SelectedRows[0].Index;
            }
        }
        private void ClearFileInfos()
        {
            tbDeviceID.Text = "";
            tbExtention.Text = "";
            tbFileName.Text = "";
            tbManufacturerID.Text = "";
        }

        private void dgItemsInWorkingDir_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (LastSelectedIndex > -1)
            {
                if (FileSystem.ChangeDirectory((int)dgItemsInWorkingDir.Rows[dgItemsInWorkingDir.SelectedRows[0].Index].Cells["Index"].Value))
                {
                    UpdateDirectoryView();
                }
            }
        }

    }
}
