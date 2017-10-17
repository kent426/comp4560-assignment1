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
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var today = DateTime.Now.Date;
            DateTime monday;
            DateTime sunday;
            if (today.DayOfWeek == DayOfWeek.Sunday)
            {
                monday = today.AddDays(-6);
                sunday = today;
            } else
            {
                monday = today.AddDays(-(int)today.DayOfWeek).AddDays(1);
                sunday = today.AddDays(-(int)today.DayOfWeek).AddDays(7);
            }
            
            
            //var events = db.Events.Include(e => e.ActivityCategory)
                //.Where(e => (e.EventFromDateTime.Date >= monday && e.EventFromDateTime.Date <= sunday));

            Dictionary<DateTime, List<Event>> eventsForAWeek = new Dictionary<DateTime, List<Event>>();

            for (int x = 0; x < 7; x++)
            {
                var thisday = monday.AddDays(x).Date;
                var eventsInDay = db.Events.Include(e => e.ActivityCategory)
                                    .Where(e =>( DbFunctions.TruncateTime(e.EventFromDateTime) == thisday && e.IsActive == true)).ToList();
                eventsInDay.Sort((i, j) => DateTime.Compare(i.EventFromDateTime, j.EventFromDateTime));
                eventsForAWeek.Add(thisday, eventsInDay);
            }

                //Dictionary<int, Dictionary<DateTime, List<Event>>> eventsForAWeek = new Dictionary<int, Dictionary<DateTime, List<Event>>>();

                //for (int x=1;x<= 7;x++)
                //{      

                //    var eventsInDay = events.Where(e => e.EventFromDateTime.Date == today.AddDays(-(int)today.DayOfWeek).AddDays(x)).OrderBy(e => e.EventFromDateTime).ToList();
                //    var thisday = today.AddDays(-(int)today.DayOfWeek).AddDays(x);
                //    var dateToEvents = new Dictionary<DateTime, List<Event>>();
                //    dateToEvents.Add(thisday, eventsInDay);
                //    eventsForAWeek.Add(x,);
                //}



                return View(eventsForAWeek);

        }
    }
}