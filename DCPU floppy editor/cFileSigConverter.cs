using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DCPU_floppy_editor
{
	static internal class cFileSigConverter
	{
		static internal ushort[] ConvertToFileNameSig(string Name)
		{
			ushort[] Result = new ushort[4];
			char[] Temp = Name.ToCharArray();
			Result[0] = (ushort)(Convert.ToByte(Temp[0]) << 8 | Convert.ToByte(Temp[1]));
			Result[1] = (ushort)(Convert.ToByte(Temp[2]) << 8 | Convert.ToByte(Temp[3]));
			Result[2] = (ushort)(Convert.ToByte(Temp[4]) << 8 | Convert.ToByte(Temp[5]));
			Result[3] = (ushort)(Convert.ToByte(Temp[6]) << 8 | Convert.ToByte(Temp[7]));
			return Result;
		}
        static internal string ConvertToFileName(ushort[] Data)
        {
            try
            {
                char[] TempChar = new char[8];
                TempChar[1] = Convert.ToChar((byte)Data[0]);
                TempChar[0] = Convert.ToChar((byte)(Data[0] >> 8));
                TempChar[3] = Convert.ToChar((byte)Data[1]);
                TempChar[2] = Convert.ToChar((byte)(Data[1] >> 8));
                TempChar[5] = Convert.ToChar((byte)Data[2]);
                TempChar[4] = Convert.ToChar((byte)(Data[2] >> 8));
                TempChar[7] = Convert.ToChar((byte)Data[3]);
                TempChar[6] = Convert.ToChar((byte)(Data[3] >> 8));
                string Result = "";
                foreach (char Item in TempChar)
                    Result += Convert.ToString(Item);
                return Result;
            }
            catch
            {
                return "";
            }
        }
        static internal string ConvertToFileExtention(ushort[] Data)
        {
            try
            {
                char[] TempChar = new char[3];
                TempChar[1] = Convert.ToChar((byte)Data[0]);
                TempChar[0] = Convert.ToChar((byte)(Data[0] >> 8));
                TempChar[2] = Convert.ToChar((byte)(Data[1] >> 8));
                string Result = "";
                foreach (char Item in TempChar)
                    Result += Convert.ToString(Item);
                return Result;
            }
            catch
            {
                return "";
            }
        }

		static internal ushort[] ConvertToExtentionSig(string Extention)
		{
			ushort[] Result = new ushort[2];
			char[] Temp = Extention.ToCharArray();
			Result[0] = (ushort)(Convert.ToByte(Temp[0]) << 8 | Convert.ToByte(Temp[1]));
			Result[1] = (ushort)(Convert.ToByte(Temp[2]) << 8);
			return Result;
		}
	}
}
