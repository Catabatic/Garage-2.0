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
            var vehicles = db.Vehicles.Include(v => v.Member).Include(v => v.VehicleType);
            return View(vehicles.ToList());
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
           // ViewBag.MemberId = new SelectList(db.Members, "Id", "FirstName");

            ViewBag.VehicleTypeId = new SelectList(db.VehicleType, "Id", "VehicleTypeName");
            if (TempData["CreatedMemberEmail"] != null)
            {
                ViewBag.MemberEmail = TempData["CreatedMemberEmail"].ToString();

            }
            else
            {
                ViewBag.MemberEmail = "j@m.se";
            }
            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MemberId,Member.Email,VehicleTypeId,RegNr,Color,Brand,Model,WheelsAmount,CheckInTime")] Vehicles vehicles)
        {
            string memberMail = ViewBag.MemberEmail;

            Members currentMember = new Members();
            currentMember = db.Members.Where(m => m.Email == memberMail).Single();

            var vehicle = db.Vehicles.Where(v => v.RegNr == vehicles.RegNr);

            if (ModelState.IsValid && !vehicle.Any() && currentMember != null)
            {
                //Connect member and vehicle
                vehicles.MemberId = currentMember.Id;

                /*CheckInTime is now being defined by the user's current time when the user parks a car (Linus)*/
                vehicles.CheckInTime = DateTime.Parse(DateTime.Now.ToString("g"));
                

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
                ViewBag.Description = "Fordonet har parkerats i garaget!";
                db.Vehicles.Add(vehicles);
                db.SaveChanges();
                ViewBag.VehicleTypeId = new SelectList(db.VehicleType, "Id", "VehicleTypeName");
                return View();
            }
            ViewBag.Warning = "Det finns redan ett fordon med samma RegNr!";

            //if (ModelState.IsValid)
            //{
            //    db.Vehicles.Add(vehicles);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

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
    }
}
