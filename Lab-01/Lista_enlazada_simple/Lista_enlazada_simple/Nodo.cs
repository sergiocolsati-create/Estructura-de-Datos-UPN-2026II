using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Representa un nodo de una lista enlazada simple.
// Cada nodo almacena datos de una tarea (código, descripción, prioridad) y una referencia (puntero) al siguiente nodo de la lista.

namespace Lista_enlazada_simple
{
    internal class Nodo
    {
        // Codigo unico identificador
        private string código;
        // Descripción de la tarea.
        private string descripción;
        // Prioridad de la tarea ("Alta", "Media", "Baja").
        private string prioridad;
        // Puntero (referencia) al siguiente nodo de la lista.

        private Nodo sgte;
        // Creando los Get y Set
        public string Código { get => código; set => código = value; } // Propiedad pública para acceder y modificar el código de la tarea
        public string Descripción { get => descripción; set => descripción = value; }// Propiedad pública para acceder y modificar la descripción de la tarea
        public string Prioridad { get => prioridad; set => prioridad = value; }// Propiedad pública para acceder y modificar la prioridad de la tarea
        internal Nodo Sgte { get => sgte; set => sgte = value; }// Propiedad interna para acceder y modificar el puntero al siguiente nodo
    }
}
