using System;
using System.Collections.Generic;
using System.Text;

namespace Shared_Demo_DBSlide.Repositories
{
    public interface IStudentRepository<TEntity>
    {
        public IEnumerable<TEntity> Get();
        public TEntity Get(int id);
        public IEnumerable<TEntity> GetBySection(int id);
        public int Insert(TEntity data);
        public void Update(TEntity data);
        public void Delete(int id);
    }
}
