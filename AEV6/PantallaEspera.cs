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
    public partial class pantallaEsperaForm : Form
    {
        public Action Proceso { get; set; }
        public pantallaEsperaForm(Action proceso, string procesoDescripcion)
        {
            InitializeComponent();
            //label1.Text = procesoDescripcion;
            Proceso = proceso;
        }

        public pantallaEsperaForm(Action proceso, string procesoDescripcion, int w, int h)
        {
            InitializeComponent();
            pantallaEsperaForm.ActiveForm.Size = new Size(w,h);
            //label1.Text = procesoDescripcion;
            Proceso = proceso;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Task.Factory.StartNew(Proceso).ContinueWith(t => { this.Close(); }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
