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
    public class VehiclesController : Controller
    {
        private GarageContext db = new GarageContext();

        // GET: Vehicles
        public ActionResult Index()
        {
            ViewBag.VehicleTypeId = new SelectList(db.VehicleType, "Id", "VehicleTypeName");//populate droplist
            var vehicles = db.Vehicles.Include(v => v.Member).Include(v => v.VehicleType);
            return View(vehicles.ToList());
        }

        public ActionResult Search(string Search)
        {
            
            var result = db.Vehicles.Where(v => v.RegNr == Search);
            ViewBag.Searched = "eftersomboolfunkarej";
            if (!result.Any())
            {
                if (Search != "")
                {
                    ViewBag.Description = "Kunde inte hitta fordonet med RegNr: " + Search;
                }
                else
                {
                    ViewBag.Description = "Vänligen ange ett registreringsnummer";
                }
                return View("Index", result?.ToList());
            }

            return View("Index", result.ToList());
        }

        // GET: Vehicles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicles vehicles = db.Vehicles.Find(id);
            if (vehicles == null)
            {
                return HttpNotFound();
            }
            return View(vehicles);
        }

        // GET: Vehicles/Create
        public ActionResult Create()
        {
            ViewBag.MemberId = new SelectList(db.Members, "Id", "FirstName");
            ViewBag.VehicleTypeId = new SelectList(db.VehicleType, "Id", "VehicleTypeName");
            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MemberId,VehicleTypeId,Verification,RegNr,Color,Brand,Model,WheelsAmount,CheckInTime,CheckOutTime,AmountFee")] Vehicles vehicles)
        {
            if (ModelState.IsValid)
            {
                db.Vehicles.Add(vehicles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MemberId = new SelectList(db.Members, "Id", "FirstName", vehicles.MemberId);
            ViewBag.VehicleTypeId = new SelectList(db.VehicleType, "Id", "VehicleTypeName", vehicles.VehicleTypeId);
            return View(vehicles);
        }

        // GET: Vehicles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicles vehicles = db.Vehicles.Find(id);
            if (vehicles == null)
            {
                return HttpNotFound();
            }
            ViewBag.MemberId = new SelectList(db.Members, "Id", "FirstName", vehicles.MemberId);
            ViewBag.VehicleTypeId = new SelectList(db.VehicleType, "Id", "VehicleTypeName", vehicles.VehicleTypeId);
            return View(vehicles);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MemberId,VehicleTypeId,Verification,RegNr,Color,Brand,Model,WheelsAmount,CheckInTime,CheckOutTime,AmountFee")] Vehicles vehicles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MemberId = new SelectList(db.Members, "Id", "FirstName", vehicles.MemberId);
            ViewBag.VehicleTypeId = new SelectList(db.VehicleType, "Id", "VehicleTypeName", vehicles.VehicleTypeId);
            return View(vehicles);
        }

        // GET: Vehicles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicles vehicles = db.Vehicles.Find(id);
            if (vehicles == null)
            {
                return HttpNotFound();
            }
            return View(vehicles);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vehicles vehicles = db.Vehicles.Find(id);
            db.Vehicles.Remove(vehicles);
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


        //Search Vehicule:
        public ActionResult SearchVehicule(string RegNr, VehicleType VehicleType)
        {
            var result = db.Vehicles.Where(v => v.RegNr == RegNr );
            

            return View("Index", result.ToList());
        }

    }
}
