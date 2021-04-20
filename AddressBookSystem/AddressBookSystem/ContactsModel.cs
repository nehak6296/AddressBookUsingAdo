using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    public class ContactsModel
    {
        public string AddressBookName { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public string Phone_number { get; set; }
        public string Email { get; set; }
        public override string ToString()
        {
            return AddressBookName+" "+First_name + " " + Last_name + " " + Address + " " + City + " " + State + " " + Zip + " " + Phone_number + " " + Email + " ";
        }
    }
    
}
