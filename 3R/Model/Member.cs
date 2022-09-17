using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3R
{
    class MemberModel : MyModel
    {
        private int id;
        private string name;
        private string email;
        private string contact;


        public int Id { get => id; }
        public string Name { get => name; }
        public string Email { get => email; }
        public string Contact { get => contact; }


        public MemberModel(int id, string name, string email, string contact)
        {
            this.id = id;
            this.name = name;
            this.email = email;
            this.contact = contact;
        }
        public MemberModel(string name, string email, string contact)
        {
            this.name = name;
            this.email = email;
            this.contact = contact;
        }

        public override void push()
        { }
        public override void pullById(int id)
        { }
        public override void update()
        { }
        public override void deleteById(int id)
        { }
    }
}