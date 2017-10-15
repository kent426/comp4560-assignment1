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
            var events = db.Events.Include(e => e.ActivityCategory);
            return View(events.ToList());

        }
    }
}