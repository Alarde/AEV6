using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace AEV6
{
	public class Empleado
	{
		public string nif { get; set; }
		public string nombre { get; set; }
		public string apellido { get; set; }
		public bool admin { get; set; }
		public string clave { get; set; }

		public Empleado(string dni, string nom, string ape, bool admi, string clav) //Constructor por si el empleado es admin
		{
			nif = dni;
			nombre = nom;
			apellido = ape;
			admin = admi;
			clave = clav;
		}

		public Empleado(string dni, string nom, string ape, bool admi) //Constructor por si el empleado no es admin
		{
			nif = dni;
			nombre = nom;
			apellido = ape;
			admin = admi;
		}

		public Empleado()
        { 
        }

		//Metodo para generar el nif segun los digitos del nif que ha pasado el usuario
		private static string GenerarNIF(string DNI)
		{
			char[] tablaLetras = new char[23] { 'T', 'R', 'W', 'A', 'G', 'M', 'Y', 'F', 'P', 'D', 'X', 'B', 'N', 'J', 'Z', 'S', 'Q', 'V', 'H', 'L', 'C', 'K', 'E' };

			int pos; //La posicion de la letra que lleva el DNI

			int.TryParse(DNI, out int dni); //Convertimos el dni que le hemos pasado a la funcion a int, para poder hacer el modulo y sacar la posicion

			pos = dni % 23; //sacamos la posicion de la letra correspondiente al dni
			return dni.ToString() + tablaLetras[pos];
		}

        public static bool ValidarNIF(string nif) //Comprobado a ojo por Aldimir, hay que probarlo
        {
			string dni = "";
            bool correcto = true;
			int contador = 0; //contador para la longitud del dni

            //Foreach para recorrer cada numero del textbox que introduzca el usuario
            //IMPORTANTE -> HAY QUE HABILITAR UN EVENTO DEL TXTBOX QUE CUANDO SE ACTUALICE COMPRUEBE SI HAY ERROR O NO CON EL ERRORPROVIDER
			foreach (char elem in nif)
			{
				contador++;
				if (char.IsLetter(elem) && contador != 9) //Si el caracter es una letra y no esta en la posicion 9 del nif
				{
                    correcto = false;
					//System.Windows.Forms.MessageBox.Show("El formato del NIF que está intentando introducir es erróneo.");
				}
				else
				{	
					dni += elem.ToString();
					if(dni.Count() == 8) //Si hay 8 numeros, comprobamos la letra
					{
						if (GenerarNIF(dni) == nif) //Comprobamos si el NIF generado es igual al NIF que ha pasado el usuario
						{
							correcto = true;
							break; //Terminamos con un break para que no añada la letra del nif introducido por el usuario al string dni
						}
						else correcto = false;
						break;
					}
				}
			}
			return correcto;
		}
    }
}
