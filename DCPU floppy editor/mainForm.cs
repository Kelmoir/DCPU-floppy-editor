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
        internal cFileSystem FileSystem;
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
            NewFloppyWizard Wizard = new NewFloppyWizard(this);
			if (Wizard.ShowDialog() == DialogResult.OK)
			{
				if (FileSystem.FAT.InitFat())
				{
					FloppyChanged = true;
				}
				else
				{
					MessageBox.Show("Failed to generate the Floppy");
					Floppy = new cFloppy(0);							//make sure, nothing happens
					FileSystem = new cFileSystem(DiskType.NonBootable, Floppy);
				}
                UpdateDirectoryView();
                UpdateDiskUsage();
			}
        }

		private void saveFloppyToolStripMenuItem_Click(object sender, EventArgs e)
		{
            if (FileSystem.ConvertToBinary())
            {
                FileSystem.FAT.SafeFloppy(cbEndian.SelectedIndex);
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
                int UsedSectors = FileSystem.GetSizeInSectors(FileSystem.FAT.GetSectorSize());
                lbSectorsUsed.Text = UsedSectors.ToString() + "/" + FileSystem.FAT.GetNumSectors() + " sectors used";
                pbMemoryUsage.Value = UsedSectors * 100 / FileSystem.FAT.GetNumSectors();
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
                    cFileSystemItem Temp = FileSystem.GetItemByIndex((int)dgItemsInWorkingDir.Rows[dgItemsInWorkingDir.SelectedRows[0].Index].Cells["Index"].Value);
                    tbFileName.Text = Temp.Metadata.GetName();
                    cbHidden.Checked = Temp.Metadata.Flags.Hidden;
                    cbReadOnly.Checked = Temp.Metadata.Flags.ReadOnly;
                    btChangeKernel.Visible = FileSystem.FAT.IsBootable();
                    tbMediaName.Text = FileSystem.GetMediaName();
                    if (!Temp.IsDirectory())
                    {
                        cbSystemFile.Checked = Temp.Metadata.Flags.SystemFile;
                        cbExecutable.Checked = Temp.Metadata.Flags.Executable;
                        cbArchive.Checked = Temp.Metadata.Flags.Archive;
                        cbExecutable.Visible = true;
                        cbSystemFile.Visible = true;
                        cbArchive.Visible = true;
                        btChangeFile.Visible = true;
                        lbDot.Visible = true;
                        tbExtention.Visible = true;
                        tbExtention.Text = Temp.Metadata.GetExtention();
                    }
                    else
                    {
                        cbSystemFile.Checked = false;
                        cbExecutable.Checked = false;
                        cbArchive.Checked = false;
                        cbExecutable.Visible = false;
                        cbSystemFile.Visible = false;
                        cbArchive.Visible = false;
                        btChangeFile.Visible = false;
                        lbDot.Visible = false;
                        tbExtention.Visible = false;
                        tbExtention.Text = "";
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
            tbExtention.Text = "";
            tbFileName.Text = "";
            cbSystemFile.Checked = false;
            cbExecutable.Checked = false;
            cbArchive.Checked = false;
            cbHidden.Checked = false;
            cbReadOnly.Checked = false;
            cbExecutable.Visible = true;
            cbSystemFile.Visible = true;
            cbArchive.Visible = true;
            btChangeFile.Visible = true;
            lbDot.Visible = true;
            tbExtention.Visible = true;
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

        private void openFloppyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cBinLoader Loader = new cBinLoader();
            if (!Loader.LoadBin(cbEndian.SelectedIndex, FileType.fullFloppy))
                return;
            cBinReader Reader = new cBinReader(Loader.GetFloppy(512));
            if (!Reader.ReadBin())
                return;
            FileSystem = Reader.GetFileSystem();
            UpdateDirectoryView();
            UpdateDiskUsage();
        }

        private void btSaveName_Click(object sender, EventArgs e)
        {
            cFileSystemItem Temp = FileSystem.GetItemByIndex((int)dgItemsInWorkingDir.Rows[dgItemsInWorkingDir.SelectedRows[0].Index].Cells["Index"].Value);
            Temp.Metadata.SetName(tbFileName.Text);
            Temp.Metadata.SetExtension(tbExtention.Text);
            Temp.Metadata.Flags.Archive = cbArchive.Checked;
            Temp.Metadata.Flags.Executable = cbExecutable.Checked;
            Temp.Metadata.Flags.Hidden = cbHidden.Checked;
            Temp.Metadata.Flags.ReadOnly = cbReadOnly.Checked;
            Temp.Metadata.Flags.SystemFile = cbSystemFile.Checked;
            UpdateDirectoryView();
        }

        private void btChangeFile_Click(object sender, EventArgs e)
        {
            cFileSystemItem Temp = FileSystem.GetItemByIndex((int)dgItemsInWorkingDir.Rows[dgItemsInWorkingDir.SelectedRows[0].Index].Cells["Index"].Value);
            Temp.ReadFile(cbEndian.SelectedIndex);
            UpdateDiskUsage();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileSystem.FAT.SetMediaName(tbMediaName.Text);
        }

        private void btChangeKernel_Click(object sender, EventArgs e)
        {
            cBinLoader Loader = new cBinLoader();
            if (Loader.LoadBin(cbEndian.SelectedIndex, FileType.Kernel))
            {
                FileSystem.FAT.ReplaceKernel(Loader.GetFile(FileType.Kernel));
                UpdateDiskUsage();
            }
        }


    }
}
