using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMenu.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : IAggregateRoot
    {
        void Add(TEntity obj);

        void Update(TEntity obj);

        void Remove(TEntity obj);

        TEntity GetById(int id);

        IEnumerable<TEntity> GetAll();

        void Dispose();
    }
}
