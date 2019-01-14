using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Text;
using System.Threading.Tasks;
using JobAdvertisement.DataAccess.Abstract;
using JobAdvertisement.DataAccess.Concrete.Context;

namespace JobAdvertisement.DataAccess.Concrete.Repository
{
    public class EfRepository<T> : IRepository<T> where T : class 
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public EfRepository(JobAdContext jobAdContext)
        {
            if (jobAdContext == null)
                throw new ArgumentException("jobAdContext can not be null");

            _dbContext = jobAdContext;
            _dbSet = jobAdContext.Set<T>();
        }

        #region IRepository Members
        public IQueryable<T> GetAll()
        {
            return _dbSet;
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }        
        #endregion
    }
}

