using System;
using System.Data;
using System.Windows.Forms;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1
{
    public partial class Return_Car : Form
    {

        private MemberModel memberModel;
        private CarModel carModel;
        private RentCarModel rentCarModel;
        private int i;


        public Return_Car()
        {
            InitializeComponent();
            memberModel = new MemberModel();
            carModel = new CarModel();
            rentCarModel = new RentCarModel();
            dateTimePicker1.MinDate = DateTime.Today;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            fillGrid(memberModel.getIdbyName(textBox1.Text));

        }

        public void fillGrid(int Id)
        {
            DataTable dataTable = rentCarModel.getNotReturndedByMemberId(Id);
            dataGridView1.DataSource = dataTable;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            panel3.Visible = true;
            i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            
            carModel.pullById(i);
            rentCarModel.pullById(i);
            Label_Model.Text = carModel.Model.ToString();
            Label_Transmision.Text = carModel.Transmision;
            Rent_Date.Text = rentCarModel.Rent_Date;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            int carId = Convert.ToInt32(dataGridView1.SelectedCells[2].Value.ToString()); 
            rentCarModel.update(i, dateTimePicker1.Value.ToString());            
            carModel.incrementAvailableQty(carId);
            MessageBox.Show("Car Returned Successfully");            
            panel3.Visible = true;
            fillGrid(memberModel.getIdbyName(textBox1.Text));
        }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            double fine = 0;
            rentCarModel.pullById(i);
            TimeSpan timeSpan1 = dateTimePicker1.Value - Convert.ToDateTime(rentCarModel.Rent_Date);
            TimeSpan timeSpan0 = Convert.ToDateTime(rentCarModel.Return_Date) - Convert.ToDateTime(rentCarModel.Rent_Date);
            if (Math.Ceiling(timeSpan1.TotalDays) > Math.Ceiling(timeSpan0.TotalDays))
            {
                label3.Visible = true;
                label3.Text = string.Concat("Car returned in ", Convert.ToString(Math.Round(timeSpan1.TotalDays-timeSpan0.TotalDays)), " days late");
                fine = Math.Round(timeSpan1.TotalDays - timeSpan0.TotalDays) * Convert.ToInt32(rentCarModel.Total_Price);
            }
            else
            {
                label3.Visible = false;
            }

            label6.Text = string.Concat(Convert.ToString(rentCarModel.Total_Price), " + ", fine.ToString());           
        }

        private void Return_Car_Load(object sender, EventArgs e)
        {

        }
    }
}
