using System;
using System.Windows.Forms;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1.Forms
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginModel loginModel = new LoginModel(textBox1.Text, textBox2.Text, textBox3.Text);
            loginModel.update();
            MessageBox.Show("Success");
            this.Close();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            LoginModel loginModel = new LoginModel();
            loginModel.pullById(1);
            textBox1.Text = loginModel.Username;
            textBox2.Text = loginModel.Password;
            textBox3.Text = loginModel.Email;           
        }
    }
}
