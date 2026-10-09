using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    internal class Nodo<T>
    {
        private T dato;
        private Nodo<T> sgte;

        public T Dato { get => dato; set => dato = value; }
        internal Nodo<T> Sgte { get => sgte; set => sgte = value; }
    }
}