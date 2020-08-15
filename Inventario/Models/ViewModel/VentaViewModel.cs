using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventario.Models.ViewModel
{
    public class VentaViewModel
    {
        public int Id { get; set; }
        public string CodigoVenta { get; set; }
        public DateTime FechaVenta { get; set; }
        public Nullable<decimal> TotalVenta { get; set; }
        public string DescrpVenta { get; set; }
        public int TipoVentaId { get; set; }
        public string DescrpTipoVenta { get; set; }
        public int TipoPagoId { get; set; }
        public string DescrpTipoPago { get; set; }
        public int ClienteId { get; set; }
        public string NomCliente { get; set; }
        public virtual ICollection<DetalleVentaViewModel> DetalleVentas { get; set; }
    }
}