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
    public class ProductosController : Controller
    {
        private ComercioRoboticoEntities db = new ComercioRoboticoEntities();

        // GET: Productos
        public ActionResult Index()
        {
            List<Productos> listado = db.Productos.Where(x => x.eliminado == false).ToList();
            return View(listado);
        }

        // GET: Productos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productos productos = db.Productos.Find(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            return View(productos);
        }

        // GET: Productos/Create
        public ActionResult Create()
        {
            ViewBag.idCategoria = new SelectList(db.Categorias, "id", "nombre");
            return View();
        }

        // POST: Productos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Productos productos)
        {
            if (ModelState.IsValid)
            {
                db.Productos.Add(productos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCategoria = new SelectList(db.Categorias, "id", "nombre", productos.idCategoria);
            return View(productos);
        }

        // GET: Productos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productos productos = db.Productos.Find(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCategoria = new SelectList(db.Categorias, "id", "nombre", productos.idCategoria);
            return View(productos);
        }

        // POST: Productos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Productos productos)
        {
            if (ModelState.IsValid)
            {
               Productos pro = db.Productos.Find(productos.id);
                pro.nombre = productos.nombre;
                pro.descripcion = productos.descripcion;
                pro.stock = productos.stock;
                pro.precio = productos.precio;
                pro.color = productos.color;
                pro.tamaño = productos.tamaño;
                pro.promocion = productos.promocion;
                pro.Categorias=productos.Categorias;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCategoria = new SelectList(db.Categorias, "id", "nombre", productos.idCategoria);
            return View(productos);
        }

        // GET: Productos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productos productos = db.Productos.Find(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            return View(productos);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Productos productos = db.Productos.Find(id);
            if (productos != null)
            {
                productos.eliminado = true;
                productos.fechaEliminacion = DateTime.Now;
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
