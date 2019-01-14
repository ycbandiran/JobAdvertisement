using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using JobAdvertisement.Entity.Concrete;
using JobAdvertisement.DataAccess.Concrete.Context;
using JobAdvertisement.DataAccess.Concrete.Repository;
using JobAdvertisement.DataAccess.Concrete.UnitOfWork;
using JobAdvertisement.DataAccess.Abstract;


namespace JobAdvertisement.Mvc.Controllers
{    
    public class JobAdListController : Controller
    {
        private JobAdContext _dbContext;

        private IUnitOfWork _uow;
        private IRepository<JobAd> _jobAdRepository;

        //GET TARAFINA REPOSİTORY EKLENECEK !!!!!!!!!!!

        // GET: JobAdList

        public async Task<ActionResult> JobAdvertising(string showAllButton)
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

        //POST TARAFINA ASYNC YAPILACAK (YAPAMADI) !!!!!!!!!!!!!!!!!!

        // POST: JobAdList/Create        

        [HttpPost]
        [ValidateAntiForgeryToken]

      public ActionResult Create(JobAd jobAd)
        {
            _dbContext = new JobAdContext();
            _uow = new EfUnitOfWork(_dbContext);
            _jobAdRepository = new EfRepository<JobAd>(_dbContext);

            if (ModelState.IsValid)
            {
                _jobAdRepository.Add(jobAd);
                _uow.SaveChanges();
              
                return RedirectToAction("JobAdvertising");
            }    
                    
            return View(jobAd);
        }
    }
}