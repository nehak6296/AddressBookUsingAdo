using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    class AddressBookRepo
    {        

        public static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AddressBookSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                
        public bool AddContact(ContactsModel contactsModel)

        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                

                using (connection)
                {
                    SqlCommand command = new SqlCommand("spAddContact", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@First_name", contactsModel.First_name);
                    command.Parameters.AddWithValue("@Last_name", contactsModel.Last_name);
                    command.Parameters.AddWithValue("@Address", contactsModel.Address);
                    command.Parameters.AddWithValue("@City", contactsModel.City);
                    command.Parameters.AddWithValue("@State", contactsModel.State);
                    command.Parameters.AddWithValue("@Zip", contactsModel.Zip);
                    command.Parameters.AddWithValue("@Phone_number", contactsModel.Phone_number);
                    command.Parameters.AddWithValue("@Email", contactsModel.Email);
                    command.Parameters.AddWithValue("@AddressBookName", contactsModel.AddressBookName);
                    
                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    connection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);                
            }
            finally
            {
                connection.Close();

            }
            return false;
        }

        public bool GetAddressBook(string BookName)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    string query = @"select count(Book_Name) from AddressBook where Book_Name =@BookName";
                    SqlCommand cmd = new SqlCommand(query,connection);
                    cmd.Parameters.AddWithValue("@BookName", BookName);
                    connection.Open();
                    int result = Convert.ToInt32(cmd.ExecuteScalar());
                    if (result > 0)
                    {
                        return true;                        
                    }
                    connection.Close();

                }
            }catch(Exception e )
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
            return false;
         }


        public void AddAddressBook(string BookName)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
               
                using (connection)
                {
                    SqlCommand cmd = new SqlCommand("spAddBook", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AddressBookName", BookName);

                    connection.Open();
                    var result = cmd.ExecuteNonQuery();
                    connection.Close();
                    if (result > 0)
                    {
                        Console.WriteLine("Address Book created...."); 
                    }
                    else
                    {
                        Console.WriteLine("Address Book already exists....");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                
            }
            finally
            {
                connection.Close();

            }
        }

            public  ContactsModel Read(string firstName, string lastName)
            {
            SqlConnection connection = new SqlConnection(connectionString);
            ContactsModel contactsModel = new ContactsModel();
            string query = @"select * from Contacts where Contacts.First_name=@firstName and Contacts.Last_name =@lastName";

            try
            {
                
                using (connection)
                {

                    SqlCommand cmd = new SqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@firstName", firstName);
                    cmd.Parameters.AddWithValue("@lastName", lastName);

                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        contactsModel.First_name = reader["First_name"].ToString();
                        contactsModel.Last_name = reader["Last_name"].ToString();
                        contactsModel.City = reader["City"].ToString();
                        contactsModel.Address = reader["Address"].ToString();
                        contactsModel.State = reader["State"].ToString();
                        contactsModel.Zip = Convert.ToInt32(reader["Zip"]);
                        contactsModel.Phone_number = reader["Phone_number"].ToString();
                        contactsModel.Email = reader["Email"].ToString();
                    }
                    connection.Close();                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);                
            }
            finally
            {
                connection.Close();

            }
            return contactsModel;

        }

        public void Delete(string firstName, string lastName)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {                
                string query = @"delete from Contacts where First_name =@firstName and Last_name=@lastName";
                using (connection)
                {
                    SqlCommand cmd = new SqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@firstName", firstName);
                    cmd.Parameters.AddWithValue("@lastName", lastName);

                    connection.Open();
                    var result = cmd.ExecuteNonQuery();
                    if(result != 0)
                    {
                        Console.WriteLine("Contact Deleted...");
                    }
                    else
                    {
                        Console.WriteLine("Contact Not Found...");
                    }
                    connection.Close();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                connection.Close()
;            }
            finally
            {
                connection.Close();

            }
        }

        public void Edit(ContactsModel contactsModel)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                
                using (connection)
                {

                    SqlCommand command = new SqlCommand("spUpdateContactDetailes", connection);

                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@First_name", contactsModel.First_name);
                    command.Parameters.AddWithValue("@Last_name", contactsModel.Last_name);
                    command.Parameters.AddWithValue("@Address", contactsModel.Address);
                    command.Parameters.AddWithValue("@City", contactsModel.City);
                    command.Parameters.AddWithValue("@State", contactsModel.State);
                    command.Parameters.AddWithValue("@Zip", contactsModel.Zip);
                    command.Parameters.AddWithValue("@Phone_number", contactsModel.Phone_number);
                    command.Parameters.AddWithValue("@Email", contactsModel.Email);

                    connection.Open();

                    var result = command.ExecuteReader();
                    connection.Close();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                
            }
            finally
            {
                connection.Close();

            }

        }       
    }
}
