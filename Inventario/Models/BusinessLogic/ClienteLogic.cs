using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inventario.Models.DB;

namespace Inventario.Models.BusinessLogic
{
    public class ClienteLogic
    {
        public List<Clientes> GetClientes(string nombre)
        {
            List<Clientes> clientes = new List<Clientes>();
            using (var db = new PulperiaDBEntities())
            {
                clientes = db.Clientes.OrderBy(p => p.NomCliente)
                     .Where(p => p.NomCliente.Contains(nombre))
                     .Take(10)
                     .ToList();
            }
            return clientes;
        }
    }
}