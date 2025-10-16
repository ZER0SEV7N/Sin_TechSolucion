using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos
{
    public class CD_Usuario

    {
        #region atributos
        //atributos
        private int _idUser;
        private string _nombre;
        private string _correoUser;
        private string _password;
        private bool _activo;
        private string _nombreRol;
        #endregion
        //constructores
        #region constructores
        public CD_Usuario()
        {
        }

        public CD_Usuario(int idUser, string nombre, string correoUser, string password, bool activo, string nombreRol)
        {
            _idUser = idUser;
            _nombre = nombre;
            _correoUser = correoUser;
            _password = password;
            _activo = activo;
            _nombreRol = nombreRol;
        }
        //MetodoGets
        #endregion
        #region gets y sets
        public int IdUser { get => _idUser; set => _idUser = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string CorreoUser { get => _correoUser; set => _correoUser = value; }
        public string Password { get => _password; set => _password = value; }
        public bool Activo { get => _activo; set => _activo = value; }
        public string NombreRol { get => _nombreRol; set => _nombreRol = value; }
        #endregion
        //instancia de la conexion
        CD_Conexion _Conexion = new CD_Conexion();
        //metodo para manejar el login
        public DataTable CD_LoginUser(string correo, string passwrdHas)
        {
            //encriptar la contraseña 
            //encriptado nro1:
            //encriptado nro2:
            //procedimiento almacenado
            SqlCommand cmd = new SqlCommand("PA_Login_Verificar", _Conexion.AbrirConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            //Añadir los valores
            cmd.Parameters.AddWithValue("@Correo_In", correo);
            cmd.Parameters.AddWithValue("@Contrasenia_In", passwrdHas);
            //Ejecutar el comando
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            //Crear el DataTable
            DataTable dt = new DataTable();
            //llenar el datatable
            da.Fill(dt);
            //cerrar la conexion
            _Conexion.CerrarConexion();
            //Devolver el datatable
            return dt;
        }
        #region Almacen
        
        #endregion
        #region Admin
        #endregion
        #region Vendedor
        #endregion
    }
}
