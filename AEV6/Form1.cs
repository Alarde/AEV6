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

            this.ActiveControl = txtnif; //Cuando abre 

			//Alarde - bdatos.AbrirConexion();
			//if (bdatos.AbrirConexion()) MessageBox.Show("se abre");
			//else MessageBox.Show("No se ha podido conectar con la base de datos."); //Si nada mas abrir el programa no se ha podido conectar con la base de datos te informa
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();
            lblTimer.Text = DateTime.Now.ToLongTimeString();
            
        }

        private void btnMantenimiento_Click(object sender, EventArgs e)
        {
            this.Hide();
			Login login = new Login();
			login.ShowDialog();
        }

        private void btnEntrada_Click(object sender, EventArgs e)
        {

			/*Alarde - if (Empleado.ValidarNIF(txtnif.Text))
			{
				(Empleado.ExisteEmpleado(txtnif.Text))
				{
					MessageBox.Show("Todo guay");
				}
				else
				{
					MessageBox.Show("Error");
				}
			}*/
        }

        private void btnSalida_Click(object sender, EventArgs e)
        {
            
        }

        private void btnPresencia_Click(object sender, EventArgs e)
        {
            
        }

        private void lblx_Click(object sender, EventArgs e)
        {
            Application.Exit(); //Cierra la aplicacion
            //Alarde - bdatos.CerrarConexion();
        }

        private void PanelIzquierda_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
