namespace JobAdvertisement.DataAccess
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using JobAdvertisement.DataAccess.Model;

    public class JobAdContext : DbContext
    {      
        public JobAdContext() : base("name=JobAdDB")
        {
            Database.SetInitializer(new JobAdConfiguration());
        }

        public DbSet<JobAd> JobAd { get; set; }
    }
}