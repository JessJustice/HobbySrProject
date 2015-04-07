using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HobbyTracker.Models;
using HobbyTracker.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HobbyTracker.Controllers
{
    public class CollectionItemController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
      //   private ApplicationDbContext db;
       private UserManager<ApplicationUser> manager;
       // private Item item;

        public CollectionItemController()
        {
            db = new ApplicationDbContext();
            manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
        }
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
            // ************** If you make changes here, be sure to check Create2 and Edit for complete change set*********
           

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
            // ************** If you make changes here, be sure to check Create2 and Edit for complete change set*********
            ViewBag.CollectionID = new SelectList(db.Collections, "CollectionID", "CollectionName", collectionItem.CollectionID);
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "ItemName", collectionItem.ItemID);

            var currentUser = manager.FindById(User.Identity.GetUserId());
            var testCollection = (from n in db.Collections 
                                  where collectionItem.CollectionID == n.CollectionID 
                                  select n.GenreID).First();
            var testItem = (from s in db.Items 
                            where collectionItem.ItemID == s.ItemID 
                            select s.GenreID).First();

         

            if (testCollection.Equals(testItem))
            {
                if (ModelState.IsValid)
                {
                    collectionItem.User = manager.FindById(User.Identity.GetUserId());
                    db.CollectionItems.Add(collectionItem);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Collection");
                }


                //  return View(collectionItem);
                return RedirectToAction("Index", "Collection");
            }
            else
            {
                
                ModelState.AddModelError("", "Your collection genre and item genre do not match.");
                return View();
               // return RedirectToAction("Index", "Collection");


            }
        }

        // GET: CollectionItem/Create2
        [Authorize]
        public ActionResult Create2()
        {

            // ************** If you make changes here, be sure to check Create1 and Edit for complete change set*********
           
            ViewBag.CollectionID = new SelectList(db.Collections, "CollectionID", "CollectionName");
     
            return View();
        }

        // POST: CollectionItem/Create2
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create2([Bind(Include = "CollectionItemID,CollectionID,ItemID")] CollectionItem collectionItem)
        {
            // ************** If you make changes here, be sure to check Create1 and Edit for complete change set*********
           
            Item newItem = TempData["passItem"] as Item;
         
            collectionItem.ItemID = newItem.ItemID;

            ViewBag.CollectionID = new SelectList(db.Collections, "CollectionID", "CollectionName", collectionItem.CollectionID);
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "ItemName", collectionItem.ItemID);

            var currentUser = manager.FindById(User.Identity.GetUserId());
            var testCollection = (from n in db.Collections
                                  where collectionItem.CollectionID == n.CollectionID
                                  select n.GenreID).First();
       
            var testItem = (from s in db.Items
                            where newItem.ItemID == s.ItemID
                            select s.GenreID).First();


            if (testCollection.Equals(testItem))
            {
                if (ModelState.IsValid)
                {
                    collectionItem.User = manager.FindById(User.Identity.GetUserId());
                    db.CollectionItems.Add(collectionItem);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Collection");
                }


                //  return View(collectionItem);
                return RedirectToAction("Index", "Collection");
            }
            else
            {

                ModelState.AddModelError("", "Your collection genre and item genre do not match.");
                return View();
                // return RedirectToAction("Index", "Collection");

            }
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
