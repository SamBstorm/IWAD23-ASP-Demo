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

        public void UpdateYearResult(int newResult) {
            if(newResult < 0 || newResult > 20) throw new ArgumentOutOfRangeException(nameof(newResult),"Les résultats scolaires sont compris entre 0 et 20");
            Year_result = newResult;
        }

        public void ClearYearResult()
        {
            Year_result = null;
        }
    }
}
