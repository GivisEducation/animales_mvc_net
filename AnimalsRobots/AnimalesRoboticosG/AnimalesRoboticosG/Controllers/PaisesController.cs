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
    public class PaisesController : Controller
    {
        private ComercioRoboticoEntities db = new ComercioRoboticoEntities();

        // GET: Paises
        public ActionResult Index()
        {
            List<Paises> listado = db.Paises.Where(x => x.eliminado == false).ToList();
            return View(listado);
        }

        // GET: Paises/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paises paises = db.Paises.Find(id);
            if (paises == null)
            {
                return HttpNotFound();
            }
            return View(paises);
        }

        // GET: Paises/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Paises/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Paises paises)
        {
            if (ModelState.IsValid)
            {
                db.Paises.Add(paises);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(paises);
        }

        // GET: Paises/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paises paises = db.Paises.Find(id);
            if (paises == null)
            {
                return HttpNotFound();
            }
            return View(paises);
        }

        // POST: Paises/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Paises paises)
        {
            if (ModelState.IsValid)
            {
                Paises pai = db.Paises.Find(paises.id);
                pai.nombre = paises.nombre;
                pai.Regiones = paises.Regiones;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(paises);
        }

        // GET: Paises/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paises paises = db.Paises.Find(id);
            if (paises == null)
            {
                return HttpNotFound();
            }
            return View(paises);
        }

        // POST: Paises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Paises paises = db.Paises.Find(id);
            if(paises != null)
            {
                paises.eliminado = true;
                paises.fechaEliminacion = DateTime.Now;
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
