using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCSuperHeroes.Z_Capa3_Datos;
using MVCSuperHeroes.Z_Capa2_Servicios;
using MVCSuperHeroes.Z_Capa2_Servicios.ClasesSuperHeroe;

namespace MVCSuperHeroes.Controllers
{
    public class SanitariosController : Controller
    {
        private SuperHeroesDBEntities db = new SuperHeroesDBEntities();
        Menu menu { get; set; }

        // GET: Sanitarios
        public ActionResult Index()
        {
            Menu menu = new Menu();
            List<SanitarioDTO> sanitario = menu.DevolverTodosLosSanitarios();
            return View(sanitario.ToList());
        }

        // GET: Sanitarios/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menu menu = new Menu();
            SanitarioDTO sanitarioDTO = menu.DevolverSanitario(id ?? 0);
            if (sanitarioDTO == null)
            {
                return HttpNotFound();
            }
            return View(sanitarioDTO);
        }

        // GET: Sanitarios/Create
        public ActionResult Create()
        {
            menu = new Menu();
            return View();
        }

        // POST: Sanitarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SanitarioDTO sanitarioDTO)
        //public ActionResult Create([Bind(Include = "Id,IdProfesionesHeroicas,Curar")] Sanitario sanitario)
        {
            if (ModelState.IsValid)
            {
                menu = new Menu();
                if (sanitarioDTO.ImageFile != null)
                {
                    sanitarioDTO.ImagenPath = menu.GuardarImagenDeSuperHeroe(sanitarioDTO.ImageFile, sanitarioDTO.nombre);
                }
                bool annadirOk = menu.AnnadirSanitario(sanitarioDTO);
                if (annadirOk == true)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();

        }

        // GET: Sanitarios/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            menu = new Menu();
            SanitarioDTO sanitarioDTO = menu.DevolverSanitario(id ?? 0);
            if (sanitarioDTO == null)
            {
                return HttpNotFound();
            }
            //ViewBag.IdProfesionesHeroicas = new SelectList(db.ProfesionesHeroicas, "Id", "Id", sanitario.IdProfesionesHeroicas);
            return View(sanitarioDTO);
        }

        // POST: Sanitarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SanitarioDTO sanitarioDTO)
        {
            if (ModelState.IsValid)
            {
                menu = new Menu();
                if (sanitarioDTO.ImageFile != null)
                {
                    sanitarioDTO.ImagenPath = menu.GuardarImagenDeSuperHeroe(sanitarioDTO.ImageFile, sanitarioDTO.nombre);
                }
                bool modificarOk = menu.ModificarSanitario(sanitarioDTO);
                if (modificarOk == true)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(sanitarioDTO);
        }

        // GET: Sanitarios/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            menu = new Menu();
            SanitarioDTO sanitarioDTO = menu.DevolverSanitario(id ?? 0);
            if (sanitarioDTO == null)
            {
                return HttpNotFound();
            }
            return View(sanitarioDTO);
        }

        // POST: Sanitarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            menu = new Menu();
            bool borrarOk = menu.BorrarSanitario(id);
            if (borrarOk == true)
            {
                return RedirectToAction("Index");
            }
            return View(id);
        }
        // POST: Buscar Sanitario por habilidad de curar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SearchByCure(string Cure)
        {
            menu = new Menu();
            List<SanitarioDTO> sanitarios = menu.DevolverSanitariosQuePuedenCurar(Cure);
            return View("Index", sanitarios.ToList());
        }

        public PartialViewResult ListaSanitarios(string Cure)
        {
            menu = new Menu();
            List<SanitarioDTO> sanitarios = menu.DevolverTodosLosSanitarios();
            return PartialView(sanitarios);
        }

    }
}
