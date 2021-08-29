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
    public class VentasController : Controller
    {
        private ComercioRoboticoEntities db = new ComercioRoboticoEntities();

        // GET: Ventas
        public ActionResult Index()
        {
            List<Ventas> listado = db.Ventas.Where(x => x.eliminado == false).ToList();
            return View(listado);
        }

        // GET: Ventas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ventas ventas = db.Ventas.Find(id);
            if (ventas == null)
            {
                return HttpNotFound();
            }
            return View(ventas);
        }

        // GET: Ventas/Create
        public ActionResult Create()
        {
            ViewBag.idMetodoPago = new SelectList(db.MetodoPagos, "id", "formaPago");
            ViewBag.idUsuario = new SelectList(db.Usuarios, "id", "nombre");
            return View();
        }

        // POST: Ventas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Ventas ventas)
        {
            if (ModelState.IsValid)
            {
                db.Ventas.Add(ventas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idMetodoPago = new SelectList(db.MetodoPagos, "id", "formaPago", ventas.idMetodoPago);
            ViewBag.idUsuario = new SelectList(db.Usuarios, "id", "nombre", ventas.idUsuario);
            return View(ventas);
        }

        // GET: Ventas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ventas ventas = db.Ventas.Find(id);
            if (ventas == null)
            {
                return HttpNotFound();
            }
            ViewBag.idMetodoPago = new SelectList(db.MetodoPagos, "id", "formaPago", ventas.idMetodoPago);
            ViewBag.idUsuario = new SelectList(db.Usuarios, "id", "nombre", ventas.idUsuario);
            return View(ventas);
        }

        // POST: Ventas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Ventas ventas)
        {
            if (ModelState.IsValid)
            {
                Ventas ven = db.Ventas.Find(ventas.id);
                ven.fecha = ventas.fecha;
                ven.total = ventas.total;
                ven.idUsuario = ventas.idUsuario;
                ven.descripcion = ventas.descripcion;
                ven.idMetodoPago = ventas.idMetodoPago;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idMetodoPago = new SelectList(db.MetodoPagos, "id", "formaPago", ventas.idMetodoPago);
            ViewBag.idUsuario = new SelectList(db.Usuarios, "id", "nombre", ventas.idUsuario);
            return View(ventas);
        }

        // GET: Ventas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ventas ventas = db.Ventas.Find(id);
            if (ventas == null)
            {
                return HttpNotFound();
            }
            return View(ventas);
        }

        // POST: Ventas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ventas ventas = db.Ventas.Find(id);
            if(ventas != null)
            {
                ventas.eliminado = true;
                ventas.fechaEliminacion = DateTime.Now;
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
