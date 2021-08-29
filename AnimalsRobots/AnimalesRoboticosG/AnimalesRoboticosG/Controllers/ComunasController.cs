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
    public class ComunasController : Controller
    {
        private ComercioRoboticoEntities db = new ComercioRoboticoEntities();

        // GET: Comunas
        public ActionResult Index()
        {
            List<Comunas> listado = db.Comunas.Where(x => x.eliminado == false).ToList();
            return View(listado);
        }

        // GET: Comunas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comunas comunas = db.Comunas.Find(id);
            if (comunas == null)
            {
                return HttpNotFound();
            }
            return View(comunas);
        }

        // GET: Comunas/Create
        public ActionResult Create()
        {
            ViewBag.idRegion = new SelectList(db.Regiones, "id", "nombre");
            return View();
        }

        // POST: Comunas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Comunas comunas)
        {
            if (ModelState.IsValid)
            {
                db.Comunas.Add(comunas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idRegion = new SelectList(db.Regiones, "id", "nombre", comunas.idRegion);
            return View(comunas);
        }

        // GET: Comunas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comunas comunas = db.Comunas.Find(id);
            if (comunas == null)
            {
                return HttpNotFound();
            }
            ViewBag.idRegion = new SelectList(db.Regiones, "id", "nombre", comunas.idRegion);
            return View(comunas);
        }

        // POST: Comunas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Comunas comunas)
        {
            if (ModelState.IsValid)
            {
                Comunas comu = db.Comunas.Find(comunas.id);
                comu.nombre = comunas.nombre;
                comu.idRegion = comunas.idRegion;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idRegion = new SelectList(db.Regiones, "id", "nombre", comunas.idRegion);
            return View(comunas);
        }

        // GET: Comunas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comunas comunas = db.Comunas.Find(id);
            if (comunas == null)
            {
                return HttpNotFound();
            }
            return View(comunas);
        }

        // POST: Comunas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comunas comunas = db.Comunas.Find(id);
            if (comunas != null) 
            {
                comunas.eliminado = true;
                comunas.fechaEliminacion = DateTime.Now;
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
