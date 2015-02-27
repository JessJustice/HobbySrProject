using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HobbyTracker.DAL;
using HobbyTracker.Models;
using HobbyTracker.ViewModels;

namespace HobbyTracker.Controllers
{
    public class UserController : Controller
    {
        private HobbyContext db = new HobbyContext();

        // GET: User
        public ActionResult Index(int? id, int? collectionID)
        {
            var viewModel = new UserIndexData();
            viewModel.Users = db.Users
                .Include(u => u.Collections)
                .OrderBy(u => u.UserName);

            if(id != null)
            {
                ViewBag.UserId = id.Value;
                viewModel.Collections = viewModel.Users.Where(u => u.UserID == id.Value).Single().Collections;
            }

            if (collectionID != null)
            {
                ViewBag.CollectionID = collectionID.Value;
                viewModel.CollectionItems = viewModel.Collections.Where(c => c.CollectionID == collectionID).Single().CollectionItems;
            }

            return View(viewModel);
        }

        // GET: User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            
            if (user == null)
            {
                return HttpNotFound();
            }

            return View(user);
        }

        public ActionResult UserPage()
        {
            var userEmail = HttpContext.User.Identity.Name;
            string[] nameArray = userEmail.Split('@');
            string userName = nameArray[0];

            if (userName == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var viewModel = new UserIndexData();

            viewModel.Users = db.Users
                .Include(u => u.Collections)
                .OrderBy(u => u.UserName);

            if (userName != null)
                {
                ViewBag.UserName = userName;
                viewModel.Collections = viewModel.Users.Where(u => u.UserName == userName).Single().Collections;
                }

            //User user = db.Users.Find(userName);
            
            //if (user == null)
            //{
            //    return HttpNotFound();
            //}

            return View(viewModel);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,UserName")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,UserName")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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
