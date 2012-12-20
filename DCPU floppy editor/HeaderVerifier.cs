using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DCPU_floppy_editor
{
    static class HeaderVerifier
    {
        static public bool VerifyFHAT16BootSector(cSector Bootloader, ushort KernelSectorSize, ushort FloppyLength, bool IsBootable)
        {
            if (IsBootable && Bootloader.Memory[0] != 0xC382)      //is the Bootable Flag correct?
            {
                MessageBox.Show("Incorrect Bootflag");
                return false;
            }
            else if (!IsBootable && Bootloader.Memory[0] != 0x0000)
            {
                MessageBox.Show("Incorrect Bootflag");
                return false;
            }
            //now some checks for consistency to the HA FAT
            if (Bootloader.Memory[8] != KernelSectorSize)
            {
                if (MessageBox.Show("Wrong amount of reserved sectors detected.\r\nCorrect them?", "FAT Inconsistency", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Bootloader.Memory[8] = KernelSectorSize;
                }
                else
                {
                    return false;
                }
            }
            if (FloppyLength != Bootloader.Memory[0xb])
            {
                if (MessageBox.Show("Wron amount of sectors specified fot the loaded Device.\r\nCorrect them?", "Device size inconsitency", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Bootloader.Memory[0xb] = FloppyLength;
                }
                else
                {
                    return false;
                }
            }
            //and whatever more can go wrong...
            return true;
        }

        internal static bool IsValidDirectoryEntry(cSector Sector, int SubIndex, ushort SectorIndex, cFAT FAT)
        {
            if (SubIndex > Sector.Memory.Length)
                return false;
            for (int i = 0; i < 6; i++)
            {
                if (Sector.Memory[SubIndex] == 0x0000)      //Name
                    return false;
            }
            uint TempSize = (uint)(Sector.Memory[SubIndex + 0xC] + (Sector.Memory[SubIndex + 0xD] << 16));
            if ((TempSize == 0) && ((Sector.Memory[SubIndex + 0x5] & 0x0010) == 0))
                return false;
            if (FAT.NextSector(SectorIndex) == 0x0000)
                return false;

            return true;
        }
    }
}
