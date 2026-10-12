using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shalom
{
    // Agencia de origen o destino. Se carga desde SQL en un ComboBox.
    public class Sede
    {
        private int id;
        private string codigo;      // LIM, ARE, TRU (se usa en el código del envío)
        private string nombre;
        private string ciudad;
        private string direccion;

        public int Id { get => id; set => id = value; }
        public string Codigo { get => codigo; set => codigo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Ciudad { get => ciudad; set => ciudad = value; }
        public string Direccion { get => direccion; set => direccion = value; }

      
    }
}

