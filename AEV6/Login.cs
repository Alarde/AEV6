using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using MySql.Data.MySqlClient;

namespace AEV6
{
    public partial class Login : Form
    {
        //Alarde - ConexionBBDD bdatos = new ConexionBBDD();
        //Alarde - MySqlConnection conexion = new MySqlConnection();
        private static bool error = false;
        public Login()
        {
            InitializeComponent();
			
        }

        private void Login_Load(object sender, EventArgs e)
        {
			//Alarde - bdatos.AbrirConexion();
			//if (bdatos.AbrirConexion()) MessageBox.Show("Se ha abierto el login");
			//else MessageBox.Show("No se ha abierto el login");

			this.ActiveControl = btnAceptar;
        }
        private bool ValidarDatos()
		{
			bool correcto = true;

			if(txtNif.Text == "" && txtContraseña.Text == "") //Si los dos campos estan vacios te informa
			{
				correcto = false;
				MessageBox.Show("El campo \"Usuario\" y \"Contraseña\" no pueden estar vacíos.");
			}
			else
			{
				if(txtNif.Text == "" && txtContraseña.Text != "") //Si solo esta vacio el campo usuario te informa
				{
					correcto = false;
					MessageBox.Show("El campo \"Usuario\" no puede estar vacío.");

				}
				if(txtContraseña.Text == "" && txtNif.Text != "") //Si solo esta vacio el campo pass te informa
				{
					correcto = false;
					MessageBox.Show("El campo \"Contraseña\" no puede estar vacío.");
				}
				if(txtNif.Text != "" && txtContraseña.Text != "" && Empleado.ValidarNIF(txtNif.Text) == false)
				{ //Si ninguno de los dos campos están vacios, pero el nif está mal, te informa
					correcto = false;
					MessageBox.Show("El NIF introducido es erróneo.");
				}
			}
			return correcto;
		}

        public void logea()
        {
            if (ValidarDatos())
            { //Si no hay ningun campo vacio
                var dbCon = DBConnection.Instance();
                if (dbCon.IsConnect())
                {
                    string query = string.Format("SELECT nif, clave FROM empleados WHERE nif=@nif AND " +
                                "clave=@clave");
                    var cmd = new MySqlCommand(query, dbCon.Connection);
                    cmd.Parameters.AddWithValue("@nif", txtNif.Text);
                    cmd.Parameters.AddWithValue("@clave", txtContraseña.Text);
                    var reader = cmd.ExecuteReader();
                    if (!reader.HasRows) //Si no hay una fila escondes este form y entras al de mantenimiento
                    {
                        error = true;
                    }
                    
                    reader.Close();
                }
            }else
            {
                error = true;
            }
            // Si en vez de complicarnos con una pantalla, lo que hacemos es cambiar el cursor a un WaitCursor sería suficiente
            //this.Login_Load.Cursor = System.Windows.Forms.Cursors.WaitCursor;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            using (var dEspera = new PantallaEspera(logea, "Revisando información de BBDD..."))
            {
                dEspera.ShowDialog(this);
            }
            if(!error)
            {
                txtNif.Text = "";
                txtContraseña.Text = "";
                Mantenimiento mantenimiento = new Mantenimiento();
                mantenimiento.Show();
            }
            else
            {
                MessageBox.Show("La contraseña introducida es incorrecta.");
                error = false;
            }
            
        }

		private void btnVaciar_Click(object sender, EventArgs e)
		{
			txtNif.Text = "";
			txtContraseña.Text = "";
		}

		private void chkMostrarPass_CheckedChanged(object sender, EventArgs e)
		{
			if (chkMostrarPass.Checked) txtContraseña.PasswordChar = '\0'; //Si la checkbox esta marcada, te mostrara la pass
			else txtContraseña.PasswordChar = '*'; //Si esta desactivada te mostrara asteriscos
		}

        private void lblVolver_Click(object sender, EventArgs e)
        {
            //Alarde - bdatos.CerrarConexion();
            this.Hide();
            Form1 form = new Form1();
            form.Show();
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        
        private void txtNif_Leave_1(object sender, EventArgs e)
        {
            /*if (ValidarDatos())
            {
                ActiveControl = btnAceptar;
            }*/
        }

        private void txtContraseña_Leave(object sender, EventArgs e)
        {
            /*if (ValidarDatos())
            {
                ActiveControl = btnAceptar;
            }*/
        }
    }
}
