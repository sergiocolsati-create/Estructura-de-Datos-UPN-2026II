using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shalom
{
    // Un registro del historial: qué pasó, cuándo y dónde
    public class EventoRastreo
    {
        private DateTime fecha;
        private EstadoEnvio estado;
        private string ubicacion;
        private string observacion;
        private bool pendienteSincronizar;   // Reemplaza "Pendiente de sincronizar" como estado

        // Obliga a que todo evento nazca completo; la fecha se pone sola
        public EventoRastreo(EstadoEnvio estado, string ubicacion, string observacion)
        {
            fecha = DateTime.Now;
            this.estado = estado;
            this.ubicacion = ubicacion;
            this.observacion = observacion;
        }

        public DateTime Fecha { get => fecha; set => fecha = value; }
        public EstadoEnvio Estado { get => estado; set => estado = value; }
        public string Ubicacion { get => ubicacion; set => ubicacion = value; }
        public string Observacion { get => observacion; set => observacion = value; }
        public bool PendienteSincronizar { get => pendienteSincronizar; set => pendienteSincronizar = value; }
    }
}
