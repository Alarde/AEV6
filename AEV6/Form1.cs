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
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
			
			timer1.Start();
            lblDate.Text = DateTime.Now.ToShortDateString();
            lblTimer.Text = DateTime.Now.ToLongTimeString();
            ActiveControl = txtnif; //Cuando abre el foco se encuentra en el txtbox nif

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();
            lblTimer.Text = DateTime.Now.ToLongTimeString();
        }

        private void btnMantenimiento_Click(object sender, EventArgs e)
        {
            this.Hide();
			mainLoginForm login = new mainLoginForm();
			login.ShowDialog();
        }

		//private bool btnEntradaWasClicked = false;
		//private bool btnSalidaWasClicked = false;
		private bool ValidarFichaje()
		{
			var correcto = true;
			/*if (AccesoDatos.DadoEntrada(txtnif.Text) == "1" && AccesoDatos.DadoSalida(txtnif.Text) == "1")
			{
				correcto = false;
				MessageBox.Show("Ya has completado tu jornada.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
			}*/

			return correcto;
		}

        private void EjecutarEntrada()
        {
            if (Empleado.ValidarNIF(txtnif.Text))
            {
                //Si el nif es correcto, comprueba si el empleado está en la base de datos
                if (AccesoDatos.BuscarEmpleado(txtnif.Text).Count == 0)
                {
                    MessageBox.Show($"El empleado con NIF { txtnif.Text } no esta dado de alta en esta empresa.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                else
                {

                    if (AccesoDatos.ValidaEntradaHoy(txtnif.Text) == 0)
                    {
                        AccesoDatos.FichajeEntrada(txtnif.Text);
                        MessageBox.Show("Has fichado correctamente. Que tengas un buen día.");
                    }
                    else
                    {
                        MessageBox.Show("Hoy ya se ha registrado un fichaje de entrada pero no de salida.");
                        if (AccesoDatos.CheckeaIncidenciasFichajes(txtnif.Text) != 0)
                        {
                            MessageBox.Show("Además, tienes incidencias de fichaje por revisar.");
                        }
                    }

                }
            }
            else MessageBox.Show("NIF erróneo", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
        }

        private void btnEntrada_Click(object sender, EventArgs e) //COMPROBAR FUNCIONAMIENTO
        {
            using (var dEspera = new pantallaEsperaForm(EjecutarEntrada))
            {
                dEspera.ShowDialog(this);
            }
        }

        private void EjecutarSalida()
        {
            //btnSalidaWasClicked = true;
            if (Empleado.ValidarNIF(txtnif.Text))
            {
                if (AccesoDatos.BuscarEmpleado(txtnif.Text).Count == 0)
                {
                    MessageBox.Show($"El empleado con NIF { txtnif.Text } no esta dado de alta en esta empresa.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                else if (AccesoDatos.ValidaSalidaHoy(txtnif.Text) == 1)
                {
                    AccesoDatos.FichajeSalida(txtnif.Text);
                    MessageBox.Show("Se ha actualizado la fecha de salida.");
                }
                else
                {
                    MessageBox.Show("No se ha registrado una entrada previa.");
                }
            }
            else MessageBox.Show("NIF erróneo", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
        }

        private void btnSalida_Click(object sender, EventArgs e) //COMPROBAR FUNCIONAMIENTO
        {
            using (var dEspera = new pantallaEsperaForm(EjecutarSalida)) //No da tiempo para su uso
            {
                dEspera.ShowDialog(this);
            }
        }


        private void lblx_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PanelIzquierda_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnPresencia_Click(object sender, EventArgs e)
        {
            this.Hide();
            Presencia presencia = new Presencia();
            presencia.ShowDialog();
        }
    }
}
