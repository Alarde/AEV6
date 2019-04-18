using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace AEV6
{
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
    }
}