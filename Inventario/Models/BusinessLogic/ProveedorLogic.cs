using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inventario.Models.DB;

namespace Inventario.Models.BusinessLogic
{
    public class ProveedorLogic
    {
        public List<Proveedores> GetProveedores(string nombre)
        {
            List<Proveedores> proveedores = new List<Proveedores>();
            using (var db = new PulperiaDBEntities())
            {
               proveedores = db.Proveedores.OrderBy(p => p.NomProveedor)
                    .Where(p => p.NomProveedor.Contains(nombre))
                    .Take(10)
                    .ToList();
            }
            return proveedores;
        }
    }
}