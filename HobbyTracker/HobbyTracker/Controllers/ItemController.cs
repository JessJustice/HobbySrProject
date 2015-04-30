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
    public class ItemController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Item
        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DescriptionSortParm = sortOrder == "Description" ? "desc_desc" : "Description";
            ViewBag.GenreSortParm = sortOrder == "Genre" ? "genre_desc" : "Genre";
            var items = from s in db.Items
                        select s;


            if (!String.IsNullOrEmpty(searchString))
            {
                  items = items.Where(s => s.Genre.GenreName.Contains(searchString));
            }


            switch (sortOrder)
            {
                case "name_desc":
                    items = items.OrderByDescending(s => s.ItemName);
                    break;
                case "Description":
                    items = items.OrderBy(s => s.ItemDesc);
                    break;
                case "desc_desc":
                    items = items.OrderByDescending(s => s.ItemDesc);
                    break;

                case "Genre":
                    items = items.OrderBy(s => s.GenreID);
                    break;
                case "genre_desc":
                    items = items.OrderByDescending(s => s.GenreID);
                    break;
                default:
                    items = items.OrderBy(s => s.ItemName);
                    break;
            }
            return View(items.ToList());
        }

        // GET: Item/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: Item/Create
        public ActionResult Create()
        {
            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "GenreName");
            return View();
        }

        // POST: Item/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemID,ItemName,ItemDesc,GenreID")] Item item)
        {
            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "GenreName", item.GenreID);
            var itemName = (from n in db.Items
                                  select n.ItemName);
            var itemDesc = (from n in db.Items
                            select n.ItemDesc);
            var itemGenre = (from n in db.Items
                             select n.GenreID);

            if(itemName.Contains(item.ItemName) == false || itemDesc.Contains(item.ItemDesc) == false || itemGenre.Contains(item.GenreID) == false){

                var key = User.Identity.GetUserId();
                var collCheck = (from s in db.Collections
                                where s.User.Id == key && s.GenreID == item.GenreID
                                select s.CollectionID);
                
            if (ModelState.IsValid)
            {
                db.Items.Add(item);
                db.SaveChanges();
          
                TempData["passItem"] = item;
                if (collCheck == null)
                {
                    return RedirectToAction("Index", "About");
                }

                return RedirectToAction("Create2", "CollectionItem"); //, new { name = itemName });
            }
        }
            else{
                ModelState.AddModelError("", "The item you are trying to add already exisits.");
                return View();
            }
                   
            
            return View(item);
        }

        // GET: Item/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "GenreName", item.GenreID);
            return View(item);
        }

        // POST: Item/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemID,ItemName,ItemDesc,GenreID")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "GenreName", item.GenreID);
            return View(item);
        }

        // GET: Item/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Item/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Item item = db.Items.Find(id);
            db.Items.Remove(item);
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
