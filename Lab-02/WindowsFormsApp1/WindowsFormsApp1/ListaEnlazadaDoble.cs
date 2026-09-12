using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{

    internal class ListaDoble
    {
        private Nodo pri;
        private Nodo ulti;

        public ListaDoble()
        {
            pri = null;
            ulti = null;
        }

       
        public bool buscarElemento(int valor)
        {
            Nodo actual = pri;

            while (actual != null)
            {
                if (actual.Dato == valor)
                {
                    return true;
                }

                actual = actual.Sgte;
            }

            return false;
        }

        
        public bool insertar(int valor)
        {
            if (buscarElemento(valor))
            {
                MessageBox.Show("El valor ya está registrado.");
                return false;
            }

            Nodo nuevo = new Nodo();
            nuevo.Dato = valor;
            nuevo.Anterior = null;
            nuevo.Sgte = null;

            if (pri == null)
            {
                pri = nuevo;
                ulti = nuevo;
            }
            else
            {
                nuevo.Anterior = ulti;
                ulti.Sgte = nuevo;
                ulti = nuevo;
            }

            return true;
        }

        public bool agregarAlFinal(int valor)
        {
            return insertar(valor);
        }

        
        public bool agregarAlInicio(int valor)
        {
            if (buscarElemento(valor))
            {
                MessageBox.Show("El valor ya está registrado.");
                return false;
            }

            Nodo nuevo = new Nodo();
            nuevo.Dato = valor;
            nuevo.Anterior = null;
            nuevo.Sgte = null;

            if (pri == null)
            {
                pri = nuevo;
                ulti = nuevo;
            }
            else
            {
                nuevo.Sgte = pri;
                pri.Anterior = nuevo;
                pri = nuevo;
            }

            return true;
        }
        public bool eliminar(int valor)
        {
            Nodo actual = pri;

            while (actual != null)
            {
                if (actual.Dato == valor)
                {
                    
                    if (actual == pri && actual == ulti)
                    {
                        pri = null;
                        ulti = null;
                    }
                   
                    else if (actual == pri)
                    {
                        pri = actual.Sgte;
                        pri.Anterior = null;
                    }
                    
                    else if (actual == ulti)
                    {
                        ulti = actual.Anterior;
                        ulti.Sgte = null;
                    }
                    
                    else
                    {
                        actual.Anterior.Sgte = actual.Sgte;
                        actual.Sgte.Anterior = actual.Anterior;
                    }

                    return true;
                }

                actual = actual.Sgte;
            }

            return false;
        }

      
        public void imprimirAdelante(ListBox lista)
        {
            lista.Items.Clear();
            Nodo actual = pri;

            while (actual != null)
            {
                lista.Items.Add(actual.Dato);
                actual = actual.Sgte;
            }
        }

       
        public void imprimirAtras(ListBox lista)
        {
            lista.Items.Clear();
            Nodo actual = ulti;

            while (actual != null)
            {
                lista.Items.Add(actual.Dato);
                actual = actual.Anterior;
            }
        }

        
        public bool verLista(ListBox lista)
        {
            imprimirAdelante(lista);
            return pri != null;
        }

       
        public bool modificar(int dato, int dato2)
        {
            Nodo actual = pri;

            while (actual != null)
            {
                if (actual.Dato == dato)
                {
                    if (dato != dato2 && buscarElemento(dato2))
                    {
                        MessageBox.Show("El nuevo valor ya está registrado.");
                        return false;
                    }

                    actual.Dato = dato2;
                    return true;
                }

                actual = actual.Sgte;
            }

            return false;
        }

       
        public void contador()
        {
            int cantidad = 0;
            Nodo actual = pri;

            while (actual != null)
            {
                cantidad++;
                actual = actual.Sgte;
            }

            MessageBox.Show("Cantidad de nodos: " + cantidad);
        }
    }
}
