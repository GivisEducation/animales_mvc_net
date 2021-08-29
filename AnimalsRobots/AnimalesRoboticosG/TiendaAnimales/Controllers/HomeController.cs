using Conexiones.Animales.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TiendaAnimales.Controllers
{
    public class HomeController : Controller
    {
       
        private ComercioRoboticoEntities db = new ComercioRoboticoEntities();
        // GET: Home 
        public HomeController()
        {
            ViewBag.Categorias = db.Categorias.ToList();
        }
        public ActionResult Index(int pagina = 1, int cat = 0)
        {
            int mostrar = 3;
            int saltar = (pagina - 1) * mostrar;
            IEnumerable<Productos> productos = db.Productos
                          .OrderBy(x => x.precio);
            decimal count = db.Productos.Count();

            if (cat != 0)
            {
                //filtrar por categoria
                productos = productos.Where(x => x.idCategoria == cat);
                count = db.Productos.Where(x => x.idCategoria == cat).Count();
            }
          
            productos=productos.Skip(saltar)
                 .Take(mostrar)
                .ToList();

            decimal CantidadPaginas = Math.Ceiling(count / mostrar);

            ViewBag.CantidadPaginas = CantidadPaginas;
            ViewBag.pagina = pagina;

            return View(productos);
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