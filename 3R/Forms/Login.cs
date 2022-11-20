using _3R;
using System;
using System.Data;
using System.Windows.Forms;
using WindowsFormsApp1.Forms;
using WindowsFormsApp1.Models;


namespace WindowsFormsApp1
{
    public partial class Login : Form
    {       
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count = 0;
            LoginModel loginModel = new LoginModel(textBox1.Text, textBox2.Text);            
            DataTable dataTable = loginModel.getInfo();            
            count = Convert.ToInt32( dataTable.Rows.Count.ToString());

           if (dataTable.Rows.Count == 0)
           {
              Console.WriteLine(count);
              MessageBox.Show("username/password doesnt match");
           }
           else
           {
                this.Hide();
                Home home = new Home();
                home.Show();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
