using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Shalom
{
    // FORMULARIO DE LOGIN
    // Valida usuario y contraseña contra la tabla Usuario (Sistema.IniciarSesion).
    // Si son correctos, se cierra con DialogResult.OK y Program.cs abre el menú.
    public partial class FormularioLogin : Form
    {
        private readonly Color rojo = Color.FromArgb(232, 38, 43);
        private readonly Color grisLinea = Color.FromArgb(210, 214, 220);

        private bool claveVisible = false;   // ¿La contraseña se está mostrando?

        public FormularioLogin()
        {
            InitializeComponent();

            // La línea de abajo de cada campo se pone roja mientras se escribe en él
            txtUsuario.Enter += (s, e) => lineaUsuario.BackColor = rojo;
            txtUsuario.Leave += (s, e) => lineaUsuario.BackColor = grisLinea;
            txtContrasena.Enter += (s, e) => lineaContrasena.BackColor = rojo;
            txtContrasena.Leave += (s, e) => lineaContrasena.BackColor = grisLinea;
        }

        // ---------- Ingresar ----------
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contrasena = txtContrasena.Text;

            if (usuario == "" || contrasena == "")
            {
                lblMensaje.Text = "Ingrese su usuario y contraseña.";
                return;
            }

            string error;
            try
            {
                error = Sistema.IniciarSesion(usuario, contrasena);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo conectar con la base de datos.\n\n" + ex.Message,
                                "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (error != "")
            {
                lblMensaje.Text = error;   // Aviso en rojo debajo del botón
                txtContrasena.Clear();
                txtContrasena.Focus();
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        // Al volver a escribir, se borra el aviso anterior
        private void Campos_TextChanged(object sender, EventArgs e)
        {
            lblMensaje.Text = "";
        }

        // ---------- Ojito: mostrar u ocultar la contraseña ----------
        private void btnMostrarClave_Click(object sender, EventArgs e)
        {
            claveVisible = !claveVisible;
            txtContrasena.UseSystemPasswordChar = !claveVisible;
            btnMostrarClave.Invalidate();   // Redibuja el ojo
            txtContrasena.Focus();
        }

        // Dibuja el ojo con líneas (sin imágenes).
        // Contraseña oculta → ojo normal. Contraseña visible → ojo tachado.
        private void btnMostrarClave_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int cx = btnMostrarClave.Width / 2;
            int cy = btnMostrarClave.Height / 2;
            Color gris = Color.FromArgb(120, 125, 130);

            using (Pen lapiz = new Pen(gris, 1.8f))
            using (SolidBrush relleno = new SolidBrush(gris))
            using (GraphicsPath ojo = new GraphicsPath())
            {
                ojo.AddBezier(cx - 10, cy, cx - 5, cy - 7, cx + 5, cy - 7, cx + 10, cy);   // Párpado de arriba
                ojo.AddBezier(cx + 10, cy, cx + 5, cy + 7, cx - 5, cy + 7, cx - 10, cy);   // Párpado de abajo
                g.DrawPath(lapiz, ojo);
                g.FillEllipse(relleno, cx - 3, cy - 3, 6, 6);                             // Pupila

                if (claveVisible)
                    g.DrawLine(lapiz, cx - 9, cy + 7, cx + 9, cy - 7);                     // Tachado
            }
        }

        // ---------- Enlaces ----------
        private void lnkColaboradores_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (Colaboradores ventana = new Colaboradores())
                ventana.ShowDialog(this);
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            using (CentroAyuda ayuda = new CentroAyuda())
                ayuda.ShowDialog(this);
        }
    }
}