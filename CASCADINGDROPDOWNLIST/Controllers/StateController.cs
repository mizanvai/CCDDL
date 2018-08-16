using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CASCADINGDROPDOWNLIST.Models;

namespace CASCADINGDROPDOWNLIST.Controllers
{
    public class StateController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: State
        public ActionResult Index()
        {
            return View(db.States.ToList());
        }

        // GET: State/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StateModel stateModel = db.States.Find(id);
            if (stateModel == null)
            {
                return HttpNotFound();
            }
            return View(stateModel);
        }

        // GET: State/Create
        public ActionResult Create()
        {
            return View();
        }
        public JsonResult GetCountries()
        {
            var list = Json(db.Countries.ToList(), JsonRequestBehavior.AllowGet);
            return list;
        }

        public JsonResult GetStatesByCountryId(string countryId)
        {
            int Id = Convert.ToInt32(countryId);

            var states = from a in db.States where a.CountryId == Id select a;

            return Json(states);
        }
        public JsonResult GetCityByStateId(string StateId)
        {
            int Id = Convert.ToInt32(StateId);

            var citi = from a in db.citis where a.StateId == Id select a;

            return Json(citi);
        }
        // POST: State/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StateModel stateModel)
        {
            if (ModelState.IsValid)
            {
                db.States.Add(stateModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stateModel);
        }

        // GET: State/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StateModel stateModel = db.States.Find(id);
            if (stateModel == null)
            {
                return HttpNotFound();
            }
            return View(stateModel);
        }

        // POST: State/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StateModel stateModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stateModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stateModel);
        }

        // GET: State/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StateModel stateModel = db.States.Find(id);
            if (stateModel == null)
            {
                return HttpNotFound();
            }
            return View(stateModel);
        }

        // POST: State/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StateModel stateModel = db.States.Find(id);
            db.States.Remove(stateModel);
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
