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
        //Instancia en referencia al objeto productos
        CD_Producto ObjProducto = new CD_Producto();
        //Metodo para listar los productos
        public DataTable CN_ListarProductos()
        {
            DataTable dt = new DataTable();
            dt = ObjProducto.ListarProductos();
            return dt;
        }
        //Metodo para insertar productos
        public void CN_InsertarProducto(string nombre,string descripcion,  double precio, int stock, int idUser)
        {
            ObjProducto.InsertarProducto(nombre, descripcion, precio, stock, idUser);
        }
        //Metodo para editar productos
        public void CN_EditarProducto(int idProducto, string nombre, string descripcion, double precio, int stock, int idUser)
        {
            ObjProducto.Editar(idProducto, nombre, descripcion, precio, stock, idUser);
        }
        //Metodo para eliminar productos
        public void CN_EliminarProducto(int idProducto)
        {
            ObjProducto.EliminarProducto(idProducto);
        }
    }
}
