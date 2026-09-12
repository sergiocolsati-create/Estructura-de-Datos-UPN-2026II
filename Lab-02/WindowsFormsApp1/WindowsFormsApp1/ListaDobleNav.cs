using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal class ListaDoble_Nav
    {
        // definimos nuestros nodos a usar como referencia

        private Nododoble head; // nodo que hara referencia al inicio en la lista 
        private Nododoble tail;// nodo que hara referencia al final de la lista
        private Nododoble current;// nodo referencial para ubicar el navegador no ira en la lista


        public ListaDoble_Nav()
        {
            head = null; // definimos head dentro de la lista y le asignamos valor vacio
            tail = null; // definimos head dentro de la lista y le asignamos valor vacio

        }

        public bool visitar(string url) // metodo equivalente a insertar o crear, nombre adaptado a la navegacion
        {

            Nododoble nuevo = new Nododoble();// creamos un nuevo nodo del tipo nododoble 
            nuevo.Navi = url; // asignamos a Navi dentro de nuevo el valor de url
            nuevo.Next = null;// al puntero next de "nuevo" le asignamos null
            nuevo.Prev = null;// al puntero prev de "nuevo" le asignamos null tambien
            if (head == null)// Si la lista esta vacia, nuevo sera el primer nodo, por lo que sera tambien head and tail
            {
                head = nuevo;
                tail = nuevo;

            }
            else // si no esta vacia la lista
            {
                nuevo.Prev = tail;// el punteror prev de nuevo apuntara a tail
                tail.Next = nuevo;// el puntero next de tail apuntara a nuevo
                tail = nuevo;// ahora nuevo se convierte en tail
                nuevo.Next = null;// el puntero next apunta a null

            }

            current = tail;//----- el nodo current toma el ultimo valor ingresado, tail
            return true;

        }

        public string Ante()// --- para navegar al anterior
        {

            if (current.Prev == null)// si el valor asignado a current no tiene un elemento anterior messagebox
            {
                MessageBox.Show("No hay una página anterior.");
                return current.Navi;// retorna el valor de current.navi para evitar errores
            }

            current = current.Prev;// para al nodo anterior
            return current.Navi;// retorna el valor actualizdo de current

        }

        public string Sgte()
        {

            if (current.Next == null)// Si el valor no tiene un Next, salta messagebox
            {
                MessageBox.Show("No hay una página Siguiente.");
                return current.Navi;// retorn el valor actual para evitar errores

            }
            current = current.Next;// pasa al siguiente nodo
            return current.Navi;// retorna el valor actualizdo de current
        }

        public void listar(ListBox lista) // metodo listar
        {

            lista.Items.Clear();// limpia el listBox
            Nododoble actual = head;// empezamos por el inicio

            while (actual != null)// meintras no este vacio recorre la lista
            {
                lista.Items.Add(actual.Navi);// agrga los datos de encontrados
                actual = actual.Next;// pasa al siguiente nodo
            }
        }

        public bool delete(string url)
        {

            Nododoble temp = head;// creamos temp y lo ponemos al inicio para empezar a recorrer la lista

            while (temp != null)
            {
                if (temp.Navi == url)// comparamos el valor de temp con el ingresado en el String
                {

                    if (temp == head && temp == tail)//-- Si temp es igual a head y teal, quiere decir que hay un solo elemento en la lista, por lo que retorna la lista vacia
                    {
                        head = null;
                        tail = null;
                    }

                    else if (temp == head)// Si temp es igual al head
                    {
                        head = temp.Next;// acutalizamos el head al siguiente elemento
                        head.Prev = null;// el valor previo a head es null
                    }

                    else if (temp == tail)
                    {
                        tail = tail.Prev;// actualiuzamos el tail al valor previo
                        tail.Next = null;// eliminamos el puntero y va a null
                    }

                    else
                    {
                        temp.Prev.Next = temp.Next;// El next del anterior a temp ahora apunta al siguiente de temp
                        temp.Next.Prev = temp.Prev;// el  prev del siguiente de temp ahora apunta al anterior de temp

                    }
                    
                }

                temp = temp.Next;// sigue recorriendo la lista
            }

            return false;
        }


    }
}
