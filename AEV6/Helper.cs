using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace AEV6
{
    public class Helper
    {
        public static string CnnVal(string name)
		{
			var output = ConfigurationManager.ConnectionStrings[name].ConnectionString;
			return output;
		}
    }
}