using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Semana05
{
    internal class Listaenlazadacircular
    {
        private Nodo head;
        private Nodo tail;

        public Listaenlazadacircular()
        {

            head = null;
            tail = null;

        }
        public bool insertarfinal(int value)
        {

            Nodo nuevo = new Nodo();
            nuevo.Dato = value;

            if (head == null)
            {
                head = nuevo;
                tail = nuevo;
                tail.Next = head;
                head.Prev = tail;
            }
            else
            {
                nuevo.Prev = tail;
                tail.Next = nuevo;
                tail = nuevo;
                tail.Next = head;
                head.Prev = tail;

            }
            return true;

        }

        public bool insertarinicio(int value)
        {

            Nodo nuevo = new Nodo();
            nuevo.Dato = value;

            if (head == null)
            {
                head = nuevo;
                tail = nuevo;
                tail.Next = head;
                head.Prev = tail;
            }
            else
            {
                nuevo.Next = head;
                head.Prev = nuevo;
                head = nuevo;
                head.Prev = tail;
                tail.Next = head;

            }
            return true;

        }

        public bool search(int value)
        {
            Nodo actual = head;
            do
            {
                if (head == null)
                {
                    return false;
                }
                if (actual.Dato == value)
                {
                    return true;
                }

                actual = actual.Next;

            } while (actual != head);
            return false;


        }


        public bool listar(ListBox list)
        {
            if (head == null && tail == null) {
                MessageBox.Show("No hay elementos que listar");
                return false;
            }
            Nodo actual = head;
            do
            {
                list.Items.Add(actual.Dato);

                actual = actual.Next;

            } while (actual != head);
            return false;

        }







        public bool delete(int value)
        {
            if (head == null && tail == null)
            {
                
                return false;
            }
            Nodo actual = head;

            do
            {
                if (actual.Dato == value)
                {

                    if(head==tail)
                    {
                        head = null;
                        tail = null;
                        return true;
                    }

                    else if (actual == head)
                    {

                        tail.Next=actual.Next;
                        actual.Next.Prev = tail;
                        head = head.Next;

                        return true;
                    }
                    else if (actual == tail)
                    {
                        head.Prev = actual.Prev;
                        actual.Prev.Next = head;
                        tail = tail.Prev;
                        
                        return true;
                    }
                    else
                    {
                        actual.Next.Prev = actual.Prev;
                        actual.Prev.Next = actual.Next;
                        return true;
                    }
                }

                actual = actual.Next;
            } while (actual != head);

                return false;
        }

        public bool edit(int valor1, int valor2)
        {
            if (head == null && tail == null)
            {
                
                return false;
            }

            Nodo actual = head;

            do

            {
                if (actual.Dato == valor1)
                {
                    actual.Dato = valor2;
                    return true;
                }

                actual = actual.Next;

            } while (actual != head);
            return false;

        }



    }

}

