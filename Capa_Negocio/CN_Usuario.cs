using Capa_Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Capa_Negocio
{
    public class CN_Usuario
    {
        //referencia a la CD_Usuario
        CD_Usuario ObjUser = new CD_Usuario();
        //Encriptacion

        //login
        public DataTable CN_Login(string correo, string passwrd)
        {
            string passEncriptada = CN_Encriptacion.Encrip(passwrd);
           
            return ObjUser.CD_LoginUser(correo, passEncriptada);
        }
    }
}
