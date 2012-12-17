using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DCPU_floppy_editor
{
    public class SupDirectorySelected : Exception
    {
    }
    public class NotADirectory : Exception
    {
    }

    internal class cFileSystemItem
    {
        private List<cFileSystemItem> Items;
        private bool IsRoot;
        internal cDirectoryEntry Metadata;
        private cFile File;

        #region Constructor
        internal cFileSystemItem(string NewName, string NewExtention, cFileFlags NewFlags, bool IsRootDirectory)
        {
            if (NewFlags.Directory)
            {
                Items = new List<cFileSystemItem>();
            }
            else
            {
                File = new cFile();
            }
            Metadata = new cDirectoryEntry(NewName, NewExtention, NewFlags);
            IsRoot = IsRootDirectory;
        }
        #endregion

        #region Get Size in Sectors
        internal int GetSizeInSectors(int SectorSize, bool Recursive)
        {
            int result = 0;
            if (Metadata.Flags.Directory)
            {
                result = this.GetNumOfItems() / 20;
                if (this.GetNumOfItems() % 20 != 0)
                {
                    result += 1;
                }
                if (Recursive)
                {
                    foreach (cFileSystemItem Item in this.Items)
                        result += Item.GetSizeInSectors(SectorSize, true);
                }
            }
            else
            {
                result = File.GetSizeInSectors(SectorSize);
            }
            return result;
        }
        #endregion

        #region Getters/setters
        internal bool AddItem(cFileSystemItem NewItem)
        {
            if (Metadata.Flags.Directory)
            {
                Items.Add(NewItem);
                return true;
            }
            else
            {
                return false;
            }
        }
        internal void DeleteItem(int IndexToDelete)
        {
            if (Metadata.Flags.Directory && IndexToDelete > 0)
            {
                Items.RemoveAt(IndexToDelete-1);
            }
        }
        internal bool SetFile(cFile NewFile)
        {
            if (!Metadata.Flags.Directory)
            {
                this.File = NewFile;
                return true;
            }
            else
            {
                return false;
            }
        }
        internal cFile GetFile()
        {
            if (!Metadata.Flags.Directory)
            {
                return this.File;
            }
            else
            {
                return null;
            }
        }

        internal bool IsDirectory()
        {
            return Metadata.Flags.Directory;
        }
        internal bool IsFileEmpty()
        {
            if (!IsDirectory())
            {
                return File.IsEmpty();
            }
            else
                return true;
        }
        internal bool IsValid()
        {
            if (!IsDirectory() && IsFileEmpty())
            {
                return false;
            }
            //other validation questions...

            return true;
        }

        #region Get Item From Index
        internal cFileSystemItem GetItemFromIndex(int Index)
        {
            if (IsDirectory() && (Index - 1 < this.Items.Count))
            {
                if (Index == 0)
                {
                    cFileFlags Flags = new cFileFlags();
                    Flags.ReadOnly = true;
                    Flags.Directory = true;
                    return new cFileSystemItem("..", "", Flags, false);
                }
                else
                {
                    return Items[Index - 1];
                }
            }
            else
            {
                return new cFileSystemItem("", "", new cFileFlags(), false);
            }
        }
        #endregion
        #endregion

        #region Clone
        internal cFileSystemItem Clone()
        {
            cFileSystemItem Clon = new cFileSystemItem(Metadata.Name, Metadata.Extention, Metadata.Flags, IsRoot);
            Clon.Metadata = this.Metadata.Clone();
            foreach (cFileSystemItem Item in this.Items)
                Clon.Items.Add(Item.Clone());
            Clon.File = this.File.Clone();
            return Clon;
        }
        #endregion

        #region ToString
        public override string ToString()
        {
            return Metadata.ToString();
        }
        #endregion


        internal cFileSystemItem ChangeDirectory(int Index)
        {
            if (Index == 0)
            {
                throw new SupDirectorySelected();
            }
            else if (!Items[Index - 1].IsDirectory() || (Index-1 >= Items.Count))
            {
                throw new NotADirectory();
            }
            else
            {
                return Items[Index - 1];
            }
        }

        internal int GetNumOfItems()
        {
            if (IsDirectory())
            {
                return Items.Count + 1;
            }
            else
            {
                return 0;
            }
        }

        internal ushort ConvertToBinary(cFAT FAT, ushort SupSector)
        {
            ushort FirstSector;
            if (IsDirectory())
            {
                ushort[] BinDataTemp = new ushort[(this.Items.Count +1)*Metadata.GetBinaryEntrySize()];
                ushort[] Temp;
                int TempIndex = 0;
                FirstSector = FAT.RegisterSectors(this.GetSizeInSectors(FAT.GetSectorSize(), false));
                cFileFlags Flags = new cFileFlags();
                Flags.ReadOnly = true;
                Flags.Directory = true;
                cFileSystemItem DirUp = new cFileSystemItem("..", "", Flags, false);
                Temp = DirUp.Metadata.GetDirectoryBinData(SupSector, 0);
                for (int i = 0; i < Temp.Length; i++)
                {
                    BinDataTemp[TempIndex] = Temp[i];
                    TempIndex++;
                }
                foreach (cFileSystemItem Item in this.Items)
                {
                    Temp = Item.Metadata.GetDirectoryBinData(Item.ConvertToBinary(FAT, FirstSector), Item.GetSizeInWordsForDirEntry());
                    for (int i = 0; i < Temp.Length; i++)
                    {
                        BinDataTemp[TempIndex] = Temp[i];
                        TempIndex++;
                    }
                }
                FAT.WriteData(BinDataTemp, FirstSector);
            }
            else
            {
                FirstSector = FAT.RegisterSectors(this.GetSizeInSectors(FAT.GetSectorSize(), false));
                FAT.WriteData(this.File.GetData(), FirstSector);
            }
            return FirstSector;
        }
        internal uint GetSizeInWordsForDirEntry()
        {
            if (IsDirectory())
            {
                return 0;       //Directory have always the binary size of 0
            }
            else
            {
                return (uint)File.GetSizeInWords();
            }
        }
    }
}
