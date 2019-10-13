using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Fit_5032_NewCar.Models;

namespace Fit_5032_NewCar.Controllers
{
    public class Order_LineController : Controller
    {
        private NewCar db = new NewCar();

        // GET: Order_Line
        public ActionResult Index()
        {
            var order_Line = db.Order_Line.Include(o => o.Booking).Include(o => o.Car);
            return View(order_Line.ToList());
        }

        // GET: Order_Line/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_Line order_Line = db.Order_Line.Find(id);
            if (order_Line == null)
            {
                return HttpNotFound();
            }
            return View(order_Line);
        }

        // GET: Order_Line/Create
        public ActionResult Create()
        {
            ViewBag.BookingBookingID = new SelectList(db.Bookings, "BookingID", "Contact_PhoneNumber");
            ViewBag.OlCarID = new SelectList(db.Cars, "CarID", "CarVin");
            return View();
        }

        // POST: Order_Line/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookingBookingID,OlCarID,ReturnDate,ReturnStatus")] Order_Line order_Line)
        {
            if (ModelState.IsValid)
            {
                db.Order_Line.Add(order_Line);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BookingBookingID = new SelectList(db.Bookings, "BookingID", "Contact_PhoneNumber", order_Line.BookingBookingID);
            ViewBag.OlCarID = new SelectList(db.Cars, "CarID", "CarVin", order_Line.OlCarID);
            return View(order_Line);
        }

        // GET: Order_Line/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_Line order_Line = db.Order_Line.Find(id);
            if (order_Line == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookingBookingID = new SelectList(db.Bookings, "BookingID", "Contact_PhoneNumber", order_Line.BookingBookingID);
            ViewBag.OlCarID = new SelectList(db.Cars, "CarID", "CarVin", order_Line.OlCarID);
            return View(order_Line);
        }

        // POST: Order_Line/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookingBookingID,OlCarID,ReturnDate,ReturnStatus")] Order_Line order_Line)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order_Line).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookingBookingID = new SelectList(db.Bookings, "BookingID", "Contact_PhoneNumber", order_Line.BookingBookingID);
            ViewBag.OlCarID = new SelectList(db.Cars, "CarID", "CarVin", order_Line.OlCarID);
            return View(order_Line);
        }

        // GET: Order_Line/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_Line order_Line = db.Order_Line.Find(id);
            if (order_Line == null)
            {
                return HttpNotFound();
            }
            return View(order_Line);
        }

        // POST: Order_Line/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order_Line order_Line = db.Order_Line.Find(id);
            db.Order_Line.Remove(order_Line);
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
