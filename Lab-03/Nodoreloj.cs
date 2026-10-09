using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana05
{
    internal class Nodoreloj
    {
        private int time;
        private Nodoreloj sgte;
        private Nodoreloj ante;

        public int Time { get => time; set => time = value; }
        internal Nodoreloj Sgte { get => sgte; set => sgte = value; }
        internal Nodoreloj Ante { get => ante; set => ante = value; }
    }
}
