using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shalom
{
    // Nodo para la pila del vehículo y para las colas (recepción y almacén).
    // Es el mismo "Nodo" de nuestras prácticas, solo que el dato ahora es un Envio.
    public class NodoEnvio
    {
        private Envio dato;
        private NodoEnvio sgte;

        public Envio Dato { get => dato; set => dato = value; }
        public NodoEnvio Sgte { get => sgte; set => sgte = value; }
    }
}