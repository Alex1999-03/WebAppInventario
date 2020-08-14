using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inventario.Models.ViewModel;
using Inventario.Models.BusinessLogic;
using Inventario.Models.DB;

namespace Inventario.Controllers
{
    public class CompraController : Controller
    {
        CompraLogic compraL = new CompraLogic();
        ProveedorLogic proveedorL = new ProveedorLogic();
        ProductoLogic productoL = new ProductoLogic();
        DetalleCompraLogic detalleL = new DetalleCompraLogic();

        // GET: Compra
        public ActionResult Index()
        {
            try
            {
                List<CompraViewModel> list = compraL.GetCompras();
                return View(list);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("Hubo un error al cargar la lista de compras", ex);
                return View();
            }
        }
        
        public JsonResult GetAutocompleteProveedor(string nombre)
        {
            return Json(proveedorL.GetProveedores(nombre), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAutocompleteProductos(string nombre)
        {
            return Json(productoL.GetProductos(nombre), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SaveCompra(CompraViewModel model)
        {
            try
            {
                compraL.Save(model);
                return Content("1");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("Hubo un error al guardar la compra. ", ex);
                return Content(ex.Message);
            }
            
        }


        public ActionResult EditarCompra(int id)
        {
            return View(compraL.Get(id));
        }

        [HttpPost]
        public ActionResult EditarCompra(CompraViewModel model)
        {
            try
            {
                compraL.Edit(model);
                return Content("1");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("Hubo un error al editar la compra", ex);
                return Content(ex.Message);
            }
        }
        
        public ActionResult EditarDetalle(int id)
        {  
            return View(detalleL.Get(id));
        }

        [HttpPost]
        public ActionResult EditarDetalle(DetalleCompraViewModel model)
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