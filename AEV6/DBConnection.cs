using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace AEV6
{
    public class DBConnection
    {
        //Éste es el bueno
        private DBConnection()
        {
			
        }

		private MySqlConnection conexion = null;

        public MySqlConnection Conexion { get { return conexion; } }		
        public string Password { get; set; }


		private static DBConnection instancia = null; //Al ser null, siempre se destruira la conexion al dejar de usarla
        public static DBConnection Instancia() //Si no hemos instanciado la base de datos, creamos una
        {
            if (instancia == null) instancia = new DBConnection();

            return instancia;
        }

        public bool Conectado() 
        {
            if (Conexion == null)
            {
                string consulta = string.Format("Server=db4free.net; port=3306; database=dbflorida19_; user=alarde01_; pwd=alarde01alalst;old guids=true");
                conexion = new MySqlConnection(consulta);
                conexion.Open();
            }
            return true;
        }

        public void Close()
        {
            conexion.Close();
        }
    }
}