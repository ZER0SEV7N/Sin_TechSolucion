using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio
{
    public static class CN_Encriptacion
    {
        //encriptacion de la contraseña
        public static string Encrip(string text)
        {
            //usar la libreira Sha256
            using (SHA256 sha = SHA256.Create())
            {
                //crar un arreglo de bytes el texto ingresado
                byte[] bytesTetxo = Encoding.UTF8.GetBytes(text);

                //calcular el arreglo de 32 bites
                byte[] hashBytes = sha.ComputeHash(bytesTetxo);

                //crear un Strign builder para construir la cadena de texto
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                 sb.Append(b.ToString("x2"));
                 return sb.ToString();
                
            }
        }
    }
}
