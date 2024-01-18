using System;
using System.Collections.Generic;
using System.Text;

namespace BLL_Demo_DBSlide.Entities
{
    public class DelStudent : Student
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

    }
}
