using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana05
{
    internal class ListaCircularR
    {

        private Nodoreloj head;
        private Nodoreloj tail;
        private Nodoreloj actual;

        public ListaCircularR()
        {

            head = null;
            tail = null;


        }

        public bool InsertarFinal(int value)
        {

            Nodoreloj nuevo = new Nodoreloj();
            nuevo.Time = value;

            if (head == null)
            {
                head = nuevo;
                tail = nuevo;
                head.Sgte = tail;
                tail.Ante = head;

            }
            else
            {
                tail.Sgte = nuevo;
                nuevo.Ante = tail;
                tail = nuevo;
                tail.Sgte = head;
                head.Ante = tail;

            }

            return true;



        }

        public void ContruirReloj(int ciclo)
        {
            int contador = 0;

            while (contador < ciclo)
            {
                InsertarFinal(contador);
                contador++;
            }

            actual = head;

        }

        public int AvanzarActual()
        {
            actual = actual.Sgte;
            return actual.Time;

        }
        public int RetrocederActual()
        {
            actual = actual.Ante;
            return actual.Time;
        }


        public int ObtenerActual()
        {

            return actual.Time;

        }

        public void Sincronizar(int valor)
        {
            while (actual.Time != valor)
            {
                actual = actual.Sgte;
            }


        }



    }
}
