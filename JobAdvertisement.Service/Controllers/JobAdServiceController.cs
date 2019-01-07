using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using JobAdvertisement.DataAccess.Model;
using JobAdvertisement.DataAccess;

namespace JobAdvertisement.Service.Controllers
{
    public class JobAdServiceController : ApiController
    {
        // GET: api/JobAdService
        public List<JobAd> Get()
        {
            using(JobAdContext jobAdContext = new JobAdContext())
            {
                return jobAdContext.JobAd.ToList();
            }           
        }
       
        public bool Post(List<JobAd> jobAdList)
        {
            try
            {
                throw new Exception();
                using (JobAdContext context = new JobAdContext())
                {
                    context.JobAd.AddRange(jobAdList);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
