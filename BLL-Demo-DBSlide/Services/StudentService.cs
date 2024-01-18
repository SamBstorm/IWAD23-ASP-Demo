using BLL_Demo_DBSlide.Entities;
using DAL = DAL_Demo_DBSlide.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BLL_Demo_DBSlide.Mappers;
using Shared_Demo_DBSlide.Repositories;

namespace BLL_Demo_DBSlide.Services
{
    public class StudentService : IStudentRepository<Student>
    {
        private readonly DAL.StudentService _repository;

        public StudentService()
        {
            _repository = new DAL.StudentService();
        }

        public IEnumerable<Student> Get()
        {
            return _repository.Get().Select(d => d.ToBLL());
        }
        public Student Get(int id)
        {
            return _repository.Get(id).ToBLL();
        }
        public int Insert(Student data) {
            return _repository.Insert(data.ToDAL());
        }
        public void Update(Student data) {
            _repository.Update(data.ToDAL());
        }
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
        public IEnumerable<Student> GetBySection(int id)
        {
            return _repository.GetBySection(id).Select(d => d.ToBLL());
        }
    }
}
