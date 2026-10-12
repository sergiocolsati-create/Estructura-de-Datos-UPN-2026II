
using System;
using System.Windows.Forms;

namespace Shalom
{
    public class ColaEnvios
    {
        private NodoEnvio pri;
        private NodoEnvio ulti;
        private int cantidad;
        private int capacidad; // 0 = sin límite

        // Cola sin límite: recepción.
        public ColaEnvios()
        {
            pri = null;
            ulti = null;
            cantidad = 0;
            capacidad = 0;
        }

        // Cola con capacidad definida: almacén.
        public ColaEnvios(int capacidad)
        {
            if (capacidad <= 0)
                throw new ArgumentException(
                    "La capacidad debe ser mayor que cero.");

            pri = null;
            ulti = null;
            cantidad = 0;
            this.capacidad = capacidad;
        }

        public int Cantidad
        {
            get { return cantidad; }
        }

        public int Capacidad
        {
            get { return capacidad; }
        }

        public bool EstaVacia()
        {
            return pri == null;
        }

        // Inserta un envío al final de la cola.
        // Devuelve false si está llena.
        public bool Encolar(Envio envio)
        {
            if (envio == null)
                throw new ArgumentNullException(
                    nameof(envio), "El envío no puede ser nulo.");

            if (capacidad > 0 && cantidad >= capacidad)
                return false;

            NodoEnvio nuevo = new NodoEnvio();
            nuevo.Dato = envio;

            if (pri == null)
            {
                pri = nuevo;
                ulti = nuevo;
            }
            else
            {
                ulti.Sgte = nuevo;
                ulti = nuevo;
            }

            cantidad++;
            return true;
        }

        // Retira y devuelve el primer envío.
        // Devuelve null si la cola está vacía.
        public Envio Desencolar()
        {
            if (pri == null)
                return null;

            Envio envio = pri.Dato;

            pri = pri.Sgte;
            cantidad--;

            if (pri == null)
                ulti = null;

            return envio;
        }

        // Consulta el primer envío sin retirarlo.
        public Envio VerFrente()
        {
            if (pri == null)
                return null;

            return pri.Dato;
        }

        // Muestra los envíos en un DataGridView.
        // Columnas: Turno, Guía, Cliente, Destino, Peso y Hora.
        public void Mostrar(DataGridView tabla)
        {
            if (tabla == null)
                throw new ArgumentNullException(nameof(tabla));

            tabla.Rows.Clear();

            // Crea las columnas si todavía no existen.
            if (tabla.Columns.Count == 0)
            {
                tabla.Columns.Add("colTurno", "Turno");
                tabla.Columns.Add("colGuia", "Guía");
                tabla.Columns.Add("colCliente", "Cliente");
                tabla.Columns.Add("colDestino", "Destino");
                tabla.Columns.Add("colPeso", "Peso (kg)");
                tabla.Columns.Add("colHora", "Última actualización");
            }

            int orden = 1;
            NodoEnvio actual = pri;

            while (actual != null)
            {
                Envio e = actual.Dato;

                string cliente = e.Remitente != null
                    ? e.Remitente.Nombres
                    : "Sin remitente";

                string destino = e.SedeDestino != null
                    ? e.SedeDestino.Codigo
                    : "Sin destino";

                tabla.Rows.Add(
                    orden,
                    e.Codigo,
                    cliente,
                    destino,
                    e.PesoKg,
                    e.FechaActualizacion.ToString("dd/MM/yyyy HH:mm")
                );

                orden++;
                actual = actual.Sgte;
            }
        }
    }
}
