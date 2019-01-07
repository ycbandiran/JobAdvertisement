namespace JobAdvertisement.DataAccess
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using JobAdvertisement.DataAccess.Model;

    public class JobAdContext : DbContext
    {
        // Your context has been configured to use a 'JobAdContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'JobAdvertisement.DataAccess.JobAdContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'JobAdContext' 
        // connection string in the application configuration file.
        public JobAdContext() : base("name=JobAdDB")
        {
            Database.SetInitializer(new JobAdConfiguration());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public DbSet<JobAd> JobAd { get; set; }
    }

    //public class Configuration : CreateDatabaseIfNotExists<JobAdContext>
    //{
    //    protected override void Seed(JobAdContext context)
    //    {
    //        context.JobAd.Add(new JobAd()
    //        {
    //            JobAdID = 1,
    //            JobAdTitle = "Manager",
    //            JobAdContent = "Managing",
    //            ApplicantName = "Yiðit",
    //            ApplicantSurname = "Can",
    //            ApplicantPhoneNumber = 5331112233,
    //            ApplicantEmailAdress = "yigit.can@gmail.com"
    //        }
    //        );

    //        context.SaveChanges();
    //    }
    //}
}