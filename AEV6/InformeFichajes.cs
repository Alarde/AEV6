using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AEV6
{
	public partial class InformeFichajes : Form
	{
		mantenimientoForm mantenimiento = new mantenimientoForm();
		List<Fichajes> fichajes = new List<Fichajes>();

		public InformeFichajes()
		{
			InitializeComponent();
		}

		private void GenerarFichajes()
		{
			fichajes = AccesoDatos.GenerarFichajes();
		}

		private void InformeFichajes_Load(object sender, EventArgs e)
		{
			using (var dEspera = new pantallaEsperaForm(GenerarFichajes)) //No da tiempo para su uso
			{
				dEspera.ShowDialog(this);
			}
			dgvFichajes.DataSource = fichajes;
			dgvFichajes.Refresh(); //Que vuelva a dibujar el datagrid
			dgvFichajes.ClearSelection(); //Para desamarcar las casillas, estetica
		}
	}
}
