using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inventario.Models.DB;

namespace Inventario.Models.BusinessLogic
{
    public class TipoPagoLogic
    {
        public List<TipoPagos> GetTiposPagos(string nombre)
        {
            List<TipoPagos> tipoPagos = new List<TipoPagos>();

            using (var db = new PulperiaDBEntities())
            {
                tipoPagos = db.TipoPagos.OrderBy(p => p.DescrpTipoPago)
                    .Where(p => p.DescrpTipoPago.Contains(nombre))
                    .Take(10)
                    .ToList();
            }
            return tipoPagos;
        }
    }
}