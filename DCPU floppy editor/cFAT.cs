using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DCPU_floppy_editor
{
	enum DiskType
	{
		Bootable = 0, NonBootable = 1
	};

	/// <summary>
	/// provides the Physical Coordination and Layout of the Floppy/device
    /// Will either being read out (open floppy)
    /// or being written enetierly. Every inline change will be done in cFileSystem
    /// thus doesn't need to search for free sectory, add them, remove them, etc. 
    /// Only the Reserved Sectors will being written and the FAT Table will be reserved on building it.
	/// </summary>
	internal class cFAT
	{
		private DiskType Mode;
		private ushort FatIndex;
		private ushort RootDirIndex;
		private ushort NumSectors;
		private ushort NumFatSectors;
		private cFloppy Floppy;
        private ushort FistFreeSector;
        private ushort SectorSize;

		internal cFAT(DiskType ModeOfDisk, cFloppy FloppyToUse)
		{
			Mode = ModeOfDisk;
			Floppy = FloppyToUse;
            SectorSize = 512;           //might need to change that later on
		}

		internal bool InitFat()
		{
			if (!CalcIndixes())
				return false;
			if (!CreateFat())
				return false;
			return true;
		}

		internal bool CalcIndixes()
		{
			
			NumSectors = Floppy.Sectors[0].Memory[0xb];
			FatIndex = Floppy.Sectors[0].Memory[8];
			try
			{
				RootDirIndex = (ushort)(FatIndex + (Floppy.Sectors[0].Memory[0xb] / Floppy.Sectors[0].Memory[0xa]));		//when not properly initialized, it can drop an exception (num fat Tables == 0)
				if ((Floppy.Sectors[0].Memory[0xb] % Floppy.Sectors[0].Memory[0xa]) != 0)
				{
					RootDirIndex++;				//add the half used sector
				}
				NumFatSectors = (ushort)(RootDirIndex - FatIndex);
                FistFreeSector = RootDirIndex;
				return true;
			}
			catch
			{
				return false;
			}
		}

		private bool CreateFat()
		{
			int Index = 1;
			Floppy.Sectors[FatIndex].Memory[0] = 0xFFFD;
			while (Index < RootDirIndex)
			{
				Floppy.Sectors[FatIndex].Memory[Index] = 0xFFFD;		//marking reserved sectors and FAT sectors as reserved
				if (Index >= FatIndex)
				{
					Floppy.Sectors[Index].Mode = SectorMode.FAT;
				}
				Index++;
			}
			//the root dir will being created later
            ClearUserSpace();
			return true;
		}

        internal int GetNumHeaderSectors()
        {
            return NumFatSectors + FatIndex + 1;
        }
        internal int GetNumSectors()
        {
            return Floppy.Sectors.Length;
        }
        internal void SafeFloppy(int Endian)
        {
            Floppy.Save(Endian);
        }

        internal void ClearUserSpace()
        {
            int Index = RootDirIndex;
            FistFreeSector = RootDirIndex;
            while (Index < NumSectors)
            {
                Floppy.Sectors[FatIndex + (Index >> 9)].Memory[Index & 0x1FF] = 0x0000;		//same as ./512 and .%512
                Floppy.Sectors[Index] = new cSector();
                Index++;
            }
        }

        internal ushort RegisterSectors(int NumberOfSectors)
        {
            ushort FirstSector = FistFreeSector;
            ushort NextSector = (ushort)(FistFreeSector + 1);
            while (NumberOfSectors > 0)
            {
                //in case the logically next sector is already used, seek for a free one
                while (Floppy.Sectors[FatIndex + (NextSector >> 9)].Memory[NextSector & 0x1FF] > 0)
                {
                    NextSector++;
                }
                if (NumberOfSectors > 1)
                {
                    Floppy.Sectors[FatIndex + (FistFreeSector >> 9)].Memory[FistFreeSector & 0x1FF] = NextSector;
                }
                else
                {
                    Floppy.Sectors[FatIndex + (FistFreeSector >> 9)].Memory[FistFreeSector & 0x1FF] = 0xFFFF;
                }
                FistFreeSector = NextSector;
                NextSector++;
                NumberOfSectors--;
            }
            return FirstSector;
        }

        internal void WriteData(ushort[] Data, ushort FirstSector)
        {
            int WriteIndex = 0;
            ushort WriteSector = FirstSector;
            while (WriteIndex < Data.Length)
            {
                Floppy.Sectors[WriteSector].Memory[WriteIndex & 0x1FF] = Data[WriteIndex];
                if ((WriteIndex & 0x1FF) == 0x1FF)
                {
                    WriteSector = NextSector(WriteSector);
                }
                WriteIndex++;
            }
        }

        internal ushort NextSector(ushort WriteSector)
        {
            return Floppy.Sectors[FatIndex + (WriteSector >> 9)].Memory[WriteSector & 0x1FF];
        }

        internal ushort GetRootDirectoryIndex()
        {
            return (ushort)RootDirIndex;
        }

        internal ushort GetSectorSize()
        {
            return SectorSize;
        }
    }
}
