using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpAddressBookTestProject
{
    public class JsonContactsModel
    {
        public int id { get; set; }
        public string AddressBookName { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone_number { get; set; }
        public string Email { get; set; }

    }
}
