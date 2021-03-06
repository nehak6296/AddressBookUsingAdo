using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    class AddressBook
    {
        ContactsModel contactsModel = new ContactsModel();
        AddressBookRepo repo = new AddressBookRepo();
        string addressBookName;
        public void AddNewContact()
        {            
            contactsModel.AddressBookName = this.addressBookName;

            Console.WriteLine("Enter First Name : ");
            contactsModel.First_name = Console.ReadLine();

            Console.WriteLine("Enter Last Name : ");
            contactsModel.Last_name = Console.ReadLine();

            Console.WriteLine("Enter Address : ");
            contactsModel.Address = Console.ReadLine();

            Console.WriteLine("Enter City : ");
            contactsModel.City = Console.ReadLine();

            Console.WriteLine("Enter State : ");
            contactsModel.State = Console.ReadLine();

            Console.WriteLine("Enter Zip : ");
            contactsModel.Zip = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Phone Number");
            contactsModel.Phone_number = Console.ReadLine();

            Console.WriteLine("Enter Email : ");
            contactsModel.Email = Console.ReadLine();

            if (repo.AddContact(contactsModel))
                Console.WriteLine("Contact added successfully");
            else
                Console.WriteLine("************Contact Already exist************");
        }

        public void GetContacts()
        {
            JsonModel jsonModel = new JsonModel();

            List<ContactsModel> contactsList = repo.GetContacts();
            jsonModel.Contacts = contactsList;
            //var json = JsonConvert.SerializeObject(contactsList);
            string file = @"C:\Users\Neha Kotarwar\Desktop\Problems\AddressBookUsingAdo\AddressBookSystem\AddressBookSystem\Output.json";
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(file))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, jsonModel);
            }
            Console.WriteLine("Data Added To Json File........");
        }

        public void GetCountByCityOrState()
        {
            Console.WriteLine("Enter City Or State:");
            string Input = Console.ReadLine();
            List<ContactsModel> contactsList = repo.SearchInCityOrState(Input);
            
            if (contactsList.Count > 0)
            {
                Console.WriteLine("Number of contacts in " + Input + " :" + contactsList.Count);
            }
            else
            {
                Console.WriteLine("________Contact doesn't exist______\n");
            }


            }

            public void SearchContacts()
        {
            Console.WriteLine("Enter City Or State:");
            string Input = Console.ReadLine();
            List<ContactsModel> contactsList = repo.SearchInCityOrState(Input);
            if (contactsList.Count > 0)
            {               
                foreach (var contact in contactsList)
                {
                    Console.WriteLine(contact.ToString() +"\n");                    
                }
            }
            else
            {
                Console.WriteLine("********* "+Input+" not exists **********");
            }
        }

        public bool IsExist()
        {
            Console.WriteLine("Enter Existing Address Book Name :");
            this.addressBookName = Console.ReadLine();
            if (repo.GetAddressBook(addressBookName))
            {
                return true;
            }
            else return false;
        }

        public void CreateNewAddressBook()
        {
            Console.WriteLine("Enter Address Book Name : ");
             this.addressBookName = Console.ReadLine();
            repo.AddAddressBook(addressBookName);
        }

        public void EditContact()
        {
            Console.WriteLine("Whose contact you want to edit ? \n Enter First Name :");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name:  ");
            string lastName = Console.ReadLine();

            ContactsModel contactsModel = repo.Read(firstName, lastName);

            Console.WriteLine(" What you want to Edit ? ");
            Console.WriteLine("Enter your Choice : ");
            Console.WriteLine("1.Address \n 2.City \n 3.State \n 4.Zip \n 5.Phone\n6.Email");

            string choice = Console.ReadLine();

            switch (choice)
            {                    
                    case "1":
                    Console.WriteLine("Enter new Address:");
                    contactsModel.Address = Console.ReadLine();
                    break;
                    case "2":
                    Console.WriteLine("Enter new City:");
                    contactsModel.City = Console.ReadLine();
                    break;
                    case "3":
                    Console.WriteLine("Enter new State:");
                    contactsModel.State = Console.ReadLine();
                    break;
                    case "4":
                    Console.WriteLine("Enter new Zip:");
                    contactsModel.Zip = Convert.ToInt32(Console.ReadLine());
                    break;
                    case "5":
                    Console.WriteLine("Enter new Phone Number:");
                    contactsModel.Phone_number = Console.ReadLine();
                    break;
                    case "6":
                    Console.WriteLine("Enter new Email:");
                    contactsModel.Email = Console.ReadLine();
                    break;
                    default:
                    Console.WriteLine("Invalid Choice.....");
                            break;
            }

            repo.Edit(contactsModel);
            Console.WriteLine("Contact Edited Sucessfully......");
        }
        public void DeleteContact()
        {
            Console.WriteLine("Enter Name To Delete : ");
            Console.WriteLine("Enter First Name :");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name :");
            string lastName = Console.ReadLine();

            repo.Delete(firstName,lastName);        
        }
    }
 }

