using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Shalom
{
    // Card de un integrante. Se diseña UNA vez y se reutiliza para todo el equipo.
    public partial class TarjetaColaborador : UserControl
    {
        private Colaborador colaborador;

        public TarjetaColaborador()
        {
            InitializeComponent();
            lnkLinkedIn.LinkClicked += (s, e) => AbrirEnlace(colaborador.LinkedIn);
            lnkGitHub.LinkClicked += (s, e) => AbrirEnlace(colaborador.GitHub);
        }

        // Llena la card con los datos de un integrante.
        // mostrarLinks: false en la ventana de los 5, true en la card individual.
        public void MostrarDatos(Colaborador c, bool mostrarLinks)
        {
            colaborador = c;

            lblNombre.Text = c.Nombre;
            lblRol.Text = c.Rol;
            lblCodigo.Text = "Código: " + c.Codigo;
            lblCarrera.Text = c.Carrera;
            picFoto.Image = c.Foto;   // Si es null, se ve el fondo gris

            // Un link solo aparece si se pidió Y la persona lo tiene.
            lnkLinkedIn.Visible = mostrarLinks && !string.IsNullOrWhiteSpace(c.LinkedIn);
            lnkGitHub.Visible = mostrarLinks && !string.IsNullOrWhiteSpace(c.GitHub);
        }

        // Abre la página en el navegador predeterminado.
        private void AbrirEnlace(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo abrir el enlace:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void lnkGitHub_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void lnkLinkedIn_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}