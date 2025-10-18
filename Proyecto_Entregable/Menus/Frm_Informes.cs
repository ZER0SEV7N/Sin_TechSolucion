using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Windows.Forms;

namespace Proyecto_Entregable
{
    public partial class Frm_Informes : Form
    {
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
            //Limpiar opciones previas
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
        //Evento del boton Generar al dar click
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
            }
        }
        //Metodo para Generar los reportes de los productos
        private void GenerarReporteProductos()
        {
            try
            {
                // TODO: esta línea de código carga datos en la tabla 'tECHSOLUBDDataSet.v_ProductosRegistrados' Puede moverla o quitarla según sea necesario.
                this.v_ProductosRegistradosTableAdapter.Fill(this.tECHSOLUBDDataSet.v_ProductosRegistrados);
                // Refrescar
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el reporte de productos: " + ex.Message);
            }
        }

        private void GenerarReporteVentas()
        {
            try
            {
                // TODO: esta línea de código carga datos en la tabla 'tECHSOLUBDDataSet1.v_VentasConDetalles' Puede moverla o quitarla según sea necesario.
                this.v_VentasConDetallesTableAdapter.Fill(this.tECHSOLUBDDataSet1.v_VentasConDetalles);
                // Refrescar
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el reporte de ventas: " + ex.Message);
            }
        }


    }
}
