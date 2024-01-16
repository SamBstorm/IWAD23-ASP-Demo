using DAL_Demo_DBSlide.Entities;
using DAL_Demo_DBSlide.Mappers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL_Demo_DBSlide.Services
{
    public class StudentService
    {
        private string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DBSlide;Integrated Security=True;Encrypt=True";
        public IEnumerable<Student> Get()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM [student]";
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader.ToStudent();
                        }
                    }
                }
            }
        }
    }
}