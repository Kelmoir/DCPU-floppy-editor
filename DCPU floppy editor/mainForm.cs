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
		cFAT FAT;


        public mainForm()
        {
            InitializeComponent();
            cbEndian.SelectedIndex = 1;         //Organic outputs big Endian
			Floppy = new cFloppy(0);
			FAT = new cFAT(DiskType.NonBootable, Floppy);
        }

        private void NewFloppyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Floppy = new cFloppy(1440);
			FAT = new cFAT(DiskType.Bootable, Floppy);
            NewFloppyWizard Wizard = new NewFloppyWizard(this);
			if (Wizard.ShowDialog() == DialogResult.OK)
			{
				if (FAT.InitFat())
				{
					FloppyChanged = true;
				}
				else
				{
					MessageBox.Show("Failed to generate the Floppy");
					Floppy = new cFloppy(0);							//make shure, nothing happens
					FAT = new cFAT(DiskType.NonBootable, Floppy);
				}
			}
        }

		private void saveFloppyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Floppy.Save(cbEndian.SelectedIndex);
		}

    }
}
