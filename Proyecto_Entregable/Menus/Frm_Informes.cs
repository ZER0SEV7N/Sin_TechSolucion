using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Windows.Forms;
using Capa_Negocio;

namespace Proyecto_Entregable
{
    public partial class Frm_Informes : Form
    {
        CN_Producto objPro = new CN_Producto();

        public Frm_Informes()
        {
            InitializeComponent();
        }

        private void Frm_Informes_Load(object sender, EventArgs e)
        {
            ConfigurarOpcionesPorRol();
            this.reportViewer1.RefreshReport();
        }
        //Metodo para configurar las opciones de comboBox por los roles
        private void ConfigurarOpcionesPorRol()
        {
            string rol = Program.Info_Organization_Session.xRol; //Ejemplo

            cmbTipoReporte.Items.Clear();

            if (rol == "Administrador" || rol == "Supervisor")
            {
                //Tiene acceso a todos los reportes
                cmbTipoReporte.Items.Add("Productos");
                cmbTipoReporte.Items.Add("Ventas");
                cmbTipoReporte.Enabled = true; //Habilita cambiarlo
            }
            else if (rol == "Vendedor")
            {
                //Solo puede ver su propio tipo de informe
                cmbTipoReporte.Items.Add("Ventas");
                cmbTipoReporte.Enabled = false; //no puede cambiarlo
            }
            else if (rol == "Almacenero")
            {
                //Solo puedes ver su propio tipo de informe
                cmbTipoReporte.Items.Add("Productos");
            }
            else
            {
                //Rol sin acceso
                cmbTipoReporte.Items.Add("Sin permisos");
                cmbTipoReporte.Enabled = false;
                btnGenerar.Enabled = false;
                MessageBox.Show("No tiene permisos para ver informes.");
            }

            cmbTipoReporte.SelectedIndex = 0;
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            string tipo = cmbTipoReporte.SelectedItem.ToString();

            switch (tipo)
            {
                case "Productos":
                    GenerarReporteProductos();
                    break;
                case "Ventas":
                    GenerarReporteVentas();
                    break;
                case "Usuarios":
                    GenerarReporteUsuarios();
                    break;
                default:
                    MessageBox.Show("Seleccione un tipo de reporte válido.");
                    break;
            }
        }

        private void GenerarReporteProductos()
        {

        }

        private void GenerarReporteVentas()
        {
            // Aquí iría el DataSet y lógica del reporte de ventas
        }

        private void GenerarReporteUsuarios()
        {
            // Aquí iría el DataSet y lógica del reporte de usuarios
        }
    }
}
