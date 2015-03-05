using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HobbyTracker.Models;

namespace HobbyTracker.Controllers
{
    public class NewUserModelController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: NewUserModel
        public ActionResult Index()
        {
            return View(db.NewUserModels.ToList());
        }

        // GET: NewUserModel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewUserModel newUserModel = db.NewUserModels.Find(id);
            if (newUserModel == null)
            {
                return HttpNotFound();
            }
            return View(newUserModel);
        }

        // GET: NewUserModel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NewUserModel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NewUserModelID")] NewUserModel newUserModel)
        {
            if (ModelState.IsValid)
            {
                db.NewUserModels.Add(newUserModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(newUserModel);
        }

        // GET: NewUserModel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewUserModel newUserModel = db.NewUserModels.Find(id);
            if (newUserModel == null)
            {
                return HttpNotFound();
            }
            return View(newUserModel);
        }

        // POST: NewUserModel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NewUserModelID")] NewUserModel newUserModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newUserModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newUserModel);
        }

        // GET: NewUserModel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewUserModel newUserModel = db.NewUserModels.Find(id);
            if (newUserModel == null)
            {
                return HttpNotFound();
            }
            return View(newUserModel);
        }

        // POST: NewUserModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NewUserModel newUserModel = db.NewUserModels.Find(id);
            db.NewUserModels.Remove(newUserModel);
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
