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
        SqlConnection connection = new SqlConnection(connectionString);
                
        public bool AddContact(AddressBookModel model)

        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("spAddContact", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@First_name", model.First_name);
                    command.Parameters.AddWithValue("@Last_name", model.Last_name);
                    command.Parameters.AddWithValue("@Address", model.Address);
                    command.Parameters.AddWithValue("@City", model.City);
                    command.Parameters.AddWithValue("@State", model.State);
                    command.Parameters.AddWithValue("@Zip", model.Zip);
                    command.Parameters.AddWithValue("@Phone_number", model.Phone_number);
                    command.Parameters.AddWithValue("@Email", model.Email);
                    this.connection.Open();
                    var result = command.ExecuteNonQuery();
                    this.connection.Close();
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
                this.connection.Close();
            }            
            return false;

        }

        public  AddressBookModel Read(string firstName, string lastName)
        {
            AddressBookModel model = new AddressBookModel();
            string query = @"select * from Contacts where Contacts.First_name=@firstName and Contacts.Last_name =@lastName";

            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                using (connection)
                {

                    SqlCommand cmd = new SqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@firstName", firstName);
                    cmd.Parameters.AddWithValue("@lastName", lastName);

                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        model.First_name = reader["First_name"].ToString();
                        model.Last_name = reader["Last_name"].ToString();
                        model.City = reader["City"].ToString();
                        model.Address = reader["Address"].ToString();
                        model.State = reader["State"].ToString();
                        model.Zip = Convert.ToInt32(reader["Zip"]);
                        model.Phone_number = reader["Phone_number"].ToString();
                        model.Email = reader["Email"].ToString();
                    }
                    connection.Close();                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                this.connection.Close();
            }            
            return model;

        }

        public void Delete(string firstName, string lastName)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
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
        }

        public void Edit(AddressBookModel model)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);

                using (connection)
                {

                    SqlCommand command = new SqlCommand("spUpdateContactDetailes", connection);

                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@First_name", model.First_name);
                    command.Parameters.AddWithValue("@Last_name", model.Last_name);
                    command.Parameters.AddWithValue("@Address", model.Address);
                    command.Parameters.AddWithValue("@City", model.City);
                    command.Parameters.AddWithValue("@State", model.State);
                    command.Parameters.AddWithValue("@Zip", model.Zip);
                    command.Parameters.AddWithValue("@Phone_number", model.Phone_number);
                    command.Parameters.AddWithValue("@Email", model.Email);

                    connection.Open();

                    var result = command.ExecuteReader();
                    connection.Close();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                this.connection.Close();
            }            

        }       
    }
}
