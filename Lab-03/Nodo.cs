using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana05
{
    internal class Nodo
    {
        private int dato;
        private Nodo prev;
        private Nodo next;

        public int Dato { get => dato; set => dato = value; }
        internal Nodo Prev { get => prev; set => prev = value; }
        internal Nodo Next { get => next; set => next = value; }
    }
}
