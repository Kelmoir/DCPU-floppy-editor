using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DCPU_floppy_editor
{
    public enum FileType
    {
        Bootloader = 0, Kernel = 1, File = 2, fullFloppy = 3
    };
    class cBinLoader
    {
        List<ushort> Readout;
        internal bool LoadBin(int Endian, FileType Mode)
        {
            Readout = new List<ushort>();
            OpenFileDialog Dialog = new OpenFileDialog();
            if (Mode == FileType.fullFloppy)
            {
                Dialog.Title = "Select the DCPU disk file to open";
                Dialog.DefaultExt = "dsk";
                Dialog.Filter = "DCPU disk files (*.dsk)|*.dsk|All files (*.*)|*.*";
            }
            else
            {
                Dialog.Title = "Select the uncompressed binary file to open";
                Dialog.DefaultExt = "bin";
                Dialog.Filter = "binary files (*.bin)|*.bin|All files (*.*)|*.*";
            }
            
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
        internal List<ushort> GetReadOut()
        {
            return Readout;
        }

        internal List<cSector> GetFile(FileType Type)
        {
            List<cSector> Result = new List<cSector>();
            cSector WorkingSector = new cSector();
            int ReadoutIndex = 0;
            int IntSectorIndex = 0;
            if (Type == FileType.Bootloader || Type == FileType.Kernel || Type == FileType.fullFloppy)
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
        internal cFloppy GetFloppy(int SectorSize)
        {
            int NumSectors = Readout.Count / SectorSize;
            if ((Readout.Count % SectorSize) != 0)
            {
                NumSectors++;
            }
            cFloppy result = new cFloppy(NumSectors);
            int SectorIndex = 0;
            int SectorPos = 0;
            int ReadoutPos = 0;
            while (SectorIndex < NumSectors)
            {
                while (SectorPos < SectorSize && ReadoutPos < Readout.Count)
                {
                    result.Sectors[SectorIndex].Memory[SectorPos] = Readout[ReadoutPos];
                    SectorPos++;
                    ReadoutPos++; 
                }
                SectorPos = 0;
                SectorIndex++;
            }
            return result;
        }
    }
}
