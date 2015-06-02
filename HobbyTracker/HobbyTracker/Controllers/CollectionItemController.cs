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
       private UserManager<ApplicationUser> manager;

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
        public ActionResult Details(string sortOrder, string search, int? id)
        {
            
         
           var collectionItems = from s in db.CollectionItems
                             where s.CollectionID == id
                             select s;
           

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CollectionItem collectionItem = db.CollectionItems.Find(id);
            if (collectionItem == null)
            {
                return HttpNotFound();
            }

            if (!String.IsNullOrEmpty(search))
            {
                collectionItems = collectionItems.Where(s => s.Item.ItemName.Contains(search)
                    || s.Note.Contains(search) || s.Item.ItemDesc.Contains(search));
              //  collectionItems = collectionItems.Where(s => s..Contains(search));
            }

            //Sorting
         

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DescSortParm = sortOrder == "Description" ? "description_desc" : "Description";
            ViewBag.NoteSortParm = sortOrder == "Note" ? "note_desc" : "Note";
            ViewBag.OwnSortParm = sortOrder == "Own" ? "own_desc" : "Own";
            switch (sortOrder)
            {
                case "name_desc":
                    collectionItems = collectionItems.OrderByDescending(s => s.Item.ItemName);
                    break;
                case "Descritpion":
                    collectionItems = collectionItems.OrderBy(s => s.Item.ItemDesc);
                    break;
                case "description_desc":
                    collectionItems = collectionItems.OrderByDescending(s => s.Item.ItemDesc);
                    break;
                case "Note":
                    collectionItems = collectionItems.OrderBy(s => s.Note);
                    break;
                case "note_desc":
                    collectionItems = collectionItems.OrderByDescending(s => s.Note);
                    break;
                case "Own":
                    collectionItems = collectionItems.OrderBy(s => s.IOwn);
                    break;
                case "own_desc":
                    collectionItems = collectionItems.OrderByDescending(s => s.IOwn);
                    break;
                default:
                    collectionItems = collectionItems.OrderBy(s => s.Item.ItemName);
                    break;
            }
            return View(collectionItems.ToList());
        }

        public ActionResult Details2(string sortOrder, string search, int? id)
        {
           
            var collection2 = from s in db.CollectionItems
                              where s.CollectionID == id
                              select s;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CollectionItem collectionItem = db.CollectionItems.Find(id);
            if (collectionItem == null)
            {
                return HttpNotFound();
            }


            if (!String.IsNullOrEmpty(search))
            {
                collection2 = collection2.Where(s => s.Item.ItemName.Contains(search)
                    || s.Item.ItemDesc.Contains(search));
  
            }

            //Sorting


            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DescSortParm = sortOrder == "Description" ? "description_desc" : "Description";

            switch (sortOrder)
            {
                case "name_desc":
                    collection2 = collection2.OrderByDescending(s => s.Item.ItemName);
                    break;
                case "Description":
                    collection2 = collection2.OrderBy(s => s.Item.ItemDesc);
                    break;
                case "description_desc":
                    collection2 = collection2.OrderByDescending(s => s.Item.ItemDesc);
                    break;
                default:
                    collection2 = collection2.OrderBy(s => s.Item.ItemName);
                    break;
            }

            return View(collection2.ToList());
        }

        // GET: CollectionItem/Create   For adding items from select lists
        [Authorize]
        public ActionResult Create(int? id)
        {
            // ************** If you make changes here, be sure to check Create2 and Edit for complete change set*********

            var key = User.Identity.GetUserId();

            var collGenre = (from s in db.Collections
                             where s.CollectionID == id
                             select s).First();
           ViewBag.ItemID = new SelectList(db.Items.Where(c => c.GenreID == collGenre.GenreID), "ItemID", "ItemName");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CollectionItem collectionItem = db.CollectionItems.Find(id);
            if (collectionItem == null)
            {
                return HttpNotFound();
            }
         //   return View(collection);
            return View();
        }

        // POST: CollectionItem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CollectionItemID,CollectionID,ItemID,Note,IOwn,Rating")] CollectionItem collectionItem, int id)
        {
            // ************** If you make changes here, be sure to check Create2 and Edit for complete change set*********
            var key = User.Identity.GetUserId();
           ViewBag.ItemID = new SelectList(db.Items.Where(c => c.GenreID == id), "ItemID", "ItemName", collectionItem.ItemID);
           collectionItem.CollectionID = id;


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

        // GET: CollectionItem/Create2       Used directly after creating a new item, item preselected to add
        [Authorize]
        public ActionResult Create2()
        {

            // ************** If you make changes here, be sure to check Create1 and Edit for complete change set*********
            var key = User.Identity.GetUserId();
           

            Item newItem = TempData["passItem"] as Item;
            ViewBag.ItemID = newItem.ItemID;
            ViewBag.CollectionID = new SelectList(db.Collections.Where(c => c.User.Id == key && c.GenreID == newItem.GenreID), "CollectionID", "CollectionName");
           var collCheck = from s in db.Collections
                           where s.User.Id == key && s.GenreID ==  newItem.GenreID 
                           select s.CollectionID;
            if (collCheck == null)
            {
                return RedirectToAction("Index", "Community");
            }
            
            TempData["passItem2"] = newItem;
           return View();
        }

        // POST: CollectionItem/Create2
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create2([Bind(Include = "CollectionItemID,CollectionID,ItemID,Note,IOwn,Rating")] CollectionItem collectionItem)
        {
            // ************** If you make changes here, be sure to check Create1 and Edit for complete change set*********
           
            Item newItem = TempData["passItem2"] as Item;

             collectionItem.ItemID = newItem.ItemID;
      

            var key = User.Identity.GetUserId();
            ViewBag.CollectionID = new SelectList(db.Collections.Where(c => c.User.Id == key && c.GenreID == newItem.GenreID), "CollectionID", "CollectionName", collectionItem.CollectionID);
            ViewBag.ItemID = new SelectList(db.Items.Where(c => c.Collection.GenreID == newItem.GenreID), "ItemID", "ItemName", collectionItem.ItemID);

            var currentUser = manager.FindById(User.Identity.GetUserId());
            var testCollection = (from n in db.Collections
                                  where collectionItem.CollectionID == n.CollectionID
                                  select n.GenreID).First();
       
            var testItem = (from s in db.Items
                            where newItem.ItemID == s.ItemID
                            select s.GenreID).First();

            var collCheck = from s in db.Collections
                            where s.User.Id == key && s.GenreID == newItem.GenreID
                            select s.CollectionID;
            if (collCheck == null)
            {
                return RedirectToAction("Index", "Community");
            }

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
                return View(collectionItem);
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
       
            return View(collectionItem);
        }

        // POST: CollectionItem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CollectionItemID,CollectionID, ItemID, Note,IOwn,Rating")] CollectionItem collectionItem)
        {
            //This is a wierd instance!!!! collectionItem is not holding its values, so this is a hack around. Jess
            var holdNote = collectionItem.Note;
            var holdOwn = collectionItem.IOwn;

            CollectionItem newItem = (from s in db.CollectionItems
                               where collectionItem.CollectionItemID == s.CollectionItemID
                               select s).First();

            collectionItem = newItem;
            collectionItem.Note = holdNote;
            collectionItem.IOwn = holdOwn;
            if (ModelState.IsValid)
            {
                db.Entry(collectionItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Collection");
            }
 
            ViewBag.CollectionID = collectionItem.CollectionID;
            ViewBag.ItemID = collectionItem.ItemID;
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
