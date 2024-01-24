using System;
using System.Collections.Generic;
using System.Text;

namespace Shared_Demo_DBSlide.Repositories
{
    public interface IStudentRepository<TEntity> : ICRUDRepository<TEntity, int> where TEntity : class
    {
        public IEnumerable<TEntity> GetBySection(int id);
        public IEnumerable<TEntity> GetDelegate();
        public TEntity GetDelegate(int id);
    }
}
