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
    public partial class Frm_Inicio : Form
    {
        //referencia a la capa de negocio
        Capa_Negocio.CN_Usuario ObjUser = new Capa_Negocio.CN_Usuario();
        
        public Frm_Inicio()
        {
            InitializeComponent();
            
        }

        private void btn_Iniciar_Click(object sender, EventArgs e)
        {
            //obtener el rol del usuario
            string rolUser = ObjUser.CN_Login(Txt_Usario.Text.ToString(), Txt_Pass.Text.ToString());
            switch (rolUser)
            {
                case "Administrador":
                    Frm_Formularios frmAdmin = new Frm_Formularios();
                    frmAdmin.Show();
                    break;
                case "Almacenero":
                    Frm_Almacenes frmAlacen = new Frm_Almacenes();
                    frmAlacen.Show();
                    break;
                case "Vendedor":
                    Frm_vendedor frmVendedor = new Frm_vendedor();
                    frmVendedor.Show();
                    break;
                default:
                    // Manejar casos donde el texto no coincide con ningún rol
                    MessageBox.Show("El usuario no activo", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
