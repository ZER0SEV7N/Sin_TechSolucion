using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos
{
    public class CD_DetalleVentas
    {
        //atributos
        private int _idVentas;
        private int _idPor;
        private int _cantidad;
        private double _precioUnitario;
        private double _subtotal;

        public CD_DetalleVentas()
        {
        }

        public CD_DetalleVentas(int idVentas, int idPor, int cantidad, double precioUnitario, double subtotal)
        {
            _idVentas = idVentas;
            _idPor = idPor;
            _cantidad = cantidad;
            _precioUnitario = precioUnitario;
            _subtotal = subtotal;
        }

        public int IdVentas { get => _idVentas; set => _idVentas = value; }
        public int IdPor { get => _idPor; set => _idPor = value; }
        public int Cantidad { get => _cantidad; set => _cantidad = value; }
        public double PrecioUnitario { get => _precioUnitario; set => _precioUnitario = value; }
        public double Subtotal { get => _subtotal; set => _subtotal = value; }
    }
}
