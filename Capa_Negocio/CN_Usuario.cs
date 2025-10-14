using Capa_Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Capa_Negocio
{
    public class CN_Usuario
    {
        //referencia a la CD_Usuario
        CD_Usuario ObjUser = new CD_Usuario();
        //logion
        public string CN_Login(string correo, string passwrd)
        {
            if (string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(passwrd))
            {
                return "Error, datos requeridos";
            }
            try
            {
                // Verifica un formato básico de email (ej: algo@dominio.algo)
                if (!Regex.IsMatch(correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    return "ERROR: El formato del correo es inválido.";
                }
            }
            catch (ArgumentException e)
            {
                return "Validacion de correo fallida";
            }
            //obtener el valor del metodo de la capa usuairo y obtener el rool 
            string rol = ObjUser.CD_LoginUser(correo, passwrd);
            return rol;
        }

        #region Almacen
        
        #endregion
    }
}
