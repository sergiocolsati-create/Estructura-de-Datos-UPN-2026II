using System.Windows.Forms;

namespace Lab06
{
    internal class ArbolBinBusq
    {
        private Nodo raiz;

        public ArbolBinBusq()
        {
            raiz = null;
        }

        public void insertar(int dato)
        {
            raiz = insertar(raiz, dato);
        }

        private Nodo insertar(Nodo actual, int dato)
        {
            if (actual == null)
            {
                Nodo nuevo = new Nodo();
                nuevo.Dato = dato;
                nuevo.Hijoizquierdo = null;
                nuevo.Hijoderecho = null;
                return nuevo;
            }

            if (dato < actual.Dato)
            {
                actual.Hijoizquierdo = insertar(actual.Hijoizquierdo, dato);
            }
            else if (dato > actual.Dato)
            {
                actual.Hijoderecho = insertar(actual.Hijoderecho, dato);
            }

            return actual;
        }

        public bool buscar(int dato)
        {
            return buscar(raiz, dato);
        }

        private bool buscar(Nodo actual, int dato)
        {
            if (actual == null)
            {
                return false;
            }

            if (dato == actual.Dato)
            {
                return true;
            }
            else if (dato < actual.Dato)
            {
                return buscar(actual.Hijoizquierdo, dato);
            }
            else
            {
                return buscar(actual.Hijoderecho, dato);
            }
        }

        public bool eliminar(int dato)
        {
            if (!buscar(dato))
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

            if (dato < actual.Dato)
            {
                actual.Hijoizquierdo = eliminar(actual.Hijoizquierdo, dato);
            }
            else if (dato > actual.Dato)
            {
                actual.Hijoderecho = eliminar(actual.Hijoderecho, dato);
            }
            else
            {
                // Si no tiene hijo izquierdo, lo reemplaza el derecho.
                // Si tampoco tiene derecho, devuelve null.
                if (actual.Hijoizquierdo == null)
                {
                    return actual.Hijoderecho;
                }

                // Si solo tiene hijo izquierdo, lo reemplaza ese hijo.
                if (actual.Hijoderecho == null)
                {
                    return actual.Hijoizquierdo;
                }

                // Si tiene dos hijos, buscamos el menor del lado derecho.
                Nodo menor = actual.Hijoderecho;

                while (menor.Hijoizquierdo != null)
                {
                    menor = menor.Hijoizquierdo;
                }

                actual.Dato = menor.Dato;
                actual.Hijoderecho = eliminar(
                    actual.Hijoderecho, menor.Dato
                );
            }

            return actual;
        }

        // CAMBIO: recorrido InOrden separado.
        public void InOrden(ListBox lista)
        {
            InOrden(raiz, lista);
        }

        private void InOrden(Nodo actual, ListBox lista)
        {
            if (actual != null)
            {
                InOrden(actual.Hijoizquierdo, lista);
                lista.Items.Add(actual.Dato);
                InOrden(actual.Hijoderecho, lista);
            }
        }

        // NUEVO: recorrido PreOrden.
        public void PreOrden(ListBox lista)
        {
            PreOrden(raiz, lista);
        }

        private void PreOrden(Nodo actual, ListBox lista)
        {
            if (actual != null)
            {
                lista.Items.Add(actual.Dato);
                PreOrden(actual.Hijoizquierdo, lista);
                PreOrden(actual.Hijoderecho, lista);
            }
        }

        // NUEVO: recorrido PostOrden (izquierdo, derecho, raiz).
        public void PostOrden(ListBox lista)
        {
            PostOrden(raiz, lista);
        }

        private void PostOrden(Nodo actual, ListBox lista)
        {
            if (actual != null)
            {
                PostOrden(actual.Hijoizquierdo, lista);
                PostOrden(actual.Hijoderecho, lista);
                lista.Items.Add(actual.Dato);
            }
        }

        public int Contador()
        {
            return Contador(raiz);
        }

        private int Contador(Nodo actual)
        {
            if (actual == null)
            {
                return 0;
            }

            return 1
                + Contador(actual.Hijoizquierdo)
                + Contador(actual.Hijoderecho);
        }
    }
}