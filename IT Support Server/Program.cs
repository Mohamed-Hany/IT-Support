﻿using CustomAlertBoxDemo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Tracking_System
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            Application.Run(new login());
            //Application.Run(new Server_Form());
        }
    }
}
