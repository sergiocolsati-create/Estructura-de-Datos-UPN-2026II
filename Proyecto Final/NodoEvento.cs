using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shalom
{
    // Nodo del historial de un envío (lista simple).
    public class NodoEvento
    {
        private EventoRastreo dato;
        private NodoEvento sgte;

        public EventoRastreo Dato { get => dato; set => dato = value; }
        public NodoEvento Sgte { get => sgte; set => sgte = value; }
    }
}
