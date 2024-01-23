using DAL = DAL_Demo_DBSlide.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using BLL_Demo_DBSlide.Entities;
using System.Linq;
using BLL_Demo_DBSlide.Mappers;
using Shared_Demo_DBSlide.Repositories;

namespace BLL_Demo_DBSlide.Services
{
    public class SectionService : ISectionRepository<Section>
    {
        private readonly ISectionRepository<DAL.Section> _sectionRepository;
        private readonly IStudentRepository<DAL.Student> _studentRepository;

        public SectionService(ISectionRepository<DAL.Section> sectionRepository, IStudentRepository<DAL.Student> studentRepository)
        {
            _sectionRepository = sectionRepository;
            _studentRepository = studentRepository;
        }

        public IEnumerable<Section> Get() {
            return _sectionRepository.Get().Select(d => d.ToBLL());
        }
        public Section Get(int id) {
            Section entity = _sectionRepository.Get(id).ToBLL();
            entity.AddGroupStudents(_studentRepository.GetBySection(id).Select(d => d.ToBLL()));
            if (!(entity.Delegate_id is null)) entity.ChangeDelegate(_studentRepository.Get((int)entity.Delegate_id).ToBLL());
            return entity;
        }
        public IEnumerable<Section> GetByDelegate(int id) { 
            return _sectionRepository.GetByDelegate(id).Select(d => d.ToBLL());
        }
        public int Insert(Section data) {
            return _sectionRepository.Insert(data.ToDAL());
        }
        public void Update(Section data) {
            _sectionRepository.Update(data.ToDAL());
        }
        public void Delete(int id) { 
            _sectionRepository.Delete(id);
        }
    }
}
