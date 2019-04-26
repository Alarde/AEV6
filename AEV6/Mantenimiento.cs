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
    public partial class mantenimientoForm : Form
    {
		List<Empleado> empleados = new List<Empleado>();
		List<Fichajes> fichajes = new List<Fichajes>();

		public TextBox TextBoxNif { get; }

		public mantenimientoForm()
        {
            InitializeComponent();
        }

        public void VaciarCampos()
        {
            txtNif.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            chkAdmin.Checked = false;
            txtClave.Text = "";
            txtClave.Enabled = false;
        }

		private void Mantenimiento_Load(object sender, EventArgs e) //Timer para mostrar la hora
		{
            timer1.Start();
			lblDate.Text = DateTime.Now.ToShortDateString();
			lblTimer.Text = DateTime.Now.ToLongTimeString();
			txtClave.Enabled = false;

			using (var dEspera = new pantallaEsperaForm(DevolverEmpleados)) //No da tiempo para su uso
			{
				dEspera.ShowDialog(this);
			}
            dgvMantenimiento.DataSource = empleados;
            dgvMantenimiento.Refresh();
            dgvMantenimiento.ClearSelection();
        }

		private void timer1_Tick(object sender, EventArgs e)
		{
			timer1.Start();
			lblTimer.Text = DateTime.Now.ToLongTimeString();
		}

		private void CargarListaEmpleados() //Metodo para cargar el datagridview con los empleados ya dados de alta directamente desde la base de datos.
		{
			
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
            DialogResult = DialogResult.OK;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AccesoDatos db = new AccesoDatos();
            Empleado emp = new Empleado();
            if (ValidarDatos())
			{
				if(chkAdmin.Checked) //Si la casila de admin está marcada, usamos el constructor de empleado con clave
				{
                    var confirmResult = MessageBox.Show("Se va a añadir un nuevo administrador, estás seguro de continuar?", "Confirmación", MessageBoxButtons.YesNo);
                    if (confirmResult == DialogResult.Yes)
                    {
                        emp = new Empleado(txtNif.Text, txtNombre.Text, txtApellido.Text, chkAdmin.Checked, txtClave.Text);
                        db.AgregarEmpleado(emp);
                        MessageBox.Show($"Usuario '{ txtNif.Text }' añadido correctamente.");
                    }
                }
                else //Si no, usamos el constructor de un empleado normal
				{
					emp = new Empleado(txtNif.Text, txtNombre.Text, txtApellido.Text, chkAdmin.Checked, "");
                    db.AgregarEmpleado(emp);
                    MessageBox.Show($"Usuario '{ txtNif.Text }' añadido correctamente.");
                }
            }
            else MessageBox.Show("Hay datos vacíos o incorrectos.");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            AccesoDatos db = new AccesoDatos();
            if (txtNif.Text == "")
            {
                errorMantenimiento.SetError(txtNif, "El campo NIF no puede estar vacío para eliminar a un empleado.");
            }
            else
            {
                var confirmResult = MessageBox.Show($"Estás seguro que quieres borrar al empleado '{ txtNif.Text }'", "Confirmación", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    db.EliminarEmpleado(txtNif.Text);
                    VaciarCampos();
                }
                else
                {
                    VaciarCampos();
                }
            }
        }

        private void btnInformes_Click(object sender, EventArgs e)
		{
			var formFichajes = new InformeFichajes();
			formFichajes.ShowDialog();
		}

		private void DevolverEmpleados()
        {
            empleados = AccesoDatos.BuscarTodosEmpleados();
        }

		private void btnActualizar_Click(object sender, EventArgs e) //Actualiza de nuevo el datagrid mostrandote todos los empleados dados de alta
		{
            using (var dEspera = new pantallaEsperaForm(DevolverEmpleados)) //No da tiempo para su uso
            {
                dEspera.ShowDialog(this);
            }
            dgvMantenimiento.DataSource = empleados;
            dgvMantenimiento.Refresh(); //Que vuelva a dibujar el datagrid
            dgvMantenimiento.ClearSelection(); //Para desamarar las casillas, estetica
        }

        private void btnCerrar_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
            Application.Exit();
        }

        private void lblAdmin_Click(object sender, EventArgs e)
        {

        }

        public void BuscarEmpleado()
        {
            empleados = AccesoDatos.BuscarEmpleado(txtbuscar.Text);
            dgvMantenimiento.DataSource = empleados;
            dgvMantenimiento.Refresh();
        }

		private void btnBuscar_Click(object sender, EventArgs e)
		{
            /*Lets call our database*/
            using (var dEspera = new pantallaEsperaForm(BuscarEmpleado))
            {
                dEspera.ShowDialog(this);
            }
        }

		private void chkAdmin_CheckedChanged(object sender, EventArgs e)
		{
			if (chkAdmin.Checked == false) txtClave.Enabled = false; //Si la casilla de admin no esta marcada no dejara escribir una contrase;a
			else txtClave.Enabled = true;
		}

        private void TxtNif_TextChanged(object sender, EventArgs e)
        {
            
        }

		private void DgvMantenimiento_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			DataGridViewRow row = dgvMantenimiento.Rows[e.RowIndex];
			txtNif.Text = row.Cells[0].Value.ToString();
			txtNombre.Text = row.Cells[1].Value.ToString();
			txtApellido.Text = row.Cells[2].Value.ToString();

			if (Boolean.Parse(row.Cells[3].Value.ToString())) chkAdmin.Checked = true;
			else chkAdmin.Checked = false;
            txtClave.Text = row.Cells[4].Value.ToString();
        }
	}
}
