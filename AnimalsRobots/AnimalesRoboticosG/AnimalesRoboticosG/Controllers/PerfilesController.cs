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
    public class PerfilesController : Controller
    {
        private ComercioRoboticoEntities db = new ComercioRoboticoEntities();

        // GET: Perfiles
        public ActionResult Index()
        {
            var perfiles = db.Perfiles.Include(p => p.Usuarios);
            return View(perfiles.ToList());
        }

        // GET: Perfiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perfiles perfiles = db.Perfiles.Find(id);
            if (perfiles == null)
            {
                return HttpNotFound();
            }
            return View(perfiles);
        }

        // GET: Perfiles/Create
        public ActionResult Create()
        {
            ViewBag.idUsuario = new SelectList(db.Usuarios, "id", "nombre");
            return View();
        }

        // POST: Perfiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Perfiles perfiles)
        {
            if (ModelState.IsValid)
            {
                db.Perfiles.Add(perfiles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuario = new SelectList(db.Usuarios, "id", "nombre");
            return View(perfiles);
        }

        // GET: Perfiles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perfiles perfiles = db.Perfiles.Find(id);
            if (perfiles == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUsuario = new SelectList(db.Usuarios, "id", "nombre");
            return View(perfiles);
        }

        // POST: Perfiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,idUsuario")] Perfiles perfiles)
        {
            if (ModelState.IsValid)
            {
                Perfiles per = db.Perfiles.Find(perfiles.id);
                per.nombre = perfiles.nombre;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuario = new SelectList(db.Usuarios, "id", "nombre");
            return View(perfiles);
        }

        // GET: Perfiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perfiles perfiles = db.Perfiles.Find(id);
            if (perfiles == null)
            {
                return HttpNotFound();
            }
            return View(perfiles);
        }

        // POST: Perfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Perfiles perfiles = db.Perfiles.Find(id);
            db.Perfiles.Remove(perfiles);
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
