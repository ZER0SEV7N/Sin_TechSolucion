using Capa_Negocio;
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
    }
}
