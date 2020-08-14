using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inventario.Models.ViewModel;
using Inventario.Models.DB;
using System.Data.Entity;

namespace Inventario.Models.BusinessLogic
{
    public class CompraLogic
    {
        public List<CompraViewModel> GetCompras()
        {
            List<CompraViewModel> list;
            using (var db = new PulperiaDBEntities())
            {

                list = (from c in db.Compras
                        select new CompraViewModel
                        {
                            Id = c.Id,
                            CodigoCompra = c.CodigoCompra,
                            FechaCompra = c.FechaCompra,
                            TotalCompra = c.TotalCompra,
                            DescrpCompra = c.DescrpCompra,
                            NomProveedor = c.Proveedores.NomProveedor,
                            ProveedorId = c.Proveedores.Id,
                            DetalleCompras = (from d in c.DetalleCompras
                                              select new DetalleCompraViewModel
                                              {
                                                  Id = d.Id,
                                                  Cantidad = d.Cantidad,
                                                  PrecioCompra = d.PrecioCompra,
                                                  FechaVencim = d.FechaVencim,
                                                  Productos = db.Productos.Where(p => p.Id == d.ProductoId).FirstOrDefault()
                                              }).ToList()


                        }).ToList();

                return list;
            }
        }

        public CompraViewModel Get(int id)
        {
            CompraViewModel compra = new CompraViewModel();
            using (var db = new PulperiaDBEntities())
            {
                compra = (from c in db.Compras
                          where c.Id == id
                          select new CompraViewModel
                          {
                              Id = c.Id,
                              CodigoCompra = c.CodigoCompra,
                              DescrpCompra = c.DescrpCompra,
                              FechaCompra = c.FechaCompra,
                              NomProveedor = c.Proveedores.NomProveedor,
                              ProveedorId = c.ProveedorId
                          }).FirstOrDefault();
                return compra;
            }
        }

        public void Save(CompraViewModel model)
        {
            Compras compra = new Compras();
            DetalleCompras detalleC = new DetalleCompras();
            using (var db = new PulperiaDBEntities())
            {
                compra.CodigoCompra = model.CodigoCompra;
                compra.DescrpCompra = model.DescrpCompra;
                compra.FechaCompra = DateTime.Now;
                compra.ProveedorId = model.ProveedorId;
                db.Compras.Add(compra);
                db.SaveChanges();
                foreach (var detalle in model.DetalleCompras)
                {
                    detalleC.CompraId = compra.Id;
                    detalleC.FechaVencim = detalle.FechaVencim;
                    detalleC.Cantidad = detalle.Cantidad;
                    detalleC.PrecioCompra = detalle.PrecioCompra;
                    detalleC.ProductoId = detalle.ProductoId;
                    db.DetalleCompras.Add(detalleC);
                    db.SaveChanges();
                }
            }   
        }

        public void Edit(CompraViewModel model)
        {
            using(var db = new PulperiaDBEntities())
            {
                Compras compra = new Compras();
                compra = db.Compras.Find(model.Id);
                compra.CodigoCompra = model.CodigoCompra;
                compra.DescrpCompra = model.DescrpCompra;
                compra.FechaCompra = model.FechaCompra;
                compra.ProveedorId = model.ProveedorId;
                db.Entry(compra).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void ActualizarTotal(decimal total, int id)
        {
            
            using (var db = new PulperiaDBEntities())
            {
                Compras model = db.Compras.Find(id);
                model.TotalCompra = total;
                db.Entry(model).State = EntityState.Modified;
                
            }
        }

        
    }
}