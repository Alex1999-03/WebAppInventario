using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inventario.Models.DB;
using Inventario.Models.ViewModel;
using System.Data.Entity;

namespace Inventario.Models.BusinessLogic
{
    public class VentaLogic
    {
        public List<VentaViewModel> GetVentas()
        {
            List<VentaViewModel> list;
            using (var db = new PulperiaDBEntities())
            {

                list = (from v in db.Ventas
                        select new VentaViewModel
                        {
                            Id = v.Id,
                            CodigoVenta = v.CodigoVenta,
                            FechaVenta = v.FechaVenta,
                            TotalVenta = v.TotalVenta,
                            DescrpVenta = v.DescrpVenta,
                            TipoVentaId = v.TipoVentaId,
                            DescrpTipoVenta = v.TipoVentas.DescrpTipoventa,
                            TipoPagoId = v.TipoPagoId,
                            DescrpTipoPago = v.TipoPagos.DescrpTipoPago,
                            ClienteId = v.ClienteId,
                            NomCliente = v.Clientes.NomCliente,
                            DetalleVentas = (from d in v.DetalleVentas
                                             select new DetalleVentaViewModel
                                             {
                                                 Id = d.Id,
                                                 Cantidad = d.Cantidad,
                                                 ProductoId = d.ProductoId,
                                                 Productos = db.Productos.Where(p => p.Id == d.ProductoId).FirstOrDefault(),
                                                 PrecioVenta = d.PrecioVenta,
                                                 VentaId = d.VentaId
                                             }).ToList()
                        }).ToList();

                return list;
            }
        }

        public VentaViewModel Get(int id)
        {
            VentaViewModel venta = new VentaViewModel();
            using (var db = new PulperiaDBEntities())
            {
                venta = (from v in db.Ventas
                          where v.Id == id
                          select new VentaViewModel
                          {
                              Id = v.Id,
                              CodigoVenta = v.CodigoVenta,
                              DescrpVenta = v.DescrpVenta,
                              FechaVenta = v.FechaVenta,
                              TipoVentaId = v.TipoVentaId,
                              DescrpTipoVenta = db.TipoVentas.Where(x => x.Id == v.TipoVentaId).Select(x => x.DescrpTipoventa).FirstOrDefault(),
                              TipoPagoId = v.TipoPagoId,
                              DescrpTipoPago = db.TipoPagos.Where(x => x.Id == v.TipoPagoId).Select(x => x.DescrpTipoPago).FirstOrDefault(),
                              ClienteId = v.ClienteId,
                              NomCliente = db.Clientes.Where(x => x.Id == v.ClienteId).Select(x => x.NomCliente).FirstOrDefault(), 
                          }).FirstOrDefault();
                return venta;
            }
        }

        public void Save(VentaViewModel model)
        {
            Ventas venta = new Ventas();
            DetalleVentas detalleV = new DetalleVentas();
            using (var db = new PulperiaDBEntities())
            {
                venta.CodigoVenta = model.CodigoVenta;
                venta.DescrpVenta = model.DescrpVenta;
                venta.FechaVenta = DateTime.Now;
                venta.TipoPagoId = model.TipoPagoId;
                venta.TipoVentaId = model.TipoVentaId;
                venta.ClienteId = model.ClienteId;
                db.Ventas.Add(venta);
                db.SaveChanges();
                foreach (var detalle in model.DetalleVentas)
                {
                    detalleV.VentaId = venta.Id;
                    detalleV.PrecioVenta = detalle.PrecioVenta;
                    detalleV.Cantidad = detalle.Cantidad;
                    detalleV.ProductoId = detalle.ProductoId;
                    db.DetalleVentas.Add(detalleV);
                    db.SaveChanges();
                }
            }
        }

        public void Edit(VentaViewModel model)
        {
            using (var db = new PulperiaDBEntities())
            {
                Ventas venta = new Ventas();
                venta = db.Ventas.Find(model.Id);
                venta.CodigoVenta = model.CodigoVenta;
                venta.DescrpVenta = model.DescrpVenta;
                venta.FechaVenta = model.FechaVenta;
                venta.ClienteId = model.ClienteId;
                venta.TipoPagoId = model.TipoPagoId;
                venta.TipoVentaId = model.TipoVentaId;
                db.Entry(venta).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void ActualizarTotal(decimal total, int id)
        {

            using (var db = new PulperiaDBEntities())
            {
                Ventas model = db.Ventas.Find(id);
                model.TotalVenta = total;
                db.Entry(model).State = EntityState.Modified;

            }
        }


    }
}
