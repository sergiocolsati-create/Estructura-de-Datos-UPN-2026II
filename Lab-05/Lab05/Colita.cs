using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab05
{
    internal class Colita
    {

        private Nodo pri;
        private Nodo ulti;

        public Colita() {

            pri = null;
            ulti = null;
        
        }

        public bool isEmpty()
        {
            return pri == null;
        }

        public void enqueue(string código, string descripción, string prioridad)
        {
            Nodo nuevo = new Nodo(); // Creamos el nodo "nuevo"

            nuevo.Cod = código;
            nuevo.Descripcion = descripción;
            nuevo.Prioridad = prioridad;
            nuevo.Sgte = null; // el nuevo siempre será el último, apunta a null

            if (isEmpty()) // Si la cola está vacía, el nuevo es pri y ulti
            {
                pri = nuevo;
                ulti = nuevo;
            }
            else
            {
                ulti.Sgte = nuevo; // ulti apunta al nuevo, ya no a null
                ulti = nuevo;      // actualizamos ulti para que sea el nuevo
            }
        }

        public Nodo dequeue()
        {
            if (isEmpty()) // si no hay nodos no hay nada que sacar
            {
                return null;
            }

            Nodo actual = pri; // guardamos el nodo que va a salir
            pri = pri.Sgte;       // el segundo nodo pasa a ser pri

            if (pri == null) // si ya no quedan nodos, ulti también debe ser null
            {
                ulti = null;
            }

            actual.Sgte = null; // desconectamos el nodo que salió
            return actual;
        }

        public Nodo front()
        {
            return pri; // si está vacía devuelve null
        }

        public void VerCola(ListBox lista)
        {
            Nodo actual = pri; // Creamos el nodo "actual" y le asignamos "pri"

            while (actual != null) // recorre hasta llegar a null (después de ulti)
            {
                lista.Items.Add(
                    actual.Cod + " - " +
                    actual.Descripcion+ " - " +
                    actual.Prioridad
                );
                actual = actual.Sgte; // pasamos al siguiente nodo
            }
        }


        public int Contador()
        {
            Nodo actual = pri;
            int contador = 0;
            while (actual != null) {
                actual=actual.Sgte; contador++;
                        }
            return contador;

        }
    }
}
