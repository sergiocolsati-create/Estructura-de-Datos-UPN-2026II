using Shalom;
using System;
using System.Windows.Forms;

namespace SoporteShalom
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Primero muestra el login.
            using (FormularioLogin login = new FormularioLogin())
            {
                if (login.ShowDialog() != DialogResult.OK)
                {
                    return; // Si se cierra el login sin ingresar, termina el programa.
                }
            }

            // Las credenciales ya se validaron localmente.
            // Esto carga los datos que necesita el sistema desde SQL.
            try
            {
                Sistema.CargarDatosSQL();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron cargar los datos del sistema desde SQL Server.\n\n" + ex.Message,
                    "Error de conexión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            // Si el login fue correcto y se cargaron los datos, abre el sistema.
            Application.Run(new RastreoYLogística());
        }
    }
}
