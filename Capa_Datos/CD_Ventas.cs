using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos
{
    public class CD_Ventas
    {
        //Atributos
        private int _idVenta;
        private int _idCliente;
        private DateTime _fecha;
        private double _Total;
        private string _Estado;
        private int _idUario;
        //contructores
        public CD_Ventas(int idVenta, int idCliente, DateTime fecha, double total, string estado, int idUario)
        {
            _idVenta = idVenta;
            _idCliente = idCliente;
            _fecha = fecha;
            _Total = total;
            _Estado = estado;
            _idUario = idUario;
        }

        public CD_Ventas()
        {
        }
        //metodos gets y setss

        public int IdVenta { get => _idVenta; set => _idVenta = value; }
        public int IdCliente { get => _idCliente; set => _idCliente = value; }
        public DateTime Fecha { get => _fecha; set => _fecha = value; }
        public double Total { get => _Total; set => _Total = value; }
        public string Estado { get => _Estado; set => _Estado = value; }
        public int IdUario { get => _idUario; set => _idUario = value; }
        //isntacia a la calse conexion
        CD_Conexion _Conexion = new CD_Conexion();
        public DataTable ListarProductos()
        {
            string sqlQuery = @"
                    SELECT 
                        idPro, 
                        nombre,
                        descripcion,
                        precio,
                        stock
                    FROM 
                       v_ProductosRegistrados";
            try
            {
                SqlCommand cmd = new SqlCommand(sqlQuery, _Conexion.AbrirConexion());
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                _Conexion.CerrarConexion();
            }
        }
        //insertar producots

        
    }
}
