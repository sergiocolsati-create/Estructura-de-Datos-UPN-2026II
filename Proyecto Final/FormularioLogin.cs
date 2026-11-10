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
    public partial class FormularioLogin : Form
    {
        public FormularioLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contrasena = txtContrasena.Text;

            if (usuario == "grupo2" && contrasena == "admin123")
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show(
                    "El usuario o la contraseña son incorrectos.",
                    "Error de acceso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtContrasena.Clear();
                txtUsuario.Focus();
            }
        }

        private void btnMostrarClave_Click(object sender, EventArgs e)
        {
            txtContrasena.UseSystemPasswordChar = !txtContrasena.UseSystemPasswordChar;
            btnMostrarClave.Text = txtContrasena.UseSystemPasswordChar ? "Ver" : "Ocultar";
            txtContrasena.Focus();
        }
    }
}
