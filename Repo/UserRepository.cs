using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace UserFormSubmission.Repo
{
    public class UserRepository : IUserRepository
    {
        private readonly string cs = ConfigurationManager.ConnectionStrings["ConnStringDb"].ConnectionString;

        public bool CheckUserExists(string email)
        {
            if(string.IsNullOrEmpty(email))
            {
                return false;
            }

            string queryString =
                         "SELECT ID FROM dbo.[User] WHERE Email = @email";

            using (SqlConnection connection =
           new SqlConnection(cs))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@email", email);

                // Open the connection in a try/catch block.
                // Create and execute the DataReader, writing the result
                // set to the console window.
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        reader.Close();
                        return true;
                    }
                    else
                    {
                        reader.Close();
                        return false;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return true;
                }
            }

        }

        public string InsertUser(string email, string password)
        {

            if(string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return "Invalid Data, Please try again";
            }

            using (SqlConnection connection =
          new SqlConnection(cs))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand("spAddUser", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@createdDate", DateTime.Now.Date);
                // Open the connection in a try/catch block.
                // Create and execute the sp

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return "User Added Successfully";
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return "Error: " + ex.Message;
                }
                finally
                {
                    connection.Close();
                }
            }


        }

        public bool RemoveUser(string email)
        {
            if(string.IsNullOrEmpty(email))
            {
                return false;
            }
            using (SqlConnection connection =
          new SqlConnection(cs))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand("spRemoveUser", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@email", email);
                // Open the connection in a try/catch block.
                // Create and execute the sp

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
                finally
                {
                    connection.Close();
                }
            }


        }
    }
}