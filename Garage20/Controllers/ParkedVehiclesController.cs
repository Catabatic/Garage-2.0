using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Garage20.DataAccess;
using Garage20.Models;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace Garage20.Controllers
{
    public class ParkedVehiclesController : Controller
    {
        private GarageContext db = new GarageContext();

        // GET: ParkedVehicles
        public ActionResult Index()
        {
            return View(db.ParkedVehicles.ToList());
        }
        public ActionResult SearchVehicle()
        {
            return View();
        }

        /*The search method. Allows you to search for any vehicle with a RegNr*/
        public ActionResult Search(string Search)
        {
            var result = db.ParkedVehicles.Where(v => v.RegNr == Search);
            if (!result.Any())
            {
                ViewBag.Description = "Could not find a vehicle with RegNr: " + Search;
            }
            return View("Index",result?.ToList());
        }

        //public ActionResult Verify(string Verify)
        //{
        //    var vehicles = db.ParkedVehicles.Where(v => v.Verification == Verify);
        //    if (vehicles.Any())
        //    {
        //        db.ParkedVehicles.Remove(vehicles.First());
        //        db.SaveChanges();
        //    }
        //    return RedirectToAction("Index");
        //}

        // GET: ParkedVehicles/Details/5
        public ActionResult Receipt(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkedVehicle parkedVehicle = db.ParkedVehicles.Find(id);
            if (parkedVehicle == null)
            {
                return HttpNotFound();
            }

            parkedVehicle.CheckOutTime = DateTime.Parse(DateTime.Now.ToString("g"));
            TimeSpan? ParkingDuration = parkedVehicle.CheckOutTime - parkedVehicle.CheckInTime;
            parkedVehicle.AmountFee = 5 * (int)Math.Ceiling(ParkingDuration?.TotalMinutes / 10 ?? 0);

            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ParkedVehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        /* AmountFee is no longer editable. It will not be calculated automatically from Views > ParkedVehicles > Index, Line: 71 (Linus)*/
        public ActionResult Create([Bind(Include = "Id,RegNr,Color,Brand,Model,WheelsAmount,VehicleType,CheckInTime")] ParkedVehicle parkedVehicle)
        {
            var vehicle = db.ParkedVehicles.Where(v => v.RegNr == parkedVehicle.RegNr);
            if (ModelState.IsValid && !vehicle.Any())
            {
                /*CheckInTime is now being defined by the user's current time when the user parks a car (Linus)*/
                parkedVehicle.CheckInTime = DateTime.Parse(DateTime.Now.ToString("g"));

                /*Verification random number generator*/
                //var ran = new Random();
                //while (true){
                //        do
                //        {
                //            parkedVehicle.Verification += ran.Next(0, 9);
                //        } while (parkedVehicle.Verification.Length != 4);
                //    var vehicles = db.ParkedVehicles.Where(v => v.Verification == parkedVehicle.Verification);
                //    if (!vehicles.Any())
                //    {
                //        break;
                //    }
                //    parkedVehicle.Verification = "";
                //}

                db.ParkedVehicles.Add(parkedVehicle);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Warning = "There is already a car with the same RegNr in the garage!";
            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkedVehicle parkedVehicle = db.ParkedVehicles.Find(id);
            if (parkedVehicle == null)
            {
                return HttpNotFound();
            }
            return View(parkedVehicle);
        }

        // POST: ParkedVehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        /* AmountFee is no longer editable. It will not be calculated automatically from Views > ParkedVehicles > Index, Line: 71 (Linus)*/
        public ActionResult Edit([Bind(Include = "Id,RegNr,Color,Brand,Model,WheelsAmount,VehicleType,CheckInTime")] ParkedVehicle parkedVehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parkedVehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkedVehicle parkedVehicle = db.ParkedVehicles.Find(id);
            if (parkedVehicle == null)
            {
                return HttpNotFound();
            }

            parkedVehicle.CheckOutTime = DateTime.Parse(DateTime.Now.ToString("g"));
            TimeSpan? ParkingDuration = parkedVehicle.CheckOutTime - parkedVehicle.CheckInTime;
            parkedVehicle.AmountFee = 5 * (int)Math.Ceiling(ParkingDuration?.TotalMinutes / 10 ?? 0);

            return View(parkedVehicle);
        }

        // POST: ParkedVehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ParkedVehicle parkedVehicle = db.ParkedVehicles.Find(id);
            db.ParkedVehicles.Remove(parkedVehicle);
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
