using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DCPU_floppy_editor
{
	class cDirectoryEntry
	{
		internal string Name;
		internal string Extention;
		internal cFileFlags Flags;
		internal uint CreateDateTime;
		internal uint AccessDateTime;
		internal uint ModifyDateTime;
		//one ushort reserved, according to spec
		internal ushort Reserved;

        private bool Driver;
        internal uint ManID;
        internal uint DevID;

		#region Constructor
		internal cDirectoryEntry(string NewName, string NewExtention, cFileFlags NewFlags)
		{
			cDcpuTime Timer = new cDcpuTime();
			//the name/extention strings can be too long - cut them silently, if neccessary or expant them, we want 8 characters long names
            SetName(NewName);
			//and 3 characters long Extensions
            SetExtension(NewExtention);
			this.Flags = NewFlags;
			CreateDateTime = Timer.ConvertToDcpuTime(DateTime.Now);
			AccessDateTime = Timer.ConvertToDcpuTime(DateTime.Now);
			ModifyDateTime = Timer.ConvertToDcpuTime(DateTime.Now);
			Reserved = 0;											//handling the data, so we hopefully just need to adapt later...
		}
		#endregion

		#region Get Binary Data (for the FAT)
		/// <summary>
		/// returns the binary data according to the FAT spec
		/// </summary>
        /// <param name="FirstSector">The first physical sector of the Stuff the entry is pointing to</param>
        /// <param name="Size">The fresh calculated size of the Physical representation</param>
		/// <returns>16 ushourts of DTE</returns>
		internal ushort[] GetDirectoryBinData(ushort FirstSector, uint Size)
		{
			ushort[] Result = new ushort[16];
			ushort[] Temp;
			Temp = cFileSigConverter.ConvertToFileNameSig(Name);
			Result[0] = Temp[0];
			Result[1] = Temp[1];
			Result[2] = Temp[2];
			Result[3] = Temp[3];
            Temp = cFileSigConverter.ConvertToExtentionSig(Extention);
			Result[4] = Temp[0];
			Result[5] = Temp[1];
			Result[5] |= (ushort)Flags.GetFlagByte();
			Result[6] = (ushort)(CreateDateTime >> 16);
			Result[7] = (ushort)CreateDateTime;
			Result[8] = (ushort)(AccessDateTime >> 16);
			Result[9] = (ushort)AccessDateTime;
			Result[10] = (ushort)(ModifyDateTime >> 16);
			Result[11] = (ushort)ModifyDateTime;
			Result[12] = (ushort)(Size >> 16);
			Result[13] = (ushort)Size;
			Result[14] = FirstSector;
			Result[15] = Reserved;
			return Result;
		}
		#endregion

        internal int GetBinaryEntrySize()
        {
            return 16;
        }

        internal void SetManIdAndDevId(uint ManID, uint DevID)
        {
            if (Driver)
            {
                this.ManID = ManID;
                this.DevID = DevID;
            }
        }

        internal void SetName(string NewName)
        {
            if (!Driver)
            {
                if (NewName.Length > 8)
                    NewName = NewName.Substring(0, 8);
                while (NewName.Length < 8)
                    NewName += " ";
                Name = NewName;
            }
        }
        internal void SetExtension(string NewExtention)
        {
            if (NewExtention.Length > 3)
                NewExtention = NewExtention.Substring(0, 3);
            while (NewExtention.Length < 3)
                NewExtention += " ";
            Extention = NewExtention;
        }

		internal cDirectoryEntry Clone()
		{
			cDirectoryEntry Clone = new cDirectoryEntry(Name, Extention, Flags);
			Clone.CreateDateTime = this.CreateDateTime;
			Clone.AccessDateTime = this.AccessDateTime;
			Clone.ModifyDateTime = this.ModifyDateTime;
			Clone.Reserved = this.Reserved;
			return Clone;
		}

        public override string ToString()
        {
            string Result;
            if (!Driver)
            {
                Result = Name;
                if (!Flags.Directory)
                {
                    Result += "." + Extention;
                }
            }
            else
            {
                Result = cHexInterface.ConvertToString(ManID);
                Result += "." + Extention;
            }
            while (Result.Length < 15)
                Result += " ";
            Result += Flags.ToString();
            return Result;
        }
        internal string GetName()
        {
            if (Driver)
            {
                return "";
            }
            else
            {
                return Name;
            }
        }
        internal string GetExtention()
        {
            return Extention;
        }
        internal string GetFlagsString()
        {
            return Flags.ToString();
        }
        internal string GetManIDstring()
        {
            if (Driver)
            {
                return cHexInterface.ConvertToString(ManID);
            }
            else
            {
                return "";
            }
        }
        internal string GetDevIDstring()
        {
            if (Driver)
            {
                return cHexInterface.ConvertToString(DevID);
            }
            else
            {
                return "";
            }
        }
        internal void MakeDriver()
        {
            Driver = true;
        }
    }
}
