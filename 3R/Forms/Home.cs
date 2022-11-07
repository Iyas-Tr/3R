using System;
using System.Windows.Forms;

namespace WindowsFormsApp1.Forms
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Garage garage = new Garage();
            garage.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Rent_Car rent_Car = new Rent_Car();
            //rent_Car.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Return_Car return_Car = new Return_Car();
            //return_Car.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //View_Cars view_Cars = new View_Cars();
            //view_Cars.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Add_Members add_Members = new Add_Members();
            add_Members.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            View_Members view_Members = new View_Members();
            view_Members.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add_Cars add_Cars = new Add_Cars();
            add_Cars.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }
    }
}
