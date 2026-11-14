using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shalom
{
    // LISTA SIMPLE: historial de un envío. Solo crece al final (orden cronológico).
    public class ListaHistorial
    {
        private NodoEvento pri;
        private NodoEvento ulti;

        public ListaHistorial()
        {
            pri = null;
            ulti = null;
        }

        public void AgregarAlFinal(EventoRastreo evento)
        {
            NodoEvento nuevo = new NodoEvento();
            nuevo.Dato = evento;

            if (pri == null)
                pri = nuevo;
            else
                ulti.Sgte = nuevo;
            ulti = nuevo;
        }

        public bool TieneEvento(EstadoEnvio? estado, DateTime desde, DateTime hasta)
        {
            NodoEvento actual = pri;
            while (actual != null)
            {
                EventoRastreo ev = actual.Dato;

                bool coincideEstado = estado == null || ev.Estado == estado;
                bool dentroDelPeriodo = ev.Fecha >= desde && ev.Fecha < hasta;

                if (coincideEstado && dentroDelPeriodo)
                {
                    return true;
                }
                actual = actual.Sgte;
            }
            return false;
        }

        // Columnas: Fecha, Estado, Ubicación
        public void Mostrar(DataGridView tabla)
        {
            tabla.Rows.Clear();
            NodoEvento actual = pri;
            while (actual != null)
            {
                EventoRastreo e = actual.Dato;
                tabla.Rows.Add(e.Fecha.ToString("dd/MM/yyyy HH:mm"), ArbolEnvios.NombreEstadoLegible(e.Estado), e.Ubicacion);
                actual = actual.Sgte;
            }
        }
        // Una línea por evento, en orden cronológico
        public string ObtenerTexto()
        {
            string texto = "";
            NodoEvento actual = pri;
            while (actual != null)
            {
                EventoRastreo ev = actual.Dato;
                texto += ev.Fecha.ToString("dd/MM HH:mm") + " - " + ArbolEnvios.NombreEstadoLegible(ev.Estado) + " - " + ev.Ubicacion;
                if (!string.IsNullOrWhiteSpace(ev.Observacion))
                    texto += " - " + ev.Observacion;
                texto += Environment.NewLine;
                actual = actual.Sgte;
            }
            return texto;
        }
    }
}