using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;


/****
 * 
 * This class requires add a new reference to the project which is System.Configuration
 *
 * Also this needs some new content called "Dapper", you can find what this does at https://dapper-tutorial.net/dapper, 
 * basically is just a basic mapper to allow use Query/Execute database operations.
 * 
 * This Dapper must be downloaded as another reference. Right click on References > Administrate NuGet packages, and search for Dapper, should be the first one.
 * 
 */

namespace AEV6
{
	/*
		This class will connect with database and using the helper who will get the connection details
	*/
    public class AccesoDatos
    {
		public void AgregarEmpleado(Empleado emp)
		{
            var dbCon = DBConnection.Instancia();
            if (dbCon.Conectado())
            {
                var cierto = 0; //Variable para decirle a la base si admin es true o false
                using (IDbConnection conexion = dbCon.Conexion)
                {
                    if (emp.admin) cierto = 1;
                    else cierto = 0;
                    //Cuando insertes los valores de empleados en la BBDD, también insertarás en fichajes su nif, pero los valores de entrada y salida estarán seteados en false ya que
                    //aún no ha fichado
                    
                    // TODO: Cuando insertas un usuario existente peta
                    conexion.Execute($"INSERT INTO empleados VALUES ('{emp.nif}', '{ emp.nombre }', '{ emp.apellido }', '{ cierto }', '{ emp.clave }');");
                }
            }
		}

        public void EliminarEmpleado(string nif)
		{
			var dbCon = DBConnection.Instancia();
			if (dbCon.Conectado())
			{
				using (IDbConnection conexion = dbCon.Conexion)
				{
					var output = conexion.Execute($"DELETE FROM empleados WHERE nif = '{ nif }'");
				}
			}
		}

        public static List<Empleado> BuscarEmpleado(string nif)
		{
            var dbCon = DBConnection.Instancia();
            if (dbCon.Conectado())
            {
                //using va a crear una conexion y luego la va a destruir, de esta forma nos ahorramos futuros problemas de conexiones ya abiertas, etc.
                using (IDbConnection conexion = dbCon.Conexion)
                {
                    var output = conexion.Query<Empleado>($"SELECT * FROM empleados WHERE nif = '{ nif }'").ToList();
                    return output;
                }
            }
            else return null; //Si la base no conecta no haces nada. 
		}


		public static List<Fichajes> GenerarFichajes()
		{
			var dbCon = DBConnection.Instancia();
			if (dbCon.Conectado())
			{
				using (IDbConnection conexion = dbCon.Conexion)
				{
					var output = conexion.Query<Fichajes>($"SELECT * FROM fichajes").Select(x => new Fichajes(x.NifEmpleado, x.Entrada, x.Salida, x.FechaEntrada, x.FechaSalida)).ToList();
					return output;
				}
			}
			else return null;
		}

        //Comprueba si se puede hacer la entrada del fichaje
		/*public static string DadoEntrada(string nif)
		{
			var dbCon = DBConnection.Instancia();
			if (dbCon.Conectado())
			{
				using (IDbConnection conexion = dbCon.Conexion)
				{
					var output = conexion.Query<int>($"SELECT entrada FROM fichajes WHERE nif = '{ nif }'").ToString();
                    return output;
				}
			}
			else return null;
		}*/

        /***
         * 
         * Con este método validamos que el NIF seleccionado no tenga la fecha de entrada rellena y la fecha de salida 
         * no tenga ningún valor, ya que esto significaría que el nif actual ya ha fichado para el día de hoy y no ha salido
         * 
        ***/
        public static int ValidaEntradaHoy(string nif)
        {
            var dbCon = DBConnection.Instancia();
            if (dbCon.Conectado())
            {
                using (IDbConnection conexion = dbCon.Conexion)
                {
                    //SELECT `id`, `nif`, `entrada`, `salida`, `fechaentrada`, `fechasalida` FROM `fichajes` WHERE fechaentrada > CURDATE() AND nif = '22222222J' and fechasalida IS NULL;
                    var output = conexion.Query<Fichajes>($"SELECT * FROM fichajes WHERE fechaentrada > CURDATE() AND nif = '{ nif }' and fechasalida IS NULL;").ToList();
                    return output.Count();
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Error inesperado, vuelva a intentarlo pasados unos minutos");
                return 200; //Código de error 200 seteado para errores inesperados.
            }
        }

        public static int ValidaSalidaHoy(string nif)
        {
            var dbCon = DBConnection.Instancia();
            if (dbCon.Conectado())
            {
                using (IDbConnection conexion = dbCon.Conexion)
                {
                    //SELECT `id`, `nif`, `entrada`, `salida`, `fechaentrada`, `fechasalida` FROM `fichajes` WHERE fechaentrada > CURDATE() AND nif = '22222222J' and fechasalida IS NULL;
                    var output = conexion.Query<Fichajes>($"SELECT * FROM fichajes WHERE fechaentrada > CURDATE() AND nif = '{ nif }' and fechasalida IS NULL;").ToList();
                    return output.Count();
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Error inesperado, vuelva a intentarlo pasados unos minutos");
                return 200; //Código de error 200 seteado para errores inesperados.
            }
        }

        public static int CheckeaIncidenciasFichajes(string nif)
        {
            var dbCon = DBConnection.Instancia();
            if (dbCon.Conectado())
            {
                using (IDbConnection conexion = dbCon.Conexion)
                {
                    //SELECT count(*) FROM `fichajes` WHERE fechaentrada < CURDATE() AND nif = '22222222J' and fechasalida IS NULL
                    var output = conexion.Query<Fichajes>($"SELECT count(*) FROM fichajes WHERE fechaentrada < CURDATE() AND nif = '{ nif }' and fechasalida IS NULL;").ToList();
                    return output.Count();
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Error inesperado, vuelva a intentarlo pasados unos minutos");
                return 200; //Código de error 200 seteado para errores inesperados.
            }
        }

        //Hace el fichaje de entrada
        public static void FichajeEntrada(string nif)
		{
            var fechaactual = DateTime.Now;
            string format = "yyyy-MM-dd HH:mm:ss";
            var dbCon = DBConnection.Instancia();
			if (dbCon.Conectado())
			{
				using (IDbConnection conexion = dbCon.Conexion)
				{
                    conexion.Execute($"INSERT INTO fichajes VALUES (NULL, '{ nif }', 1, 0, '{ fechaactual.ToString(format) }', NULL);");
                }
			}
		}

		public static string DadoSalida(string nif)
		{
			var dbCon = DBConnection.Instancia();
			if (dbCon.Conectado())
			{
				using (IDbConnection conexion = dbCon.Conexion)
				{
					var output = conexion.Query<int>($"SELECT entrada FROM fichajes WHERE nif = '{ nif }'").ToString();
					return output;
				}
			}
			else return null;
		}

		public static void FichajeSalida(string nif)
		{
			//Form1 form = new Form1();
			var fechaactual = DateTime.Now;
            string format = "yyyy-MM-dd HH:mm:ss";
            var dbCon = DBConnection.Instancia();
			if (dbCon.Conectado())
			{
				using (IDbConnection conexion = dbCon.Conexion)
				{
                    
                    try
                    {
                        conexion.Execute($"UPDATE fichajes SET salida = 1, fechasalida = '{ fechaactual.ToString(format) }' WHERE nif = '{ nif }' AND fechaentrada > CURDATE() and fechasalida IS NULL;");
                    }
                    catch (Exception)
                    {
                        System.Windows.Forms.MessageBox.Show($"No hemos podido actualizar el fichaje de salida del empleado con nif { nif }", "Alerta", System.Windows.Forms.MessageBoxButtons.OK,
                            System.Windows.Forms.MessageBoxIcon.Exclamation, System.Windows.Forms.MessageBoxDefaultButton.Button1);
                    }
					
                    
				}
			}
		}

		public static List<Empleado> BuscarTodosEmpleados()
        {
            var dbCon = DBConnection.Instancia();
            if (dbCon.Conectado())
            {
                using (IDbConnection conexion = dbCon.Conexion)
                {
                    var output = conexion.Query<Empleado>($"SELECT * FROM empleados").ToList();
                    return output;
                }
            }
            else return null;
        }

        public static List<Empleado> BuscarNomApe()
        {
            var dbCon = DBConnection.Instancia();
            if (dbCon.Conectado())
            {
                using (IDbConnection conexion = dbCon.Conexion)
                {
                    var output = conexion.Query<Empleado>($"SELECT nombre, apellido FROM empleados").ToList();
                    return output;
                }
            }
            else return null;
        }

        public static void Entrada(string nif)
		{
			var dbCon = DBConnection.Instancia();
			if (dbCon.Conectado())
			{
				using (IDbConnection conexion = dbCon.Conexion)
				{
					conexion.Execute($"UPDATE fichajes SET entrada = 1");
				}
			}
		}
		
		
	}
}