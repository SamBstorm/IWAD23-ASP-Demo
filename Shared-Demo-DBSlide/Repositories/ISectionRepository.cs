using System;
using System.Collections.Generic;
using System.Text;

namespace Shared_Demo_DBSlide.Repositories
{
    public interface ISectionRepository<TEntity> : ICRUDRepository<TEntity, int> where TEntity : class
    {
        public IEnumerable<TEntity> GetByDelegate(int id);
    }
}
