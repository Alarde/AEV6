using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace AEV6
{
	class Empleado
	{
        public static MySqlConnection conexion = new MySqlConnection();

        private string nif;
		private string nombre;
		private string apellido;
		private bool admin; //True es admin, false no
		private string clave; //Clave del administrador. Máximo 16 carácteres

		public string Nif { get { return nif; } set { nif = value; } }
		public string Nombre { get { return nombre; } set { nombre = value; } }
		public string Apellido { get { return apellido; } set { apellido = value; } }
		public bool Admin { get { return admin; } set { admin = value; } }
		public string Clave { get { return clave; } set { clave = value; } }

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
            
			foreach (char elem in nif)//Foreach para recorrer cada numero del textbox que introduzca el usuario
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
						else
						{
							correcto = false;
							break;
						}
					}
				}
			}
			return correcto;
		}

        //Funcion que usaremos para corroborar que el empleado está dado de alta
        public static bool ExisteEmpleado(string nif)
        {
            string consulta = string.Format("SELECT * FROM empleados WHERE nif = {0}", nif);
            MySqlCommand comando = new MySqlCommand(consulta, conexion);
			MySqlDataReader reader = comando.ExecuteReader();

            if (reader.HasRows) return true; //Comprobamos que el usuario existe
            else return false;
        }
        
        public int Entrada(string nif)
        {
			int retorno;
            string consulta = string.Format("UPDATE fichajes SET fichadoEntrada = 1 WHERE nif = {0};", nif);
            MySqlCommand comando = new MySqlCommand(nif, conexion);
            retorno = comando.ExecuteNonQuery();

			return retorno;
		}

        /*
		public int Salida(MySqlConnection conexion, string nif)
		{
			int retorno;
            string consulta = string.Format("UPDATE fichajes");
		}
		*/
		//Boton de agregar para el mantenimineto

		public static int AgregarEmpleado(Empleado emp)
		{
            int retorno;
			string consulta = string.Format("INSERT INTO empleados (nif, nombre, apellido, admin, clave) VALUES(@nif, @nombre, @apellido, @admin, @clave)");
			MySqlCommand comando = new MySqlCommand(consulta, conexion);
			comando.Parameters.AddWithValue("@nif", emp.nif);
			comando.Parameters.AddWithValue("@nombre", emp.nombre.Trim());
			comando.Parameters.AddWithValue("@apellido", emp.apellido.Trim());
			comando.Parameters.AddWithValue("@admin", emp.admin);
			comando.Parameters.AddWithValue("@clave", emp.clave); //Y si el empleado agregado no es admin? Hay que poner un valor por defecto si el campo está vacío. ¿Se puede 
            //poner un valor null por defecto en la base de datos por si el empleado no es admin?
            retorno = comando.ExecuteNonQuery();
            return retorno;
		}

        public static int EliminarEmpleado(Empleado emp)
        {
            int retorno;
            string consulta = string.Format("DELETE FROM empleados WHERE nif={0} AND nombre={1} AND apellidos={2}", emp.nif, emp.nombre,
                emp.apellido);
            MySqlCommand comando = new MySqlCommand(consulta, conexion);
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        public static List<Empleado> BuscarEmpleados() //Metodo para el informe visual de mantenimiento
        {
			var dbCon = DBConnection.Instance();
            List<Empleado> empleados = new List<Empleado>();
            if (dbCon.IsConnect())
            {
                string consulta = string.Format("SELECT nif, nombre, apellido, admin FROM empleados");
                var cmd = new MySqlCommand(consulta, dbCon.Connection);
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Empleado emp = new Empleado(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetBoolean(3));
                        empleados.Add(emp);
                    }
                }
                reader.Close();
            }return empleados;
        }
        public static List<Empleado> BuscarNif() //Metodo para el informe visual de mantenimiento
        {
            var dbCon = DBConnection.Instance();
            List<Empleado> empleados = new List<Empleado>();
            if (dbCon.IsConnect())
            {
                string consulta = string.Format("SELECT nif, nombre, apellido, admin, clave FROM empleados");
                var cmd = new MySqlCommand(consulta, dbCon.Connection);
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Empleado emp = new Empleado(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetBoolean(3), reader.GetString(4));
                        empleados.Add(emp);
                    }
                }
                reader.Close();
            }
            return empleados;
        }
    }
}
