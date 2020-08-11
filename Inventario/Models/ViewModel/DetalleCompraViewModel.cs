using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inventario.Models.DB;
namespace Inventario.Models.ViewModel
{
    public class DetalleCompraViewModel
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioCompra { get; set; }
        public System.DateTime FechaVencim { get; set; }
        public Productos Productos { get; set; }
        public int ProductoId { get; set; }
    }
}