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
    public class DataAccess
    {
        public List<Empleado> GetEmployee(string nif)
		{
            var dbCon = DBConnection.Instance();
            if (dbCon.IsConnect())
            {

                //using will use the connection and will destroy the connection after used.
                using (IDbConnection connection = dbCon.Connection)
                {
                    var output = connection.Query<Empleado>($"select * from empleados where nif = '{ nif }'").ToList();
                    return output;
                }
            }
            else
            {
                return null;
            }
		}

        public List<Empleado> GetAllEmployees()
        {
            var dbCon = DBConnection.Instance();
            if (dbCon.IsConnect())
            {
                using (IDbConnection connection = dbCon.Connection)
                {
                    var output = connection.Query<Empleado>($"select * from empleados").ToList();
                    return output;
                }
            }
            else
            {
                return null;
            }
        }

        public void eliminaEmpleado(string nif)
        {
            var dbCon = DBConnection.Instance();
            if (dbCon.IsConnect())
            {
                using (IDbConnection connection = dbCon.Connection)
                {
                    var output = connection.Execute($"delete from empleados where empleados.nif = '{ nif }'");
                }
            }
        }
		
		public void InsertarEmpleado(Empleado e)
		{
            var dbCon = DBConnection.Instance();
            if (dbCon.IsConnect())
            {
                var parseValue = 0;
                using (IDbConnection connection = dbCon.Connection)
                {
                    if (e.admin)
                    {
                        parseValue = 1;
                    }
                    else
                    {
                        parseValue = 0;
                    }
                    connection.Execute($"insert into empleados (`nif`, `nombre`, `apellido`, `admin`, `clave`) VALUES ('{ e.nif }', '{ e.nombre }', '{ e.apellido }', '{ parseValue }', '{ e.clave }') ");
                }
            }
		}
    }
}