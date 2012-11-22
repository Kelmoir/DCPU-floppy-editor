using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DCPU_floppy_editor
{
	internal class cDcpuTime
	{
		//TODO: replace once there in an time definitionfor the DCPU (and an starting time)
		internal uint ConvertToDcpuTime(DateTime RlTime)
		{
			return 0;
		}

		internal DateTime ConvertToRlTime(uint DcpuTime)
		{
			return DateTime.Now;
		}
	}
}
