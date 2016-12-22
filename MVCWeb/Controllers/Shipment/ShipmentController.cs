using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCWeb.Models;

namespace MVCWeb.Controllers.Shipment
{
    public class ShipmentController : Controller
    {
        private readonly ShipmentContext db = new ShipmentContext();


        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            // Here should be the business logic in the buisness tier
            // Instead since this will never change ill just manipulate data directly
            return View(db.Shipments);
        }

        #region  Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Models.Shipment shipment)
        {
            // Here should be the business logic in the buisness tier
            // Instead since this will never change ill just manipulate data directly
            if (ModelState.IsValid)
            {
                db.Shipments.Add(shipment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shipment);

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

            Models.Shipment shipment = db.Shipments.Find(id);
            if (shipment == null)
            {
                return HttpNotFound();
            }
            return View(shipment);
        }
        #endregion

        #region Update
        [HttpGet]
        public ActionResult Edit(int id)
        {
            // Here should be the business logic in the buisness tier
            // Instead since this will never change ill just manipulate data directly
            Models.Shipment shipment = db.Shipments.Find(id);

            return View(shipment);
        }

        [HttpPost]
        public ActionResult Edit(Models.Shipment shipment)
        {
            // Here should be the business logic in the buisness tier
            // Instead since this will never change ill just manipulate data directly
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(shipment).State = EntityState.Modified;
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
            Models.Shipment shipment = db.Shipments.Find(id);
            if (shipment == null)
            {
                return HttpNotFound();
            }

            return View(shipment);
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
                    Models.Shipment shipment = db.Shipments.Find(id);

                    if (shipment == null)
                    {
                        return HttpNotFound();
                    }

                    db.Shipments.Remove(shipment);
                    db.SaveChanges();

                }
                return RedirectToAction("Index", "Shipment");
            }
            catch
            {
                return View();
            }
        }

        #endregion
    }
}
