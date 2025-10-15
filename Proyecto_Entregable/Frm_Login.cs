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
    public partial class Frm_Login : Form
    {
        //referencia a la capa de negocio
        Capa_Negocio.CN_Usuario ObjUser = new Capa_Negocio.CN_Usuario();

        public Frm_Login()
        {
            InitializeComponent();
        }

        private void btn_Iniciar_Click(object sender, EventArgs e)
        {
            string usuario = Txt_Usario.Text.Trim();
            string pass = Txt_Pass.Text.Trim();
            CN_Usuario ObjUser = new CN_Usuario();
            DataTable dt = ObjUser.CN_Login(usuario, pass);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                bool activo = Convert.ToBoolean(row["activo"]);

                if (!activo)
                {
                    MessageBox.Show("El usuario está inactivo.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //Guardar la sesión en Program.Info_Organization_Session
                Program.Info_Organization_Session.xId_Usuario = Convert.ToInt32(row["idUser"]);
                Program.Info_Organization_Session.xNombres = row["nombre"].ToString();
                Program.Info_Organization_Session.xApellidos = row["apellido"].ToString();
                Program.Info_Organization_Session.xCorreo = row["correo"].ToString();
                Program.Info_Organization_Session.xRol = row["nombreRol"].ToString();

                //Mostrar formulario principal
                string nombreCompleto = $"{row["nombre"]} {row["apellido"]}";
                string rol = row["nombreRol"].ToString();
                //Cargar el formulario principal
                Frm_Principal frm = new Frm_Principal();
                frm.Show();
                this.Hide();
            }
            else
            {
                // Mostrar mensaje de error
                MessageBox.Show("Credenciales incorrectas o usuario no registrado.", "Error de acceso",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
