using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AEV6
{
    public partial class pantallaEsperaForm : Form
    {
        public Action Proceso { get; set; }

        public pantallaEsperaForm(Action proceso)
        {
            InitializeComponent();
            Proceso = proceso;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Task.Factory.StartNew(Proceso).ContinueWith(t => { this.Close(); }, TaskScheduler.FromCurrentSynchronizationContext());
        }

		private void PictureBox1_Click(object sender, EventArgs e)
		{

		}
	}
}
