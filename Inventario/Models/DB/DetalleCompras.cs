//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Inventario.Models.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class DetalleCompras
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioCompra { get; set; }
        public System.DateTime FechaVencim { get; set; }
        public int CompraId { get; set; }
        public int ProductoId { get; set; }
    
        public virtual Compras Compras { get; set; }
        public virtual Productos Productos { get; set; }
    }
}
