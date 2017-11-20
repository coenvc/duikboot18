using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Duikboot.Data.Live;
using Duikboot.Data.Live.Repository;

namespace Duikboot.Registration.Web.Controllers
{
    public class MeerijderController : Controller
    {
        private CapacityRepository CapacityRepository;
        private MeerijderRepository MeerijderRepository; 
        public MeerijderController()
        {
            this.MeerijderRepository = new MeerijderRepository();
            this.CapacityRepository = new CapacityRepository();
        }

        // GET: Meerijder
        [Route("backoffice/meerijders")]
        public ActionResult Overview()
        {
            return View(MeerijderRepository.GetAll());
        }

        public ActionResult DailyOverview(string day)
        {
            ViewBag.Title = day;
            var meerijders = MeerijderRepository.GetMeerijderByDay(day);  
            return View(meerijders);
        }

        // GET: Capacity
        [HttpGet]
        public ActionResult DailyOccupationPercentage()
        {
            Dictionary<string, int> dailyPercentage = new Dictionary<string, int>()
            {
                {"zaterdag", CapacityRepository.GetPercentage("zaterdag")},
                {"zondag", CapacityRepository.GetPercentage("zondag")},
                {"maandag", CapacityRepository.GetPercentage("maandag")},
                {"dinsdag", CapacityRepository.GetPercentage("dinsdag")}
            };

            return Json(dailyPercentage, JsonRequestBehavior.AllowGet);
        }
    }
}