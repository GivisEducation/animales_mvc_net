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
    public class PedidosController : Controller
    {
        private ComercioRoboticoEntities db = new ComercioRoboticoEntities();

        // GET: Pedidos
        public ActionResult Index()
        {
            List<Pedidos> listado = db.Pedidos.Where(x => x.eliminado == false).ToList();
            return View(listado);
        }

        // GET: Pedidos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedidos pedidos = db.Pedidos.Find(id);
            if (pedidos == null)
            {
                return HttpNotFound();
            }
            return View(pedidos);
        }

        // GET: Pedidos/Create
        public ActionResult Create()
        {
            ViewBag.direccion = new SelectList(db.Direcciones, "id", "nombre");
            ViewBag.idVenta = new SelectList(db.Ventas, "id", "descripcion");
            return View();
        }

        // POST: Pedidos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pedidos pedidos)
        {
            if (ModelState.IsValid)
            {
                db.Pedidos.Add(pedidos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.direccion = new SelectList(db.Direcciones, "id", "nombre", pedidos.direccion);
            ViewBag.idVenta = new SelectList(db.Ventas, "id", "descripcion", pedidos.idVenta);
            return View(pedidos);
        }

        // GET: Pedidos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedidos pedidos = db.Pedidos.Find(id);
            if (pedidos == null)
            {
                return HttpNotFound();
            }
            ViewBag.direccion = new SelectList(db.Direcciones, "id", "nombre", pedidos.direccion);
            ViewBag.idVenta = new SelectList(db.Ventas, "id", "descripcion", pedidos.idVenta);
            return View(pedidos);
        }

        // POST: Pedidos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Pedidos pedidos)
        {
            if (ModelState.IsValid)
            {
                Pedidos ped = db.Pedidos.Find(pedidos.id);
                ped.idVenta = pedidos.idVenta;
                ped.fecha = pedidos.fecha;
                ped.fechaEnvio = pedidos.fechaEnvio;
                ped.nombreDestinatario = pedidos.nombreDestinatario;
                ped.direccion = pedidos.direccion;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.direccion = new SelectList(db.Direcciones, "id", "nombre", pedidos.direccion);
            ViewBag.idVenta = new SelectList(db.Ventas, "id", "descripcion", pedidos.idVenta);
            return View(pedidos);
        }

        // GET: Pedidos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedidos pedidos = db.Pedidos.Find(id);
            if (pedidos == null)
            {
                return HttpNotFound();
            }
            return View(pedidos);
        }

        // POST: Pedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pedidos pedidos = db.Pedidos.Find(id);
            if(pedidos != null)
            {
                pedidos.eliminado = true;
                pedidos.fechaEliminacion = DateTime.Now;
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
