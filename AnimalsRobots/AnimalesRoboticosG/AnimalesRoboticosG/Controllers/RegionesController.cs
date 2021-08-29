using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Conexiones.Animales.Models;

namespace AnimalesRoboticosG.Controllers
{
    public class RegionesController : Controller
    {
        private ComercioRoboticoEntities db = new ComercioRoboticoEntities();

        // GET: Regiones
        public ActionResult Index()
        {
            List<Regiones> listado = db.Regiones.Where(x => x.eliminado == false).ToList();
            return View(listado);
        }

        // GET: Regiones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Regiones regiones = db.Regiones.Find(id);
            if (regiones == null)
            {
                return HttpNotFound();
            }
            return View(regiones);
        }

        // GET: Regiones/Create
        public ActionResult Create()
        {
            ViewBag.idPais = new SelectList(db.Paises, "id", "nombre");
            return View();
        }

        // POST: Regiones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Regiones regiones)
        {
            if (ModelState.IsValid)
            {
                db.Regiones.Add(regiones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idPais = new SelectList(db.Paises, "id", "nombre", regiones.idPais);
            return View(regiones);
        }

        // GET: Regiones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Regiones regiones = db.Regiones.Find(id);
            if (regiones == null)
            {
                return HttpNotFound();
            }
            ViewBag.idPais = new SelectList(db.Paises, "id", "nombre", regiones.idPais);
            return View(regiones);
        }

        // POST: Regiones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Regiones regiones)
        {
            if (ModelState.IsValid)
            {
                Regiones reg = db.Regiones.Find(regiones.id);
                reg.nombre = regiones.nombre;
                reg.idPais = regiones.idPais;
    
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idPais = new SelectList(db.Paises, "id", "nombre", regiones.idPais);
            return View(regiones);
        }

        // GET: Regiones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Regiones regiones = db.Regiones.Find(id);
            if (regiones == null)
            {
                return HttpNotFound();
            }
            return View(regiones);
        }

        // POST: Regiones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Regiones regiones = db.Regiones.Find(id);
            if(regiones != null)
            {
                regiones.eliminado = true;
                regiones.fechaEliminacion = DateTime.Now;
                db.SaveChanges();
            }

            
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
