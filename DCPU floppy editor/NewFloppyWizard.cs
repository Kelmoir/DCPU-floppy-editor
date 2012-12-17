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
            if (Loader.LoadBin(Master.cbEndian.SelectedIndex))
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
            if (Loader.LoadBin(Master.cbEndian.SelectedIndex))
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
            if (Bootloader.Count > 1)
            {
                MessageBox.Show("Bootloader is too big");
                return false;
            }
            if (Bootloader[0].Memory[0] != 0xC382)      //is the Bootable Flag correct?
            {
                MessageBox.Show("Incorrect Bootflag");
                return false;
            }
            //now some checks for consistency to the HA FAT
            if (Bootloader[0].Memory[8] != Kernel.Count)
            {
                if (MessageBox.Show("Wrong amount of reserved sectors detected.\r\nCorrect them?", "FAT Inconsistency", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Bootloader[0].Memory[8] = (ushort)Kernel.Count;
                }
                else
                {
                    return false;
                }
            }
			if (Master.Floppy.Sectors.Length != (int)Bootloader[0].Memory[0xb])
			{
				if (MessageBox.Show("Wron amount of sectors specified fot the loaded Device.\r\nCorrect them?", "Device size inconsitency", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Bootloader[0].Memory[0xb] = (ushort)Master.Floppy.Sectors.Length;
                }
                else
                {
                    return false;
                }
			}
            //and whatever more can go wrong...


            return true;
        }

    }
}
