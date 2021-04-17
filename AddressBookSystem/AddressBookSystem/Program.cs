﻿using System;
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
            
            while (choice != "3")
            {
                Console.WriteLine("1.Add Contact \n 2.Edit Contact \n  3.Exit");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        addressBook.AddNewContact();
                        break;
                    case "2":addressBook.EditContact();
                        break;
                    case "3":
                        break;
                    default:
                        Console.WriteLine("Invalid Choice.....");
                        break;
                }
            }
            
        }
    }
}
