using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCSuperHeroes.Z_Capa3_Datos;

namespace MVCSuperHeroes.Controllers
{
    public class DCsController : Controller
    {
        private SuperHeroesDBEntities db = new SuperHeroesDBEntities();

        // GET: DCs
        public ActionResult Index()
        {
            var dC = db.DC.Include(d => d.SuperHumanos);
            return View(dC.ToList());
        }

        // GET: DCs/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DC dC = db.DC.Find(id);
            if (dC == null)
            {
                return HttpNotFound();
            }
            return View(dC);
        }

        // GET: DCs/Create
        public ActionResult Create()
        {
            ViewBag.IdSuperHumanos = new SelectList(db.SuperHumanos, "Id", "Id");
            return View();
        }

        // POST: DCs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdSuperHumanos,LigaDeLaJusticia")] DC dC)
        {
            if (ModelState.IsValid)
            {
                db.DC.Add(dC);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdSuperHumanos = new SelectList(db.SuperHumanos, "Id", "Id", dC.IdSuperHumanos);
            return View(dC);
        }

        // GET: DCs/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DC dC = db.DC.Find(id);
            if (dC == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdSuperHumanos = new SelectList(db.SuperHumanos, "Id", "Id", dC.IdSuperHumanos);
            return View(dC);
        }

        // POST: DCs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdSuperHumanos,LigaDeLaJusticia")] DC dC)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dC).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdSuperHumanos = new SelectList(db.SuperHumanos, "Id", "Id", dC.IdSuperHumanos);
            return View(dC);
        }

        // GET: DCs/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DC dC = db.DC.Find(id);
            if (dC == null)
            {
                return HttpNotFound();
            }
            return View(dC);
        }

        // POST: DCs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            DC dC = db.DC.Find(id);
            db.DC.Remove(dC);
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
