using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Dapper;
namespace AEV6
{
    public partial class Presencia : Form
    {
        List<Empleado> empleados = new List<Empleado>();
        SqlConnection conexion = new SqlConnection();

        public Presencia()
        {
            InitializeComponent();
        }

        private void Presencia_Load(object sender, EventArgs e)
        {
            
		}

        private void BtnMostrar_Click(object sender, EventArgs e)
        {

        }
    }
}
