using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Duikboot.Data.Live.Repository;

namespace Duikboot.Registration.Web.Controllers
{
    public class CapacityController : Controller
    {
        private CapacityRepository CapacityRepository;

        public CapacityController()
        {
            this.CapacityRepository = new CapacityRepository();
        }

        // GET: Capacity
        [HttpGet]
        public ActionResult DailyPercentage()
        {
            Dictionary<string, int> dailyPercentage = new Dictionary<string, int>()
            {
                {"zaterdag", CapacityRepository.GetPercentage("zaterdag")},
                {"zondag", CapacityRepository.GetPercentage("zondag")},
                {"maandag", CapacityRepository.GetPercentage("maandag")},
                {"dinsdag", CapacityRepository.GetPercentage("dinsdag")}
            };

            return Json(dailyPercentage,JsonRequestBehavior.AllowGet);
        }
    }
}