using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace Capa_Datos
{
    public class CD_Conexion
    {
        private SqlConnection Conexion = new SqlConnection(@"Data Source=DESKTOP-B2KRD4S;Initial Catalog=TECHSOLUBD;Integrated Security=True;Encrypt=False");
        //Establecer COnexion a la base de datos
        public SqlConnection AbrirConexion()
        {
            if (Conexion.State == ConnectionState.Closed)
            {
                Conexion.Open();
            }
            return Conexion;
        }
        public SqlConnection CerrarConexion()
        {
            if (Conexion.State == ConnectionState.Open)
            {
                Conexion.Close();
            }
            return Conexion;
        }

    }
}
