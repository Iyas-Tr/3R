using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3R
{
    class LoginModel : MyModel
    {

        private string username;
        private string password;
        private string email;

        public string Username { get => username; }
        public string Password { get => password; }
        public string Email { get => email; }

        public LoginModel()
        {

        }

        public LoginModel(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public LoginModel(string username, string password, string email)
        {
            this.username = username;
            this.password = password;
            this.email = email;
        }


        public override void pullById(int id)
        {
        }
        public override void update()
        {
        }

    }
}