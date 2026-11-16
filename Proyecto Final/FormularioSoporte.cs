
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace SoporteShalom
{
    public partial class FormularioSoporte : Form
    {
        private const string CorreoSoporte = "soporte@shalom.com";

        public FormularioSoporte()
        {
            InitializeComponent();
            lnkCorreoSoporte.Text = CorreoSoporte;
        }

        private void lnkCorreoSoporte_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void btnEnviarConsulta_Click(object sender, EventArgs e)
        {
            AbrirCorreoSoporte();
        }

        private void AbrirCorreoSoporte()
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "mailto:" + CorreoSoporte,
                    UseShellExecute = true
                });
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "No se pudo abrir una aplicación de correo. Puedes escribir directamente a " + CorreoSoporte,
                    "Correo de soporte",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FormularioSoporte
            // 
            this.ClientSize = new System.Drawing.Size(506, 445);
            this.Name = "FormularioSoporte";
            this.ResumeLayout(false);

        }
    }
}
