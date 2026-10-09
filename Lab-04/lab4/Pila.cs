using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab4
{
    internal class Pila<T>
    {
        private Nodo<T> pri;

        public Pila()
        {
            pri = null;
        }

        public void push(T valor)
        {
            Nodo<T> nuevo = new Nodo<T>();
            nuevo.Dato = valor;
            nuevo.Sgte = pri;
            pri = nuevo;
        }

        // Ahora pop devuelve el elemento que saca
        public T pop()
        {
            if (isEmpty())
            {
                MessageBox.Show("La pila está vacía");
                return default(T);
            }

            T valor = pri.Dato;
            pri = pri.Sgte;
            return valor;
        }

        public bool isEmpty()
        {
            return pri == null;
        }

        public T Top()
        {
            if (isEmpty())

                MessageBox.Show("La pila está vacía");
            return pri.Dato;


            
        }

        public bool listar(ListBox lista)
        {
            lista.Items.Clear();

            if (isEmpty())
            {
                MessageBox.Show("La pila está vacía");
                return false;
            }

            Nodo<T> actual = pri;

            while (actual != null)
            {
                lista.Items.Add(actual.Dato);
                actual = actual.Sgte;
            }

            return true;
        }

        public void clear()
        {
            pri = null;
        }
    }
}