using System.Data.OleDb;
using Npgsql;

namespace WindowsFormsApp1.Models
{
    class MyModel
    {
        //protected static readonly OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\RentCar.accdb");
        protected static readonly NpgsqlConnection con = new NpgsqlConnection("Server=localhost;Port=5432;Database=3R;User Id=postgres;Password=postgres");

        public virtual void push()
        {

        }

        public virtual void pullById(int id)
        {

        }

        public virtual void update()
        {

        }

        public virtual void deleteById(int id)
        {

        }
    }
}
