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
    public class DetallePedidosController : Controller
    {
        private ComercioRoboticoEntities db = new ComercioRoboticoEntities();

        // GET: DetallePedidos
        public ActionResult Index()
        {
            var detallePedidos = db.DetallePedidos.Include(d => d.Pedidos).Include(d => d.Productos);
            return View(detallePedidos.ToList());
        }

        // GET: DetallePedidos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetallePedidos detallePedidos = db.DetallePedidos.Find(id);
            if (detallePedidos == null)
            {
                return HttpNotFound();
            }
            return View(detallePedidos);
        }

        // GET: DetallePedidos/Create
        public ActionResult Create()
        {
            ViewBag.idPedido = new SelectList(db.Pedidos, "id", "nombreDestinatario");
            ViewBag.idProducto = new SelectList(db.Productos, "id", "nombre");
            return View();
        }

        // POST: DetallePedidos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DetallePedidos detallePedidos)
        {
            if (ModelState.IsValid)
            {
                db.DetallePedidos.Add(detallePedidos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idPedido = new SelectList(db.Pedidos, "id", "nombreDestinatario", detallePedidos.idPedido);
            ViewBag.idProducto = new SelectList(db.Productos, "id", "nombre", detallePedidos.idProducto);
            return View(detallePedidos);
        }

        // GET: DetallePedidos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetallePedidos detallePedidos = db.DetallePedidos.Find(id);
            if (detallePedidos == null)
            {
                return HttpNotFound();
            }
            ViewBag.idPedido = new SelectList(db.Pedidos, "id", "nombreDestinatario", detallePedidos.idPedido);
            ViewBag.idProducto = new SelectList(db.Productos, "id", "nombre", detallePedidos.idProducto);
            return View(detallePedidos);
        }

        // POST: DetallePedidos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( DetallePedidos detallePedidos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detallePedidos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idPedido = new SelectList(db.Pedidos, "id", "nombreDestinatario", detallePedidos.idPedido);
            ViewBag.idProducto = new SelectList(db.Productos, "id", "nombre", detallePedidos.idProducto);
            return View(detallePedidos);
        }

        // GET: DetallePedidos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetallePedidos detallePedidos = db.DetallePedidos.Find(id);
            if (detallePedidos == null)
            {
                return HttpNotFound();
            }
            return View(detallePedidos);
        }

        // POST: DetallePedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetallePedidos detallePedidos = db.DetallePedidos.Find(id);
            db.DetallePedidos.Remove(detallePedidos);
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
