using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shalom
{
    // Nodo de la ruta del vehículo (lista doblemente enlazada).
    // Igual que en "Enlazadadoble": Sgte apunta al siguiente, Ante al anterior.
    public class NodoParada
    {
        private Envio dato;
        private int orden;
        private NodoParada sgte;
        private NodoParada ante;

        public Envio Dato { get => dato; set => dato = value; }
        public int Orden { get => orden; set => orden = value; }
        public NodoParada Sgte { get => sgte; set => sgte = value; }
        public NodoParada Ante { get => ante; set => ante = value; }
    }
}
