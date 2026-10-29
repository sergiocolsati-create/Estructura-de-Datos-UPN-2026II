using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab06
{
    internal class Nodo
    {
        private int dato;
        private Nodo hijoizquierdo;
        private Nodo hijoderecho;

        public int Dato { get => dato; set => dato = value; }
        internal Nodo Hijoizquierdo { get => hijoizquierdo; set => hijoizquierdo = value; }
        internal Nodo Hijoderecho { get => hijoderecho; set => hijoderecho = value; }
    }
}
