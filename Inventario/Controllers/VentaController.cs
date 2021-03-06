﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inventario.Models.DB;
using Inventario.Models.BusinessLogic;
using Inventario.Models.ViewModel;

namespace Inventario.Controllers
{
    public class VentaController : Controller
    {
        VentaLogic ventaL = new VentaLogic();
        DetalleVentaLogic detalleL = new DetalleVentaLogic();
        ProductoLogic productoL = new ProductoLogic();
        ClienteLogic clientesL = new ClienteLogic();
        TipoPagoLogic tipoPagoL = new TipoPagoLogic();
        TipoVentaLogic tipoVentaL = new TipoVentaLogic();

        // GET: Venta
        public ActionResult Index()
        {
            try
            {
                List<VentaViewModel> list = ventaL.GetVentas();
                return View(list);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("Hubo un error al cargar la lista de ventas", ex);
                return View();
            }
        }

        public JsonResult GetAutocompleteProductos(string nombre)
        {
            return Json(productoL.GetProductos(nombre), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAutocompleteClientes(string nombre)
        {
            return Json(clientesL.GetClientes(nombre), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAutocompleteTipoVenta(string nombre)
        {
            return Json(tipoVentaL.GetTiposVentas(nombre), JsonRequestBehavior.AllowGet); 
        }

        public JsonResult GetAutocompleteTipoPago(string nombre)
        {
            return Json(tipoPagoL.GetTiposPagos(nombre), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SaveVenta(VentaViewModel model)
        {
            try
            {
                ventaL.Save(model);
                return Content("1");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("Hubo un error al guardar la venta. ", ex);
                return Content(ex.Message);
            }

        }


        public ActionResult EditarVenta(int id)
        {
            return View(ventaL.Get(id));
        }

        [HttpPost]
        public ActionResult EditarVenta(VentaViewModel model)
        {
            try
            {
                ventaL.Edit(model);
                return Content("1");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("Hubo un error al editar la venta", ex);
                return Content(ex.Message);
            }
        }


        public ActionResult EditarDetalle(int id)
        {
            return View(detalleL.Get(id));
        }

        [HttpPost]
        public ActionResult EditarDetalle(DetalleVentaViewModel model)
        {
            try
            {
                detalleL.Edit(model);
                return Content("1");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Hubo un error al editar el detalle. ", ex);
                return Content(ex.Message);

            }
        }


    }
}