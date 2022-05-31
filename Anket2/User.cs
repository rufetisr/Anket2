using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anket2
{
    internal class User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime Birthday { get; set; }

        public override string ToString() => $"Name: {Name}\nSurname: {Surname}\nEmail: {Email}\nPhone: {Phone}\nBirthday: {Birthday}\n";
    }
}
