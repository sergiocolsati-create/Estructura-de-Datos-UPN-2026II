using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class Nodo
    {
        private int dato;
        private Nodo sgte;
        private Nodo anterior;

        public int Dato { get => dato; set => dato = value; }
        internal Nodo Sgte { get => sgte; set => sgte = value; }
        internal Nodo Anterior { get => anterior; set => anterior = value; }
    }
}
