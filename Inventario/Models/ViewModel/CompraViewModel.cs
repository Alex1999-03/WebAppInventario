using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inventario.Models.DB;

namespace Inventario.Models.ViewModel
{
    public class CompraViewModel
    {
        public int Id { get; set; }
        public string CodigoCompra { get; set; }
        public System.DateTime FechaCompra { get; set; }
        public Nullable<decimal> TotalCompra { get; set; }
        public string DescrpCompra { get; set; }
        public string NomProveedor { get; set; }
        public int ProveedorId { get; set; }
        public virtual ICollection<DetalleCompraViewModel> DetalleCompras { get; set; }
    }
}