using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab06
{
    internal class ArbolBinBusq
    {
        private Nodo raiz;

        private ArbolBinBusq() {

            raiz = null;
        }

        public void insertar(int dato) {
        
        raiz=insertar(raiz,dato);
        
        
        }

        private Nodo insertar(Nodo actual, int dato)
        {
            if (actual == null) // llegamos a un lugar vacío, aquí va el nuevo nodo
            {
                Nodo nuevo = new Nodo();
                nuevo.Dato = dato;
                nuevo.Hijoizquierdo = null;
                nuevo.Hijoderecho = null;
                return nuevo;
            }

            if (dato < actual.Dato) // si es menor, va por la izquierda
            {
                actual.Hijoizquierdo = insertar(actual.Hijoizquierdo, dato);
            }
            else if (dato > actual.Dato) // si es mayor, va por la derecha
            {
                actual.Hijoderecho = insertar(actual.Hijoderecho, dato);
            }
            // si es igual no se inserta (no se permiten repetidos)

            return actual; // devolvemos el nodo para no perder los enlaces
        }

        public bool buscar(int dato)
        {
            return buscar(raiz, dato);
        }
        private bool buscar(Nodo actual, int dato)
        {
            if (actual == null) // llegamos a null, no existe
            {
                return false;
            }

            if (dato == actual.Dato) // lo encontramos
            {
                return true;
            }
            else if (dato < actual.Dato) // si es menor, buscamos por la izquierda
            {
                return buscar(actual.Hijoizquierdo, dato);
            }
            else // si es mayor, buscamos por la derecha
            {
                return buscar(actual.Hijoderecho, dato);
            }
        }

        public bool eliminar(int dato)
        {
            if (!buscar(dato)) // si no existe no hay nada que eliminar
            {
                return false;
            }
            raiz = eliminar(raiz, dato);
            return true;
        }

        private Nodo eliminar(Nodo actual, int dato)
        {
            if (actual == null)
            {
                return null;
            }

            if (dato < actual.Dato) // está a la izquierda
            {
                actual.Hijoizquierdo = eliminar(actual.Hijoizquierdo, dato);
            }
            else if (dato > actual.Dato) // está a la derecha
            {
                actual.Hijoderecho = eliminar(actual.Hijoderecho, dato);
            }
            else // lo encontramos
            {
                // Caso 1 y 2: no tiene hijo izquierdo, lo reemplaza su hijo derecho (o null si es hoja)
                if (actual.Hijoizquierdo == null)
                {
                    return actual.Hijoderecho;
                }
                // Caso 2: no tiene hijo derecho, lo reemplaza su hijo izquierdo
                if (actual.Hijoderecho == null)
                {
                    return actual.Hijoizquierdo;
                }

                // Caso 3: tiene dos hijos
                // buscamos el menor del lado derecho (el sucesor)
                Nodo menor = actual.Hijoderecho;
                while (menor.Hijoizquierdo != null)
                {
                    menor = menor.Hijoizquierdo;
                }

                actual.Dato = menor.Dato; // copiamos el dato del sucesor
                actual.Hijoderecho = eliminar(actual.Hijoderecho, menor.Dato); // eliminamos el sucesor de la derecha
            }

            return actual;
        }

        public void VerArbol(ListBox lista)
        {
            InOrden(raiz, lista);
        }
        private void InOrden(Nodo actual, ListBox lista)
        {
            if (actual != null)
            {
                InOrden(actual.Hijoizquierdo, lista); // primero la izquierda
                lista.Items.Add(actual.Dato);         // luego el nodo
                InOrden(actual.Hijoderecho, lista);   // al final la derecha
            }
        }

        public int Contador()
        {
            return Contador(raiz); // empezamos desde la raíz
        }

        private int Contador(Nodo actual)
        {
            if (actual == null) // no hay nodo, no suma nada
            {
                return 0;
            }

            return 1 + Contador(actual.Hijoizquierdo) + Contador(actual.Hijoderecho);
        }
    }
}
