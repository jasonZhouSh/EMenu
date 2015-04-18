using EMenu.Data.Context;
using EMenu.Domain.Interfaces;
using EMenu.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMenu.Data.Repositories
{
    public class Repository<TEntity> : IDisposable, IUnitOfWork, IRepository<TEntity> where TEntity : class, IAggregateRoot
    {
        private readonly EMenuContext _dbContext;
        private bool _committed;

        public bool Committed
        {
            get { return _committed; }
            protected set { _committed = value; }
        }

        public Repository(EMenuContext dbContext)
        {
            if (dbContext==null)
            {
                throw new ArgumentNullException("method");
            }
            _dbContext = dbContext;
        }

        public void Add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            Committed = false;
        }

        public void Update(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            Committed = false;
        }


        public void Remove(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            Committed = false;
        }

        public TEntity GetById(int id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().ToList();
        }


        public bool Commit()
        {
            if (!Committed)
            {
                if (_dbContext.SaveChanges() > 0)
                {
                    Committed = true;
                    return true;
                }
                else
                {
                    Committed = false;
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public void Rollback()
        {
            Committed = false;
        }

        public void Dispose()
        {
            if (!Committed)
                Commit();
            _dbContext.Dispose();
        }
 
    }
}
