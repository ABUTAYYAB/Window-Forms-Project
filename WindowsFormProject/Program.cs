using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DairyDelightsLibrary.BL;
using DairyDelightsLibrary.Interface;
using DairyDelightsLibrary.DL.DataBase;
//using DairyDelightsLibrary.DL.FileHandling;

using DairyDelightsLibrary.Validation;
using WindowsFormProject.UI.CustomerUI;

namespace WindowsFormProject
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new UI.SignUP());
        }
        


    }
}
