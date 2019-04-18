using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AEV6
{
    public partial class Mantenimiento : Form
    {
        //Alarde - ConexionBBDD bdatos = new ConexionBBDD();
        //Alarde - MySqlConnection conexion = new MySqlConnection();
		List<Empleado> empleados = new List<Empleados>();
        public Mantenimiento()
        {
            InitializeComponent();
			//Connecting datagrid with the employees
			dgvMantenimiento.DataSource = empleados;
			
        }

		private void Mantenimiento_Load(object sender, EventArgs e) //Timer para mostrar la hora
		{
            //Alarde - bdatos.AbrirConexion();
            timer1.Start();
			lblDate.Text = DateTime.Now.ToShortDateString();
			lblTimer.Text = DateTime.Now.ToLongTimeString();
			txtClave.Enabled = false;
			CargarListaEmpleados();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			timer1.Start();
			lblTimer.Text = DateTime.Now.ToLongTimeString();
		}

		private void CargarListaEmpleados() //Metodo para cargar el datagridview con los empleados ya dados de alta directamente desde la base de datos.
		{
            //if (bdatos.AbrirConexion())
            //{
            //Alarde - dgvMantenimiento.DataSource = Empleado.BuscarEmpleados(bdatos.Conexion);
            //Alarde - bdatos.CerrarConexion();
            //}
            //else MessageBox.Show("No se ha podido conectar con la base de datos para cargar la lista de empleados.");
        }

        private bool ValidarDatos()
		{
			bool correcto = true;

			if (txtNif.Text == "")
			{
				correcto = false;
				errorMantenimiento.SetError(txtNif, "El campo NIF no puede estar vacío.");
			}
			if (Empleado.ValidarNIF(txtNif.Text) == false)
			{
				correcto = false;
				errorMantenimiento.SetError(txtNif, "El formato del NIF que está intentando introducir es erróneo.");
			}
			if(txtNombre.Text == "")
			{
				correcto = false;
				errorMantenimiento.SetError(txtNombre, "El campo NOMBRE no puede estar vacío.");
			}
			if (txtApellido.Text == "")
			{
				correcto = false;
				errorMantenimiento.SetError(txtApellido, "El campo APELLIDO no puede estar vacío.");
			}
			return correcto;
		}
		
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

           
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
			try
			{
				//if(bdatos.AbrirConexion())
				//{
					if (ValidarDatos())
					{
						if(chkAdmin.Checked) //Si la casila de admin está marcada, usamos el constructor de empleado con clave
						{
							Empleado emp = new Empleado(txtNif.Text, txtNombre.Text, txtApellido.Text, chkAdmin.Checked, txtClave.Text);
                        //Alarde - Empleado.AgregarEmpleado(conexion, emp);
                    }
                    else //Si no, usamos el constructor de un empleado normal
						{
							Empleado emp = new Empleado(txtNif.Text, txtNombre.Text, txtApellido.Text, chkAdmin.Checked);
                        //Alarde - Empleado.AgregarEmpleado(conexion, emp);
                    }
                }
					else MessageBox.Show("Hay datos vacíos o incorrectos.");
				//}
				//else
				//{
					//MessageBox.Show("No se ha podido establecer la conexión con la base de datos, por favor inténtelo de nuevo más tarde.");
				//}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
			}
			//finally
			//{
				//bdatos.CerrarConexion();
			//}
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
			try
			{

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
			}
        }

        private void btnInformes_Click(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click_1(object sender, EventArgs e)
        {
            //Alarde - bdatos.CerrarConexion();
            this.Dispose();
        }

        private void lblAdmin_Click(object sender, EventArgs e)
        {

        }

		private void btnBuscar_Click(object sender, EventArgs e)
		{
			/*Lets call our database*/
			DataAccess db = new DataAccess();
			
			empleados = db.GetPeople(textBox1.Text);
			dgvMantenimiento.DataSource = empleados;
		}

		private void chkAdmin_CheckedChanged(object sender, EventArgs e)
		{
			if (chkAdmin.Checked == false) txtClave.Enabled = false; //Si la casilla de admin no esta marcada no dejara escribir una contrase;a
			else txtClave.Enabled = true;
		}

		private void btnActualizar_Click(object sender, EventArgs e) //Actualiza de nuevo el datagrid mostrandote todos los empleados dados de alta
		{
			CargarListaEmpleados();
		}
	}
}
