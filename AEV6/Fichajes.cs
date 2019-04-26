using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace AEV6
{
    public class Fichajes
    {
        private string nif;
        private bool entrada; //True si ha fichado de entrada
        private bool salida; //True si ha fichado de salida
        private DateTime fechaentrada; //Coger dd/mm/aa y hora
        private DateTime fechasalida; //Coger dd/mm/aa y hora


        public string NifEmpleado { get { return nif; } set { nif = value; } }
        public bool Entrada { get { return entrada; } set { entrada = value; } }
        public bool Salida { get { return salida; } set { salida = value; } }
        public DateTime FechaEntrada { get { return fechaentrada; } set { fechaentrada = value; } }
        public DateTime FechaSalida { get { return fechasalida; } set { fechasalida = value; } }

        public Fichajes(string dni, bool en, bool sal, DateTime fentr, DateTime fsal)
        {
            nif = dni;
            entrada = en;
            salida = sal;
            fechaentrada = fentr;
            fechasalida = fsal;
        }

        public Fichajes()
        {
        }
		
    }
}
