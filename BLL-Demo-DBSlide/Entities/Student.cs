using System;
using System.Collections.Generic;
using System.Text;

namespace BLL_Demo_DBSlide.Entities
{
    public class Student : Person
    {
        
        public int Student_id { get; private set; }
        public DateTime Birth_date { get; private set; }
        public int Years_old { get
            {
                return (int)Math.Floor((DateTime.Now - Birth_date).TotalDays / 365.25);
            }
        }
        public string Login { get; private set;}
        public int Section_id { get; private set;}

        public Section Section { get; private set;}
        public int? Year_result { get; set; }
        public string Course_id { get; private set;}

        public Student(int student_id, string first_name, string last_name, DateTime birth_date, string login, int section_id, int? year_result, string course_id) : base(first_name, last_name)
        {
            Student_id = student_id;
            Birth_date = birth_date;
            Login = login;
            Section_id = section_id;
            Year_result = year_result;
            Course_id = course_id;
        }

        public Student(int student_id, string first_name, string last_name, DateTime birth_date, string login, Section section, int? year_result, string course_id) : base(first_name, last_name)
        {
            Student_id = student_id;
            Birth_date = birth_date;
            Login = login;
            Section = section;
            if (!(section is null)) Section_id = section.Section_id;
            Year_result = year_result;
            Course_id = course_id;
        }

        public void UpdateYearResult(int newResult) {
            if(newResult < 0 || newResult > 20) throw new ArgumentOutOfRangeException(nameof(newResult),"Les résultats scolaires sont compris entre 0 et 20");
            Year_result = newResult;
        }

        public void ClearYearResult()
        {
            Year_result = null;
        }

        public void ChangeSection(Section section)
        {
            if(section is null) throw new ArgumentNullException(nameof(section),"La section est obligatoire.");
            if (!(Section is null) && Section != section)
            {
                Section.RemoveStudent(this);
                Section = null;
            }
            if(Section is null)
            {
                Section = section;
                Section_id = section.Section_id;
                section.AddStudent(this);
            }
        }
    }
}
