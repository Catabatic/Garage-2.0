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

        /*The search method. Allows you to search for any vehicle with a RegNr*/
        public ActionResult Search(string Search)
        {
            var result = from v in db.ParkedVehicles
                         where v.RegNr == Search
                         select v;

            if (!result.Any())
            {
                ViewBag.Description = "Could not find a vehicle with RegNr: " + Search;
                return View(result?.ToList());
            }
            return View(result?.ToList());
        }

        // GET: ParkedVehicles/Details/5
        public ActionResult Details(int? id)
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
            var vehicle = (from v in db.ParkedVehicles
                           where v.RegNr == parkedVehicle.RegNr
                           select v.RegNr);

            if (ModelState.IsValid && !vehicle.Any())
            {
                /*CheckInTime is now being defined by the user's current time when the user parks a car (Linus)*/
                parkedVehicle.CheckInTime = DateTime.Parse(DateTime.Now.ToString("g"));
                db.ParkedVehicles.Add(parkedVehicle);
                db.SaveChanges();
                return RedirectToAction("Index","Home");
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

            parkedVehicle.CheckOutTime = DateTime.Now;
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
