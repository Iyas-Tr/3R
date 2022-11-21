using System;
using System.Collections.Specialized;
using System.Data;
using System.Net;
using System.Windows.Forms;
using WindowsFormsApp1.Models;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using System.Drawing;

namespace WindowsFormsApp1
{
    public partial class Garage : Form
    {        
        public Garage()
        {
            InitializeComponent();
        }

        private void Garage_Load(object sender, EventArgs e)
        {
            fillGrid();
        }

        public void fillGrid()
        {
            CarModel carModel = new CarModel();
            dataGridView1.DataSource =  carModel.getDataTable();

            foreach (DataGridViewRow row in dataGridView1.Rows)
                if (Convert.ToInt32(row.Cells[6].Value) > Convert.ToInt32(row.Cells[7].Value))
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.Green;
                }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            RentCarModel rentCarModel = new RentCarModel();
            DataTable dataTable = rentCarModel.getNotReturndedByCarId(i);
            dataGridView2.DataSource = dataTable;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CarModel carModel = new CarModel();
            DataTable dataTable = carModel.searchNameOrBrand(textBox1.Text, textBox1.Text);
            dataGridView1.DataSource = dataTable; 
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = Convert.ToInt32(dataGridView2.SelectedCells[1].Value.ToString());
            MemberModel memberModel = new MemberModel();
            memberModel.pullById(i);
            textBox2.Text = memberModel.Contact;
            label7.Text = memberModel.Name;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            //smtp.EnableSsl = true;
            //smtp.UseDefaultCredentials = false;
            ////(username, password)
            //smtp.Credentials = new NetworkCredential("xxx@gmail.com", "xxx");
            ////(from, to, subject, body)
            //MailMessage mail = new MailMessage("xxx@gmail.com", textBox2.Text, "Rent-A-Car Notification", textBox3.Text);
            //mail.Priority = MailPriority.High;
            //smtp.Send(mail);
            //MessageBox.Show("Mail Has Been Sent");
            try
            {
                string accountSid = Environment.GetEnvironmentVariable("TwilioSID");
                string authToken = Environment.GetEnvironmentVariable("TwilioAuth");

                TwilioClient.Init(accountSid, authToken);

                var message = MessageResource.Create(
                    body: textBox3.Text,
                    from: new Twilio.Types.PhoneNumber("+15597853327"),
                    to: new Twilio.Types.PhoneNumber(textBox2.Text)
                );

                MessageBox.Show(message.Sid);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                //throw;
            }



        }
    }
}
