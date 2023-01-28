using Code_Challenge.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace Code_Challenge.Data
{
    internal class UserDAO
    {
        //performs all database actions

        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TestDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //Get all data
        public List<UserModel> GetAll()
        {
            List<UserModel> returnList = new List<UserModel> ();

            //access database

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM dbo.TestData";

                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if(reader.HasRows)
                {
                    while (reader.Read())
                    {
                        UserModel user = new UserModel();
                        user.UserId = reader.GetInt32(0);
                        user.Username = reader.GetString(1);
                        user.Password = reader.GetString(2);

                        returnList.Add(user);
                    }
                }
                return returnList;
            }
        }

        public UserModel GetOne(int Id)
        {
            //access database

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM dbo.TestData WHERE Id = @id";

                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                cmd.Parameters.Add("@Id", System.Data.SqlDbType.VarChar, 40).Value = Id;

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                UserModel user = new UserModel();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        user.UserId = reader.GetInt32(0);
                        user.Username = reader.GetString(1);
                        user.Password = reader.GetString(2);
                    }
                }
                return user;
            }
        }

        //Create
        public int Create(UserModel userModel)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "INSERT INTO dbo.TestData VALUES (@UserName, @Password)";

                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                cmd.Parameters.Add("@UserName", System.Data.SqlDbType.VarChar, 40).Value = userModel.Username;
                cmd.Parameters.Add("@Password", System.Data.SqlDbType.VarChar, 20).Value = userModel.Password;

                con.Open();
                int newID = cmd.ExecuteNonQuery();
                       
                return newID;     
            }           
            
        }

        //Delete


        //Edit
    }
}