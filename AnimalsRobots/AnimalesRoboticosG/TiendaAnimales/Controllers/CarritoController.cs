using Conexiones.Animales.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaAnimales.Models;

namespace TiendaAnimales.Controllers
{
    public class CarritoController : Controller
    {


        private ComercioRoboticoEntities db = new ComercioRoboticoEntities();
        public CarritoController()
        {
            ViewBag.Categorias = db.Categorias.ToList();
        }
        // POST: Carrito
        [HttpPost]
        public JsonResult Agregar(Productos pro)
        {
            byte cantidad = pro.Cantidad;
            pro = db.Productos.Find(pro.id);
            pro.Cantidad = cantidad;
            Carritos miCarrito = null;
            if (Session["carrito"] == null)
            {
                miCarrito = new Carritos();

            }
            else
            {
                miCarrito = (Carritos)Session["carrito"];
            }

            miCarrito.Agregar(pro);
            Session["carrito"] = miCarrito;

            return Json(new { Mensaje = "Agregado con exito", Estado = true });

        }
        public JsonResult Traer()
        {
            Carritos miCarrito = null;
            if (Session["carrito"] == null)
            {
                miCarrito = new Carritos();
            }
            else
            {
                miCarrito = (Carritos)Session["carrito"];
            }



            return Json(new
            {
                miCarrito.Contar,
                miCarrito.Totalizar,
                Traer = miCarrito.Traer.Select
                (x => new { x.Cantidad, x.SubTotal, x.nombre, x.id, x.precio }).ToList()
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Eliminar(int id)
        {
            Carritos miCarrito = null;
            if (Session["carrito"] == null)
            {
                miCarrito = new Carritos();
            }
            else
            {
                miCarrito = (Carritos)Session["carrito"];
            }
            miCarrito.Eliminar(id);

            return Json(new { Mensaje = "Eliminado con exito", Estado = true }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Editar(int id, byte cantidad)
        {
            Carritos miCarrito = null;
            if (Session["carrito"] == null)
            {
                miCarrito = new Carritos();
            }
            else
            {
                miCarrito = (Carritos)Session["carrito"];
            }
            miCarrito.Editar(id, cantidad);
            return Json(new { Mensaje = "Modificado con exito", Estado = true }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Pagando()
        {
            if (Session["Usuario"] == null)
            {
                ViewBag.Mensaje = "Debe iniciar Sesión para pagar";
                return Redirect("/Usuarios/Index");
            }
            else 
            {
                return View();
            }
            
        }

        public ActionResult Pagar()
        {
            UsuariosViewModel usu = null;
            Carritos miCarrito = null;

            if (Session["Usuario"] != null)
            {
                //Ciclo Pago 
                usu = (UsuariosViewModel)Session["usuario"];
                miCarrito = (Carritos)Session["carrito"];

                if (miCarrito.Totalizar > 0)
                {
                    //Procedemos a Pago
                    Ventas venta = new Ventas();
                    venta.idUsuario = usu.Id;
                    venta.total = (short)miCarrito.Totalizar;
                    venta.fecha = DateTime.Now;


                    //Detalles esta venta
                    venta.DetalleVentas = new List<DetalleVentas>();
                    foreach (var det in miCarrito.Traer)
                    {
                        venta.DetalleVentas.Add(new DetalleVentas()
                        {
                            idProducto = det.id,
                            cantidad = det.Cantidad,
                            subTotal = (short)det.SubTotal
                        });

                    }
                    //Aplicar API para Medio de pago ejemplo paypal
                    venta.idMetodoPago = 11;
                    db.Ventas.Add(venta);
                    db.SaveChanges();

                }
                else
                {
                    //estafa o vacio
                    ViewBag.Mensaje = "No se puede procesar el pago en estos momentos";
                    return View();
                }
            }

            return View("/Carrito/Pagando");
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