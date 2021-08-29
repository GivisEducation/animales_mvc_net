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
    public class CategoriasController : Controller
    {
        private ComercioRoboticoEntities db = new ComercioRoboticoEntities();

        // GET: Categorias
        public ActionResult Index()
        {
            List<Categorias> listado = db.Categorias.Where(x => x.eliminacion == false).ToList();
            return View(listado);
        }

        // GET: Categorias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categorias categorias = db.Categorias.Find(id);
            if (categorias == null)
            {
                return HttpNotFound();
            }
            return View(categorias);
        }

        // GET: Categorias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categorias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categorias categorias)
        {
            if (ModelState.IsValid)
            {
                db.Categorias.Add(categorias);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categorias);
        }

        // GET: Categorias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categorias categorias = db.Categorias.Find(id);
            if (categorias == null)
            {
                return HttpNotFound();
            }
            return View(categorias);
        }

        // POST: Categorias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categorias categorias)
        {
            if (ModelState.IsValid)
            {
                Categorias cate = db.Categorias.Find(categorias.id);
                cate.nombre = categorias.nombre;
                cate.descripcion = categorias.descripcion;
                cate.Productos = categorias.Productos;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categorias);
        }

        // GET: Categorias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categorias categorias = db.Categorias.Find(id);
            if (categorias == null)
            {
                return HttpNotFound();
            }
            return View(categorias);
        }

        // POST: Categorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Categorias categorias = db.Categorias.Find(id);
            if (categorias != null)
            {
                categorias.eliminacion = true;
                categorias.fechaEliminacion = DateTime.Now;
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
