using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;

namespace Capa_Negocio
{
    public class CN_Producto
    {
        //obejto de referencia
        CD_Producto ObjProducto = new CD_Producto();
        //obtener los productos
        public DataTable CN_TabalaProductos()
        {
            DataTable dt = new DataTable();
            dt = ObjProducto.ListarProductos();
            return dt;
        }
    }
}
