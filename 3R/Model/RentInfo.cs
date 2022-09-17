using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3R
{
    class RentCarModel : MyModel
    {
        private int id;
        private int member_Id;
        private int car_Id;
        private string rent_Date;
        private string return_Date;
        private string total_Price;
        private bool is_Returned;


        public string Rent_Date { get => rent_Date; }
        public string Return_Date { get => return_Date; }
        public string Total_Price { get => total_Price; }



        public RentCarModel(int member_Id, int car_Id, string rent_Date, string return_Date, string total_Price, bool is_Returned)
        {
            this.member_Id = member_Id;
            this.car_Id = car_Id;
            this.rent_Date = rent_Date;
            this.return_Date = return_Date;
            this.total_Price = total_Price;
            this.is_Returned = is_Returned;
        }
        public override void push()
        {

        }
        public override void pullById(int id)
        {

        }
        public override void update()
        { }
    }
}
