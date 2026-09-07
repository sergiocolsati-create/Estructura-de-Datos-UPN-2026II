using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lista_enlazada_simple
{
    internal class Lista
    {
        private Nodo pri = new Nodo();  // Puntero al primer nodo de la lista
        private Nodo ulti = new Nodo(); // Puntero al último nodo de la lista

        public Lista()// inicializa la lista vacía (sin nodos)
        {
            pri = null;
            ulti = null;
        }
        // Método para insertar un nuevo nodo  al final de la lista
        public void InsertarNodo(string código, string descripción, string prioridad)
        {
            // Creamos el nodo "nuevo"
            Nodo nuevo = new Nodo();

            nuevo.Código = código;// asignamos valor que recibimos como parametro en este caso "código"
            nuevo.Descripción = descripción;// asignamos valor que recibimos como parametro en este caso "descripción"
            nuevo.Prioridad = prioridad;// asignamos valor que recibimos como parametro en este caso "prioridad"

            if (pri == null)
            {
                pri = nuevo;
                pri.Sgte = null;
                ulti = nuevo;
            } // Si la lista está vacía, el nuevo nodo sea  pri y ulti
            else
            {
                ulti.Sgte = nuevo;// Si ya hay nodos, ulti apunta al  nuevo ya no a null
                ulti = nuevo; // Actualizamos ulti para que ahora sea el nodo nuevo
                ulti.Sgte = null;// ulti apunta a null
            }
        }
        // Método para recorrer la lista y mostrar todos los nodos en un ListBox
        public bool VerLista(ListBox lista)
        {
            Nodo actual = pri; // Creamos el nodo "actual" y le asignamos "pri"

            while (actual != null)//mientras actual sea diferente de null, recorrera la lista, como null es el ultimo ahi se detiene.
            {
                lista.Items.Add(
                    actual.Código + " - " +
                    actual.Descripción + " - " +
                    actual.Prioridad
                ); // Agregamos los datos del nodo actual al ListBox

                actual = actual.Sgte;// se actualiza el puntero al siguiente nodo
            }

            return true;
        }


        // Método para buscar un nodo por código y mostrarlo en un ListBox si se encuentra
        public bool ListarBusqueda(string código, ListBox lista)// Parametros de busqueda, el codigo y la lista donde lo buscara
        {
            Nodo actual = pri;// Creamos el nodo "actual" y le asignamos "pri"
            bool encontrado = false; // se define la variable de tipo booleana y se le asigna el valor inicial false

            while (actual != null) // Comparamos el código del nodo actual con el que buscamos 
            {
                if (actual.Código == código) // Si coincide, lo agregamos al ListBox
                {
                    lista.Items.Add(
                        actual.Código + " - " +
                        actual.Descripción + " - " +
                        actual.Prioridad
                    );
                    encontrado = true;
                    break;// Salimos del ciclo porque ya lo encontramos
                }
                actual = actual.Sgte;// si no lo encuentra pasa al siguiente nodo
            }

            return encontrado;
        }


        public bool BuscarNodo(string código)// Método para verificar si existe un nodo con el código indicado (sin mostrarlo)
        {
            Nodo actual = pri;  // Creamos el nodo "actual" y le asignamos "pri"

            while (actual != null)// Comparamos el código del nodo actual con el que buscamos 
            {
                if (actual.Código == código)// Si coincide, devuelve true, sino sigue buscando
                {
                    return true;
                }

                actual = actual.Sgte;
            }

            return false;
        }
        // Método para contar cuántos nodos hay en la lista
        public int ContarNodos()
        {
            int contador = 0; // define la variable contador tipo int y le asigna le valor inicila 0

            Nodo actual = pri;// Creamos el nodo "actual" y le asignamos "pri"

            while (actual != null)// Para actual diferente de null, es decir la lista no esta vacia el contador aumenta en 1 y pasa al siguiente
            {
                contador++;
                actual = actual.Sgte;
            }

            return contador;
        }
        // Método para eliminar un nodo de la lista según su código
        public bool eliminarNodo(string código)
        {
            Nodo actual = pri;// Nodo que vamos revisando
            Nodo anterior = null;// Guarda el nodo anterior al actual
            while (actual != null)
            {

                if (actual.Código == código)// Si encontramos el nodo que buscamos

                {

                    if (anterior == null) // Si no hay nodo anterior, significa que es el primero de la lista
                    {
                        pri = actual.Sgte;// El segundo nodo pasa a ser el primero
                    }
                    else
                    {
                        anterior.Sgte = actual.Sgte;// Si hay nodo anterior, lo conectamos con el siguiente del actual, asi saltamos el nodo a eliminar
                    }
                    if (actual == ulti)// Si el nodo eliminado era el último, actualizamos el puntero "ulti"
                    {
                        ulti = anterior;
                    }
                    return true; // Eliminación exitosa
                }
                anterior = actual;// avanzamos al siguiente nodo
                actual = actual.Sgte;//actualizamos puntero mientras avanzamos
            }
            return false;
        }

    }
}