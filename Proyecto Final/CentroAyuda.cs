using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shalom
{
    public partial class CentroAyuda : Form
    {
        public CentroAyuda()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEnviarSolicitud_Click(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text.Trim();
            string problema = txtDescripcion.Text.Trim();

            if (string.IsNullOrWhiteSpace(correo))
            {
                MessageBox.Show("Ingresa tu correo electrónico.");
                txtCorreo.Focus();
                return;
            }

            try
            {
                var direccion = new System.Net.Mail.MailAddress(correo);

                if (direccion.Address != correo || !direccion.Host.Contains("."))
                    throw new FormatException();
            }
            catch (FormatException)
            {
                MessageBox.Show("Ingresa un correo válido, por ejemplo: usuario@gmail.com.");
                txtCorreo.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(problema))
            {
                MessageBox.Show("Describe el problema antes de continuar.");
                txtDescripcion.Focus();
                return;
            }

            MessageBox.Show("Los datos de tu solicitud se completaron correctamente.",
                "Centro de ayuda", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }
    }
}
