using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZenithDataLib.Models;
using Microsoft.AspNet.Identity;
using System.Data.Entity;

namespace ZenithWebSite.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            ViewBag.Message = "This Week's Events at Zenith Society";
            ApplicationDbContext db = new ApplicationDbContext();

            int today = (int)DateTime.Now.DayOfWeek;
            int difference;
            if (today == 0) { difference = 6; }
            else difference = today - 1;

            DateTime monday = DateTime.Now.AddDays(-difference);
            DateTime sunday = monday.AddDays(6);


            /* List<Event> model = db.Events
                 .Where(x => x.EventToDateTime.CompareTo(monday) >=0 )
                 .Where(x => x.EventFromDateTime.CompareTo(sunday) <= 0)
                 .Include(x => x.ActivityCategory).ToList();           
                 */

            List<Event> model = db.Events
                .Where(x => x.EventToDateTime.CompareTo(DateTime.Now) >= 0)
                .Where(x => x.EventFromDateTime.CompareTo(DateTime.Now) <= 6)
                .Include(x => x.ActivityCategory).ToList();

            return View(model);
  
        }
    }
}