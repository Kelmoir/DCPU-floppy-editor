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
	/// provides the logical view onto the Floppy.
	/// it does create an dualistic Dataholt, but the abstracted one is much easier to handler, and the binary data is just read upon loading stuff..
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
			if (!CreateRootDir())
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

		private bool CreateRootDir()
		{
			try
			{
				cFileFlags ParentFlags = new cFileFlags();
				cDirectoryEntry EntryToParentSector = new cDirectoryEntry("..", "", 0, (ushort)RootDirIndex, ParentFlags, (ushort)RootDirIndex);
				ParentFlags.Directory = true;
				ParentFlags.ReadOnly = true;
				//using try-catch here, to have it all running in an transaction - handling for error is much more simple (no manual undoing of actions)
				RegisterNewSector((ushort)RootDirIndex, SectorMode.Directory);
				//and the one back to the parent
				CreateDirTableEntry(EntryToParentSector);
				return true;
			}
			catch
			{
				return false;
			}
		}
		/// <summary>
		/// Creates the new directory Table, thus effectively opening the new directory, and adding neccessary entrys
		/// </summary>
		/// <param name="Sector">sector Index of </param>
		/// <param name="ParentSector"></param>
		/// <returns></returns>
		internal bool CreateNewDirectoryTable(ushort ParentSector, string Name)
		{
			try
			{
				cFileFlags SectorFlags = new cFileFlags();
				cFileFlags ParentFlags = new cFileFlags();
				ushort TempSec = FindFreeSector();
				cDirectoryEntry EntryToNewSector = new cDirectoryEntry(Name, "", 0, TempSec, SectorFlags, ParentSector);
				cDirectoryEntry EntryToParentSector = new cDirectoryEntry("..", "", 0, ParentSector, ParentFlags, TempSec);
				SectorFlags.Directory = true;
				ParentFlags.Directory = true;
				ParentFlags.ReadOnly = true;
				//using try-catch here, to have it all running in an transaction - handling for error is much more simple (no manual undoing of actions)

				RegisterNewSector(EntryToNewSector.FirstSector, SectorMode.Directory);	
				//create the Entry for the new directory
				CreateDirTableEntry(EntryToNewSector);
			
				//and the one back to the parent
				CreateDirTableEntry(EntryToParentSector);

			}
			catch
			{
				return false;
			}

			return true;
		}

		internal void CreateDirTableEntry(cDirectoryEntry NewEntry)
		{
			ushort Address = ObtainSpaceForEntry(NewEntry);
			NewEntry.ResidentSector = Address;
			Floppy.Sectors[Address].DirectoryEntrys.Add(NewEntry);
			Floppy.Sectors[Address].UpdateDirectoryEntrysToBinary();
		}

		#region register new sectorlist
		/// <summary>
		/// registers a new sector list beginning with the submitted sector
		/// </summary>
		/// <param name="Sector">the sector index to start with</param>
		/// <param name="Mode">What is in the sector (directory vs. file is important)</param>
		internal void RegisterNewSector(ushort Sector, SectorMode Mode)
		{
			int SecNum = FatIndex + (Sector >> 9);
			int Secindex = Sector & 0x1FF;
			if (Floppy.Sectors[SecNum].Memory[Secindex] == 0)
			{
				Floppy.Sectors[SecNum].Memory[Secindex] = 0xFFFF;
				Floppy.Sectors[Sector].Mode = Mode;
			}
			else
			{
				throw new Exception("unable to register a new sector there");
			}
		}
		#endregion

		#region Find free sector
		/// <summary>
		/// gets the address of the first free sector avaiable
		/// </summary>
		/// <returns>the address of the first free sector</returns>
		internal ushort FindFreeSector()
		{
			ushort Index = 0;
			bool found = false;
			while (!found && Index < Floppy.Sectors.Length)
			{
				if (Floppy.Sectors[FatIndex + (Index >> 9)].Memory[Index & 0x1FF] == 0)
				{
					found = true;
				}
				else
				{
					Index++;
				}
			}
			if (found)
			{
				return Index;
			}
			else
			{
				throw new Exception("No free space avaiable");
			}
		}
		#endregion

		#region expand sector
		/// <summary>
		/// expands the List of sectors allocated to one specific file or directory
		/// </summary>
		/// <param name="FirstSector">the Index of the (not neccessarly) first sector of the Object</param>
		/// <returns>the address of the new sector</returns>
		internal ushort ExpandSector(ushort FirstSector)
		{
			FirstSector = FindLastSector(FirstSector);
			if (Floppy.Sectors[FatIndex + (FirstSector >> 9)].Memory[FirstSector & 0x1FF] == 0xFFFF)
			{
				ushort NextSector = FindFreeSector();
				Floppy.Sectors[FatIndex + (FirstSector >> 9)].Memory[FirstSector & 0x1FF] = (ushort)NextSector;
				Floppy.Sectors[FatIndex + (NextSector >> 9)].Memory[NextSector & 0x1FF] = 0xFFFF;
				Floppy.Sectors[FatIndex + (NextSector >> 9)].Mode = Floppy.Sectors[FirstSector >> 9].Mode;
				return NextSector;
			}
			else
			{
				throw new Exception("Sector list corrupted");
			}

		}
		#endregion

		#region find last sector
		/// <summary>
		/// gets the last sector in the currentsector list
		/// </summary>
		/// <param name="FirstSector"></param>
		/// <returns>the address of the last sector</returns>
		internal ushort FindLastSector(ushort FirstSector)
		{
			while (Floppy.Sectors[FatIndex + (FirstSector >> 9)].Memory[FirstSector & 0x1FF] < 0xFFF0)
				FirstSector = Floppy.Sectors[FatIndex + (FirstSector >> 9)].Memory[FirstSector & 0x1FF];
			return FirstSector;
		}
		#endregion

		private ushort ObtainSpaceForEntry(cDirectoryEntry NewEntry)
		{
			if (Floppy.Sectors[FindLastSector(NewEntry.ResidentSector)].DirectoryEntrys.Count == 0x20)		//Sector full with Entrys, we need a new one
			{
				return ExpandSector(NewEntry.ResidentSector);
			}
			else
			{
				return FindLastSector(NewEntry.ResidentSector);
			}
		}

		internal bool RemoveDirTableEntry(cDirectoryEntry SectorEntry)
		{
			return true;
		}
	}
}
