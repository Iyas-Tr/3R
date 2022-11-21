using System;
using System.Windows.Forms;
using WindowsFormsApp1.Forms;//

namespace WindowsFormsApp1
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
            //Application.Run(new View_Cars());
            //Application.Run(new Add_Cars());
            //Application.Run(new Add_Members()); 
            //Application.Run(new View_Members());
            //Application.Run(new Rent_Car());
            //Application.Run(new Return_Car());
            //Application.Run(new Garage());
            //Application.Run(new Home());
           
        }
    }
}
