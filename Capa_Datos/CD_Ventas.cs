using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Capa_Datos
{
    public class CD_Ventas
    {
        //Propiedades de ventas
        public int IdVenta { get; set; }
        public int IdCliente { get; set; }
        public DateTime Fecha { get; set; }
        public double Total { get; set; }
        public string Estado { get; set; }
        public int IdUsuario { get; set; }

        //Lista de detalles
        public List<CD_DetalleVentas> Detalles { get; set; } = new List<CD_DetalleVentas>();

        //Instancia de conexión
        CD_Conexion conexion = new CD_Conexion();

        // --- Método para insertar venta con detalles ---
        public bool InsertarVentaCompleta()
        {
            SqlConnection cn = conexion.AbrirConexion();
            SqlTransaction transaccion = cn.BeginTransaction();

            try
            {
                // Insertar la venta principal
                SqlCommand cmdVenta = new SqlCommand(
                    @"INSERT INTO Ventas (IdCliente, Fecha, Total, Estado, IdUsuario)
                      VALUES (@IdCliente, @Fecha, @Total, @Estado, @IdUsuario);
                      SELECT SCOPE_IDENTITY();", cn, transaccion);

                cmdVenta.Parameters.AddWithValue("@IdCliente", IdCliente);
                cmdVenta.Parameters.AddWithValue("@Fecha", Fecha);
                cmdVenta.Parameters.AddWithValue("@Total", Total);
                cmdVenta.Parameters.AddWithValue("@Estado", Estado);
                cmdVenta.Parameters.AddWithValue("@IdUsuario", IdUsuario);

                // Obtener el ID generado
                int idVentaGenerado = Convert.ToInt32(cmdVenta.ExecuteScalar());

                // Insertar los detalles
                foreach (var detalle in Detalles)
                {
                    SqlCommand cmdDetalle = new SqlCommand(
                        @"INSERT INTO DetalleVenta (IdVenta, IdPro, Cantidad, PrecioUnitario, Subtotal)
                          VALUES (@IdVenta, @IdPro, @Cantidad, @PrecioUnitario, @Subtotal)", cn, transaccion);

                    cmdDetalle.Parameters.AddWithValue("@IdVenta", idVentaGenerado);
                    cmdDetalle.Parameters.AddWithValue("@IdPro", detalle.IdPor);
                    cmdDetalle.Parameters.AddWithValue("@Cantidad", detalle.Cantidad);
                    cmdDetalle.Parameters.AddWithValue("@PrecioUnitario", detalle.PrecioUnitario);
                    cmdDetalle.Parameters.AddWithValue("@Subtotal", detalle.Subtotal);

                    cmdDetalle.ExecuteNonQuery();

                    // Disminuir stock
                    SqlCommand cmdStock = new SqlCommand(
                        "UPDATE Productos SET stock = stock - @Cantidad WHERE idPro = @IdPro", cn, transaccion);
                    cmdStock.Parameters.AddWithValue("@Cantidad", detalle.Cantidad);
                    cmdStock.Parameters.AddWithValue("@IdPro", detalle.IdPor);
                    cmdStock.ExecuteNonQuery();
                }

                // Si todo sale bien
                transaccion.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaccion.Rollback();
                Console.WriteLine("Error al registrar venta: " + ex.Message);
                return false;
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }

        //Listar productos disponibles
        public DataTable ListarProductos()
        {
            string query = @"SELECT idPro, nombre, descripcion, precio, stock FROM v_ProductosRegistrados";
            SqlCommand cmd = new SqlCommand(query, conexion.AbrirConexion());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conexion.CerrarConexion();
            return dt;
        }
    }
}