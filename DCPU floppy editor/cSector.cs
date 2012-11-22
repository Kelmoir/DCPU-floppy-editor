using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DCPU_floppy_editor
{
	internal enum SectorMode
	{
		Boot = 0, Reserved = 1, FAT = 2, Directory = 3, File = 4, Empty = 5
	}
    internal class cSector
    {
        internal ushort[] Memory;
		internal List<cDirectoryEntry> DirectoryEntrys;
		internal SectorMode Mode;

        internal cSector()
        {
            Memory = new ushort[512];
			Mode = SectorMode.Empty;
			DirectoryEntrys = new List<cDirectoryEntry>();
        }
        internal cSector Clone()
        {
            cSector Clone = new cSector();
            for (int i = 0; i < this.Memory.Length; i++)
            {
                Clone.Memory[i] = this.Memory[i];
            }
			foreach (cDirectoryEntry Element in this.DirectoryEntrys)
			{
				Clone.DirectoryEntrys.Add(Element.Clone());
			}
			Clone.Mode = this.Mode;
            return Clone;
        }
		internal void Clear()
		{
			for (int i = 0; i < this.Memory.Length; i++)
				this.Memory[i] = 0;
			this.Mode = SectorMode.Empty;
			this.DirectoryEntrys.Clear();
		}
		internal void UpdateDirectoryEntrysToBinary()
		{
			if (this.Mode == SectorMode.Directory)
			{
				int i;
				ushort[] Buffer;
				for (i = 0; i < this.Memory.Length; i++)
					this.Memory[i] = 0;
				i = 0;
				foreach (cDirectoryEntry Element in this.DirectoryEntrys)
				{
					Buffer = Element.GetDirectoryBinData();
					for (int j = 0; j < 16; j++)
						this.Memory[i+j] = Buffer[j];
					i += 16;
				}
			}
		}

		internal void WriteToFile(System.IO.Stream Savestream, int Endian)
		{
			byte[] Buffer = new byte[2];
			foreach (ushort Element in this.Memory)
			{
				if (Endian == 0)        //little Endian
				{
					Buffer[0] = (byte)Element;
					Buffer[1] = (byte)(Element >> 8);
				}
				else
				{
					Buffer[1] = (byte)Element;
					Buffer[0] = (byte)(Element >> 8);
				}
				Savestream.Write(Buffer, 0, 2);
			}
		}
	}
}
