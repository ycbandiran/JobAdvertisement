using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using JobAdvertisement.DataAccess.Abstract;
using JobAdvertisement.DataAccess.Concrete.Context;
using JobAdvertisement.DataAccess.Concrete.Repository;

namespace JobAdvertisement.DataAccess.Concrete.UnitOfWork
{
    public class EfUnitOfWork : IUnitOfWork 
    {
        private readonly JobAdContext _jobAdContext;

        public EfUnitOfWork(JobAdContext jobAdContext)
        {
            Database.SetInitializer<JobAdContext>(null);

            if (jobAdContext == null)
                throw new ArgumentNullException("jobAdContext can not be null");

            _jobAdContext = jobAdContext;

            _jobAdContext.Configuration.ValidateOnSaveEnabled = true;
        }

        #region IUnitOfWork Members
        public IRepository<T> GetRepository<T>() where T : class
        {
            return new EfRepository<T>(_jobAdContext);
        }

        public int SaveChanges()
        {
            try
            {
                return _jobAdContext.SaveChanges();
            }
            catch
            {               
                throw;
            }
        }
        #endregion      
    }
}
