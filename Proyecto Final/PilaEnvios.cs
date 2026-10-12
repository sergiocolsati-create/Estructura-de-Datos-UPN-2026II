using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shalom
{
    // PILA (LIFO): carga del vehículo. Entra y sale por el tope (pri).
    // Mismo esquema que vimos en clase (apilar/desapilar/listar/contar/buscar),
    // solo que aquí el dato guardado es un Envio en vez de un número.
    public class PilaEnvios
    {
        private NodoEnvio pri;
        private decimal capacidadKg;
        private decimal pesoActual;
  

        public PilaEnvios(decimal capacidadKg)
        {
            pri = null;
            this.capacidadKg = capacidadKg;
            pesoActual = 0;
        }

        public decimal PesoActual { get => pesoActual; }
        public decimal CapacidadKg { get => capacidadKg; }

 

        public bool EstaVacia()
        {
            return pri == null;
        }

        // Devuelve true si se pudo apilar; false si se pasa de la capacidad del vehículo.
        public bool Apilar(Envio envio)
        {
            if (pesoActual + envio.PesoKg > capacidadKg)
                return false;

            NodoEnvio nuevo = new NodoEnvio();
            nuevo.Dato = envio;
            nuevo.Sgte = pri;
            pri = nuevo;

            pesoActual = pesoActual + envio.PesoKg;
            return true;
        }

        // Saca el envío del tope. Devuelve null si la pila está vacía.
        public Envio Desapilar()
        {
            if (pri == null)
                return null;

            Envio envio = pri.Dato;
            pri = pri.Sgte;
            pesoActual = pesoActual - envio.PesoKg;
            return envio;
        }

        // Solo mira el tope, no lo saca.
        public Envio VerTope()
        {
            if (pri == null)
                return null;
            return pri.Dato;
        }

        public bool Buscar(string codigo)
        {
            NodoEnvio actual = pri;
            while (actual != null)
            {
                if (actual.Dato.Codigo == codigo)
                    return true;
                actual = actual.Sgte;
            }
            return false;
        }

        public int Contar()
        {
            int contador = 0;
            NodoEnvio actual = pri;
            while (actual != null)
            {
                contador++;
                actual = actual.Sgte;
            }
            return contador;
        }

        // Devuelve todos los envíos de la pila, del tope hacia la base.
        public Envio[] ObtenerTodos()
        {
            Envio[] resultado = new Envio[Contar()];
            int i = 0;
            NodoEnvio actual = pri;
            while (actual != null)
            {
                resultado[i] = actual.Dato;
                i++;
                actual = actual.Sgte;
            }
            return resultado;
        }

        // Del tope (sale primero) hacia la base (se cargó primero).
        public void Listar(ListBox lista)
        {
            lista.Items.Clear();
            NodoEnvio actual = pri;
            while (actual != null)
            {
                lista.Items.Add(actual.Dato.Codigo + " | " + actual.Dato.PesoKg + " kg");
                actual = actual.Sgte;
            }
        }
    }
}
