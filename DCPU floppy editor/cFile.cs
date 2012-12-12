using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DCPU_floppy_editor
{
    class cFile
    {
        ushort[] Data;

        internal cFile()
        {
        }

        internal int GetSizeInSectors(int SectorSize)
        {
            int Size = 0;
            if (Data != null)
            {
                Size = Data.Length / SectorSize;
                if (Data.Length % SectorSize != 0)
                    Size++;
            }
            return Size;
        }
        internal bool SetFileData(List<ushort> NewData)
        {
            Data = new ushort[NewData.Count];
            for (int i = 0; i < NewData.Count; i++)
                Data[i] = NewData[i];
            return true;
        }

        internal cFile Clone()
        {
            throw new NotImplementedException();
        }

        internal bool IsEmpty()
        {
            return (Data == null);
        }
    }
}
