using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shalom
{
    // LISTA DOBLE: ruta de reparto del vehículo (igual que "Enlazadadoble" de clase,
    // pero cada nodo guarda un Envio en vez de un número).
    public class ListaRuta
    {
        private NodoParada pri;
        private NodoParada ulti;

        public ListaRuta()
        {
            pri = null;
            ulti = null;
        }

        public bool EstaVacia()
        {
            return pri == null;
        }

        public int ContarParadas()
        {
            int contador = 0;
            NodoParada actual = pri;
            while (actual != null)
            {
                contador++;
                actual = actual.Sgte;
            }
            return contador;
        }

        private NodoParada Buscar(string codigo)
        {
            NodoParada actual = pri;
            while (actual != null)
            {
                if (actual.Dato.Codigo == codigo)
                    return actual;
                actual = actual.Sgte;
            }
            return null;
        }

        // Vuelve a numerar 1, 2, 3... después de cualquier cambio en la lista.
        private void ActualizarOrdenes()
        {
            int orden = 1;
            NodoParada actual = pri;
            while (actual != null)
            {
                actual.Orden = orden;
                orden++;
                actual = actual.Sgte;
            }
        }

        // Agrega una nueva parada al final de la ruta.
        public bool AgregarAlFinal(Envio envio)
        {
            if (Buscar(envio.Codigo) != null)
                return false;   // ya está en la ruta

            NodoParada nuevo = new NodoParada();
            nuevo.Dato = envio;

            if (pri == null)
            {
                pri = nuevo;
            }
            else
            {
                ulti.Sgte = nuevo;
                nuevo.Ante = ulti;
            }
            ulti = nuevo;

            ActualizarOrdenes();
            return true;
        }

        // Inserta una parada nueva justo después de la parada con guía "codigoReferencia".
        public bool InsertarDespues(string codigoReferencia, Envio envio)
        {
            NodoParada actual = Buscar(codigoReferencia);
            if (actual == null || Buscar(envio.Codigo) != null)
                return false;

            NodoParada nuevo = new NodoParada();
            nuevo.Dato = envio;
            nuevo.Ante = actual;
            nuevo.Sgte = actual.Sgte;

            if (actual.Sgte != null)
                actual.Sgte.Ante = nuevo;
            else
                ulti = nuevo;   // se insertó al final

            actual.Sgte = nuevo;

            ActualizarOrdenes();
            return true;
        }

        // Quita la parada con esa guía y vuelve a enlazar a sus vecinos.
        public bool EliminarParada(string codigo)
        {
            NodoParada actual = Buscar(codigo);
            if (actual == null)
                return false;

            if (actual.Ante != null)
                actual.Ante.Sgte = actual.Sgte;
            else
                pri = actual.Sgte;   // era la cabeza

            if (actual.Sgte != null)
                actual.Sgte.Ante = actual.Ante;
            else
                ulti = actual.Ante;  // era la cola

            ActualizarOrdenes();
            return true;
        }

        // Dice si ya existe una parada con esa guía en la ruta.
        public bool Contiene(string codigo)
        {
            return Buscar(codigo) != null;
        }

        // Aplica el mismo estado a todas las paradas (botón "Confirmar ruta").
        public void CambiarEstadoTodas(EstadoEnvio estado, string ubicacion, string observacion)
        {
            NodoParada actual = pri;
            while (actual != null)
            {
                actual.Dato.CambiarEstado(estado, ubicacion, observacion);
                actual = actual.Sgte;
            }
        }

        // Columnas: Orden, Guía, Destino, Siguiente
        public void Mostrar(DataGridView tabla)
        {
            tabla.Rows.Clear();
            NodoParada actual = pri;
            while (actual != null)
            {
                string destino = "";
                if (actual.Dato.SedeDestino != null) destino = actual.Dato.SedeDestino.Nombre;

                string siguiente = "NULL (Fin)";
                if (actual.Sgte != null) siguiente = actual.Sgte.Dato.Codigo;

                tabla.Rows.Add(actual.Orden, actual.Dato.Codigo, destino, siguiente);
                actual = actual.Sgte;
            }
        }

        // Devuelve el texto de cada parada en orden 
        // para pintar la cadena visual de botones.
        public string[] ObtenerTextos()
        {
            string[] textos = new string[ContarParadas()];
            int i = 0;
            NodoParada actual = pri;
            while (actual != null)
            {
                textos[i] = "P" + actual.Orden + "." + actual.Dato.Codigo;
                i++;
                actual = actual.Sgte;
            }
            return textos;
        }
        public Envio[] ObtenerEnvios()
        {
            Envio[] envios = new Envio[ContarParadas()];
            int i = 0;
            NodoParada actual = pri;
            while (actual != null)
            {
                envios[i] = actual.Dato;
                i++;
                actual = actual.Sgte;
            }
            return envios;
        }
    }
}
