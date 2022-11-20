using System;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;
using Npgsql;
using System;
using _3R;

namespace WindowsFormsApp1
{
    public partial class Rent_Car : Form
    {
        //OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\RentCar.accdb");
        protected static readonly NpgsqlConnection con = new NpgsqlConnection("Server=localhost;Port=5432;Database=3R;User Id=postgres;Password=postgres");

        public Rent_Car()
        {
            InitializeComponent();
            dateTimePicker1.MinDate = DateTime.Today;
            dateTimePicker2.MinDate = DateTime.Today;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;

            MemberModel memberModel = new MemberModel();
            i = memberModel.searchByName(Name1.Text);
            
            if (i == 0)
            {
                MessageBox.Show("Can't Find This Name");
            }
            else
            {
                Name2.Text = memberModel.Name;
                Email.Text = memberModel.Email;
                Contact.Text = memberModel.Contact;
            }
        }

        private void Rent_Car_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)           
                con.Close();          
            con.Open();
        }

        private void Brand_KeyUp(object sender, KeyEventArgs e)
        {
            int count = 0;
            if (e.KeyCode != Keys.Enter)
            {
                listBox1.Items.Clear();

                NpgsqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select distinct \"Brand\"  from \"Cars_Info\" where \"Brand\" like('%" + Brand.Text + "%')";
                cmd.ExecuteNonQuery();

                DataTable dataTable = new DataTable();
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(cmd);
                dataAdapter.Fill(dataTable);
                count = Convert.ToInt32(dataTable.Rows.Count.ToString());

                if(count > 0)
                {
                    listBox1.Visible = true;
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        listBox1.Items.Add(dataRow["Brand"].ToString());
                    }
                }
            }
        }

        private void Brand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                listBox1.Focus();
                listBox1.SelectedIndex = 0;
            }
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Brand.Text = listBox1.SelectedItem.ToString();
                listBox1.Visible = false; 
            }
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Brand.Text = listBox1.SelectedItem.ToString();
            listBox1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e) //rent button
        {
            int car_availableQty = 0;
            int car_ID = 0; 
            int member_ID = 0;
            CarModel carModel = new CarModel();
            MemberModel memberModel = new MemberModel();
                        
            carModel.pullByBMT(Brand.Text, Model.Text, Transmision.Text);
            car_availableQty = carModel.Available_Quantity;
            car_ID = carModel.Id;

            memberModel.pullByNEC(Name2.Text, Email.Text, Contact.Text);
            member_ID = memberModel.Id;



            if (car_availableQty > 0)
            {
                RentCarModel rentCarModel = new RentCarModel(member_ID, car_ID, dateTimePicker1.Value.ToString(), dateTimePicker2.Value.ToString(), Label_Total_Price.Text, false);
                rentCarModel.push();
                carModel.decrementAvailableQty(carModel.Id);
                MessageBox.Show("Data Added Successfully");
            }
            else
            {
                MessageBox.Show("Car Are Not Available for Now");
            }

            Name1.Text = "";
            Name2.Text = "";
            Contact.Text = "";
            Email.Text = "";
            Brand.Text = "";
            Model.Text = "";
            Transmision.Text = "";
            Label_Total_Price.Text = "";
            Label_PricePerDay.Text = "";
        }


        private void Model_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                listBox2.Focus();
                listBox2.SelectedIndex = 0;
            }
        }

        private void listBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Model.Text = listBox2.SelectedItem.ToString();
                listBox2.Visible = false;
            }
        }

        private void listBox2_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                Model.Text = listBox2.SelectedItem.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Harap Pilih Salah Satu Item");
                throw;
            }
            
            listBox2.Visible = false;
        }


        private void Model_KeyUp(object sender, KeyEventArgs e)
        {
            int count = 0;
            if (e.KeyCode != Keys.Enter)
            {
                listBox2.Items.Clear();
                NpgsqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select distinct \"Model\" from \"Cars_Info\" where \"Brand\"=('" + Brand.Text + "') AND \"Model\" like ('%"+ Model.Text +"%') ";
                cmd.ExecuteNonQuery();
                DataTable dataTable = new DataTable();
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(cmd);
                dataAdapter.Fill(dataTable);
                count = Convert.ToInt32(dataTable.Rows.Count.ToString());

                if (count > 0)
                {
                    listBox2.Visible = true;
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        listBox2.Items.Add(dataRow["Model"].ToString());
                    }
                }

            }
        }

        private void Transmision_KeyUp(object sender, KeyEventArgs e)
        {
            int count = 0;
            if (e.KeyCode != Keys.Enter)
            {
                listBox3.Items.Clear();

                NpgsqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select distinct \"Transmision\" from \"Cars_Info\" where \"Model\"=('" + Model.Text + "') AND \"Transmision\" like ('%"+ Transmision.Text +"%') ";
                cmd.ExecuteNonQuery();
                DataTable dataTable = new DataTable();
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(cmd);
                dataAdapter.Fill(dataTable);
                count = Convert.ToInt32(dataTable.Rows.Count.ToString());

                if (count > 0)
                {
                    listBox3.Visible = true;
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        listBox3.Items.Add(dataRow["Transmision"].ToString());
                    }
                }
            }
        }

        private void Transmision_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                listBox3.Focus();
                listBox3.SelectedIndex = 0;
            }
        }

        private void listBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Transmision.Text = listBox3.SelectedItem.ToString();
                listBox3.Visible = false;
            }
        }

        private void listBox3_MouseClick(object sender, MouseEventArgs e)
        {
            Transmision.Text = listBox3.SelectedItem.ToString();
            listBox3.Visible = false;          
        }


        private void button3_Click(object sender, EventArgs e)//calcuate price
        {
            CarModel carModel = new CarModel();
            //DataTable dataTable = carModel.getPrice();///
            carModel.pullByBMT(Brand.Text, Model.Text, Transmision.Text);

            DateTime date1 = dateTimePicker1.Value;
            DateTime date2 = dateTimePicker2.Value;
            TimeSpan timeSpan = date2 - date1;

            Label_PricePerDay.Text = carModel.Price.ToString();
            double totalPrice = Math.Ceiling(timeSpan.TotalDays) * Convert.ToInt32(carModel.Price);
            Label_Total_Price.Text = totalPrice.ToString();

            //Label_Total_Price.Text = CalculatePrice(Math.Ceiling(timeSpan.TotalDays), (carModel.Price)).ToString();
        }

        public double CalculatePrice(double a, double b)
        {
            double c = a * b;
            return c;
            throw new NotImplementedException();
        }


    }
}
