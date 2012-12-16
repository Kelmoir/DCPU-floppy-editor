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

        internal void CreateNewDirectory(cFileSystemItem Item)
        {
            cFileFlags Flags = new cFileFlags();
            Flags.Directory = true;
            WorkingDirectory.AddItem(Item);
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
                Result += Element.Metadata.GetName().Trim() + "\\";
            }
            return Result;
        }

        internal List<string> GetListOfEntrysInWorkingDirectory()
        {
            return WorkingDirectory.GetItemList();
        }
        internal bool RemoveDirTableEntry(cFileSystemItem ItemToRemove)
        {
            return WorkingDirectory.DeleteItem(ItemToRemove);
        }

        internal cFileSystemItem GetItemByIndex(int Index)
        {
            return this.WorkingDirectory.GetItemFromIndex(Index);
        }



        internal void ChangeDirectory(int Index)
        {
            try
            {
                cFileSystemItem NewDir = WorkingDirectory.ChangeDirectory(Index);
                PathToWorkingDirectory.Add(NewDir);
                WorkingDirectory = NewDir;
            }
            catch (SupDirectorySelected ex)
            {
                if (PathToWorkingDirectory.Count > 1)
                {
                    WorkingDirectory = PathToWorkingDirectory[PathToWorkingDirectory.Count -2];
                    PathToWorkingDirectory.RemoveAt(PathToWorkingDirectory.Count-1);
                }
            }
            catch (NotADirectory na)
            {
            }
        }
    }
}
