using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shalom
{
    // Estados del envío y estructura donde se encuentra en cada uno
    public enum EstadoEnvio
    {
        Registrado,      // Cola de recepción
        EnPreparacion,   // Cola de almacén
        EnTransito,      // Pila del vehículo
        EnReparto,       // Ruta del vehículo
        Entregado,       // Solo en el árbol
        Incidencia
    }

    public enum TipoPaquete { Sobre, Caja }

    public enum ModalidadPago { PagadoEnOrigen, PorCobrarEnDestino }
}
