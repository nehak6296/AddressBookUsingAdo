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

        public void EditContact()
        {
            Console.WriteLine("Whose contact you want to edit ? \n Enter First Name :");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name:  ");
            string lastName = Console.ReadLine();

            AddressBookModel model = repo.Read(firstName, lastName);

            Console.WriteLine(" What you want to Edit ? ");
            Console.WriteLine("Enter your Choice : ");
            Console.WriteLine("1.Address \n 2.City \n 3.State \n 4.Zip \n 5.Phone\n6.Email");

            string choice = Console.ReadLine();

            switch (choice)
            {                    
                    case "1":
                    Console.WriteLine("Enter new Address:");
                    model.Address = Console.ReadLine();
                    break;
                    case "2":
                    Console.WriteLine("Enter new City:");
                    model.City = Console.ReadLine();
                    break;
                    case "3":
                    Console.WriteLine("Enter new State:");
                    model.State = Console.ReadLine();
                    break;
                    case "4":
                    Console.WriteLine("Enter new Zip:");
                    model.Zip = Convert.ToInt32(Console.ReadLine());
                    break;
                    case "5":
                    Console.WriteLine("Enter new Phone Number:");
                    model.Phone_number = Console.ReadLine();
                    break;
                    case "6":
                    Console.WriteLine("Enter new Email:");
                    model.Email = Console.ReadLine();
                    break;
                    default:
                    Console.WriteLine("Invalid Choice.....");
                            break;
            }

            repo.Edit(model);
        }
    }
 }

