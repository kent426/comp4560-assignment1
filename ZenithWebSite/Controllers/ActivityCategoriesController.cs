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
    public class ActivityCategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize]
        // GET: ActivityCategories
        public ActionResult Index()
        {
            return View(db.ActivityCategories.ToList());
        }

        [Authorize(Roles = "Admin")]
        // GET: ActivityCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivityCategory activityCategory = db.ActivityCategories.Find(id);
            if (activityCategory == null)
            {
                return HttpNotFound();
            }
            return View(activityCategory);
        }

        [Authorize(Roles = "Admin")]
        // GET: ActivityCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        // POST: ActivityCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ActivityCategoryId,ActivityDescription")] ActivityCategory activityCategory)
        {
            activityCategory.CreationDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.ActivityCategories.Add(activityCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(activityCategory);
        }

        [Authorize(Roles = "Admin")]
        // GET: ActivityCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivityCategory activityCategory = db.ActivityCategories.Find(id);
            if (activityCategory == null)
            {
                return HttpNotFound();
            }
            return View(activityCategory);
        }

        [Authorize(Roles = "Admin")]
        // POST: ActivityCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ActivityCategoryId,ActivityDescription")] ActivityCategory activityCategory)
        {
            activityCategory.CreationDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Entry(activityCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(activityCategory);
        }

        [Authorize(Roles = "Admin")]
        // GET: ActivityCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivityCategory activityCategory = db.ActivityCategories.Find(id);
            if (activityCategory == null)
            {
                return HttpNotFound();
            }
            return View(activityCategory);
        }

        [Authorize(Roles = "Admin")]
        // POST: ActivityCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ActivityCategory activityCategory = db.ActivityCategories.Find(id);
            db.ActivityCategories.Remove(activityCategory);
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
