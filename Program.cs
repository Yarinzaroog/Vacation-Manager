using MyVacationManager.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyVacationManager
{
    internal static class Program
    {
        // (יצירת רשימה מקושרת סטטית (כדי שתחייה לאורך כל התכנית
        public static  RentalPropetyCollection rentalPropetyCollection = new RentalPropetyCollection(); 

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
