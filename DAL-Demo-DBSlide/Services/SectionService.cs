using DAL_Demo_DBSlide.Entities;
using DAL_Demo_DBSlide.Mappers;
using Shared_Demo_DBSlide.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL_Demo_DBSlide.Services
{
    public class SectionService : ISectionRepository<Section>
    {
        private string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DBSlide;Integrated Security=True;Encrypt=True";

        public IEnumerable<Section> Get() {
            using (SqlConnection connection = new SqlConnection(_connectionString)) {
                using(SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM [section]";
                    connection.Open();
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            yield return reader.ToSection();
                        }
                    }
                }
            }
        }
        public Section Get(int id) {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM [section] WHERE [section_id] = @id";
                    command.Parameters.AddWithValue("id", id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if(reader.Read()) return reader.ToSection();
                        throw new ArgumentException(nameof(id), $"L'identifiant {id} n'existe pas dans la base de données.");
                    }
                }
            }
        }
        public IEnumerable<Section> GetByDelegate(int id) {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM [section] WHERE [delegate_id] = @id";
                    command.Parameters.AddWithValue("id", id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader.ToSection();
                        }
                    }
                }
            }
        }
        public int Insert(Section data) {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO [section] VALUES (@section_id, @section_name, @delegate_id)";
                    command.Parameters.AddWithValue("section_id", data.Section_id);
                    command.Parameters.AddWithValue("section_name", data.Section_name);
                    command.Parameters.AddWithValue("delegate_id", data.Delegate_id);
                    connection.Open();
                    if(command.ExecuteNonQuery() <= 0) throw new ArgumentException(nameof(data), $"Erreur lors de l'insertion des données.");
                    return data.Section_id;
                }
            }
        }
        public void Update(Section data) {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE [section] SET [section_name] = @section_name, [delegate_id] = @delegate_id WHERE [section_id] = @section_id";
                    command.Parameters.AddWithValue("section_id", data.Section_id);
                    command.Parameters.AddWithValue("section_name", data.Section_name);
                    command.Parameters.AddWithValue("delegate_id", data.Delegate_id);
                    connection.Open();
                    if (command.ExecuteNonQuery() <= 0) throw new ArgumentException(nameof(data.Section_id), $"L'identifiant {data.Section_id} n'existe pas dans la base de données.");
                }
            }
        }
        public void Delete(int id) {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM [section] WHERE [section_id] = @section_id";
                    command.Parameters.AddWithValue("section_id", id);
                    connection.Open();
                    if (command.ExecuteNonQuery() <= 0) throw new ArgumentException(nameof(id), $"L'identifiant {id} n'existe pas dans la base de données.");
                }
            }
        }
    }
}
