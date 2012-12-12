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
    public partial class NewItemWizard : Form
    {
        cFileFlags Flags;
        internal cFileSystemItem NewItem;
        int Endian;
        public NewItemWizard(bool IsDirectory, int Endianess)
        {
            InitializeComponent();
            Flags = new cFileFlags();
            Flags.Directory = IsDirectory;
            if (Flags.Directory)
            {
                gbNewExtension.Visible = false;
                cbExecutable.Visible = false;
                cbDriver.Visible = false;
                btReadFile.Visible = false;
                cbSystemFile.Visible = false;
                cbArchive.Visible = false;
            }
            NewItem = new cFileSystemItem("", "", Flags, false);
            Endian = Endianess;
        }

        private void cbDriver_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDriver.Checked)
            {
                gbNewName.Text = "ManID (0x...)";
                gbNewExtension.Text = "DevID (0x...)";
            }
            else
            {
                gbNewName.Text = "Name (max 8 chars)";
                gbNewExtension.Text = "Extension (3 chars)";
            }
        }

        private void btReadFile_Click(object sender, EventArgs e)
        {
            cBinLoader Loader = new cBinLoader();
            if (Loader.LoadBin(Endian))
            {
                cFile File = new cFile();
                File.SetFileData(Loader.GetReadOut());
                NewItem.SetFile(File);
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btCreate_Click(object sender, EventArgs e)
        {
            if (!NewItem.IsValid())
                return;
            NewItem.Metadata.Flags.Archive = cbArchive.Checked;
            NewItem.Metadata.Flags.Executable = cbExecutable.Checked;
            NewItem.Metadata.Flags.Hidden = cbHidden.Checked;
            NewItem.Metadata.Flags.ReadOnly = cbReadOnly.Checked;
            NewItem.Metadata.Flags.SystemFile = cbSystemFile.Checked;
            if (!cbDriver.Checked)
            {
                if (tbNewName.Text != "")
                    NewItem.Metadata.SetName(tbNewName.Text);
                else
                    return;
                if (!NewItem.Metadata.Flags.Directory)
                {
                    if (tbNewExtension.Text != "")
                        NewItem.Metadata.SetExtension(tbNewExtension.Text);
                    else
                        return;
                }
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                try
                {
                    NewItem.Metadata.SetNameFromManIdAndDevId(cHexInterface.ConvertToUint(tbNewName.Text), cHexInterface.ConvertToUint(tbNewExtension.Text));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error converting the MaID and the DevID.\r\n\r\n" + ex.Message);
                    return;
                }
                NewItem.Metadata.Extention = "drv";
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

    }
}
