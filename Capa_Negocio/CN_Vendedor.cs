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
        CD_Producto ObjteProducto = new CD_Producto();

        public DataTable Listar()
        {
            DataTable dt = new DataTable();
            return dt = ObjteProducto.ListarProductos();
        }
    }
}
