using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Shalom
{
    // Card de un integrante. Se diseña UNA vez y se reutiliza para todo el equipo.
    //
    // Desde cualquier formulario se abre con una sola línea:
    //     TarjetaColaborador.Abrir("N00525394", this);
    public partial class TarjetaColaborador : UserControl
    {
        private Colaborador colaborador;   // Integrante que se está mostrando

        public TarjetaColaborador()
        {
            InitializeComponent();
        }

        // Abre una ventana con la card del integrante que tiene ese código.
        // La ventana se arma aquí mismo: no hace falta un formulario aparte.
        public static void Abrir(string codigo, Form dueño)
        {
            Colaborador c = Colaborador.Buscar(codigo);
            if (c == null)
            {
                MessageBox.Show("No se encontró al integrante con código " + codigo + ".");
                return;
            }

            TarjetaColaborador tarjeta = new TarjetaColaborador();
            tarjeta.MostrarDatos(c);

            using (Form ventana = new Form())
            {
                ventana.Text = "Desarrollador";
                ventana.ClientSize = tarjeta.Size;
                ventana.FormBorderStyle = FormBorderStyle.FixedDialog;
                ventana.MaximizeBox = false;
                ventana.MinimizeBox = false;
                ventana.ShowInTaskbar = false;
                ventana.StartPosition = FormStartPosition.CenterParent;
                ventana.Controls.Add(tarjeta);

                ventana.ShowDialog(dueño);   // El botón Cerrar de la card la cierra (DialogResult = Cancel)
            }
        }

        // Llena la card con los datos de un integrante.
        // Cada link solo aparece si la persona lo tiene.
        public void MostrarDatos(Colaborador c)
        {
            colaborador = c;

            lblNombre.Text = c.Nombre;
            lblRol.Text = c.Rol;
            lblCodigo.Text = "Código: " + c.Codigo;
            lblCarrera.Text = c.Carrera;
            picFoto.Image = c.Foto;   // Si es null, se ve el fondo gris

            lnkLinkedIn.Visible = !string.IsNullOrWhiteSpace(c.LinkedIn);
            lnkGitHub.Visible = !string.IsNullOrWhiteSpace(c.GitHub);
        }

        private void lnkLinkedIn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AbrirEnlace(colaborador.LinkedIn);
        }

        private void lnkGitHub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AbrirEnlace(colaborador.GitHub);
        }

        // Abre la página en el navegador predeterminado
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
    }
}