using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3R
{
     class MyModel
    {
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
