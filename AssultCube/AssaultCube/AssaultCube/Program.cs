using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace AssaultCube
{
    class Program
    {
        static string process = "ac_client";
        static int playerBase = 0x00509B74;
        static int healthOffset = 0xF8;
        static int ammoOffset = 0x150;
        static bool isRunning = false;
        static Process[] pName = Process.GetProcessesByName(process);


        //[DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true)]
        //public static extern int GetAsyncKeyState(int vKey);
        //Add on/off-switch with this

        static void Main(string[] args)
        {
            VAMemory vam = new VAMemory(process);
            //Addresses to the ammo and health
            int LocalPlayer = vam.ReadInt32((IntPtr) playerBase);
            int ammoAddress = LocalPlayer + ammoOffset;
            int healthAddress = LocalPlayer + healthOffset;


            while(true)
            { 
                    vam.WriteInt32((IntPtr)ammoAddress, 1000);
                    vam.WriteInt32((IntPtr)healthAddress, 250);
            }
        }
    }
}
