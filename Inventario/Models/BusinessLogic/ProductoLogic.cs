using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inventario.Models.DB;

namespace Inventario.Models.BusinessLogic
{
    public class ProductoLogic
    {
        public List<Productos> GetProductos(string nombre)
        {
            List<Productos> productos = new List<Productos>();

            using (var db = new PulperiaDBEntities())
            {
                productos = db.Productos.OrderBy(p => p.DescrpProducto)
                    .Where(p => p.DescrpProducto.Contains(nombre))
                    .Take(10)
                    .ToList();
            }
            return productos;
        }
    }
}