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
             AddressBook addressBook = new AddressBook();
            
            Console.WriteLine("Enter Your Choice : ");
            string choice = "";
            
            while (choice != "2")
            {
                Console.WriteLine("1.Add Contact \n 2.Exit");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        addressBook.AddNewContact();
                        break;
                    default:
                        Console.WriteLine("Invalid Choice.....");
                        break;
                }
            }
            
        }
    }
}
