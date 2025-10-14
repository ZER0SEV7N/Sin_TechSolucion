using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos
{
    public class CD_Cliente
    {
        //Atributos
        private int _idCliente;
        private string _nombreCliente;
        private string _Documento;
        private string _Direccion;
        private string _Telefono;
        private string _Correo;
        
        
        // Constructores
        public CD_Cliente()
        {

        }
        public CD_Cliente(int idCliente, string nombreCliente, string documento, string direccion, string telefono, string correo)
        {
            _idCliente = idCliente;
            _nombreCliente = nombreCliente;
            _Documento = documento;
            _Direccion = direccion;
            _Telefono = telefono;
            _Correo = correo;
        }

        public int IdCliente { get => _idCliente; set => _idCliente = value; }
        public string NombreCliente { get => _nombreCliente; set => _nombreCliente = value; }
        public string Documento { get => _Documento; set => _Documento = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Correo { get => _Correo; set => _Correo = value; }
    }
}
