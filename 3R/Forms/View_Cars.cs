using System;
using System.Data;
using System.Windows.Forms;

using WindowsFormsApp1.Models;

namespace WindowsFormsApp1
{
   
    public partial class View_Cars : Form
    {
       

        public View_Cars()
        {
            InitializeComponent();
        }

        private void View_Cars_Load(object sender, EventArgs e)
        {
            displayCars();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            try
            {
                CarModel carModel = new CarModel();                
                DataTable dataTable = carModel.searchNameOrBrand(textBox1.Text, textBox1.Text);              
                

                i = Convert.ToInt32(dataTable.Rows.Count.ToString());
                dataGridView1.DataSource = dataTable;          

                if ( i == 0)
                    MessageBox.Show("Not Found");                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }


        }
        private void button2_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            try
            {
                CarModel carModel = new CarModel(i, Brand.Text, Model.Text, Transmision.Text, Max_Passenger.Text, Price.Text, Quantity.Text);
                carModel.update();
                displayCars();
                MessageBox.Show("Record Updated");
                panel2.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            panel2.Visible = true; 
            int i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            try
            {
                CarModel carModel = new CarModel();
                carModel.pullById(i);

                Brand.Text = carModel.Brand;
                Model.Text = carModel.Model;
                Transmision.Text = carModel.Transmision;
                Max_Passenger.Text = carModel.Max_Passenger.ToString();
                Price.Text = carModel.Price.ToString();
                Quantity.Text = carModel.Quantity.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        public void displayCars()
        {
            try
            {
                CarModel carModel = new CarModel();
                DataTable dataTable = carModel.getDataTable();
                dataGridView1.DataSource = dataTable;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            try
            {
                CarModel carModel = new CarModel();
                carModel.deleteById(i);
                displayCars();
                MessageBox.Show("Record Updated");
                panel2.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
    }
}
