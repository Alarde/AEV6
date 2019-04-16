using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace AEV6
{
    class ConexionBBDD
    {
        private MySqlConnection conexion;

        public MySqlConnection Conexion {
            get {
                return conexion;
            } 
        }
        

        public ConexionBBDD()
        {

            string connectionstring = "server=db4free.net; port=3306; database=dbflorida19_; uid=alarde01_; pwd=alarde01alalst; old guids=true;";
            conexion = new MySqlConnection(connectionstring);
            /*
            string server = "server=127.0.0.1;";
            string port = "port=3306;";
            string database = "database=BBDDProgramacion;";
            string usuario = "uid=root;";
            string password = "pwd=;";
            string connectionstring = server + port + database + usuario + password;
            */

        }

        public bool AbrirConexion()
        {
            //Verificar si la conexión está abierta
            if(conexion != null && conexion.State == ConnectionState.Closed){
                try
                {
                    conexion.Open();
                    return true;
                }
                catch (MySqlException ex)
                {
                    switch (ex.Number) //La app responderá en funcion de qué error ha ocurrido. Los más comunes son el 0 y el 1045
                    {
                        case 0: //El error 0 es que no se ha podido conectar con el servidor
                            System.Windows.Forms.MessageBox.Show("No se pudo conectar con el servidor.", "Error de conexión");
                            break;
                        case 1045: //El error 1045 es que se ha introducido un usuario y/o contraseña incorrectos.
                            System.Windows.Forms.MessageBox.Show("Usuario o contraseña erróneos, inténtelo de nuevo.", "Datos erróneos");
                            break;
                    }
                    return false;
                }
            }else{
                //Como mi conexión está abierta, devuelvo true
                return true;
            }
        }

        public bool CerrarConexion()
        {
            try
            {
                conexion.Close();
                System.Windows.Forms.MessageBox.Show("Base de datos cerrada.");
                return true;
            }
            catch (MySqlException)
            {
                return false;
            }
            finally
            {
                //Cierra la conexion aunque no se pueda
                conexion.Close();
            }
        }
    }
}
