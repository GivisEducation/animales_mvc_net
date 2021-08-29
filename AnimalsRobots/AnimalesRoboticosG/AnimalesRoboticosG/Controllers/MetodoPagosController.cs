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
    public class MetodoPagosController : Controller
    {
        private ComercioRoboticoEntities db = new ComercioRoboticoEntities();

        // GET: MetodoPagos
        public ActionResult Index()
        {
            List<MetodoPagos> listado = db.MetodoPagos.Where(x => x.eliminado == false).ToList();
            return View(listado);
        }

        // GET: MetodoPagos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MetodoPagos metodoPagos = db.MetodoPagos.Find(id);
            if (metodoPagos == null)
            {
                return HttpNotFound();
            }
            return View(metodoPagos);
        }

        // GET: MetodoPagos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MetodoPagos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MetodoPagos metodoPagos)
        {
            if (ModelState.IsValid)
            {
                db.MetodoPagos.Add(metodoPagos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(metodoPagos);
        }

        // GET: MetodoPagos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MetodoPagos metodoPagos = db.MetodoPagos.Find(id);
            if (metodoPagos == null)
            {
                return HttpNotFound();
            }
            return View(metodoPagos);
        }

        // POST: MetodoPagos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MetodoPagos metodoPagos)
        {
            if (ModelState.IsValid)
            {
                MetodoPagos mp = db.MetodoPagos.Find(metodoPagos.id);
                mp.formaPago = metodoPagos.formaPago;
                mp.descripcion = metodoPagos.descripcion;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(metodoPagos);
        }

        // GET: MetodoPagos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MetodoPagos metodoPagos = db.MetodoPagos.Find(id);
            if (metodoPagos == null)
            {
                return HttpNotFound();
            }
            return View(metodoPagos);
        }

        // POST: MetodoPagos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MetodoPagos metodoPagos = db.MetodoPagos.Find(id);
            if (metodoPagos != null)
            {
                metodoPagos.eliminado = true;
                metodoPagos.fechaEliminacion = DateTime.Now;
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
