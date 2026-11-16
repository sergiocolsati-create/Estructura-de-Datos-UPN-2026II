using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shalom
{
    public partial class CentroAyuda : Form
    {
        private const string CorreoSoporte = "soporte@shalom.com";
        public CentroAyuda()
        {
            InitializeComponent();
            lnkCorreoSoporte.Text = CorreoSoporte;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEnviarSolicitud_Click(object sender, EventArgs e)
        {
            
        }

        private void lnkCorreoSoporte_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            {
                string url = "https://mail.google.com/mail/?view=cm&fs=1&to="
                    + Uri.EscapeDataString(CorreoSoporte)
                    + "&su=" + Uri.EscapeDataString("Consulta de soporte SHALOM")
                    + "&body=" + Uri.EscapeDataString("Hola, necesito ayuda con mi envío.");

                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
        }
    }
}
