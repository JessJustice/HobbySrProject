using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HobbyTracker.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HobbyTracker.Controllers
{
    public class ActivityController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Activity
        public ActionResult Index()
        {
            string key = null;

            if (User.Identity.GetUserId() != null) //If the current user has an ID
            {
                key = User.Identity.GetUserId(); //The ID of the current user becomes the key
            }

            var activities = db.Activities.Include(c => c.Community);
            return View(activities.ToList());
        }

        // GET: Activity/Details/5
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            string key = null;

            if (User.Identity.GetUserId() != null) //If the current user has an ID
            {
                key = User.Identity.GetUserId(); //The ID of the current user becomes the key
            }

            Activity activity = db.Activities.Find(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            return View(activity);
        }

        [Authorize]
        // GET: Activity/Create
        public ActionResult Create()
        {
            ViewBag.CommunityID = new SelectList(db.Communities, "CommunityID", "CommunityName");
            return View();
        }

        [Authorize]
        // POST: Activity/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ActivityID,ActName,Email,Phone,WillAttend,CommunityID,Username")] Activity activity)
        {
            
            //get the current user name
            string key = null;
            if(User.Identity.GetUserId() != null) //this needed to be != instead of ==
            {
                key = User.Identity.GetUserId(); 
            }
            else
            {
                return Redirect("Account/Register");
            }


            var user = (from s in db.Users
                           where s.Id == key
                           select s).First(); // only one thing in the list so pull the first thing


            activity.UserName = user.UserName;
            activity.Email = user.Email;
            //done getting user name
            
            if (ModelState.IsValid)
            {

                db.Activities.Add(activity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CommunityID = new SelectList(db.Communities, "CommunityID", "CommunityName", activity.CommunityID);
            return View(activity);
        }

        [Authorize]
        // GET: Activity/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity activity = db.Activities.Find(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            ViewBag.CommunityID = new SelectList(db.Communities, "CommunityID", "CommunityName", activity.CommunityID);
            return View(activity);
        }

        [Authorize]
        // POST: Activity/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ActivityID,ActName,Email,Phone,WillAttend,CommunityID,UserName")] Activity activity)
        {
      
            ViewBag.CommunityID = new SelectList(db.Communities, "CommunityID", "CommunityName", activity.CommunityID);
            if (activity.UserName == null)
            {
                activity.UserName = "administrator@hobbytracker.com";
            }

            if (ModelState.IsValid)
            {
                db.Entry(activity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(activity);
        }

        [Authorize]
        // GET: Activity/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity activity = db.Activities.Find(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            return View(activity);
        }

        [Authorize]
        // POST: Activity/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Activity activity = db.Activities.Find(id);
            db.Activities.Remove(activity);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

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
