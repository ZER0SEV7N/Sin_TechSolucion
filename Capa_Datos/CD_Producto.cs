using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos
{
    public class CD_Producto
    {
        //atrivutos
        private int _IdProducto;
        private string _Nombre;
        private double _Precio;
        private int _stock;
        private bool _activo;
        private int _IdUser;

        //constructores 

        public CD_Producto()
        {        }
        public CD_Producto(int idProducto, string nombre, double precio, int stock, bool activo, int idUser)
        {
            _IdProducto = idProducto;
            _Nombre = nombre;
            _Precio = precio;
            _stock = stock;
            _activo = activo;
            _IdUser = idUser;
        }
        //metodos get y set
        public int IdProducto { get => _IdProducto; set => _IdProducto = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public double Precio { get => _Precio; set => _Precio = value; }
        public int Stock { get => _stock; set => _stock = value; }
        public bool Activo { get => _activo; set => _activo = value; }
        public int IdUser { get => _IdUser; set => _IdUser = value; }
        //objeto conexion
        CD_Conexion _Conexion = new CD_Conexion();
        //metodo para ver los porducots
        public DataTable ListarProductos()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_CRUD_Productos", _Conexion.AbrirConexion());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Opcion", "LISTAR");

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
               
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error de obtener prodcutos", ex);
                return null;
            }
            finally
            {
                _Conexion.CerrarConexion();
            }
        }
    }
}
