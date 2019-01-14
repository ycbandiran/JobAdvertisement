using System;
using System.Data.Entity;
using System.Linq;
using JobAdvertisement.DataAccess.Concrete.Context;
using JobAdvertisement.Entity.Concrete;

namespace JobAdvertisement.DataAccess.Concrete.Context
{
    public class JobAdContext : DbContext
    {      
        public JobAdContext() : base("name=JobAdDB")
        {
            Database.SetInitializer(new JobAdConfiguration());
        }

        public DbSet<JobAd> JobAd { get; set; }
    }
}