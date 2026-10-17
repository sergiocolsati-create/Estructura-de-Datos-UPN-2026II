using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shalom
{
    // ÁRBOL BINARIO DE BÚSQUEDA: registro general de TODOS los envíos.
    // Un envío entra al registrarse y ya no se borra (sirve para Rastreo y el Panel).
    // La clave de comparación es el código del envío (texto).
    public class ArbolEnvios
    {
        private NodoArbol raiz;

        public bool EstaVacio()
        {
            return raiz == null;
        }

        public bool Insertar(Envio envio)
        {
            NodoArbol nuevo = new NodoArbol();
            nuevo.Dato = envio;

            if (raiz == null)
            {
                raiz = nuevo;
                return true;
            }

            NodoArbol actual = raiz;
            while (true)
            {
                int comparacion = string.Compare(envio.Codigo, actual.Dato.Codigo);

                if (comparacion == 0)
                    return false;   // código repetido

                if (comparacion < 0)
                {
                    if (actual.Izquierdo == null) { actual.Izquierdo = nuevo; return true; }
                    actual = actual.Izquierdo;
                }
                else
                {
                    if (actual.Derecho == null) { actual.Derecho = nuevo; return true; }
                    actual = actual.Derecho;
                }
            }
        }

        public Envio Buscar(string codigo)
        {
            NodoArbol actual = raiz;
            while (actual != null)
            {
                int comparacion = string.Compare(codigo, actual.Dato.Codigo);
                if (comparacion == 0)
                    return actual.Dato;

                if (comparacion < 0)
                    actual = actual.Izquierdo;
                else
                    actual = actual.Derecho;
            }
            return null;   // no se encontró
        }

        // Para los contadores del Panel principal (cuántos envíos hay en cada estado).
        public int Contar(EstadoEnvio estado)
        {
            return ContarNodo(raiz, estado);
        }

        private int ContarNodo(NodoArbol nodo, EstadoEnvio estado)
        {
            if (nodo == null)
                return 0;

            int propio = 0;
            if (nodo.Dato.Estado == estado)
                propio = 1;

            return propio + ContarNodo(nodo.Izquierdo, estado) + ContarNodo(nodo.Derecho, estado);
        }

        // Recorrido InOrden: muestra los envíos ordenados por código.
        // filtro = null muestra todos; si no, solo los que tengan ese estado.
        // Columnas: Guía, Cliente, Destino, Estado, Actualización
        public void Mostrar(DataGridView tabla, EstadoEnvio? filtro)
        {
            tabla.Rows.Clear();
            InOrden(raiz, tabla, filtro);
        }

        public static string NombreCliente(Envio e)
        {
            if (e.Remitente != null) return e.Remitente.Nombres;
            return "";
        }

        public static string NombreDestino(Envio e)
        {
            if (e.SedeDestino != null) return e.SedeDestino.Nombre;
            return "";
        }

        public static void AgregarFila(DataGridView tabla, Envio e)
        {
            tabla.Rows.Add(e.Codigo, NombreCliente(e), NombreDestino(e), NombreEstadoLegible(e.Estado), e.FechaActualizacion.ToString("dd/MM/yyyy HH:mm"));
        }

        private void InOrden(NodoArbol nodo, DataGridView tabla, EstadoEnvio? filtro)
        {
            if (nodo == null)
                return;

            InOrden(nodo.Izquierdo, tabla, filtro);

            Envio e = nodo.Dato;
            if (filtro == null || e.Estado == filtro)
            {
                AgregarFila(tabla, e);
            }

            InOrden(nodo.Derecho, tabla, filtro);
        }

        public List<Envio> ObtenerTodos()
        {
            List<Envio> lista = new List<Envio>();
            InOrdenLista(raiz, lista);
            return lista;
        }

        public static string NombreEstadoLegible(EstadoEnvio estado)
        {
            switch (estado)
            {
                case EstadoEnvio.Registrado: return "Registrado";
                case EstadoEnvio.EnPreparacion: return "En Preparación";
                case EstadoEnvio.EnTransito: return "En Tránsito";
                case EstadoEnvio.EnReparto: return "En Reparto";
                case EstadoEnvio.Entregado: return "Entregado";
                case EstadoEnvio.Incidencia: return "Incidencia";
                default: return estado.ToString();
            }
        }

        private void InOrdenLista(NodoArbol nodo, List<Envio> lista)
        {
            if (nodo == null) return;
            InOrdenLista(nodo.Izquierdo, lista);
            lista.Add(nodo.Dato);
            InOrdenLista(nodo.Derecho, lista);
        }
    }
}
