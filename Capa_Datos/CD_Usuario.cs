using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
        //metodo apra el 
        public string CD_LoginUser(string correo, string passwrd)
        {
            string rolUser = "";
            string prod_name= "PA_Login_Verificar";
            //prepara la ejecucion SQL 
            SqlCommand comando = new SqlCommand(prod_name, _Conexion.AbrirConexion());
            comando.CommandType = CommandType.StoredProcedure;
            //asignar valores para el procedimiento
            comando.Parameters.AddWithValue("@Correo_In", correo);
            comando.Parameters.AddWithValue("@Contrasenia_In", passwrd);
            try
            {
                //ejecutar par la lectrus
                SqlDataReader leer = comando.ExecuteReader();
                //verificar si esta siendo leido
                if (leer.Read())
                {
                    //obtener los datos requerido
                    rolUser = leer["nombreRol"].ToString();
                    //verificar si el usuario esta activo
                    bool activo = (bool)leer["activo"];
                    //negar acceso al estar inactivo y retornar nada
                    if (!activo) return rolUser = "";
                }

            }
            catch (Exception e)
            {

            }
            finally
            {
                _Conexion.CerrarConexion();
            }
            return rolUser;

        }
        #region Almacen
        
        #endregion
        #region Admin
        #endregion
        #region Vendedor
        #endregion
    }
}
