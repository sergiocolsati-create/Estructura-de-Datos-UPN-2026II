
using System;

namespace Shalom
{
    // Contiene los datos y las reglas principales de un envío.
    public class Envio
    {
        private static readonly Random aleatorio = new Random();

        // Identificación
        private int id;
        private string codigo;
        private string claveSeguridad;

        // Origen y destino
        private Sede sedeOrigen;
        private Sede sedeDestino;
        private Persona remitente;
        private Persona destinatario;

        // Datos del paquete
        private TipoPaquete tipo;
        private string descripcion;
        private decimal pesoKg;

        // Cobro
        private decimal precio;
        private ModalidadPago modalidadPago;

        // Fechas y estado
        private DateTime fechaRegistro;
        private EstadoEnvio estado;
        private DateTime fechaActualizacion;

        // Vehículo asignado
        private string placaVehiculo;

        // Historial de trazabilidad
        private ListaHistorial historial;

        public Envio()
        {
            fechaRegistro = DateTime.Now;
            fechaActualizacion = fechaRegistro;

            estado = EstadoEnvio.Registrado;
            claveSeguridad = aleatorio.Next(0, 10000).ToString("D4");

            historial = new ListaHistorial();
        }

        // Identificación
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public string ClaveSeguridad
        {
            get { return claveSeguridad; }
            set { claveSeguridad = value; }
        }

        // Origen y destino
        public Sede SedeOrigen
        {
            get { return sedeOrigen; }
            set { sedeOrigen = value; }
        }

        public Sede SedeDestino
        {
            get { return sedeDestino; }
            set { sedeDestino = value; }
        }

        public Persona Remitente
        {
            get { return remitente; }
            set { remitente = value; }
        }

        public Persona Destinatario
        {
            get { return destinatario; }
            set { destinatario = value; }
        }

        // Datos del paquete
        public TipoPaquete Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public decimal PesoKg
        {
            get { return pesoKg; }
            set { pesoKg = value; }
        }

        // Cobro
        public decimal Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        public ModalidadPago ModalidadPago
        {
            get { return modalidadPago; }
            set { modalidadPago = value; }
        }

        // Fechas y estado
        public DateTime FechaRegistro
        {
            get { return fechaRegistro; }
            set { fechaRegistro = value; }
        }

        public EstadoEnvio Estado
        {
            get { return estado; }
        }

        public DateTime FechaActualizacion
        {
            get { return fechaActualizacion; }
        }

        // Vehículo asignado
        public string PlacaVehiculo
        {
            get { return placaVehiculo; }
            set { placaVehiculo = value; }
        }

        // Historial de trazabilidad
        public ListaHistorial Historial
        {
            get { return historial; }
        }

        // El peso facturable corresponde al peso real del paquete.
        public decimal PesoFacturable
        {
            get { return pesoKg; }
        }

        // Genera el código después de obtener el ID de SQL Server.
        public void GenerarCodigo()
        {
            if (id <= 0)
                throw new InvalidOperationException(
                    "El envío debe tener un ID válido generado por SQL.");

            if (sedeOrigen == null || sedeDestino == null)
                throw new InvalidOperationException(
                    "Debe seleccionar las sedes de origen y destino.");

            codigo = sedeOrigen.Codigo + "-" +
                     sedeDestino.Codigo + "-" +
                     id.ToString("D6");
        }

        // Calcula el precio según la tarifa de SQL Server.
        public void CalcularPrecio(
            decimal precioBase, decimal precioPorKg)
        {
            if (precioBase < 0 || precioPorKg < 0)
                throw new ArgumentException(
                    "Los valores de la tarifa no pueden ser negativos.");

            precio = precioBase + PesoFacturable * precioPorKg;
            precio = Math.Round(precio, 2);
        }

        // Registra el cambio de estado y su evento de trazabilidad.
        public void CambiarEstado(
            EstadoEnvio nuevoEstado,
            string ubicacion,
            string observacion)
        {
            if (historial == null)
                historial = new ListaHistorial();

            estado = nuevoEstado;
            fechaActualizacion = DateTime.Now;

            historial.AgregarAlFinal(
                new EventoRastreo(
                    nuevoEstado,
                    ubicacion,
                    observacion));
        }

        // Carga el estado desde SQL sin duplicar eventos del historial.
        public void FijarEstadoDesdeSQL(
            EstadoEnvio estadoCargado,
            DateTime fechaCargada)
        {
            estado = estadoCargado;
            fechaActualizacion = fechaCargada;
        }

        // Devuelve una cadena vacía si los datos son válidos.
        public string Validar()
        {
            if (sedeOrigen == null || sedeDestino == null)
                return "Seleccione la sede de origen y destino.";

            if (sedeOrigen.Id == sedeDestino.Id)
                return "El origen y el destino no pueden ser la misma sede.";

            if (remitente == null ||
                string.IsNullOrWhiteSpace(remitente.NumeroDocumento))
                return "Ingrese los datos del remitente.";

            if (destinatario == null ||
                string.IsNullOrWhiteSpace(destinatario.NumeroDocumento))
                return "Ingrese los datos del destinatario.";

            if (pesoKg <= 0)
                return "El peso debe ser mayor que cero.";

            if (string.IsNullOrWhiteSpace(descripcion))
                return "Ingrese la descripción del contenido.";

            if (precio < 0)
                return "El precio no puede ser negativo.";

            return "";
        }
    }
}
