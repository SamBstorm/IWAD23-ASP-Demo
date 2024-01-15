using DAL_Demo_DBSlide.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL_Demo_DBSlide.Services
{
    public class StudentService
    {
        private string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DBSlide;Integrated Security=True;Encrypt=True";
        public IEnumerable<Student> Get()
        {

        }
    }
}
