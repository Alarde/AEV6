using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEV6
{
    class Fichajes
    {
        private string nifEmpleado;
        private bool entrada; //True si ha fichado de entrada
        private bool salida; //True si ha fichado de salida
        private DateTime fechaEntrada; //Coger dd/mm/aa y hora
        private DateTime fechaSalida; //Coger dd/mm/aa y hora


        public string NifEmpleado { get { return nifEmpleado; } set { nifEmpleado = value; } }
        public bool Entrada { get { return entrada; } set { entrada = value; } }
        public bool Salida { get { return salida; } set { salida = value; } }
        public DateTime FechaEntrada { get { return fechaEntrada; } set { fechaEntrada = value; } }
        public DateTime FechaSalida { get { return fechaSalida; } set { fechaSalida = value; } }

        public Fichajes(string nif, bool en, bool sal, DateTime fentr, DateTime fsal)
        {
            nifEmpleado = nif;
            entrada = en;
            salida = sal;
            fechaEntrada = fentr;
            fechaSalida = fsal;
        }
    }
}
