using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shalom
{
    // Nodo del árbol binario de búsqueda. La clave es el código del envío.
    public class NodoArbol
    {
        private Envio dato;
        private NodoArbol izquierdo;   // códigos menores
        private NodoArbol derecho;     // códigos mayores

        public Envio Dato { get => dato; set => dato = value; }
        public NodoArbol Izquierdo { get => izquierdo; set => izquierdo = value; }
        public NodoArbol Derecho { get => derecho; set => derecho = value; }
    }
}
