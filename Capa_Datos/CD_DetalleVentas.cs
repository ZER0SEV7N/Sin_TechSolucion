using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos
{
    public class CD_DetalleVentas
    {
        //atributos
        private int _idVentas;
        private int _idPor;
        private int _cantidad;
        private double _precioUnitario;
        private double _subtotal;

        public CD_DetalleVentas()
        {
        }

        public CD_DetalleVentas(int idVentas, int idPor, int cantidad, double precioUnitario, double subtotal)
        {
            _idVentas = idVentas;
            _idPor = idPor;
            _cantidad = cantidad;
            _precioUnitario = precioUnitario;
            _subtotal = subtotal;
        }

        public int IdVentas { get => _idVentas; set => _idVentas = value; }
        public int IdPor { get => _idPor; set => _idPor = value; }
        public int Cantidad { get => _cantidad; set => _cantidad = value; }
        public double PrecioUnitario { get => _precioUnitario; set => _precioUnitario = value; }
        public double Subtotal { get => _subtotal; set => _subtotal = value; }
        //intancia a la conexion
        CD_Conexion _conexion = new CD_Conexion();
        //meotod para insertarVneta
        public int InsertarVenta(int idCliente, int idUser, decimal total, List<CD_DetalleVentas> detalles)
        {
            int idVentaGenerada = 0;

            //Convertir la lista en un datatable para su
            DataTable dt = new DataTable();
            dt.Columns.Add("idPro", typeof(int));
            dt.Columns.Add("cantidad", typeof(int));
            dt.Columns.Add("precioUnitario", typeof(int));
            foreach (var detalle in detalles)
            {
                dt.Rows.Add(detalle._idPor, detalle.Cantidad, detalle._precioUnitario);

            }
            //ejecutar el procedimento almacenado
            try
            {
                //preparar comando
                SqlCommand cmd = new SqlCommand();
                //datos a ingresar para la cabecer (isnercion a la tabla datos)
                cmd.Parameters.AddWithValue("@idCliente", idCliente);
                cmd.Parameters.AddWithValue("@idUser", idUser);
                cmd.Parameters.AddWithValue("@Total", total);

                //Parametros para el detalles
                SqlParameter detalleParam = new SqlParameter();
                detalleParam.ParameterName = "@DetalleVenta";
                detalleParam.SqlDbType = SqlDbType.Structured;
                detalleParam.TypeName = "dbo.TipoDetalleVenta";
                detalleParam.Value = dt;
                cmd.Parameters.Add(detalleParam);

                //objeto a ejecutar y botener el id retornado por SqlParament
                object resultado = cmd.ExecuteScalar();
                if (resultado != null && resultado != DBNull.Value)
                {
                    idVentaGenerada = Convert.ToInt32(resultado);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error en el emtodoVnetas" + ex.Message);
            }
            finally{
                _conexion.CerrarConexion();
            }
            return idVentaGenerada;
        }

    }
}
