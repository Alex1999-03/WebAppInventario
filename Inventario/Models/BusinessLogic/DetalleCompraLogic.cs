using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inventario.Models.ViewModel;
using Inventario.Models.DB;
using System.Data.Entity;
using Inventario.Models.BusinessLogic;

namespace Inventario.Models.BusinessLogic
{
    public class DetalleCompraLogic
    {
        CompraLogic compraL = new CompraLogic();

        public void Edit(DetalleCompraViewModel model)
        {
            
           
            using (var db = new PulperiaDBEntities())
            {
                decimal total = 0;
                DetalleCompras detalle = db.DetalleCompras.Find(model.Id);
                detalle.FechaVencim = model.FechaVencim;
                detalle.ProductoId = model.ProductoId;
                detalle.Cantidad = model.Cantidad;
                detalle.PrecioCompra = model.PrecioCompra;
                db.Entry(detalle).State = EntityState.Modified;
                db.SaveChanges();

                List<DetalleCompras> listD = db.DetalleCompras.Where(d => d.CompraId == detalle.CompraId).ToList();
                foreach(var d in listD)
                {
                    total += (d.Cantidad * d.PrecioCompra);
                }

                compraL.ActualizarTotal(total, detalle.CompraId);
            }
        }

        public DetalleCompraViewModel Get(int id)
        {
            DetalleCompraViewModel model = new DetalleCompraViewModel();
            using(var db = new PulperiaDBEntities())
            {
                
                var detalle = db.DetalleCompras.Find(id);
                model.Id = detalle.Id;
                model.FechaVencim = detalle.FechaVencim;
                model.Cantidad = detalle.Cantidad;
                model.PrecioCompra = detalle.PrecioCompra;
                model.ProductoId = detalle.ProductoId;
                model.Productos = db.Productos.Find(detalle.ProductoId);
                
                return model;
            }
        }
    }
}