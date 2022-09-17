using System;
using System.Collections.Generic;
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

        public override void push()
        {

        }

        public override void pullById(int id)
        {

        }
    }
}