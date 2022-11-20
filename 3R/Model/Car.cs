using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3R
{
    class CarModel : MyModel
    {
        private int id;
        private string brand;
        private string model;
        private string transmision;
        private int price;
        private int max_Passenger;
        private int quantity;
        private int available_Quantity;

        public int Id { get { return id; } }
        public string Brand { get { return brand; } }
        public string Model { get { return model; } }
        public string Transmision { get { return transmision; } }
        public int Price { get { return price; } }
        public int Max_Passenger { get { return max_Passenger; } }
        public int Quantity { get { return quantity; } }
        public int Available_Quantity { get { return available_Quantity; } }

        public CarModel(string brand, string model, string transmision, string max_Passenger, string price, string quantity, string available_Quantity)
        {
            this.brand = brand;
            this.model = model;
            this.transmision = transmision;
            this.price = Convert.ToInt32(price);
            this.max_Passenger = Convert.ToInt32(max_Passenger);
            this.quantity = Convert.ToInt32(quantity);
            this.available_Quantity = Convert.ToInt32(available_Quantity);
        }
        public CarModel(int id, string brand, string model, string transmision, string max_Passenger, string price, string quantity)
        {
            this.id = id;
            this.brand = brand;
            this.model = model;
            this.transmision = transmision;
            this.price = Convert.ToInt32(price);
            this.max_Passenger = Convert.ToInt32(max_Passenger);
            this.quantity = Convert.ToInt32(quantity);
        }
        public CarModel()
        {

        }


        public override void push()
        {
            con.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(" INSERT INTO \"Cars_Info\" (\"Brand\", \"Model\", \"Transmision\", \"Max_Passenger\", \"Price\", \"Quantity\", \"Available_Quantity\") VALUES ('" + brand + "', '" + model + "', '" + transmision + "', '" + max_Passenger + "', '" + price + "', '" + quantity + "', '" + available_Quantity + "') ", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public override void pullById(int id)
        {
            con.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("select * from \"Cars_Info\" where \"ID\"=" + id + "", con);
            cmd.ExecuteNonQuery();
            con.Close();
            DataTable dataTable = new DataTable();
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(cmd);
            dataAdapter.Fill(dataTable);

            foreach (DataRow dataRow in dataTable.Rows)
            {
                this.id = Convert.ToInt32(dataRow["ID"]);
                brand = dataRow["Brand"].ToString();
                model = dataRow["Model"].ToString();
                transmision = dataRow["Transmision"].ToString();
                max_Passenger = Convert.ToInt32(dataRow["Max_Passenger"].ToString());
                price = Convert.ToInt32(dataRow["Price"].ToString());
                quantity = Convert.ToInt32(dataRow["Quantity"].ToString());
            }
            con.Close();
        }

        public void pullByBMT(string brand, string model, string transmision)
        {
            con.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("select * from \"Cars_Info\" where \"Brand\"='" + brand + "' AND \"Model\"='" + model + "' AND \"Transmision\"='" + transmision + "'  ", con);
            cmd.ExecuteNonQuery();
            con.Close();
            DataTable dataTable = new DataTable();
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(cmd);
            dataAdapter.Fill(dataTable);

            foreach (DataRow dataRow in dataTable.Rows)
            {
                id = Convert.ToInt32(dataRow["ID"]);
                brand = dataRow["Brand"].ToString();
                model = dataRow["Model"].ToString();
                transmision = dataRow["Transmision"].ToString();
                max_Passenger = Convert.ToInt32(dataRow["Max_Passenger"].ToString());
                price = Convert.ToInt32(dataRow["Price"].ToString());
                quantity = Convert.ToInt32(dataRow["Quantity"].ToString());
                available_Quantity = Convert.ToInt32(dataRow["available_Quantity"].ToString());
            }
        }

        public DataTable getDataTable()
        {
            con.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("select \"ID\", \"Brand\", \"Model\", \"Transmision\", \"Max_Passenger\", \"Price\", \"Quantity\", \"Available_Quantity\" from \"Cars_Info\"", con);
            cmd.ExecuteNonQuery();
            con.Close();
            DataTable dataTable = new DataTable();
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(cmd);
            dataAdapter.Fill(dataTable);
            return dataTable;
        }

        public DataTable searchNameOrBrand(string brand, string model)//////////////////
        {
            con.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("select * from \"Cars_Info\" where \"Brand\" like('%" + brand + "%') or \"Model\" like('%" + model + "%') ", con);
            cmd.ExecuteNonQuery();
            con.Close();
            DataTable dataTable = new DataTable();
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(cmd);
            dataAdapter.Fill(dataTable);

            return dataTable;
        }

        public override void update()
        {
            con.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("update \"Cars_Info\" set \"Brand\"='" + brand + "', \"Model\"='" + model + "', \"Transmision\"='" + transmision + "', \"Max_Passenger\"='" + max_Passenger + "', \"Price\'='" + price + "', \"Quantity\"='" + quantity + "' where \"ID\"=" + id + "    ", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public override void deleteById(int id)
        {
            con.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("delete from \"Cars_Info\"  where \"ID\"=" + id + " ", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void decrementAvailableQty(int id)
        {
            con.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("update \"Cars_Info\" set \"Available_Quantity\"=\"Available_Quantity\"-1 where \"ID\"=" + id + " ", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void incrementAvailableQty(int id)
        {
            con.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("update \"Cars_Info\" set \"Available_Quantity\"=\"Available_Quantity\"+1 where \"ID\"=" + id + " ", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}