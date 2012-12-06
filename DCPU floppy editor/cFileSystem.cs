using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DCPU_floppy_editor
{
    internal class cFileSystem
    {
        private cFileSystemItem WorkingDirectory;
        private List<cFileSystemItem> PathToWorkingDirectory;
        internal cFileSystemItem RootDirectory;
        internal cFAT FAT;

        internal cFileSystem(DiskType ModeOfDisk, cFloppy FloppyToUse)
        {
            FAT = new cFAT(ModeOfDisk, FloppyToUse);
            cFileFlags RootDirFlags = new cFileFlags();
            RootDirFlags.Directory = true;
            RootDirectory = new cFileSystemItem("", "", RootDirFlags, true);
            WorkingDirectory = RootDirectory;
            PathToWorkingDirectory = new List<cFileSystemItem>();
            PathToWorkingDirectory.Add(RootDirectory);
        }

        internal void CreateNewDirectory(string Name)
        {
            cFileFlags Flags = new cFileFlags();
            Flags.Directory = true;
            WorkingDirectory.AddItem(new cFileSystemItem(Name, "", Flags, false));
        }

        internal cFileSystemItem GetWorkingDirektory()
        {
            return WorkingDirectory;
        }
        internal string GetPathToWorkingDirectoryString()
        {
            string Result = "";
            foreach (cFileSystemItem Element in PathToWorkingDirectory)
            {
                Result += Element.GetName().Trim() + "\\";
            }
            return Result;
        }

        internal List<string> GetListOfEntrysInWorkingDirectory()
        {
            return WorkingDirectory.GetCopyOfItemList();
        }
        internal bool RemoveDirTableEntry(cFileSystemItem ItemToRemove)
        {
            return WorkingDirectory.DeleteItem(ItemToRemove);
        }



    }
}
