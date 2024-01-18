using Mockup_Demo_DBSlide.Entities;
using Shared_Demo_DBSlide.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mockup_Demo_DBSlide.Services
{
    public class StudentService : IStudentRepository<Student>
    {
        private List<Student> _students = new List<Student>()
        {
            new Student(){ Student_id = 1, First_name = "Emanuela", Last_name = "Cardu", Birth_date = DateTime.Now, Login = "ecardu", Section_id = 1110, Year_result = 20, Course_id = "0"},
            new Student(){ Student_id = 2, First_name = "Laurence", Last_name = "Delforge", Birth_date = DateTime.Now, Login = "ldelforg", Section_id = 1110, Year_result = 20, Course_id = "0"}
        };
        public void Delete(int id)
        {
            _students = _students.Where(d => d.Student_id != id).ToList();
        }

        public IEnumerable<Student> Get()
        {
            return _students;
        }

        public Student Get(int id)
        {
            return _students.SingleOrDefault(d => d.Student_id == id);
        }

        public IEnumerable<Student> GetBySection(int id)
        {
            return _students.Where(d => d.Section_id == id);
        }

        public int Insert(Student data)
        {
            data.Student_id = _students.Max(d=> d.Student_id) + 1;
            _students.Add(data);
            return data.Student_id;
        }

        public void Update(Student data)
        {
            Student result = _students.SingleOrDefault(d => d.Student_id == data.Student_id);
            result.First_name = data.First_name;
            result.Last_name = data.Last_name;
            result.Birth_date = data.Birth_date;
            result.Login = data.Login;
            result.Section_id = data.Section_id;
            result.Year_result = data.Year_result;
            result.Course_id = data.Course_id;
        }
    }
}
