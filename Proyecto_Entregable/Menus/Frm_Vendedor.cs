using Capa_Negocio;
using Capa_Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic; 

namespace Proyecto_Entregable
{
    public partial class Frm_Vendedor : Form
    {
        public Frm_Vendedor()
        {
            InitializeComponent();
            ListarProductos();
        }
        //referencia a la capa de neogcio
        CN_Vendedor objVendedor = new CN_Vendedor();

        //cargar datos en el dataGrid
        private void ListarProductos()
        {
            DGVproducto.DataSource = objVendedor.Listar();
        }
        private void limpiarAreas()
        {
            txtCorreo.Clear();
            txtDireccion.Clear();
            txtNombre.Clear();
            txtDocumento.Clear();
            txtTelefono.Clear();
        }
        private List<CD_DetalleVentas> Carrito = new List<CD_DetalleVentas>();
        // Método para calcular el Total de la venta
        private void CrearVenta()
        {
            //validar campos rellenados
            if (string.IsNullOrEmpty(txtNombre.Text) ||
                string.IsNullOrEmpty(txtDocumento.Text) ||
                DTGProductosC.CurrentRow == null
             )
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }
            //obtenr datos 
            //manejo de errores 
            try
            {

                //llamar el metodo de insertar venta
                //Mensaje de exito
                MessageBox.Show("Venta creada correctamente");
                //Cragra productos
                ListarProductos();
                //limpiar los txt areas
                limpiarAreas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear venta: " + ex.Message);
            }

        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (DGVproducto.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un prodcuto para añadir", "alerta");
                return;
            }
            //obtener los datos del producto selecionado
            DataGridViewRow fila = DGVproducto.CurrentRow;
            int idPro = Convert.ToInt32(fila.Cells["idPro"].Value);
            string nombre = fila.Cells["nombre"].Value.ToString();
            decimal precio = Convert.ToDecimal(fila.Cells["precio"].Value);
            decimal stock = Convert.ToInt32(fila.Cells["stock"].Value);
            // 2. Mostrar la ventana emergente y obtener el valor
            string input = Interaction.InputBox(
                $"Ingrese la cantidad a vender (Max: {stock}):", // Prompt/Mensaje
                "Cantidad del Producto", // Título de la ventana
                "1" // Valor por defecto
            );
            if (!string.IsNullOrEmpty(input))
            {
                if (int.TryParse(input, out int cantidad) && cantidad > 0)
                {
                    if (cantidad <= stock)
                    {
                        // 4. Lógica para agregar/sumar al carrito
                        AgregarProductoAlCarrito(idPro, nombre, precio, cantidad);
                    }
                    else
                    {
                        MessageBox.Show($"La cantidad ({cantidad}) excede el stock disponible ({stock}).", "Error de Stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Cantidad inválida. Ingrese un número entero positivo.", "Error de Entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void AgregarProductoAlCarrito(int idPro, string nombre, decimal precio, int cantidad)
        {
            var itemExistente = Carrito.FirstOrDefault(d => d.IdPor == idPro);

            if (itemExistente != null)
            {
                itemExistente.Cantidad += cantidad;
            }
            else
            {
                // Nota: Solo se necesitan idPro, cantidad y precioUnitario para la BD.
                // Las otras propiedades son para mostrar en el DataGrid de la presentación.
                double precioDouble = (double)precio;
                double subtotalCalculado = cantidad * precioDouble;
                Carrito.Add(new CD_DetalleVentas
                {
                    IdPor = idPro,

                    // Usamos Cantidad y PrecioUnitario (con mayúsculas)
                    Cantidad = cantidad,
                    PrecioUnitario = precioDouble,

                    // El subtotal solo se necesita aquí para la presentación, pero no se envía a la BD
                    Subtotal = subtotalCalculado
                });
            }

            // 4. Refrescar el DataGridView del carrito (asumimos que es DTGProductosC)
            DTGProductosC.DataSource = null;
            DTGProductosC.DataSource = Carrito;
        }

    }
}
