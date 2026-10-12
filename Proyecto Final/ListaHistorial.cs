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

        // Columnas: Fecha, Estado, Ubicación
        public void Mostrar(DataGridView tabla)
        {
            tabla.Rows.Clear();
            NodoEvento actual = pri;
            while (actual != null)
            {
                EventoRastreo e = actual.Dato;
                tabla.Rows.Add(e.Fecha.ToString("dd/MM/yyyy HH:mm"), e.Estado, e.Ubicacion);
                actual = actual.Sgte;
            }
        }
    }
}