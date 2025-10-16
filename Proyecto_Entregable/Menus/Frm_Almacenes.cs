using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Negocio;

namespace Proyecto_Entregable
{
    public partial class Frm_Almacenes : Form
    {
        //referencia con objeto producto
        CN_Producto objPro = new CN_Producto();
        // Variable privada para guardar el ID del producto seleccionado
        private int? productoSeleccionadoId = null;
        //Modo actual del formulario
        private ModoOperacion modoActual = ModoOperacion.Ninguno;
        //Enumeracion para los modos de operacion
        public enum ModoOperacion
        {
            Ninguno,
            Insertar,
            Editar,
            Eliminar
        }
        //Constructor
        public Frm_Almacenes()
        {
            InitializeComponent();
            CargarProducto();
        }
        
        //metodo para invocar datos del producto
        private void CargarProducto()
        {
            objPro.CN_ListarProductos();
            DGVAlmacen.DataSource = objPro.CN_ListarProductos();
        }
        //Metodo para deshabilitar campos
        private void DeshabilitarCampos()
        {
            txtNombre.Enabled = false;
            txtDescripcion.Enabled = false;
            txtPrecio.Enabled = false;
            txtStock.Enabled = false;
            btnConfirmar.Enabled = false;
        }
        //Metodo para habilitar campos

        private void HabilitarCampos()
        {
            txtNombre.Enabled = true;
            txtDescripcion.Enabled = true;
            txtPrecio.Enabled = true;
            txtStock.Enabled = true;
            btnConfirmar.Enabled = true;
        }
        //Metodo para activar modo editar en el formulario principal
        public void ActivarModoInsertar()
        {
            LimpiarCampos();
            modoActual = ModoOperacion.Insertar;
            HabilitarCampos();
            lblOpcion.Text = "Insertar Producto";
            btnConfirmar.Text = "Guardar Producto";
        }
        //Metodo para insertar producto
        private void insertarProducto()
        {
            try { 
                if(string.IsNullOrWhiteSpace(txtNombre.Text) ||
                    string.IsNullOrWhiteSpace(txtPrecio.Text) ||
                    string.IsNullOrWhiteSpace(txtStock.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos.");
                    return;
                }
                objPro.CN_InsertarProducto(txtNombre.Text, 
                txtDescripcion.Text, 
                Convert.ToDouble(txtPrecio.Text), 
                Convert.ToInt32(txtStock.Text), 
                Program.Info_Organization_Session.xId_Usuario);
                MessageBox.Show("Producto insertado correctamente");
                CargarProducto();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar producto: " + ex.Message);
            }
        }
        //Metodo para activar modo editar en el formulario principal
        public void ActivarModoEditar()
        {
            if (productoSeleccionadoId == null)
            {
                MessageBox.Show("Seleccione un producto de la lista antes de editar.");
                return;
            }
            modoActual = ModoOperacion.Editar;
            HabilitarCampos();
            lblOpcion.Text = "Editar Producto";
            btnConfirmar.Text = "Confirmar";
        }
        //Metodo para editar producto
        private void editarProducto()
        {
            try
            {
                
                objPro.CN_EditarProducto(productoSeleccionadoId.Value,
                    txtNombre.Text,
                    txtDescripcion.Text,
                    Convert.ToDouble(txtPrecio.Text),
                    Convert.ToInt32(txtStock.Text),
                    Program.Info_Organization_Session.xId_Usuario);
                MessageBox.Show("Producto editado correctamente");
                CargarProducto();
                LimpiarCampos();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar producto: " + ex.Message);
            }
        }
        //Metodo para activar modo eliminar en el formulario principal
        public void ActivarModoEliminar()
        {
            if (productoSeleccionadoId == null)
            {
                MessageBox.Show("Seleccione un producto de la lista antes de editar.");
                return;
            }
            eliminarProducto();
        }
        //Metodo para eliminar producto
        private void eliminarProducto()
        {
            try
            {
                //Confirmacion de eliminacion de producto
                var confirm = MessageBox.Show(
                  "¿Seguro que desea eliminar este producto?",
                  "Confirmar eliminación",
                  MessageBoxButtons.YesNo,
                  MessageBoxIcon.Warning
                );
                if(confirm == DialogResult.Yes) { 
                    objPro.CN_EliminarProducto(productoSeleccionadoId.Value);
                    MessageBox.Show("Producto eliminado correctamente");
                    CargarProducto();
                    LimpiarCampos();
                    productoSeleccionadoId = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar producto: " + ex.Message);
            }
        }

        //Metodo para limpiar campos
        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
        }

        private void DGVAlmacen_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            switch (modoActual)
            {
                case ModoOperacion.Insertar:
                    insertarProducto();
                    break;
                case ModoOperacion.Editar:
                    editarProducto();
                    break;
            }

            modoActual = ModoOperacion.Ninguno;
            DeshabilitarCampos();
        }

        private void DGVAlmacen_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = DGVAlmacen.Rows[e.RowIndex];
                productoSeleccionadoId = Convert.ToInt32(row.Cells["idPro"].Value);
                txtNombre.Text = row.Cells["Nombre"].Value.ToString();
                txtDescripcion.Text = row.Cells["Descripcion"].Value.ToString();
                txtPrecio.Text = row.Cells["Precio"].Value.ToString();
                txtStock.Text = row.Cells["Stock"].Value.ToString();
            }
        }
    }
}

