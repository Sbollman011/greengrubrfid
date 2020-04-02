using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace UHFAPP
{
    static class Program
    {
        /// <summary>
        /// 
        /// </summary>
        [STAThread]
        static void Main()
        {


            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
            catch (Exception ex) { 
            
            }
        }


       
    }
}
