﻿using System;
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
    public class CollectionController : Controller
    {
       // private ApplicationDbContext db = new ApplicationDbContext();

       private ApplicationDbContext db;
       private UserManager<ApplicationUser> manager;
       // private Item item;

        public CollectionController()
        {
            db = new ApplicationDbContext();
            manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
        }
        // GET: Collection
        // FOr My collections  if you make changes here, look to see if you need to make them index2 as well
        public ActionResult Index(string sortOrder, int? collectionID, bool filterByUser = true )
        {
          

            string key = null;
            
            if (User.Identity.GetUserId() != null) //If the current user has an ID
            {
                key = User.Identity.GetUserId(); //The ID of the current user becomes the key
            }
                else
                {
                    return Redirect("Account/Register");
                }

            var collections = from s in db.Collections
                              select s;
         

            
            // Set up the view model to include some related data
            //var collections2 = new List<Collection>();
            //collections2 = db.Collections
            //    .Include(c => c.User)
            //    .Include(c => c.Genre) // The genre of the collection
            //    .OrderBy(c => c.CollectionID) // Order by the ID number of the collection
            //    .ToList();

            //var collections3 = from a in db.Collections
            //                   selec

            if (filterByUser) collections = collections.Where(c => c.User.Id == key); // Show only the collections

           

            //*************************************************
            //Top half sorting
            //*************************************************
            //var collections = new List<Collection>();

            //collections = db.Collections
            //    .Include(s => s.Genre)
            //    //  .Include(s => s.Private)
            //    //  .Include(s => s.CollectionName)
            //    .ToList();
            
   
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.GenreSortParm = sortOrder == "Genre" ? "genre_desc" : "Genre";
            ViewBag.PrivateSortParm = sortOrder == "Private" ? "private_dec" : "Private";

            switch (sortOrder)
            {
                case "name_desc":
                    collections = collections.OrderByDescending(s => s.CollectionName);
                    break;
                case "Genre":
                    collections = collections.OrderBy(s => s.GenreID);
                    break;
                case "genre_desc":
                    collections = collections.OrderByDescending(s => s.GenreID);
                    break;
                case "Private":
                    collections = collections.OrderBy(s => s.Private);
                    break;
                case "private_desc":
                    collections = collections.OrderByDescending(s => s.Private);
                    break;
                default:
                    collections = collections.OrderBy(s => s.CollectionName);
                    break;
            }
       
            return View(collections.ToList());
        }



  
        // GET: Collection
        //For other collections  if you make changes here, check to see if you need to make changes for index as well!!
        public ActionResult Index2(int? collectionID, bool privacy = true)
        {
            // Create a view model for the related information that needs to be displayed on this page
            var viewModel = new CollectionIndexData();

            // Set up the view model to include some related data
            viewModel.Collections = db.Collections.Where(c => c.Private == false)
                .Include(c => c.User)
                .Include(c => c.Genre) // The genre of the collection
                .OrderBy(c => c.CollectionID); // Order by the ID number of the collection

            if (privacy) viewModel.Collections = viewModel.Collections.Where(c => c.Private == false);

            if (collectionID != null) // Show the collections for the specified user
            {
                ViewBag.CollectionID = collectionID.Value;
                viewModel.CollectionItems = viewModel.Collections.Where(
                    c => c.CollectionID == collectionID).Single().CollectionItems; // Show the items in the collection
            }
            return View(viewModel);
        }

        // GET: Collection/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Collection collection = db.Collections.Find(id);
            if (collection == null)
            {
                return HttpNotFound();
            }
            return View(collection);
        }

     

        // GET: Collection/Create
        public ActionResult Create()
        {
            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "GenreName", "Private");
            return View();
        }

        // POST: Collection/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CollectionID,CollectionName,GenreID,Private")] Collection collection)
        {
            //!!!!!!!! Get the currently logged-in user !!!!!!
            var currentUser = manager.FindById(User.Identity.GetUserId());
            if (ModelState.IsValid)
            {
                collection.User = manager.FindById(User.Identity.GetUserId());
                db.Collections.Add(collection);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            
            return View(collection);
        }

        // GET: Collection/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Collection collection = db.Collections.Find(id);
            if (collection == null)
            {
                return HttpNotFound();
            }
            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "GenreName", collection.GenreID);
            return View(collection);
        }

        // POST: Collection/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CollectionID,CollectionName,GenreID,Private")] Collection collection)
        {
            if (ModelState.IsValid)
            {
                db.Entry(collection).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "GenreName", collection.GenreID);
            return View(collection);
        }

        // GET: Collection/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Collection collection = db.Collections.Find(id);
            if (collection == null)
            {
                return HttpNotFound();
            }
            return View(collection);
        }

        // POST: Collection/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Collection collection = db.Collections.Find(id);
            db.Collections.Remove(collection);
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

        // GET: Item/Create
        public ActionResult CreateItem()
        {
          RedirectToAction("Create,Item");
            return View();
        }
    }
}
