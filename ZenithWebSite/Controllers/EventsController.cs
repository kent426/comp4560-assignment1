using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ZenithDataLib.Models;

namespace ZenithWebSite.Controllers
{
    [Authorize]
    public class EventsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize]
        // GET: Events
        public ActionResult Index()
        {
            var events = db.Events.Include(e => e.ActivityCategory);
            return View(events.ToList());
        }

        [Authorize(Roles = "Admin")]
        // GET: Events/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        [Authorize(Roles = "Admin")]
        // GET: Events/Create
        public ActionResult Create()
        {
            ViewBag.ActivityCategoryId = new SelectList(db.ActivityCategories, "ActivityCategoryId", "ActivityDescription");
            return View();
        }

        [Authorize(Roles = "Admin")]
        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventId,EventFromDateTime,EventToDateTime,IsActive,ActivityCategoryId")] Event @event)
        {
            @event.CreationDate = DateTime.Now;
            
            @event.EnteredByUsername = User.Identity.GetUserName();
            if (ModelState.IsValid)
            {
                db.Events.Add(@event);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ActivityCategoryId = new SelectList(db.ActivityCategories, "ActivityCategoryId", "ActivityDescription", @event.ActivityCategoryId);
            return View(@event);
        }

        [Authorize(Roles = "Admin")]
        // GET: Events/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            ViewBag.ActivityCategoryId = new SelectList(db.ActivityCategories, "ActivityCategoryId", "ActivityDescription", @event.ActivityCategoryId);
            return View(@event);
        }

        [Authorize(Roles = "Admin")]
        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventId,EventFromDateTime,EventToDateTime,IsActive,ActivityCategoryId")] Event @event)
        {
            @event.CreationDate = DateTime.Now;
            @event.EnteredByUsername = User.Identity.GetUserName();
            if (ModelState.IsValid)
            {
                db.Entry(@event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ActivityCategoryId = new SelectList(db.ActivityCategories, "ActivityCategoryId", "ActivityDescription", @event.ActivityCategoryId);
            return View(@event);
        }

        [Authorize(Roles = "Admin")]
        // GET: Events/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        [Authorize(Roles = "Admin")]
        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event @event = db.Events.Find(id);
            db.Events.Remove(@event);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
