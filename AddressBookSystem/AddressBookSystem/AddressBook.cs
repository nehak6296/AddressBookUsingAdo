using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    class AddressBook
    {
        AddressBookModel model = new AddressBookModel();
        AddressBookRepo repo = new AddressBookRepo();
        public void AddNewContact()
        {
            Console.WriteLine("Enter First Name : ");
            model.First_name = Console.ReadLine();

            Console.WriteLine("Enter Last Name : ");
            model.Last_name = Console.ReadLine();

            Console.WriteLine("Enter Address : ");
            model.Address = Console.ReadLine();

            Console.WriteLine("Enter City : ");
            model.City = Console.ReadLine();

            Console.WriteLine("Enter State : ");
            model.State = Console.ReadLine();

            Console.WriteLine("Enter Zip : ");
            model.Zip = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Phone Number");
            model.Phone_number = Console.ReadLine();

            Console.WriteLine("Enter Email : ");
            model.Email = Console.ReadLine();

            if (repo.AddContact(model))
                Console.WriteLine("Records added successfully");
        }

    }
}
