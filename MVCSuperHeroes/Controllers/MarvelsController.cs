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
    public class MarvelsController : Controller
    {
        private SuperHeroesDBEntities db = new SuperHeroesDBEntities();

        // GET: Marvels
        public ActionResult Index()
        {
            var marvel = db.Marvel.Include(m => m.SuperHumanos);
            return View(marvel.ToList());
        }

        // GET: Marvels/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marvel marvel = db.Marvel.Find(id);
            if (marvel == null)
            {
                return HttpNotFound();
            }
            return View(marvel);
        }

        // GET: Marvels/Create
        public ActionResult Create()
        {
            ViewBag.IdSuperHumanos = new SelectList(db.SuperHumanos, "Id", "Id");
            return View();
        }

        // POST: Marvels/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdSuperHumanos,Vengadores")] Marvel marvel)
        {
            if (ModelState.IsValid)
            {
                db.Marvel.Add(marvel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdSuperHumanos = new SelectList(db.SuperHumanos, "Id", "Id", marvel.IdSuperHumanos);
            return View(marvel);
        }

        // GET: Marvels/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marvel marvel = db.Marvel.Find(id);
            if (marvel == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdSuperHumanos = new SelectList(db.SuperHumanos, "Id", "Id", marvel.IdSuperHumanos);
            return View(marvel);
        }

        // POST: Marvels/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdSuperHumanos,Vengadores")] Marvel marvel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(marvel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdSuperHumanos = new SelectList(db.SuperHumanos, "Id", "Id", marvel.IdSuperHumanos);
            return View(marvel);
        }

        // GET: Marvels/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marvel marvel = db.Marvel.Find(id);
            if (marvel == null)
            {
                return HttpNotFound();
            }
            return View(marvel);
        }

        // POST: Marvels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Marvel marvel = db.Marvel.Find(id);
            db.Marvel.Remove(marvel);
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
