using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DCPU_floppy_editor
{
	internal class cFileSigConverter
	{
		internal ushort[] ConvertToFileNameSig(string Name)
		{
			ushort[] Result = new ushort[4];
			char[] Temp = Name.ToCharArray();
			Result[0] = (ushort)(Convert.ToByte(Temp[0]) << 8 | Convert.ToByte(Temp[1]));
			Result[1] = (ushort)(Convert.ToByte(Temp[2]) << 8 | Convert.ToByte(Temp[3]));
			Result[2] = (ushort)(Convert.ToByte(Temp[4]) << 8 | Convert.ToByte(Temp[5]));
			Result[3] = (ushort)(Convert.ToByte(Temp[6]) << 8 | Convert.ToByte(Temp[7]));
			return Result;
		}

		internal ushort[] ConvertToExtentionSig(string Extention)
		{
			ushort[] Result = new ushort[2];
			char[] Temp = Extention.ToCharArray();
			Result[0] = (ushort)(Convert.ToByte(Temp[0]) << 8 | Convert.ToByte(Temp[1]));
			Result[1] = (ushort)(Convert.ToByte(Temp[2]) << 8);
			return Result;
		}
	}
}
