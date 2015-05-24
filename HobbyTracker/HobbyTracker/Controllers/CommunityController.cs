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

namespace HobbyTracker.Controllers
{
    public class CommunityController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Community
        //public ActionResult Index()
             public ActionResult Index(int? id, int? commentID, int? communityID, string sortOrder, string searchString)
        {
            var viewModel = new CommunityIndexData();
            viewModel.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name_desc" : "";

            switch (sortOrder)
            {
                case "Name_desc":
                    viewModel.Communities = db.Communities.OrderByDescending(i => i.CommunityName);
                    break;
                default:
                    viewModel.Communities = db.Communities.OrderBy(i => i.CommunityName);
                    break;
            }

            //String CommName = null;
            
            //if (id != null)
            //{
            //    //CommName is the name of the community that is being selected. id.value is the community id
            //    CommName = (from n in db.Communities
            //                      where n.CommunityID == id.Value 
            //                      select n.CommunityName).First();
            //    ViewBag.CommunityID = id.Value;
            //    ViewBag.CommunityName = CommName;
            //    viewModel.Comments = viewModel.Communities.Where(
            //        i => i.CommunityID == id.Value).Single().Comments.Take(5);

            //    //pick up CommunID/Name for use in comment create
            //    var CommuID = id.Value;
            //    TempData["commuID"] = CommuID;
            //}

            //String CommDesc = null;
            //if(id != null) // grab the information from the database when it is clicked
            //{
            //    CommDesc = (from n in db.Communities
            //                where n.CommunityID == id.Value
            //                select n.DescriptionField).First(); //always returns an array, so take the first element
            //    ViewBag.CommunityID = id.Value;
            //    ViewBag.DescriptionField = CommDesc;
            //}
            
            if (commentID != null)
            {
                ViewBag.CommentID = commentID.Value;
            }

            if(communityID != null)
            {
                ViewBag.CommunityID = communityID.Value;
            }

            return View(viewModel);
        }

        // GET: Community/Details/5
        [Authorize]
        public ActionResult Details(string search, int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Community community = db.Communities.Find(id);
            if (community == null)
            {
                return HttpNotFound();
            }
            //pick up CommunID/Name for use in comment create
            var CommuID = id.Value;
            TempData["commuID"] = CommuID;

            //search
            var user = from s in db.Users
                       select s;
            ViewBag.comments = from c in db.Comments
                               where c.CommunityID == id
                               select c;
            
            if (!String.IsNullOrEmpty(search))
            {         
                ViewBag.comments = from c in db.Comments
                                 where c.CommentUser.Contains(search) && c.CommunityID == id
                                 select c;
                var   community2 = db.Communities.Where(c => c.CommunityID == id );
                return View(community);
            }
        


            return View(community);
        }

        // GET: Community/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Community/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CommunityID,CommunityName,DescriptionField,CommunityLoc")] Community community)
        {
            if (ModelState.IsValid)
            {
                db.Communities.Add(community);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(community);
        }

        // GET: Community/Edit/5
        [Authorize] 
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Community community = db.Communities.Find(id);
            if (community == null)
            {
                return HttpNotFound();
            }
            return View(community);
        }

        // POST: Community/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CommunityID,CommunityName,DescriptionField,CommunityLoc")] Community community)
        {
            if (ModelState.IsValid)
            {
                db.Entry(community).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(community);
        }

        // GET: Community/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Community community = db.Communities.Find(id);
            if (community == null)
            {
                return HttpNotFound();
            }
            return View(community);
        }

        // POST: Community/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Community community = db.Communities.Find(id);
            db.Communities.Remove(community);
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
