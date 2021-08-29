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
    public class DireccionesController : Controller
    {
        private ComercioRoboticoEntities db = new ComercioRoboticoEntities();

        // GET: Direcciones
        public ActionResult Index()
        {
            List<Direcciones> listado = db.Direcciones.Where(x => x.eliminado == false).ToList();
            return View(listado);
        }

        // GET: Direcciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direcciones direcciones = db.Direcciones.Find(id);
            if (direcciones == null)
            {
                return HttpNotFound();
            }
            return View(direcciones);
        }

        // GET: Direcciones/Create
        public ActionResult Create()
        {
            ViewBag.idComuna = new SelectList(db.Comunas, "id", "nombre");
            ViewBag.idUsuario = new SelectList(db.Usuarios, "id", "nombre");
            return View();
        }

        // POST: Direcciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Direcciones direcciones)
        {
            if (ModelState.IsValid)
            {
                db.Direcciones.Add(direcciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idComuna = new SelectList(db.Comunas, "id", "nombre", direcciones.idComuna);
            ViewBag.idUsuario = new SelectList(db.Usuarios, "id", "nombre", direcciones.idUsuario);
            return View(direcciones);
        }

        // GET: Direcciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direcciones direcciones = db.Direcciones.Find(id);
            if (direcciones == null)
            {
                return HttpNotFound();
            }
            ViewBag.idComuna = new SelectList(db.Comunas, "id", "nombre", direcciones.idComuna);
            ViewBag.idUsuario = new SelectList(db.Usuarios, "id", "nombre", direcciones.idUsuario);
            return View(direcciones);
        }

        // POST: Direcciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Direcciones direcciones)
        {
            if (ModelState.IsValid)
            {
                Direcciones dir = db.Direcciones.Find(direcciones.id);
                dir.nombre = direcciones.nombre;
                dir.idComuna = direcciones.idComuna;
                dir.idUsuario = direcciones.idUsuario;
                dir.codigoPostal = direcciones.codigoPostal;
                dir.referencias = direcciones.referencias;
                dir.recibidor = direcciones.recibidor;
                dir.numero = direcciones.numero;
                dir.departamento = direcciones.departamento;
                dir.principal = direcciones.principal;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idComuna = new SelectList(db.Comunas, "id", "nombre", direcciones.idComuna);
            ViewBag.idUsuario = new SelectList(db.Usuarios, "id", "nombre", direcciones.idUsuario);
            return View(direcciones);
        }

        // GET: Direcciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direcciones direcciones = db.Direcciones.Find(id);
            if (direcciones == null)
            {
                return HttpNotFound();
            }
            return View(direcciones);
        }

        // POST: Direcciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Direcciones direcciones = db.Direcciones.Find(id);
            if(direcciones != null)
            {
                direcciones.eliminado = true;
                direcciones.fechaEliminacion = DateTime.Now;
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
