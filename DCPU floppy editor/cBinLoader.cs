using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DCPU_floppy_editor
{
    public enum FileType
    {
        Bootloader = 0, Kernel = 1, File = 2
    };
    class cBinLoader
    {
        List<ushort> Readout;
        internal bool LoadBin(int Endian)
        {
            Readout = new List<ushort>();
            OpenFileDialog Dialog = new OpenFileDialog();
            Dialog.Title = "Select the uncompressed bin file to open";
            if (Dialog.ShowDialog() == DialogResult.OK)
            {
                System.IO.Stream Input;
                try
                {
                    Input = Dialog.OpenFile();
                }
                catch
                {
                    MessageBox.Show("Invalid file");
                    return false;
                }
                byte[] TempBuffer = new byte[2];
                int Position = 0;
                ushort TempWord;
                for (Position = 0; Position < Input.Length - 1; Position += 2)
                {
                    Input.Read(TempBuffer, 0, 2);
                    if (Endian == 0)        //little Endian
                    {
                        TempWord = (ushort)((TempBuffer[1] << 8) | TempBuffer[0]);
                    }
                    else
                    {
                        TempWord = (ushort)((TempBuffer[0] << 8) | TempBuffer[1]);
                    }
                    Readout.Add(TempWord);
                }
                Input.Close();
                return true;
            }
            else
            {
                return false;
            }
        }
        internal List<cSector> GetFile(FileType Type)
        {
            List<cSector> Result = new List<cSector>();
            cSector WorkingSector = new cSector();
            int ReadoutIndex = 0;
            int IntSectorIndex = 0;
            if (Type == FileType.Bootloader || Type == FileType.Kernel)
            {
                //atm no special actions required...
            }
            else
            {
                //add file Metadata
                //name is 0 for now
                //extensaion is 0 for now
                //dateTimes 0 for now
                WorkingSector.Memory[0xC] = (ushort)(Readout.Count & 0x0000FFFF);
                WorkingSector.Memory[0xD] = (ushort)(Readout.Count >> 16);
                //First Sector unknown for now
                //reserved is reserved
                IntSectorIndex = 0x0010;
            }
            for (ReadoutIndex = 0; ReadoutIndex < Readout.Count; ReadoutIndex++)
            {
                WorkingSector.Memory[IntSectorIndex] = Readout[ReadoutIndex];
                IntSectorIndex++;
                if (IntSectorIndex == WorkingSector.Memory.Length)    //current sector is full, need new one
                {
                    IntSectorIndex = 0;
                    Result.Add(WorkingSector.Clone());
                    WorkingSector = new cSector();
                }
            }
            if (IntSectorIndex > 0)
            {
                Result.Add(WorkingSector.Clone());
            }
            return Result;
        }

    }
}
