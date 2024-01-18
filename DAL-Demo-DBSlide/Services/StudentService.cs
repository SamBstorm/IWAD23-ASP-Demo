using DAL_Demo_DBSlide.Entities;
using DAL_Demo_DBSlide.Mappers;
using Shared_Demo_DBSlide.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL_Demo_DBSlide.Services
{
    public class StudentService : IStudentRepository<Student>
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
        public Student Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM [student] WHERE [student_id] = @id";
                    /* Paramètre Méthode difficile
                    SqlParameter param_01 = new SqlParameter();
                    param_01.ParameterName = "id";
                    param_01.Value = id;
                    command.Parameters.Add(param_01);*/
                    command.Parameters.AddWithValue("id", id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read()) return reader.ToStudent();
                        throw new ArgumentException(nameof(id), $"L'identifiant {id} n'existe pas dans la base de données.");
                    }
                }
            }
        }
        public int Insert(Student data)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_student_insert";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("first_name", data.First_name);
                    command.Parameters.AddWithValue("last_name", data.Last_name);
                    command.Parameters.AddWithValue("birth_date", data.Birth_date);
                    command.Parameters.AddWithValue("section_id", data.Section_id);
                    command.Parameters.AddWithValue("year_result", data.Year_result ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("course_id", data.Course_id);
                    connection.Open();
                    return (int) command.ExecuteScalar();
                }
            }
        }
        public void Update(Student data) {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_student_update_year_result";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("id", data.Student_Id);
                    command.Parameters.AddWithValue("year_result", data.Year_result ?? (object)DBNull.Value);
                    connection.Open();
                    if (command.ExecuteNonQuery() <= 0)
                        throw new ArgumentException(nameof(data.Student_Id), $"L'identifiant {data.Student_Id} n'est pas das la base de données");
                }
            }
        }
        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_student_delete";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("id", id);
                    connection.Open();
                    if (command.ExecuteNonQuery() <= 0)
                        throw new ArgumentException(nameof(id), $"L'identifiant {id} n'est pas das la base de données");
                }
            }
        }

        public IEnumerable<Student> GetBySection(int id)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                using(SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM [student] WHERE [section_id] = @id";
                    command.Parameters.AddWithValue("id", id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read()) yield return reader.ToStudent();
                    }
                }
            }
        }
    }
}