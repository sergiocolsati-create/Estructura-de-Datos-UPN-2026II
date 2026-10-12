// PASO 3 de 15 — No depende de nada
namespace Shalom
{
    // Misma clase para remitente y destinatario
    public class Persona
    {
        private int id;
        private string tipoDocumento;     // DNI, CE, RUC
        private string numeroDocumento;
        private string nombres;
        private string telefono;

        public int Id { get => id; set => id = value; }
        public string TipoDocumento { get => tipoDocumento; set => tipoDocumento = value; }
        public string NumeroDocumento { get => numeroDocumento; set => numeroDocumento = value; }
        public string Nombres { get => nombres; set => nombres = value; }
        public string Telefono { get => telefono; set => telefono = value; }

    }
}
