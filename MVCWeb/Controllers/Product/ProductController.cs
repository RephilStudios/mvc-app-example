using MVCWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVCWeb.Controllers.Product
{
    public class ProductController : Controller
    {
        private readonly ProductContext db = new ProductContext();


        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            // Here should be the business logic in the buisness tier
            // Instead since this will never change ill just manipulate data directly
            return View(db.Products);
        }

        #region  Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Models.Product product)
        {
            // Here should be the business logic in the buisness tier
            // Instead since this will never change ill just manipulate data directly
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);

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

            Models.Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        #endregion

        #region Update
        [HttpGet]
        public ActionResult Edit(int id)
        {
            // Here should be the business logic in the buisness tier
            // Instead since this will never change ill just manipulate data directly
            Models.Product product = db.Products.Find(id);

            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Models.Product product)
        {
            // Here should be the business logic in the buisness tier
            // Instead since this will never change ill just manipulate data directly
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(product).State = EntityState.Modified;
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
            Models.Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
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
                    Models.Product product = db.Products.Find(id);

                    if (product == null)
                    {
                        return HttpNotFound();
                    }

                    db.Products.Remove(product);
                    db.SaveChanges();

                }
                return RedirectToAction("Index", "Product");
            }
            catch
            {
                return View();
            }
        }

#endregion
    }
}
