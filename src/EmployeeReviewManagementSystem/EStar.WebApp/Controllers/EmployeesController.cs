using EStar.WebApp.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace EStar.WebApp.Controllers
{
    public class EmployeesController : Controller
    {
        private EStarDBEntities db = new EStarDBEntities();

        // GET: Employees
        public ActionResult Index()
        {
            var employees = db.Employees.Include(e => e.Department);
            return View(employees.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int id)
        {
            // Employee Rating
            ViewBag.EmployeeHighestRating = EmployeeTotalScore(id);
            ViewBag.EmployeeRating = EmployeeScore(id);

            // Department Rating
            ViewBag.DepartmenteHighestRating = DepartmentTotalScore(id);
            ViewBag.DepartmentRating = DepartmentScore(id);

            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        //// GET: Employees/Create
        //public ActionResult Create()
        //{
        //    ViewBag.DepartmentID = new SelectList(db.Departments, "ID", "Name");
        //    return View();
        //}

        //// POST: Employees/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ID,Name,Gender,Designation,DepartmentID,YearsOfExperience,Salary,City,Country,Username,Password")] Employee employee)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Employees.Add(employee);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.DepartmentID = new SelectList(db.Departments, "ID", "Name", employee.DepartmentID);
        //    return View(employee);
        //}

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "ID", "Name", employee.DepartmentID);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Gender,Designation,DepartmentID,YearsOfExperience,Salary,City,Country,Username,Password")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "ID", "Name", employee.DepartmentID);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: UserController/SignIn
        public ActionResult SignIn()
        {
            return View();
        }

        // POST: UserController/SignIn/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignIn(Employee model)
        {
            if (ModelState.IsValid)
            {
                var user = db.Employees
                    .Where(x => x.Username == model.Username && x.Password == model.Password)
                    .FirstOrDefault();
                if (user != null)
                {
                    Session["ID"] = user.ID.ToString();
                    Session["UserName"] = user.Username.ToString();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password is Incorrect");
                }
            }
            return View(model);
        }

        // GET: Employees/SignUp
        public ActionResult SignUp()
        {
            ViewBag.DepartmentID = new SelectList(db.Departments, "ID", "Name");
            return View();
        }

        // POST: Employees/SignUp
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp([Bind(Include = "ID,Name,Gender,Designation,DepartmentID,YearsOfExperience,Salary,City,Country,Username,Password")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentID = new SelectList(db.Departments, "ID", "Name", employee.DepartmentID);
            return View(employee);
        }
        public ActionResult SignOut()
        {
            Session.Clear();
            return RedirectToAction(nameof(SignIn));
        }
        public int EmployeeTotalScore(int employeeID)
        {
            var totalScore = 2 * (db.Reviews
                .Where(x => x.EmployeeID == employeeID)
                .Count());
            return totalScore;
        }
        public int EmployeeScore(int employeeID)
        {
            var answerScore = db.Reviews
                .Where(x => x.EmployeeID == employeeID)
                .Select(x => x.Answer.Score)
                .Sum();

            return answerScore;
        }
        public int DepartmentTotalScore(int employeeID)
        {
            var employee = db.Employees.Where(x => x.ID == employeeID).FirstOrDefault();
            var totalScore = 2 * (db.Reviews
                .Where(x => x.DepartmentID == employee.DepartmentID)
                .Count());
            return totalScore;
        }

        public int DepartmentScore(int employeeID)
        {
            var employee = db.Employees.Where(x => x.ID == employeeID).FirstOrDefault();
            var answerScore = db.Reviews
                .Where(x => x.DepartmentID == employee.DepartmentID)
                .Select(x => x.Answer.Score)
                .Sum();
            return answerScore;
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
