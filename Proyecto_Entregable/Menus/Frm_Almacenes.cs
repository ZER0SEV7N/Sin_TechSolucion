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
        public Frm_Almacenes()
        {
            InitializeComponent();
        }
        //referencia con objeto producto
        CN_Producto objProd = new CN_Producto();
        private void DGVAlmacen_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CargarProducto();
        }
        //meotod para invocar datos del producto
        private void CargarProducto()
        {
        }
    }
}
