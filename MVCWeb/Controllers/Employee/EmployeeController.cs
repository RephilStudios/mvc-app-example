using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCWeb.Models;

namespace MVCWeb.Controllers.Employee
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeContext db = new EmployeeContext();


        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            // Here should be the business logic in the buisness tier
            // Instead since this will never change ill just manipulate data directly
            return View(db.Employees);
        }

        #region  Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Models.Employee employee)
        {
            // Here should be the business logic in the buisness tier
            // Instead since this will never change ill just manipulate data directly
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);

        }
        #endregion

        #region Retrieve
        [HttpGet]
        public ActionResult Details(int? id)
        {
            // Here should be the business logic in the buisness tier
            // Instead since this will never change ill just manipulate data directly
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);

            Models.Employee Employee = db.Employees.Find(id);
            if (Employee == null)
            {
                return HttpNotFound();
            }
            return View(Employee);
        }
        #endregion

        #region Update
        [HttpGet]
        public ActionResult Edit(int id)
        {
            // Here should be the business logic in the buisness tier
            // Instead since this will never change ill just manipulate data directly
            Models.Employee employee = db.Employees.Find(id);

            return View(employee);
        }

        [HttpPost]
        public ActionResult Edit(Models.Employee employee)
        {
            // Here should be the business logic in the buisness tier
            // Instead since this will never change ill just manipulate data directly
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(employee).State = EntityState.Modified;
                    db.SaveChanges();
                    RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
        #endregion

        #region Delete
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            // Here should be the business logic in the buisness tier
            // Instead since this will never change ill just manipulate data directly
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }

            return View(employee);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            // Here should be the business logic in the buisness tier
            // Instead since this will never change ill just manipulate data directly
            try
            {
                if (ModelState.IsValid)
                {
                    if (id == null)
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    Models.Employee employee = db.Employees.Find(id);

                    if (employee == null)
                    {
                        return HttpNotFound();
                    }

                    db.Employees.Remove(employee);
                    db.SaveChanges();

                }
                return RedirectToAction("Index", "Employee");
            }
            catch
            {
                return View();
            }
        }

        #endregion
    }
}
