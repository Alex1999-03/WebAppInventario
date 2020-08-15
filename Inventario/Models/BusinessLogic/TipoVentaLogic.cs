using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inventario.Models.DB;

namespace Inventario.Models.BusinessLogic
{
    public class TipoVentaLogic
    {
        public List<TipoVentas> GetTiposVentas(string nombre)
        {
            List<TipoVentas> tipoVentas = new List<TipoVentas>();

            using (var db = new PulperiaDBEntities())
            {
                tipoVentas = db.TipoVentas.OrderBy(p => p.DescrpTipoventa)
                    .Where(p => p.DescrpTipoventa.Contains(nombre))
                    .Take(10)
                    .ToList();
            }
            return tipoVentas;
        }
    }
}