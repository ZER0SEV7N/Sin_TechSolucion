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
            //Cargar datos en el datagridview
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
            //Limpiar campos antes de insertar
            LimpiarCampos();
            //Cambiar modo a insertar
            modoActual = ModoOperacion.Insertar;
            //Habilitar campos
            HabilitarCampos();
            //Actualizar etiquetas y botones
            lblOpcion.Text = "Insertar Producto";
            btnConfirmar.Text = "Guardar Producto";
            //Deseleccionar cualquier fila seleccionada en el DataGridView
            DGVAlmacen.ClearSelection();
            //Resetear ID de producto seleccionado
            productoSeleccionadoId = null;
        }
        //Metodo para insertar producto
        private void insertarProducto()
        {
            //Agregar Try/Catch para manejo de errores
            try
            {
                //Validar que los campos obligatorios no esten vacios
                if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                    string.IsNullOrWhiteSpace(txtPrecio.Text) ||
                    string.IsNullOrWhiteSpace(txtStock.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos.");
                    return;
                }
                //Llamar al metodo de insertar producto de la capa de negocio y pasar los parametros
                objPro.CN_InsertarProducto(txtNombre.Text, 
                    txtDescripcion.Text, 
                    Convert.ToDouble(txtPrecio.Text), 
                    Convert.ToInt32(txtStock.Text), 
                    Program.Info_Organization_Session.xId_Usuario);
                //Mensaje de exito
                MessageBox.Show("Producto insertado correctamente");
                //Recargar productos en el datagridview
                CargarProducto();
                //Limpiar los campos
                LimpiarCampos();
                //Deshabilitar campos
                DeshabilitarCampos();
            }
            //En caso de error, mostrar mensaje
            catch (Exception ex)
            { 
                MessageBox.Show("Error al insertar producto: " + ex.Message);
            }
        }
        //Metodo para activar modo editar en el formulario principal
        public void ActivarModoEditar()
        {
            //Verificar si hay un producto seleccionado
            if (productoSeleccionadoId == null)
            {
                MessageBox.Show("Seleccione un producto de la lista antes de editar.");
                return;
            }
            //Actualizar etiquetas y botones
            lblOpcion.Text = "Editar Producto";
            btnConfirmar.Text = "Confirmar";
            //Cambiar modo a editar
            modoActual = ModoOperacion.Editar;
            //Habilitar campos
            HabilitarCampos();
        }
        //Metodo para editar producto
        private void editarProducto()
        {
            //Try/Catch para manejo de errores
            try
            {
                //LLamar al metodo de editar producto de la capa de negocio y pasar los parametros
                objPro.CN_EditarProducto(productoSeleccionadoId.Value,
                    txtNombre.Text,
                    txtDescripcion.Text,
                    Convert.ToDouble(txtPrecio.Text),
                    Convert.ToInt32(txtStock.Text),
                    Program.Info_Organization_Session.xId_Usuario);
                //Mensaje de exito
                MessageBox.Show("Producto editado correctamente");
                //Recargar productos en el datagridview
                CargarProducto();
                //Limpiar los campos
                LimpiarCampos();
                //Deshabilitar campos
                DeshabilitarCampos();

            }
            //Catch para manejo de errores
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar producto: " + ex.Message);
            }
        }
        //Metodo para activar modo eliminar en el formulario principal
        public void ActivarModoEliminar()
        {
            //Verificar si hay un producto seleccionado
            if (productoSeleccionadoId == null)
            {
                MessageBox.Show("Seleccione un producto de la lista antes de editar.");
                return;
            }
            DeshabilitarCampos();
            //Cambiar modo a eliminar
            modoActual = ModoOperacion.Eliminar;
            //Llamar directamente al metodo de eliminar producto
            eliminarProducto();
            //Limpiar campos despues de eliminar
            LimpiarCampos();
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
                    //Llamar al metodo de eliminar producto de la capa de negocio y pasar el parametro
                    objPro.CN_EliminarProducto(productoSeleccionadoId.Value);
                    //Mensaje de exito
                    MessageBox.Show("Producto eliminado correctamente");
                    //Resetear ID de producto seleccionado
                    productoSeleccionadoId = null;
                    //Recargar productos en el datagridview
                    CargarProducto();
                    //Limpiar campos
                    LimpiarCampos();
                    
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
            lblOpcion.Text = "Visualizar Producto";
            btnConfirmar.Text = "XXXXXXXXXXX";
        }
        //Metodo para filtrar productos por nombre
        public void FiltrarProductos(string filtro)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(filtro))
                {
                    DGVAlmacen.DataSource = objPro.CN_ListarProductos();
                }
                else
                {
                    DGVAlmacen.DataSource = objPro.CN_BuscarProductos(filtro);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar productos: " + ex.Message);
            }
        }
        //Evento click del boton confirmar
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
        //Evento para seleccionar fila del datagridview
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

