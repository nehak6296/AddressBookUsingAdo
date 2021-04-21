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
            string preference = "";
            while (preference != "6")
            {
                Console.WriteLine(" 1.Add New Address Book \n 2.Select existing Address Book \n 3.Search Person In city or state \n 4.Count By City Or State \n 5.Sort AddressBook by FirstName \n 6.Exit");
                preference = Console.ReadLine();
                switch (preference)
                {
                    case "1":
                        addressBook.CreateNewAddressBook();
                        RunAddressBook(addressBook);
                        break;
                    case "2":
                        bool result = addressBook.IsExist();
                        if (result)
                            RunAddressBook(addressBook);
                        else
                            Console.WriteLine("AddressBook don't exist..");
                        break;
                    case "3":addressBook.SearchContacts();
                        break;
                    case "4":addressBook.GetCountByCityOrState();
                        break;
                    case "5":AddressBookRepo repo = new AddressBookRepo();
                            repo.SortByFirstName();
                        break;
                    case "6":
                        break;
                    default:
                        break;

                }
            }

        }

        public static void RunAddressBook(AddressBook addressBook)
            {
            //AddressBook addressBook = new AddressBook();
            Console.WriteLine("Enter Your Choice : ");
            string choice = "";
            while (choice != "4")
            {
                Console.WriteLine("1.Add Contact \n 2.Edit Contact \n 3.Delete Contact \n 4.Exit");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        addressBook.AddNewContact();
                        break;
                    case "2":
                        addressBook.EditContact();
                        break;
                    case "3":
                        addressBook.DeleteContact();
                        break;
                    case "4":
                        break;
                    default:
                        Console.WriteLine("Invalid Choice.....");
                        break;
                }
            }
        }
    }

}
