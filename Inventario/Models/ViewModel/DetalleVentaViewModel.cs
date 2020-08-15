using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inventario.Models.DB;
namespace Inventario.Models.ViewModel
{
    public class DetalleVentaViewModel
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioVenta { get; set; }
        public int VentaId { get; set; }
        public int ProductoId { get; set; }
        public Productos Productos { get; set; }
    }
}