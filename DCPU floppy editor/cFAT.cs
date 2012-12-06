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
		private int FatIndex;
		private int RootDirIndex;
		private int NumSectors;
		private int NumFatSectors;
		private cFloppy Floppy;

		internal cFAT(DiskType ModeOfDisk, cFloppy FloppyToUse)
		{
			Mode = ModeOfDisk;
			Floppy = FloppyToUse;
		}

		internal bool InitFat()
		{
			if (!CalcIndixes())
				return false;
			if (!CreateFat())
				return false;
			return true;
		}

		private bool CalcIndixes()
		{
			
			NumSectors = Floppy.Sectors[0].Memory[0xb];
			FatIndex = Floppy.Sectors[0].Memory[8];
			try
			{
				RootDirIndex = FatIndex + (Floppy.Sectors[0].Memory[0xb] / Floppy.Sectors[0].Memory[0xa]);		//when not properly initialized, it can drop an exception (num fat Tables == 0)
				if ((Floppy.Sectors[0].Memory[0xb] % Floppy.Sectors[0].Memory[0xa]) != 0)
				{
					RootDirIndex++;				//add the half used sector
				}
				NumFatSectors = RootDirIndex - FatIndex;
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
			while (Index < NumSectors)
			{
				Floppy.Sectors[FatIndex +(Index >> 9)].Memory[Index  & 0x1FF] = 0x0000;		//same as ./512 and .%512
				Index++;
			}
			Index = 0;
			return true;
		}
    }
}
