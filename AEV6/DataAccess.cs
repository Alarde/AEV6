using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace AEV6
{
	/*
		This class will connect with database and using the helper who will get the connection details
	*/
    public class DataAccess
    {
        public List<Empleado> GetPeople(string nif)
		{
			
			//Reference: https://www.youtube.com/watch?v=Et2khGnrIqc
			
			//using will use the connection and will destroy the connection after used.
			using(IDbConnection connection = new System.Data.MySqlClient.MySqlConnection(Helper.CnnVal("databaseCon")))
			{
				var output = connection.Query<Empleado>($"select * from empleados where nif = '{ nif }'");
				return output;
			}
		}
		
		public void InsertarEmpleado(string Nif, string Nombre, string Apellido, bool Admin, string Clave)
		{
			using(IDbConnection connection = new System.Data.MySqlClient.MySqlConnection(Helper.CnnVal("databaseCon")))
			{
			Empleado nEmpleado = new Empleado { nif = Nif, nombre = Nombre, apellido = Apellido, admin = Admin, clave = Clave};
			
			connection.Execute($"insert '{nEmpleado.nif}'");
			
			}
		}
    }
}