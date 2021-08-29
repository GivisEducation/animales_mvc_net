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
    public class DetalleVentasController : Controller
    {
        private ComercioRoboticoEntities db = new ComercioRoboticoEntities();

        // GET: DetalleVentas
        public ActionResult Index()
        {
            var detalleVentas = db.DetalleVentas.Include(d => d.Ventas).Include(d => d.Productos);
            return View(detalleVentas.ToList());
        }

        // GET: DetalleVentas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleVentas detalleVentas = db.DetalleVentas.Find(id);
            if (detalleVentas == null)
            {
                return HttpNotFound();
            }
            return View(detalleVentas);
        }

        // GET: DetalleVentas/Create
        public ActionResult Create()
        {
            ViewBag.idVenta = new SelectList(db.Ventas, "id", "descripcion");
            ViewBag.idProducto = new SelectList(db.Productos, "id", "nombre");
            return View();
        }

        // POST: DetalleVentas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,idVenta,idProducto,cantidad,subTotal")] DetalleVentas detalleVentas)
        {
            if (ModelState.IsValid)
            {
                db.DetalleVentas.Add(detalleVentas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idVenta = new SelectList(db.Ventas, "id", "descripcion", detalleVentas.idVenta);
            ViewBag.idProducto = new SelectList(db.Productos, "id", "nombre", detalleVentas.idProducto);
            return View(detalleVentas);
        }

        // GET: DetalleVentas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleVentas detalleVentas = db.DetalleVentas.Find(id);
            if (detalleVentas == null)
            {
                return HttpNotFound();
            }
            ViewBag.idVenta = new SelectList(db.Ventas, "id", "descripcion", detalleVentas.idVenta);
            ViewBag.idProducto = new SelectList(db.Productos, "id", "nombre", detalleVentas.idProducto);
            return View(detalleVentas);
        }

        // POST: DetalleVentas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DetalleVentas detalleVentas)
        {
            if (ModelState.IsValid)
            {
                DetalleVentas dv = db.DetalleVentas.Find(detalleVentas.id);
                dv.cantidad = detalleVentas.cantidad;
                dv.subTotal = detalleVentas.subTotal;
                dv.idVenta = detalleVentas.idVenta;
                dv.idProducto = detalleVentas.idProducto;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idVenta = new SelectList(db.Ventas, "id", "descripcion", detalleVentas.idVenta);
            ViewBag.idProducto = new SelectList(db.Productos, "id", "nombre", detalleVentas.idProducto);
            return View(detalleVentas);
        }

        // GET: DetalleVentas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleVentas detalleVentas = db.DetalleVentas.Find(id);
            if (detalleVentas == null)
            {
                return HttpNotFound();
            }
            return View(detalleVentas);
        }

        // POST: DetalleVentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetalleVentas detalleVentas = db.DetalleVentas.Find(id);
            db.DetalleVentas.Remove(detalleVentas);
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
