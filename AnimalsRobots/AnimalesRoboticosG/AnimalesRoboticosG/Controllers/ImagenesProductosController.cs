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
    public class ImagenesProductosController : Controller
    {
        private ComercioRoboticoEntities db = new ComercioRoboticoEntities();

        // GET: ImagenesProductos
        public ActionResult Index()
        {
            var imagenesProductos = db.ImagenesProductos.Include(i => i.Productos);
            return View(imagenesProductos.ToList());
        }

        // GET: ImagenesProductos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImagenesProductos imagenesProductos = db.ImagenesProductos.Find(id);
            if (imagenesProductos == null)
            {
                return HttpNotFound();
            }
            return View(imagenesProductos);
        }

        // GET: ImagenesProductos/Create
        public ActionResult Create()
        {
            ViewBag.idProducto = new SelectList(db.Productos, "id", "nombre");
            return View();
        }

        // POST: ImagenesProductos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ImagenesProductos imagenesProductos, HttpPostedFileBase imagen)
        {
            string ruta = Server.MapPath("/Content/img");
            if (ModelState.IsValid)
            {
                if (imagen == null)
                {
                    ViewBag.idProducto = new SelectList(db.Productos, "id", "nombre");
                    ViewBag.Mensaje = "Debe subir una imágen";
                    return View("Create");
                }
                imagen.SaveAs($"{ruta}/{imagen.FileName}");
                imagenesProductos.url = $"/Content/img/{imagen.FileName}";
                db.ImagenesProductos.Add(imagenesProductos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idProducto = new SelectList(db.Productos, "id", "nombre", imagenesProductos.idProducto);
            return View(imagenesProductos);
        }

        // GET: ImagenesProductos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImagenesProductos imagenesProductos = db.ImagenesProductos.Find(id);
            if (imagenesProductos == null)
            {
                return HttpNotFound();
            }
            ViewBag.idProducto = new SelectList(db.Productos, "id", "nombre", imagenesProductos.idProducto);
            return View(imagenesProductos);
        }

        // POST: ImagenesProductos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ImagenesProductos imagenesProductos, HttpPostedFileBase imagen)
        {
            string ruta = Server.MapPath("/Content/img");
            if (ModelState.IsValid)
            {                   
                ImagenesProductos imagenesProductosDB = db.ImagenesProductos.Find(imagenesProductos.id);

                if (imagen != null)
                {
                    imagen.SaveAs($"{ruta}/{imagen.FileName}");
                    imagenesProductosDB.url = $"/Content/img/{imagen.FileName}";
                }
                imagenesProductosDB.idProducto = imagenesProductos.idProducto;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idProducto = new SelectList(db.Productos, "id", "nombre", imagenesProductos.idProducto);
            return View(imagenesProductos);
        }

        // GET: ImagenesProductos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImagenesProductos imagenesProductos = db.ImagenesProductos.Find(id);
            if (imagenesProductos == null)
            {
                return HttpNotFound();
            }
            return View(imagenesProductos);
        }

        // POST: ImagenesProductos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ImagenesProductos imagenesProductos = db.ImagenesProductos.Find(id);
            db.ImagenesProductos.Remove(imagenesProductos);
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
