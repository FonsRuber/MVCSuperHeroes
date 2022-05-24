using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCSuperHeroes.Z_Capa2_Servicios.ClasesSuperHeroe;
using MVCSuperHeroes.Z_Capa2_Servicios;
using MVCSuperHeroes.Z_Capa3_Datos;

namespace MVCSuperHeroes.Controllers
{
    public class BomberosController : Controller
    {
        private SuperHeroesDBEntities db = new SuperHeroesDBEntities();
        Menu menu { get; set; }


        // GET: Bomberos
        public ActionResult Index()
        {
            Menu menu = new Menu();
            List<BomberoDTO> bombero = menu.DevolverTodosLosBomberos();
            return View(bombero.ToList());
        }

        // GET: Bomberos/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menu menu = new Menu();
            BomberoDTO bomberoDTO = menu.DevolverBombero(id ?? 0);
            if (bomberoDTO == null)
            {
                return HttpNotFound();
            }
            return View(bomberoDTO);
        }

        // GET: Bomberos/Create
        public ActionResult Create()
        {
            menu = new Menu();
            return View();
        }

        // POST: Bomberos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BomberoDTO bomberoDTO)
        {
            if (ModelState.IsValid)
            {
                menu = new Menu();
                if (bomberoDTO.ImageFile != null)
                {
                    bomberoDTO.ImagenPath = menu.GuardarImagenDeSuperHeroe(bomberoDTO.ImageFile, bomberoDTO.nombre);
                }
                bool annadirOk = menu.AnnadirBombero(bomberoDTO);
                if (annadirOk == true)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        // GET: Bomberos/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bombero bombero = db.Bombero.Find(id);
            if (bombero == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdProfesionesHeroicas = new SelectList(db.ProfesionesHeroicas, "Id", "Id", bombero.IdProfesionesHeroicas);
            return View(bombero);
        }

        // POST: Bomberos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdProfesionesHeroicas,ApagarFuego")] Bombero bombero)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bombero).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdProfesionesHeroicas = new SelectList(db.ProfesionesHeroicas, "Id", "Id", bombero.IdProfesionesHeroicas);
            return View(bombero);
        }

        // GET: Bomberos/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bombero bombero = db.Bombero.Find(id);
            if (bombero == null)
            {
                return HttpNotFound();
            }
            return View(bombero);
        }

        // POST: Bomberos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Bombero bombero = db.Bombero.Find(id);
            db.Bombero.Remove(bombero);
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
