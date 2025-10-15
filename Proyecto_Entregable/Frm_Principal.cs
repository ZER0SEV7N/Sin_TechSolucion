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
            //Cerrar formularios abiertos
            foreach (Form form in this.MdiChildren)
            {
                form.Close();
            }
            //Abrir formulario
            FormHijo.MdiParent = this;
            FormHijo.Dock = DockStyle.Fill;
            FormHijo.Show();
            CargarOpcionesDelFormulario(FormHijo.GetType().Name);
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
            switch (FormularioActivo)
            {
                case "Frm_Almacenes":
                    ToolStripMenuItem menuProd = new ToolStripMenuItem("Productos");
                    menuProd.DropDownItems.Add("Agregar Producto", null, (s, e) => { /* Lógica para agregar producto */ });
                    menuProd.DropDownItems.Add("Modificar Producto", null, (s, e) => { /* Lógica para modificar producto */ });
                    menuProd.DropDownItems.Add("Eliminar Producto", null, (s, e) => { /* Lógica para eliminar producto */ });
                    menuProd.DropDownItems.Add("Generar Reporte de Productos", null, (s, e) => { /* Lógica para generar reporte */ });
                    menuStrip1.Items.AddRange(new ToolStripItem[] { menuProd});
                    break;
                case "Frm_Vendedor":
                    //Agregar opciones especificas para Frm_Vendedor
                    break;
                case "Frm_Informes":
                    //Agregar opciones especificas para Frm_Informes
                    break;
                default:
                    // Si el formulario no tiene menú propio, muestra solo volver
                    ToolStripMenuItem volverDefault = new ToolStripMenuItem("← Volver al menú principal");
                    volverDefault.Click += (s, e) => CargarMenu(Program.Info_Organization_Session.xRol);
                    menuStrip1.Items.Add(volverDefault);
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


    }
}
