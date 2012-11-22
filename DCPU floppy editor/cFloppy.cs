using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DCPU_floppy_editor
{
	/// <summary>
	/// provides the raw view onto the data of the floppy
	/// </summary>
    internal class cFloppy
    {
        internal cSector[] Sectors;

		internal cFloppy(int NumSectors)
		{
			Sectors = new cSector[NumSectors];
			for (int i = 0; i < NumSectors; i++)
				this.Sectors[i] = new cSector();
		}

		internal cFloppy Clone()
        {
            cFloppy Clone = new cFloppy(this.Sectors.Length);
            for (int i = 0; i < this.Sectors.Length; i++)
            {
                Clone.Sectors[i] = this.Sectors[i].Clone();
            }
            return Clone;
        }

		internal void Save(int Endian)
		{
			SaveFileDialog Dia = new SaveFileDialog();
			Dia.Title = "Select a File to save the flopy";
			if (Dia.ShowDialog() == DialogResult.OK)
			{
				try
				{
					System.IO.Stream Savestream = Dia.OpenFile();
					foreach (cSector Element in Sectors)
						Element.WriteToFile(Savestream, Endian);

					Savestream.Close();
				}
				catch (Exception ex)
				{
					MessageBox.Show("Error while saving the file.\r\n\r\n" + ex.ToString());
				}
			}
		}
    }
}
