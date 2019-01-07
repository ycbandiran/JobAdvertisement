using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using JobAdvertisement.DataAccess.Model;
using JobAdvertisement.DataAccess;

namespace JobAdvertisement.Mvc.Controllers
{    
    public class JobAdListController : Controller
    {
        JobAdContext jobAdContext = new JobAdContext();


        // GET: JobAdList

        public async Task<ActionResult> JobAdvertising(string showAllButton )
        {           
            using(HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync("http://localhost:51923/api/jobadservice");
                var model = JsonConvert.DeserializeObject<List<JobAd>>(
                    response.Content.ReadAsStringAsync().Result);
                if (!string.IsNullOrEmpty(showAllButton))
                {
                    return View(model.OrderByDescending(y => y.JobAdID).ToList());
                }                
                return View(model.OrderByDescending(x => x.JobAdID).Take(5).ToList());
            }            
        }
        

        //GET: /JobAdList/Create

        public ActionResult Create()
        {
            return View();
        }


        // POST: JobAdList/Create        

        [HttpPost]
        [ValidateAntiForgeryToken]

      public ActionResult Create(JobAd jobAd)
        {
            if (ModelState.IsValid)
            {
                jobAdContext.JobAd.Add(jobAd);
                jobAdContext.SaveChanges();

                return RedirectToAction("JobAdvertising");
            }    
                    
            return View(jobAd);
        }
    }
}