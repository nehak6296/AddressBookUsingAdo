using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            AddressBookModel model = new AddressBookModel();

            model.First_name = "Neha";
            model.Last_name = "Kotarwar";
            model.Address = "Ravi Nagar";
            model.City = "Karanja";
            model.State = "Maharashtra";
            model.Zip = 444105;
            model.Phone_number = "7768965972";
            model.Email = "nehak6296@gmail.com";
            
        }
    }
}
