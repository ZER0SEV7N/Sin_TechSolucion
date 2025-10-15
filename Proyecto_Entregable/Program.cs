using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Entregable
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Frm_Login());
        }

        public class Info_Organization_Session
        {
            public static string xDireccion = "Av Siempre Viva 123";
            public static string xTelefono = "809-555-5555";
            public static int xId_Usuario;
            public static string xNombres = "";
            public static string xApellidos = "";
            public static string xCorreo = "";
            public static string xClave = "";
            public static int xId_Rol = 0;
            public static string xRol = "";
            // Método de limpieza de sesión (al cerrar sesión)
            public static void LimpiarSesion()
            {
                xId_Usuario = 0;
                xNombres = "";
                xApellidos = "";
                xCorreo = "";
                xClave = "";
                xId_Rol = 0;
                xRol = "";
            }
        }

    }
}
