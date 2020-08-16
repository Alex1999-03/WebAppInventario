using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inventario.Models.DB;
using Inventario.Models.ViewModel;
using System.Data.Entity;

namespace Inventario.Models.BusinessLogic
{
    public class DetalleVentaLogic
    {
        VentaLogic ventaL = new VentaLogic();

        public void Edit(DetalleVentaViewModel model)
        {
            using (var db = new PulperiaDBEntities())
            {
                decimal total = 0;
                DetalleVentas detalle = db.DetalleVentas.Find(model.Id);
                detalle.Cantidad = model.Cantidad;
                detalle.PrecioVenta = model.PrecioVenta;
                detalle.ProductoId = model.ProductoId;
                db.Entry(detalle).State = EntityState.Modified;
                db.SaveChanges();

                List<DetalleVentas> listD = db.DetalleVentas.Where(d => d.VentaId == detalle.VentaId).ToList();
                foreach (var d in listD)
                {
                    total += (d.Cantidad * d.PrecioVenta);
                }

                ventaL.ActualizarTotal(total, detalle.VentaId);
            }
        }

        public DetalleVentaViewModel Get(int id)
        {
            DetalleVentaViewModel model = new DetalleVentaViewModel();
            using (var db = new PulperiaDBEntities())
            {

                var detalle = db.DetalleVentas.Find(id);
                model.Id = detalle.Id;
                model.Cantidad = detalle.Cantidad;
                model.PrecioVenta = detalle.PrecioVenta;
                model.ProductoId = detalle.ProductoId;
                model.Productos = db.Productos.Find(detalle.ProductoId);

                return model;
            }
        }
    }
}