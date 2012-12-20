using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DCPU_floppy_editor
{
    class cBinReader
    {
        cFAT InputFAT;
        cFloppy InputFloppy;
        cFileSystem OutputFS;
        cFloppy OutputFloppy;
        bool Success = false;

        internal cBinReader(cFloppy NewFloppy)
        {
            InputFloppy = NewFloppy;
            OutputFloppy = new cFloppy(InputFloppy.Sectors.Length);
            if (IsBootable(InputFloppy))
            {
                OutputFS = new cFileSystem(DiskType.Bootable, OutputFloppy);
                OutputFS.FAT.InitFat();
                InputFAT = new cFAT(DiskType.Bootable, InputFloppy);
            }
            else
            {
                OutputFS = new cFileSystem(DiskType.NonBootable, OutputFloppy);
                OutputFS.FAT.InitFat();
                InputFAT = new cFAT(DiskType.NonBootable, InputFloppy);
            }
        }

        private bool IsBootable(cFloppy FloppyToUse)
        {
            try
            {
                if (FloppyToUse.Sectors[0].Memory[0] == 0xC382)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }


        /// <summary>
        /// Reads out the filesystem supplied with the binary File
        /// </summary>
        /// <returns></returns>
        internal bool ReadBin()
        {

            if (!ObtainBootSector())
                return false;
            if (!VerifyBootSector(IsBootable(InputFloppy)))
                return false;
            ObtainEntireHeader();
            if (!InputFAT.CalcIndixes())
                return false;
            if (!OutputFS.FAT.InitFat())
                return false;
            //Header was read, now continue with all the stuff inside. Beware OutputFloppy must now be modified anymore.
            if (!ConvertEntrys(OutputFS.FAT.GetRootDirectoryIndex(), OutputFS.GetWorkingDirektory(), (uint)0))
                return false;
            Success = true;
            return true;
        }

        private bool ObtainBootSector()
        {
            for (int i = 0; i < InputFloppy.Sectors[0].Memory.Length; i++)
            {
                OutputFloppy.Sectors[0].Memory[i] = InputFloppy.Sectors[0].Memory[i];
            }
            return true;
        }

        private bool VerifyBootSector(bool IsBootable)
        {
            return HeaderVerifier.VerifyFHAT16BootSector(OutputFloppy.Sectors[0], OutputFloppy.Sectors[0].Memory[8], (ushort)OutputFloppy.Sectors.Length, IsBootable);
        }
        private void ObtainEntireHeader()
        {
            for (int i = 1; i < OutputFloppy.Sectors[0].Memory[8]; i++ )
            {
                for (int j = 0; j < OutputFloppy.Sectors[0].Memory.Length; j++)
                {
                    OutputFloppy.Sectors[i].Memory[j] = InputFloppy.Sectors[i].Memory[j];
                }
            }
        }
        private bool ConvertEntrys(ushort SectorNumber, cFileSystemItem ItemToFill, uint Size)
        {
            if (ItemToFill.IsDirectory())
            {
                //ignore the first Entry, as it is isn't displayed in the logical structure
                int SubIndex = ItemToFill.Metadata.GetBinaryEntrySize();
                bool run = true;
                while (run)
                {
                    if (HeaderVerifier.IsValidDirectoryEntry(InputFloppy.Sectors[SectorNumber], SubIndex, SectorNumber, InputFAT))
                    {
                        //TODO: Read/write the datetimes
                        cFileFlags Flags = new cFileFlags();
                        Flags.ReadFromBinary((byte)InputFloppy.Sectors[SectorNumber].Memory[SubIndex + 5]);
                        ushort[] Data = new ushort[4];
                        Data[0] = InputFloppy.Sectors[SectorNumber].Memory[SubIndex + 0];
                        Data[1] = InputFloppy.Sectors[SectorNumber].Memory[SubIndex + 1];
                        Data[2] = InputFloppy.Sectors[SectorNumber].Memory[SubIndex + 2];
                        Data[3] = InputFloppy.Sectors[SectorNumber].Memory[SubIndex + 3];
                        string Name = cFileSigConverter.ConvertToFileName(Data);
                        Data = new ushort[2];
                        Data[0] = InputFloppy.Sectors[SectorNumber].Memory[SubIndex + 4];
                        Data[1] = InputFloppy.Sectors[SectorNumber].Memory[SubIndex + 5];
                        string Extention = cFileSigConverter.ConvertToFileExtention(Data);
                        cFileSystemItem NewItem = new cFileSystemItem(Name, Extention, Flags, false);
                        Size = (uint)((uint)InputFloppy.Sectors[SectorNumber].Memory[SubIndex + 13] << 16 |
                                    (uint)InputFloppy.Sectors[SectorNumber].Memory[SubIndex + 12]);
                        if (ConvertEntrys(InputFloppy.Sectors[SectorNumber].Memory[SubIndex + 14], NewItem, Size))
                        {
                            ItemToFill.AddItem(NewItem);
                        }
                        SubIndex += ItemToFill.Metadata.GetBinaryEntrySize();
                        if (SubIndex >= InputFAT.GetSectorSize())
                        {
                            SubIndex = 0;
                            SectorNumber = InputFAT.NextSector(SectorNumber);
                            if (SectorNumber >= 0xFFF0)
                            {
                                run = false;
                            }
                        }
                    }
                    else
                    {
                        run = false;
                    }
                }
                return true;
            }
            else
            {
                List<ushort> Data = new List<ushort>();
                bool run = true;
                uint i = 0;
                while (run)
                {
                    int subIndex = 0;
                    while (subIndex < 512 && i < Size)
                    {
                        Data.Add(InputFloppy.Sectors[SectorNumber].Memory[subIndex]);
                        i++;
                        subIndex++;
                    }
                    SectorNumber = InputFAT.NextSector(SectorNumber);
                    if (SectorNumber >= 0xFFF0)
                    {
                        run = false;
                    }
                }
                cFile Newfile = new cFile();
                Newfile.SetFileData(Data);
                ItemToFill.SetFile(Newfile);
                return true;
            }
        }
        internal cFileSystem GetFileSystem()
        {
            if (Success)
                return OutputFS;
            else
                return null;
        }
    }
}
