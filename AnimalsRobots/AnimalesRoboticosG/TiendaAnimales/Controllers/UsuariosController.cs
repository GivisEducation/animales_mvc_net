using Conexiones.Animales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using TiendaAnimales.Models;

namespace TiendaAnimales.Controllers
{
    public class UsuariosController : Controller
    {
        private ComercioRoboticoEntities db = new ComercioRoboticoEntities();

        public UsuariosController()
        {
            ViewBag.Categorias = db.Categorias.ToList();
        }

        // Get: Usuarios
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registro(Usuarios usuario, string reClave)
        {
            if (usuario.clave != reClave)
            {
                ViewBag.Mensaje = "La clave no coincide";
                return View("Index");
            }

            Usuarios usuarioDb = db.Usuarios.Where(x => x.email == usuario.email).FirstOrDefault();

            if (usuarioDb == null)
            {
                usuario.activo = true;
                db.Usuarios.Add(usuario);
                db.SaveChanges();

            }
            else
            {
                ViewBag.Mensaje = "Este usuario ya existe";
                return View("Index");
            }

            ViewBag.Mensaje = "Usuario creado con exito ";

            return View("Index");
        }

        [HttpPost]
        public ActionResult Login(string email, string clave)
        {
            
            Usuarios usuarioDB = db.Usuarios.Where(x => x.email == email && x.clave == clave)
                .FirstOrDefault();
            if (usuarioDB != null)
            {
                //Usuario existe
                UsuariosViewModel usu = new UsuariosViewModel();
                usu.Id = usuarioDB.id;
                usu.nombre = usuarioDB.nombre;
                Session["Usuario"] = usu;
            } 
            return Redirect("/Home/Index");
          
        }

        public ActionResult cerrar()
        {
            Session["Usuario"] = null;
            return View("Index");
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