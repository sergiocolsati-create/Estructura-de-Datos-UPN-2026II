using System;
using System.Windows.Forms;

namespace Shalom
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                // Conectar con SQL y cargar los datos iniciales.
                Sistema.CargarDatosSQL();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo conectar con SQL Server.\n\n" +
                    "Verifica el nombre del servidor y la base de datos.\n\n" +
                    "Detalle: " + ex.Message,
                    "Error de conexión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return;
            }

            Application.Run(new RastreoYLogística());
        }
    }
}
