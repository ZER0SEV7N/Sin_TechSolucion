using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Entregable
{
    public partial class Frm_Principal : Form
    {
        // Variable para guardar el formulario anterior
        private Type formularioAnterior = null;
        public Frm_Principal()
        {
            InitializeComponent();
        }
        //Funcion para configurar el mdi con los datos de la organizacion y del usuario
        private void configuration_mdi()
        {
            DireccionLabel.Text = Program.Info_Organization_Session.xDireccion;
            TelefonoLabel.Text = Program.Info_Organization_Session.xTelefono;
            toolStripStatusLabelNombreYapellido.Text = Program.Info_Organization_Session.xNombres + "," +" " + Program.Info_Organization_Session.xApellidos;
            toolStripStatusLabelRol.Text = Program.Info_Organization_Session.xRol;
        }
        //Evento load del formulario
        private void Frm_Principal_Load(object sender, EventArgs e)
        {
            configuration_mdi();
            CargarMenu(Program.Info_Organization_Session.xRol);

        }
        //Funcion para abrir formularios hijos
        private void AbrirFormularios(Form FormHijo)
        {
            //Buscar si el formulario ya está abierto
            Form formularioExistente = Application.OpenForms
                .Cast<Form>()
                .FirstOrDefault(f => f.GetType() == FormHijo.GetType());
            //Si ya está abierto
            if (formularioExistente != null)
            {
                //Si ya está abierto, solo lo traemos al frente
                formularioExistente.BringToFront();
                formularioExistente.Activate();
                return;
            }

            //Cerrar otros formularios MDI
            foreach (Form form in this.MdiChildren.ToArray())
            {
                form.Close();
            }

            //Mostrar el nuevo formulario
            FormHijo.MdiParent = this;
            FormHijo.Dock = DockStyle.Fill;
            FormHijo.Load += (s, e) =>
            {
                CargarOpcionesDelFormulario(FormHijo.GetType().Name);
            };

            FormHijo.Show();
        }
        private void CargarMenu(string rol)
        {
            //Limpiar el menuStrip
            menuStrip1.Items.Clear();

            //Agregar items segun el rol
            switch (rol.ToLower())
            {
                //Caso administrador
                case "administrador":
                    //Crear el menu "Inicio" con sus subitems
                    ToolStripMenuItem menuInicio = new ToolStripMenuItem("Inicio");
                    //Agregar subitems al menu "Inicio y manejar el evento para abrir el formulario correspondiente"
                    menuInicio.DropDownItems.Add("Gestión de Productos", null, (s, e) => AbrirFormularios(new Frm_Almacenes()));
                    menuInicio.DropDownItems.Add("Gestión de Ventas", null, (s, e) => AbrirFormularios(new Frm_Vendedor()));
                    menuInicio.DropDownItems.Add("Reportes", null, (s, e) => AbrirFormularios(new Frm_Informes()));
                    //Agregar el menu "Inicio" al menuStrip
                    menuStrip1.Items.Add(menuInicio);
                    break;
                //Caso vendedor
                case "vendedor":
                    // Abrir directamente el formulario por defecto
                    AbrirFormularios(new Frm_Vendedor());
                    //Crear el menu "Ventas" con su subitem
                    ToolStripMenuItem menuVentas = new ToolStripMenuItem("Ventas");
                    //Agregar subitem al menu "Ventas" y manejar el evento para abrir el formulario correspondiente
                    menuVentas.DropDownItems.Add("Registrar Venta", null, (s, e) => AbrirFormularios(new Frm_Vendedor()));
                    menuStrip1.Items.Add(menuVentas);
                    break;
                //Caso almacenero
                case "almacenero":
                    ToolStripMenuItem menuAlmacen = new ToolStripMenuItem("Productos");
                    menuAlmacen.DropDownItems.Add("Gestión de Productos", null, (s, e) => AbrirFormularios(new Frm_Almacenes()));
                    menuStrip1.Items.Add(menuAlmacen);
                    break;
                //Caso no reconocido
                default:
                    MessageBox.Show("Rol no reconocido. Se cargarán opciones limitadas.");
                    break;
            }
        }
        //Metodo para actualizar el menuStrip dependiendo del rol
        private void CargarOpcionesDelFormulario(String FormularioActivo)
        {
            //Eliminar todos los menús dinámicos excepto los fijos como "Inicio" 
            for (int i = menuStrip1.Items.Count - 1; i >= 0; i--)
            {
                //Obtener el nombre del item
                string nombreItem = menuStrip1.Items[i].Text;
                if (nombreItem != "Inicio")
                {
                    //Remover el item del menu
                    menuStrip1.Items.RemoveAt(i);
                }
            }
            //Agregar opciones específicas según el formulario activo
            switch (FormularioActivo)
            {
                //Caso Frm_Almacenes
                case "Frm_Almacenes":
                    //Agregar opciones especificas para Frm_Almacenes
                    ToolStripMenuItem menuProd = new ToolStripMenuItem("Productos");
                    menuProd.DropDownItems.Add("Agregar Producto", null, (s, e) => {
                        var form = this.ActiveMdiChild as Frm_Almacenes;
                        form?.ActivarModoInsertar();
                    });
                    menuProd.DropDownItems.Add("Modificar Producto", null, (s, e) => {
                        var form = this.ActiveMdiChild as Frm_Almacenes;
                        form?.ActivarModoEditar();
                    });
                    menuProd.DropDownItems.Add("Eliminar Producto", null, (s, e) => {
                        var form = this.ActiveMdiChild as Frm_Almacenes;
                        form?.ActivarModoEliminar();
                    });
                    menuProd.DropDownItems.Add("Generar Reporte de Productos", null, (s, e) => {
                        formularioAnterior = this.ActiveMdiChild.GetType();
                        AbrirFormularios(new Frm_Informes());
                    });
                    //Agregar el separador visual
                    ToolStripSeparator Separator = new ToolStripSeparator();
                    //Agregar los controles para filtrar por nombre
                    ToolStripTextBox lblFiltro = new ToolStripTextBox
                    {
                        Name = "lblFiltro",
                        Text = "Filtrar por Nombre: ",
                        ReadOnly = true,
                        BorderStyle = BorderStyle.None,
                        Width = 130
                    };
                    ToolStripTextBox txtFiltroAlmacenes = new ToolStripTextBox // Cambiado el nombre aquí
                    {
                        Name = "txtFiltro",
                        Width = 200,
                        BorderStyle = BorderStyle.FixedSingle
                    };
                    //Evento para filtrar en tiempo real
                    txtFiltroAlmacenes.TextChanged += (s, e) => {
                        var form = this.ActiveMdiChild as Frm_Almacenes;
                        form?.FiltrarProductos(txtFiltroAlmacenes.Text);
                    };
                    menuStrip1.Items.AddRange(new ToolStripItem[] { menuProd});
                    menuStrip1.Items.Add(Separator);
                    menuStrip1.Items.Add(lblFiltro);
                    menuStrip1.Items.Add(txtFiltroAlmacenes); // Usar el nuevo nombre
                    break;
                case "Frm_Vendedor":
                    //Menu Ventas
                    ToolStripMenuItem menuVentas = new ToolStripMenuItem("Ventas");
                    //Opcion para registrar venta
                    menuVentas.DropDownItems.Add("Registrar Venta", null, (s, e) => {
                        var form = this.ActiveMdiChild as Frm_Vendedor;
                        //form?.ActivarModoVenta();
                    });
                    //Opcion para modificar Estado de venta
                    menuVentas.DropDownItems.Add("Modificar Estado de Venta", null, (s, e) => {
                        var form = this.ActiveMdiChild as Frm_Vendedor;
                        //form?.ActivarModoModificarEstado();
                    });
                    //Opcion para eliminar venta
                    menuVentas.DropDownItems.Add("Eliminar Venta", null, (s, e) =>
                    {
                        var form = this.ActiveMdiChild as Frm_Vendedor;
                        //form?.ActivarModoEliminarVenta();
                    });
                    //Separador
                    menuVentas.DropDownItems.Add(new ToolStripSeparator());
                    //Opcion para generar reporte de ventas
                    menuVentas.DropDownItems.Add("Generar Reporte de Ventas", null, (s, e) => {
                        formularioAnterior = this.ActiveMdiChild.GetType();
                        AbrirFormularios(new Frm_Informes());
                    });
                    
                    //Menu Clientes
                    ToolStripMenuItem menuClientes = new ToolStripMenuItem("Clientes");
                    //Opcion para agregar cliente
                    menuClientes.DropDownItems.Add("Agregar Cliente", null, (s, e) => {
                        var form = this.ActiveMdiChild as Frm_Vendedor;
                        //form?.ActivarModoAgregarCliente();
                    });
                    //opcion para editar cliente
                    menuClientes.DropDownItems.Add("Modificar Cliente", null, (s, e) => {
                        var form = this.ActiveMdiChild as Frm_Vendedor;
                        //form?.ActivarModoModificarCliente();
                    });
                    menuClientes.DropDownItems.Add(new ToolStripSeparator());
                    //Opcion para ver lista de clientes
                    menuClientes.DropDownItems.Add("Ver Lista de Clientes", null, (s, e) =>
                    {
                        var form = this.ActiveMdiChild as Frm_Vendedor;
                        //form?.MostrarListaClientes();
                    });
                    // ===== FILTRO RÁPIDO =====
                    ToolStripSeparator separatorFiltro = new ToolStripSeparator();

                    ToolStripLabel lblFiltroVendedor = new ToolStripLabel("Buscar venta/cliente:");
                    ToolStripTextBox txtFiltroVendedor = new ToolStripTextBox // Cambiado el nombre aquí
                    {
                        Name = "txtFiltro",
                        Width = 200,
                        BorderStyle = BorderStyle.FixedSingle
                    };

                    txtFiltroVendedor.TextChanged += (s, e) =>
                    {
                        var form = this.ActiveMdiChild as Frm_Vendedor;
                        //form?.FiltrarGeneral(txtFiltroVendedor.Text);
                    };

                    // Agregar todos al menú principal
                    menuStrip1.Items.AddRange(new ToolStripItem[]
                    {
                        menuVentas,
                        menuClientes,
                        separatorFiltro,
                        lblFiltroVendedor,
                        txtFiltroVendedor 
                    });

                    break;
                case "Frm_Informes":
                    //Agregar opciones especificas para Frm_Informes
                    //Opcion para volver al formulario anterior
                    ToolStripMenuItem menuVolver = new ToolStripMenuItem("Volver");
                    //Metodo para volver al formulario anterior
                    menuVolver.Click += (s, e) => {
                        //Verificar si hay un formulario anterior guardado
                        if (formularioAnterior != null)
                        {
                            //Abrir el formulario anterior
                            //Crear una nueva instancia del formulario anterior
                            Form nuevoFormulario = (Form)Activator.CreateInstance(formularioAnterior);
                            AbrirFormularios(nuevoFormulario);
                            formularioAnterior = null; // Limpiar referencia
                        }
                    };
                    //Agregar al menuStrip
                    menuStrip1.Items.Add(menuVolver);
                    break;
                }
        }
        

        //Metodo para cerrar sesion
        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Cerrar el formulario principal
            this.Close();
            //Mostrar el formulario de login
            Frm_Login frmLogin = new Frm_Login();
            frmLogin.Show();
        }
        //Evento para confirmar el cierre del formulario principal
        private void Frm_Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Confirmar cierre si se desea
            DialogResult result = MessageBox.Show(
                "¿Seguro que desea salir del sistema?",
                "Confirmar salida",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No)
            {
                e.Cancel = true;//Cancela el cierre
                return;
            }
        }
    }
}
