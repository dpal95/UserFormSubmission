﻿using System;
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
        //private readonly string cs = ConfigurationManager.ConnectionStrings["ConnStringDb"].ConnectionString;

        public bool checkUserExists(string email)
        {
            string cs = ConfigurationManager.ConnectionStrings["ConnStringDb"].ConnectionString;

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

        public bool InsertUser(string email, string password)
        {
           string cs = ConfigurationManager.ConnectionStrings["ConnStringDb"].ConnectionString;

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
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }


        }
    }
}