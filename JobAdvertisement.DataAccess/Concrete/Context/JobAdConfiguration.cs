using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using JobAdvertisement.Entity.Concrete;


namespace JobAdvertisement.DataAccess.Concrete.Context
{
    public class JobAdConfiguration : CreateDatabaseIfNotExists<JobAdContext>
    {
        protected override void Seed(JobAdContext context)
        {
            context.JobAd.Add(new JobAd()
            {
                JobAdID = 1,
                JobAdTitle = "Manager",
                JobAdContent = "Managing",
                ApplicantName = "Yiğit",
                ApplicantSurname = "Can",
                ApplicantPhoneNumber = 5331112233,
                ApplicantEmailAdress = "yigit.can@gmail.com"
            }
            );

            context.SaveChanges();
        }
    }
}
