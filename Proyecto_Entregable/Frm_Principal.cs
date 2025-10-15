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

        private void configuration_mdi()
        {
            DireccionLabel.Text = Program.Info_Organization_Session.xDireccion;
            TelefonoLabel.Text = Program.Info_Organization_Session.xTelefono;
            toolStripStatusLabelNombreYapellido.Text = Program.Info_Organization_Session.xNombres + "," +" " + Program.Info_Organization_Session.xApellidos;
            toolStripStatusLabelRol.Text = Program.Info_Organization_Session.xRol;
        }

        private void Frm_Principal_Load(object sender, EventArgs e)
        {
            configuration_mdi();
        }

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
        }

    }
}
