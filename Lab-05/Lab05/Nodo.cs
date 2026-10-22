using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab05
{
    internal class Nodo
    {
        private string cod;
        private string descripcion;
        private string prioridad;
        private Nodo sgte;

        public string Cod { get => cod; set => cod = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Prioridad { get => prioridad; set => prioridad = value; }
        internal Nodo Sgte { get => sgte; set => sgte = value; }
    }
}
