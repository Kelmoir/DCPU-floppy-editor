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
    public partial class NewFloppyWizard : Form
    {
        internal mainForm Master;
        private List<cSector> Bootloader;
        private List<cSector> Kernel;
        private bool BooloaderAvaiable = false;
        private bool KernelAvaiable = false;

        public NewFloppyWizard(mainForm MasterForm)
        {
            InitializeComponent();
            Master = MasterForm;
            Bootloader = new List<cSector>();
            Kernel = new List<cSector>();
        }

        private void NewFloppyWizard_Shown(object sender, EventArgs e)
        {
        }

        private void btAddBootloader_Click(object sender, EventArgs e)
        {
            cBinLoader Loader = new cBinLoader();
            if (Loader.LoadBin(Master.cbEndian.SelectedIndex, FileType.Bootloader))
            {
                Bootloader = Loader.GetFile(FileType.Bootloader);
                lbBootloaderStatus.Text = "bootloader status: bootloader loaded";
                BooloaderAvaiable = true;
                if (BooloaderAvaiable && KernelAvaiable)
                {
                    btCreateFloppy.Visible = true;
                }
            }

        }

        private void btAddKernel_Click(object sender, EventArgs e)
        {
            cBinLoader Loader = new cBinLoader();
            if (Loader.LoadBin(Master.cbEndian.SelectedIndex, FileType.Kernel))
            {
                Kernel = Loader.GetFile(FileType.Kernel);
                lbKernelStatus.Text = "kernel status: kernel loaded";
                KernelAvaiable = true;
                if (BooloaderAvaiable && KernelAvaiable)
                {
                    btCreateFloppy.Visible = true;
                }
            }
        }

        private void btCreateFloppy_Click(object sender, EventArgs e)
        {
            if (CheckForValidBootSectors())
            {
                int Index;
                for (Index = 0; Index < Bootloader.Count; Index++)
                {
                    Master.Floppy.Sectors[Index] = Bootloader[Index];
					Master.Floppy.Sectors[Index].Mode = SectorMode.Boot;
                }
                for (Index = 0; Index < Kernel.Count; Index++)
                {
                    Master.Floppy.Sectors[Index + Bootloader.Count] = Kernel[Index];
					Master.Floppy.Sectors[Index + Bootloader.Count].Mode = SectorMode.Reserved;
                }
				this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool CheckForValidBootSectors()
        {
            if (Bootloader.Count == 1)
            {
                return HeaderVerifier.VerifyFHAT16BootSector(Bootloader[0], (ushort)Kernel.Count, (ushort)Master.Floppy.Sectors.Length, true);
            }
            else
            {
                MessageBox.Show("Bootloader is too big");
                return false;
            }
        }

        private void btBootableFloppy_Click(object sender, EventArgs e)
        {
            gbFloppyType.Visible = false;
            gbBootableFloppy.Visible = true;
            //gbBootableFloppy.Location.X = 1;
            //gbBootableFloppy.Location.Y = 2;
            Master.Floppy = new cFloppy(1440);
            Master.FileSystem = new cFileSystem(DiskType.Bootable, Master.Floppy);
        }

        private void btNonBootableFloppy_Click(object sender, EventArgs e)
        {
            gbFloppyType.Visible = false;
            gbNonBootFloppy.Visible = true;
            //gbNonBootFloppy.Location.X = 1;
            //gbNonBootFloppy.Location.Y = 2;
        }

        private void btCreateNonBootFloppy_Click(object sender, EventArgs e)
        {
            try
            {
                int NumSectors = Convert.ToInt32(tbNumSectors.Text);
                Master.Floppy = new cFloppy(NumSectors);
                Master.FileSystem = new cFileSystem(DiskType.NonBootable, Master.Floppy);

                Master.FileSystem.FAT.CreateBootSector(tbMediaName.Text, NumSectors);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch
            {
                MessageBox.Show("Error while creating the floppy");
            }
        }

        private void tbMediaName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btCreateNonBootFloppy_Click(sender, new EventArgs());
            }
        }

    }
}
