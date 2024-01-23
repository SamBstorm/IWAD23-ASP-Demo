using System;
using System.Collections.Generic;
using System.Text;

namespace BLL_Demo_DBSlide.Entities
{
    /*public class DelStudent : Student
    {
        public Section DelSection { get; private set; }
        public DelStudent(int student_id, string first_name, string last_name, DateTime birth_date, string login, int section_id, int? year_result, string course_id, Section delSection) : base(student_id, first_name, last_name, birth_date, login, section_id, year_result, course_id)
        {
            DelSection = delSection;
        }

        public DelStudent(int student_id, string first_name, string last_name, DateTime birth_date, string login, Section section, int? year_result, string course_id, Section delSection) : base(student_id, first_name, last_name, birth_date, login, section, year_result, course_id)
        {
            DelSection = delSection;
        }

    }*/

    public class DelStudent
    {
        private Student _student;

        public int Student_id { get { return _student.Student_id; } }
        public string First_name { get { return _student.First_name; } }
        public string Last_name { get { return _student.Last_name; } }
        public DateTime Birth_date { get { return _student.Birth_date; } }
        public int Years_old { get { return _student.Years_old; } }
        public string Login { get { return _student.Login; } }
        public int Section_id { get { return _student.Section_id; } }
        public Section Section { get { return _student.Section; } }
        public int? Year_result { get { return _student.Year_result; } }
        public string Course_id { get { return _student.Course_id; } }

        public Section DelSection { get; private set; }

        public DelStudent(Student student, Section section)
        {
            if (student is null) throw new ArgumentNullException(nameof(student));
            if (section is null) throw new ArgumentNullException(nameof(section));
            _student = student;
            DelSection = section;
        }


    }
}
