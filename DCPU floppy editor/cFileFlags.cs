using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DCPU_floppy_editor
{
	internal class cFileFlags
	{
		//Flags
		internal bool ReadOnly;
		internal bool Hidden;
		internal bool SystemFile;
		//Bit 3 is reserved
		internal bool Directory;
		internal bool Archive;
		internal bool Executable;
		//bit 7 in reserved

		internal cFileFlags()
		{
			ReadOnly = false;
			Hidden = false;
			SystemFile = false;
			Directory = false;
			Archive = false;
			Executable = false;
		}

		internal byte GetFlagByte()
		{
			byte Result = 0x0;
			if (ReadOnly)
				Result |= 0x1;
			if (Hidden)
				Result |= 0x2;
			if (SystemFile)
				Result |= 0x4;
			if (Directory)
				Result |= 0x10;
			if (Archive)
				Result |= 0x20;
			if (Executable)
				Result |= 0x40;
			return Result;
		}

		internal cFileFlags Clone()
		{
			cFileFlags Clone = new cFileFlags();
			Clone.Archive = this.Archive;
			Clone.Directory = this.Directory;
			Clone.Executable = this.Executable;
			Clone.Hidden = this.Hidden;
			Clone.ReadOnly = this.ReadOnly;
			Clone.SystemFile = this.SystemFile;
			return Clone;
		}
        public override string ToString()
        {
            string Result = "";
            if (Archive)
                Result += "A";
            else
                Result += " ";
            if (Directory)
                Result += "D";
            else
                Result += " ";
            if (Executable)
                Result += "X";
            else
                Result += " ";
            if (Hidden)
                Result += "h";
            else
                Result += " ";
            if (ReadOnly)
                Result += "R";
            else
                Result += " ";
            return Result;
        }
	}
}
