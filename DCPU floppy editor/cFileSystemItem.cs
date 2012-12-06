using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DCPU_floppy_editor
{
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
        internal int GetSizeInSectors(int SectorSize)
        {
            int result = 0;
            if (Metadata.Flags.Directory)
            {
                foreach (cFileSystemItem Element in Items)
                    result += Element.GetSizeInSectors(SectorSize);
                result += 0x10;     //the ".." entry
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
        internal bool DeleteItem(cFileSystemItem ItemToDelete)
        {
            if (Metadata.Flags.Directory)
            {
                return Items.Remove(ItemToDelete);
            }
            else
            {
                return false;
            }
        }
        internal List<string> GetCopyOfItemList()
        {
            if (Metadata.Flags.Directory)
            {
                List<string> ResultList = new List<string>();
                if (!IsRoot)
                {
                    cFileFlags Flags = new cFileFlags();
                    Flags.ReadOnly = true;
                    Flags.Directory = true;
                    cFileSystemItem Temp = new cFileSystemItem("..", "", Flags, false);
                    ResultList.Add(Temp.ToString());
                }
                foreach (cFileSystemItem Item in Items)
                    ResultList.Add(this.ToString());
                return ResultList;
            }
            else
            {
                return null;
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

        internal string GetName()
        {
            return Metadata.Name;
        }

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

        public override string ToString()
        {
            string Result = Metadata.Name;
            if (!Metadata.Flags.Directory)
            {
                Result += "." + Metadata.Extention;
            }
            while (Result.Length < 15)
                Result += " ";
            Result += Metadata.Flags.ToString();
            return Result;
        }
    }
}
