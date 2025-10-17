using Capa_Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio
{
    public class CN_Vendedor
    {
        //intancia referencia a objeto producto en la capa datos
        CD_Ventas ObjteProducto = new CD_Ventas();
        //instancia a Detalle
        CD_DetalleVentas objDetalle = new CD_DetalleVentas();
        public DataTable Listar()
        {
            DataTable dt = new DataTable();
            return dt = ObjteProducto.ListarProductos();
        }
        public int CrearVenta(int idCliente, int idUser, decimal total, List<CD_DetalleVentas> detalles)
        {
            return objDetalle.InsertarVenta(idCliente, idUser, total, detalles);
        }
    }
}
