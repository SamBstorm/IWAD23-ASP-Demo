using System;
using System.Collections.Generic;
using System.Text;

namespace BLL_Demo_DBSlide.Entities
{
    public class Section
    {
        private List<Student> _students;

        public int Section_id { get; private set; }
        public string Section_name { get; private set; }
        public int? Delegate_id { get; private set; }
        public Student Delegate { get; private set; }

        public Student[] Students { 
            get { 
                return _students.ToArray();
            }
        }

        public Section(int section_id, string section_name, int? delegate_id)
        {
            Section_id = section_id;
            Section_name = section_name;
            Delegate_id = delegate_id;
        }

        public Section(int section_id, string section_name, Student del)
        {
            Section_id = section_id;
            Section_name = section_name;
            Delegate = del;
            if (!(del is null)) Delegate_id = del.Student_id;
        }

        public void AddStudent(Student student)
        {
            _students ??= new List<Student>();
            if(student is null) throw new ArgumentNullException(nameof(student));
            if (_students.Contains(student)) throw new ArgumentException(nameof(student), $"L'étudiant {student.Student_id} est déjà inscrit dans cette section.");
            if ((!(student.Section is null) && student.Section != this) || student.Section_id != this.Section_id) throw new ArgumentException(nameof(student), $"L'étudiant {student.Student_id} est déjà inscrit dans une section différente.");
            _students.Add(student);
        }

        public void AddGroupStudents(IEnumerable<Student> students)
        {
            if (students is null) throw new ArgumentNullException(nameof(students));
            foreach(Student student in students)
            {
                AddStudent(student);
            }
        }

        public void RemoveStudent(Student student)
        {
            if (_students is null) return;
            if(student is null) throw new ArgumentNullException(nameof(student));
            if (!_students.Contains(student)) throw new ArgumentException(nameof(student), $"L'étudiant {student.Student_id} n'est pas inscrit dans cette section.");
            _students.Remove(student);
        }
    }
}
