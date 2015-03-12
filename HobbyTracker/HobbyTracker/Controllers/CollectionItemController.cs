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
    public class CollectionItemController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CollectionItem
        public ActionResult Index()
        {
            var collectionItems = db.CollectionItems.Include(c => c.Collection).Include(c => c.Item);
            return View(collectionItems.ToList());
        }


        // GET: CollectionItem/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CollectionItem collectionItem = db.CollectionItems.Find(id);
            if (collectionItem == null)
            {
                return HttpNotFound();
            }
            return View(collectionItem);
        }

        // GET: CollectionItem/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.CollectionID = new SelectList(db.Collections, "CollectionID", "CollectionName");
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "ItemName");
            return View();
        }

        // POST: CollectionItem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CollectionItemID,CollectionID,ItemID")] CollectionItem collectionItem)
        {
            if (ModelState.IsValid)
            {
                db.CollectionItems.Add(collectionItem);
                db.SaveChanges();
                return RedirectToAction("Index", "Collection");
            }

            ViewBag.CollectionID = new SelectList(db.Collections, "CollectionID", "CollectionName", collectionItem.CollectionID);
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "ItemName", collectionItem.ItemID);
          //  return View(collectionItem);
            return RedirectToAction("Index", "Collection");
        }

        // GET: CollectionItem/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CollectionItem collectionItem = db.CollectionItems.Find(id);
            if (collectionItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.CollectionID = new SelectList(db.Collections, "CollectionID", "CollectionName", collectionItem.CollectionID);
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "ItemName", collectionItem.ItemID);
            return View(collectionItem);
        }

        // POST: CollectionItem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CollectionItemID,CollectionID,ItemID")] CollectionItem collectionItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(collectionItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CollectionID = new SelectList(db.Collections, "CollectionID", "CollectionName", collectionItem.CollectionID);
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "ItemName", collectionItem.ItemID);
            return View(collectionItem);
        }

        // GET: CollectionItem/Delete/5
       [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CollectionItem collectionItem = db.CollectionItems.Find(id);
            if (collectionItem == null)
            {
                return HttpNotFound();
            }
            return View(collectionItem);
        }

        // POST: CollectionItem/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CollectionItem collectionItem = db.CollectionItems.Find(id);
            db.CollectionItems.Remove(collectionItem);
            db.SaveChanges();
            return RedirectToAction("Index", "Collection");
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
