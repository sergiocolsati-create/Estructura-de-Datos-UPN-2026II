using System;
using System.Windows.Forms;

namespace Shalom
{
    public partial class DevAnsh : Form
    {
        public DevAnsh()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lblCarrera_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DevEst siguiente = new DevEst();
            siguiente.Show();
            this.Close();
        }
    }
}