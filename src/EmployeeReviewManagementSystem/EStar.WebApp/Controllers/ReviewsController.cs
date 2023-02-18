using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EStar.WebApp.Models;

namespace EStar.WebApp.Controllers
{
    public class ReviewsController : Controller
    {
        private EStarDBEntities db = new EStarDBEntities();

        // GET: Reviews
        public ActionResult Index()
        {
            var reviews = db.Reviews.Include(r => r.Answer).Include(r => r.Category).Include(r => r.Department).Include(r => r.Employee).Include(r => r.Question);
            return View(reviews.ToList());
        }

        // GET: Reviews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // GET: Reviews/Create
        public ActionResult Create()
        {
            ViewBag.AnswerID = new SelectList(db.Answers, "ID", "Answer1");
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Category1");
            ViewBag.DepartmentID = new SelectList(db.Departments, "ID", "Name");
            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "Name");
            ViewBag.QuestionID = new SelectList(db.Questions, "ID", "Question1");
            return View();
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DepartmentID,EmployeeID,CategoryID,QuestionID,AnswerID")] Review review)
        {
            if (ModelState.IsValid)
            {
                db.Reviews.Add(review);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AnswerID = new SelectList(db.Answers, "ID", "Answer1", review.AnswerID);
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Category1", review.CategoryID);
            ViewBag.DepartmentID = new SelectList(db.Departments, "ID", "Name", review.DepartmentID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "Name", review.EmployeeID);
            ViewBag.QuestionID = new SelectList(db.Questions, "ID", "Question1", review.QuestionID);
            return View(review);
        }

        // GET: Reviews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            ViewBag.AnswerID = new SelectList(db.Answers, "ID", "Answer1", review.AnswerID);
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Category1", review.CategoryID);
            ViewBag.DepartmentID = new SelectList(db.Departments, "ID", "Name", review.DepartmentID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "Name", review.EmployeeID);
            ViewBag.QuestionID = new SelectList(db.Questions, "ID", "Question1", review.QuestionID);
            return View(review);
        }

        // POST: Reviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DepartmentID,EmployeeID,CategoryID,QuestionID,AnswerID")] Review review)
        {
            if (ModelState.IsValid)
            {
                db.Entry(review).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AnswerID = new SelectList(db.Answers, "ID", "Answer1", review.AnswerID);
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Category1", review.CategoryID);
            ViewBag.DepartmentID = new SelectList(db.Departments, "ID", "Name", review.DepartmentID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "Name", review.EmployeeID);
            ViewBag.QuestionID = new SelectList(db.Questions, "ID", "Question1", review.QuestionID);
            return View(review);
        }

        // GET: Reviews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Review review = db.Reviews.Find(id);
            db.Reviews.Remove(review);
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
