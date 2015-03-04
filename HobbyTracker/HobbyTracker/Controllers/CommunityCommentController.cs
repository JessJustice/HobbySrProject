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
    public class CommunityCommentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CommunityComment
        public ActionResult Index()
        {
            var communityComments = db.CommunityComments.Include(c => c.Comment).Include(c => c.Community);
            return View(communityComments.ToList());
        }

        // GET: CommunityComment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommunityComment communityComment = db.CommunityComments.Find(id);
            if (communityComment == null)
            {
                return HttpNotFound();
            }
            return View(communityComment);
        }

        // GET: CommunityComment/Create
        public ActionResult Create()
        {
            ViewBag.CommentID = new SelectList(db.Comments, "CommentID", "TextInput");
            ViewBag.CommunityID = new SelectList(db.Communities, "CommunityID", "CommunityName");
            return View();
        }

        // POST: CommunityComment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CommunityCommentID,CommunityID,CommentID")] CommunityComment communityComment)
        {
            if (ModelState.IsValid)
            {
                db.CommunityComments.Add(communityComment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CommentID = new SelectList(db.Comments, "CommentID", "TextInput", communityComment.CommentID);
            ViewBag.CommunityID = new SelectList(db.Communities, "CommunityID", "CommunityName", communityComment.CommunityID);
            return View(communityComment);
        }

        // GET: CommunityComment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommunityComment communityComment = db.CommunityComments.Find(id);
            if (communityComment == null)
            {
                return HttpNotFound();
            }
            ViewBag.CommentID = new SelectList(db.Comments, "CommentID", "TextInput", communityComment.CommentID);
            ViewBag.CommunityID = new SelectList(db.Communities, "CommunityID", "CommunityName", communityComment.CommunityID);
            return View(communityComment);
        }

        // POST: CommunityComment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CommunityCommentID,CommunityID,CommentID")] CommunityComment communityComment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(communityComment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CommentID = new SelectList(db.Comments, "CommentID", "TextInput", communityComment.CommentID);
            ViewBag.CommunityID = new SelectList(db.Communities, "CommunityID", "CommunityName", communityComment.CommunityID);
            return View(communityComment);
        }

        // GET: CommunityComment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommunityComment communityComment = db.CommunityComments.Find(id);
            if (communityComment == null)
            {
                return HttpNotFound();
            }
            return View(communityComment);
        }

        // POST: CommunityComment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CommunityComment communityComment = db.CommunityComments.Find(id);
            db.CommunityComments.Remove(communityComment);
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
