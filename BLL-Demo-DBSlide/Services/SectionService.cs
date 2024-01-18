using DAL = DAL_Demo_DBSlide.Services;
using System;
using System.Collections.Generic;
using System.Text;
using BLL_Demo_DBSlide.Entities;
using System.Linq;
using BLL_Demo_DBSlide.Mappers;

namespace BLL_Demo_DBSlide.Services
{
    public class SectionService
    {
        private readonly DAL.SectionService _repository;

        public SectionService()
        {
            _repository = new DAL.SectionService();
        }

        public IEnumerable<Section> Get() {
            return _repository.Get().Select(d => d.ToBLL());
        }
        public Section Get(int id) {
            return _repository.Get(id).ToBLL();
        }
        public IEnumerable<Section> GetByDelegate(int id) { 
            return _repository.GetByDelegate(id).Select(d => d.ToBLL());
        }
        public int Insert(Section data) {
            return _repository.Insert(data.ToDAL());
        }
        public void Update(Section data) {
            _repository.Update(data.ToDAL());
        }
        public void Delete(int id) { 
            _repository.Delete(id);
        }
    }
}
