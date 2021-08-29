using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conexiones.Animales.Models
{
    public class Carritos
    {
        private List<Productos> elementos = new List<Productos>();
        private int total = 0;
        private byte cantidad = 0;
        public void Agregar(Productos pro)
        {
            //Si cantidad es valida
            if (pro.Cantidad > 0)
            {
                /*Validar si producto existe*/
                Productos proTemp = elementos
                                    .Where(x => x.id == pro.id)
                                    .FirstOrDefault();
                if (proTemp == null)
                {
                    elementos.Add(pro);
                }
                else
                {
                    //Incrementar Cantidad
                    proTemp.Cantidad++;
                }
            }
            else
            {
                Eliminar(pro.id);
            }
        }



        public void Eliminar(int id)
        {
            /*Validar si producto existe*/
            Productos proTemp = elementos
                                .Where(x => x.id == id)
                                .FirstOrDefault();
            if (proTemp != null)
            {
                elementos.Remove(proTemp);
            }
            else
            {
                //Mandar Mensaje eliminar
            }
        }



        public void Editar(int id, byte cantidad)
        {
            if (cantidad > 0)
            {
                /*Validar si producto existe*/
                Productos proTemp = elementos
                                    .Where(x => x.id == id)
                                    .FirstOrDefault();
                if (proTemp != null)
                {
                    proTemp.Cantidad = cantidad;
                }

            }
            else
            {
                Eliminar(id);
            }


        }

        public List<Productos> Traer
        {
            get
            {
                return elementos;
            }
        }

        public int Totalizar
        {
            get
            {
                elementos.ForEach(x => x.SubTotal = x.precio * x.Cantidad);
                total = elementos.Sum(x => x.SubTotal);
                return total;
            }

        }

        public byte Contar
        {
            get
            {
                cantidad = byte.Parse(elementos.Sum(x => x.Cantidad).ToString());
                return cantidad;
            }

        }

        public void Limpiar()
        {
            //elementos = null;
            elementos.Clear();
        }

    }
}
