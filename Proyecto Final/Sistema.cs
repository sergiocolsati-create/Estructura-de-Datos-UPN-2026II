using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Shalom
{
    // CLASE SISTEMA
    // Es el "centro" del programa. Es estática: existe una sola en toda la aplicación
    // y todos los formularios la usan sin crearla (Sistema.Recepcion, Sistema.RegistrarEnvio...).
    //
    // Hace tres cosas:
    //   1. Guarda las estructuras de datos en memoria (colas, árbol, vehículos con su pila y ruta).
    //   2. Al iniciar, carga esas estructuras con lo que hay en SQL Server.
    //   3. Cada vez que algo cambia, lo guarda en SQL Server y actualiza las estructuras.
    //
    // Los formularios NO hablan con la base de datos: siempre pasan por aquí.
    internal static class Sistema
    {
        // =========================================================
        //  CONEXIÓN A SQL SERVER
        // =========================================================

        // Dirección de la base de datos. Si en otra PC el servidor se llama distinto
        // (por ejemplo localhost\SQLEXPRESS), se cambia aquí. Se ve en SSMS → Conectar.
        private static readonly string cadenaConexion =
            @"Data Source=ANGGIE\SQLEXPRESS;Initial Catalog=ShalomDB_Final;Integrated Security=True;";

        // Crea una conexión nueva. Cada método la abre, la usa y la cierra
        // (el "using" la cierra solo al terminar, aunque haya un error).
        public static SqlConnection CrearConexion()
        {
            return new SqlConnection(cadenaConexion);
        }

        // =========================================================
        //  ESTRUCTURAS DE DATOS (en memoria)
        // =========================================================

        public static ColaEnvios Recepcion = new ColaEnvios();     // COLA: envíos recién registrados (FIFO)
        public static ColaEnvios Almacen = new ColaEnvios(50);     // COLA: envíos en almacén, máximo 50
        public static ArbolEnvios Registro = new ArbolEnvios();    // ÁRBOL: TODOS los envíos, para buscar por guía rápido

        // =========================================================
        //  CATÁLOGOS (datos fijos que se leen de la base)
        // =========================================================

        public static Sede[] Sedes = new Sede[0];             // Lima, Arequipa, Trujillo, Cusco...
        public static Vehiculo[] Vehiculos = new Vehiculo[0]; // Cada vehículo tiene su PILA (Carga) y su LISTA (Ruta)

        // Recorre el arreglo de sedes y devuelve la que tiene ese Id (o null si no existe)
        public static Sede BuscarSedePorId(int id)
        {
            for (int i = 0; i < Sedes.Length; i++)
            {
                if (Sedes[i].Id == id)
                    return Sedes[i];
            }

            return null;
        }

        // Recorre el arreglo de vehículos y devuelve el que tiene esa placa (o null)
        public static Vehiculo BuscarVehiculoPorPlaca(string placa)
        {
            if (string.IsNullOrWhiteSpace(placa))
                return null;

            for (int i = 0; i < Vehiculos.Length; i++)
            {
                if (Vehiculos[i].Placa == placa)
                    return Vehiculos[i];
            }

            return null;
        }

        // =========================================================
        //  CARGA INICIAL: SQL SERVER → ESTRUCTURAS
        //  Se ejecuta al abrir el programa. Lee las tablas y coloca
        //  cada envío en la estructura que le corresponde según su estado.
        // =========================================================

        // Método principal de carga. El orden importa: primero sedes, vehículos y personas,
        // porque los envíos los necesitan para armarse.
        public static void CargarDatosSQL()
        {
            // Se crean estructuras vacías para no duplicar datos si se carga dos veces
            Recepcion = new ColaEnvios();
            Almacen = new ColaEnvios(50);
            Registro = new ArbolEnvios();

            using (SqlConnection conexion = CrearConexion())
            {
                conexion.Open();

                CargarSedes(conexion);
                CargarVehiculos(conexion);

                List<Persona> personas = CargarPersonas(conexion);
                List<Envio> envios = CargarEnvios(conexion, personas);

                CargarHistorial(conexion, envios);   // Eventos de rastreo de cada envío
                CargarParadas(conexion, envios);     // Rutas de los vehículos
            }
        }

        // Lee la tabla Sede y llena el arreglo Sedes
        private static void CargarSedes(SqlConnection conexion)
        {
            List<Sede> lista = new List<Sede>();

            string consulta =
                "SELECT Id, Codigo, Nombre, Ciudad, Direccion " +
                "FROM Sede ORDER BY Id";

            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            using (SqlDataReader lector = comando.ExecuteReader())
            {
                while (lector.Read())   // Una vuelta por cada fila de la tabla
                {
                    Sede sede = new Sede();

                    sede.Id = Convert.ToInt32(lector["Id"]);
                    sede.Codigo = lector["Codigo"].ToString();
                    sede.Nombre = lector["Nombre"].ToString();
                    sede.Ciudad = lector["Ciudad"].ToString();

                    // DBNull = la celda está vacía (NULL) en SQL; en C# se usa ""
                    sede.Direccion =
                        lector["Direccion"] == DBNull.Value
                            ? ""
                            : lector["Direccion"].ToString();

                    lista.Add(sede);
                }
            }

            Sedes = lista.ToArray();
        }

        // Lee la tabla Vehiculo y llena el arreglo Vehiculos
        // (cada vehículo nace con su pila y su ruta vacías)
        private static void CargarVehiculos(SqlConnection conexion)
        {
            List<Vehiculo> lista = new List<Vehiculo>();

            string consulta =
                "SELECT Placa, Conductor, CapacidadKg " +
                "FROM Vehiculo ORDER BY Placa";

            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            using (SqlDataReader lector = comando.ExecuteReader())
            {
                while (lector.Read())
                {
                    Vehiculo vehiculo = new Vehiculo(
                        lector["Placa"].ToString(),
                        lector["Conductor"].ToString(),
                        Convert.ToDecimal(lector["CapacidadKg"]));

                    lista.Add(vehiculo);
                }
            }

            Vehiculos = lista.ToArray();
        }

        // Lee la tabla Persona (remitentes y destinatarios) y devuelve la lista
        private static List<Persona> CargarPersonas(
            SqlConnection conexion)
        {
            List<Persona> lista = new List<Persona>();

            string consulta =
                "SELECT Id, TipoDocumento, NumeroDocumento, Nombres, Telefono " +
                "FROM Persona ORDER BY Id";

            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            using (SqlDataReader lector = comando.ExecuteReader())
            {
                while (lector.Read())
                {
                    Persona persona = new Persona();

                    persona.Id = Convert.ToInt32(lector["Id"]);
                    persona.TipoDocumento =
                        lector["TipoDocumento"].ToString();

                    persona.NumeroDocumento =
                        lector["NumeroDocumento"].ToString();

                    persona.Nombres = lector["Nombres"].ToString();

                    persona.Telefono =
                        lector["Telefono"] == DBNull.Value
                            ? ""
                            : lector["Telefono"].ToString();

                    lista.Add(persona);
                }
            }

            return lista;
        }

        // Busca una persona por su Id dentro de la lista ya cargada (o null)
        private static Persona BuscarPersonaPorId(
            List<Persona> personas, int id)
        {
            for (int i = 0; i < personas.Count; i++)
            {
                if (personas[i].Id == id)
                    return personas[i];
            }

            return null;
        }

        // En SQL el estado se guarda como texto ("EnTransito");
        // este método lo convierte al enum de C# (EstadoEnvio.EnTransito)
        private static EstadoEnvio ConvertirEstado(string texto)
        {
            switch (texto)
            {
                case "Registrado":
                    return EstadoEnvio.Registrado;

                case "EnPreparacion":
                    return EstadoEnvio.EnPreparacion;

                case "EnTransito":
                    return EstadoEnvio.EnTransito;

                case "EnReparto":
                    return EstadoEnvio.EnReparto;

                case "Entregado":
                    return EstadoEnvio.Entregado;

                case "Incidencia":
                    return EstadoEnvio.Incidencia;

                default:
                    throw new Exception(
                        "Estado de envío no reconocido en SQL Server: "
                        + texto);
            }
        }

        // Busca un envío por su guía dentro de la lista ya cargada (o null)
        private static Envio BuscarEnvioPorCodigo(
            List<Envio> envios, string codigo)
        {
            for (int i = 0; i < envios.Count; i++)
            {
                if (envios[i].Codigo == codigo)
                    return envios[i];
            }

            return null;
        }

        // Lee la tabla Envio, arma cada objeto Envio y lo coloca en su estructura:
        //   Registrado    → cola de Recepción
        //   EnPreparacion → cola del Almacén
        //   EnTransito    → pila del vehículo
        //   (EnReparto va a la ruta, eso lo hace CargarParadas)
        // Además, TODOS entran al árbol para poder buscarlos por guía.
        private static List<Envio> CargarEnvios(
            SqlConnection conexion, List<Persona> personas)
        {
            List<Envio> lista = new List<Envio>();

            // Se ordena por fecha para que las colas y pilas queden en el orden en que llegaron
            string consulta =
                "SELECT Id, Codigo, ClaveSeguridad, " +
                "SedeOrigenId, SedeDestinoId, RemitenteId, DestinatarioId, " +
                "Tipo, Descripcion, PesoKg, Precio, ModalidadPago, " +
                "FechaRegistro, FechaActualizacion, Estado, PlacaVehiculo " +
                "FROM Envio ORDER BY FechaActualizacion, Id";

            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            using (SqlDataReader lector = comando.ExecuteReader())
            {
                while (lector.Read())
                {
                    Envio envio = new Envio();

                    envio.Id = Convert.ToInt32(lector["Id"]);
                    envio.Codigo = lector["Codigo"].ToString();

                    envio.ClaveSeguridad =
                        lector["ClaveSeguridad"].ToString();

                    // En la tabla solo están los Id; aquí se cambian por los objetos completos
                    envio.SedeOrigen = BuscarSedePorId(
                        Convert.ToInt32(lector["SedeOrigenId"]));

                    envio.SedeDestino = BuscarSedePorId(
                        Convert.ToInt32(lector["SedeDestinoId"]));

                    envio.Remitente = BuscarPersonaPorId(
                        personas,
                        Convert.ToInt32(lector["RemitenteId"]));

                    envio.Destinatario = BuscarPersonaPorId(
                        personas,
                        Convert.ToInt32(lector["DestinatarioId"]));

                    // Tipo de paquete: texto de SQL → enum de C#
                    string tipoTexto = lector["Tipo"].ToString();

                    switch (tipoTexto)
                    {
                        case "Caja":
                            envio.Tipo = TipoPaquete.Caja;
                            break;

                        case "Sobre":
                            envio.Tipo = TipoPaquete.Sobre;
                            break;

                        default:
                            throw new Exception(
                                "Tipo de paquete no reconocido: " +
                                tipoTexto);
                    }

                    envio.Descripcion =
                        lector["Descripcion"] == DBNull.Value
                            ? ""
                            : lector["Descripcion"].ToString();

                    envio.PesoKg =
                        Convert.ToDecimal(lector["PesoKg"]);

                    envio.Precio =
                        Convert.ToDecimal(lector["Precio"]);

                    // Modalidad de pago: texto de SQL → enum de C#
                    string pagoTexto =
                        lector["ModalidadPago"].ToString();

                    switch (pagoTexto)
                    {
                        case "PagadoEnOrigen":
                            envio.ModalidadPago =
                                ModalidadPago.PagadoEnOrigen;
                            break;

                        case "PorCobrarEnDestino":
                            envio.ModalidadPago =
                                ModalidadPago.PorCobrarEnDestino;
                            break;

                        default:
                            throw new Exception(
                                "Modalidad de pago no reconocida: " +
                                pagoTexto);
                    }

                    envio.FechaRegistro =
                        Convert.ToDateTime(lector["FechaRegistro"]);

                    envio.PlacaVehiculo =
                        lector["PlacaVehiculo"] == DBNull.Value
                            ? null
                            : lector["PlacaVehiculo"].ToString();

                    EstadoEnvio estado =
                        ConvertirEstado(lector["Estado"].ToString());

                    // Se fija el estado tal como está en la base, sin crear un evento nuevo
                    envio.FijarEstadoDesdeSQL(
                        estado,
                        Convert.ToDateTime(
                            lector["FechaActualizacion"]));

                    // Según su estado, el envío entra a una estructura u otra
                    if (estado == EstadoEnvio.Registrado)
                    {
                        Recepcion.Encolar(envio);
                    }
                    else if (estado == EstadoEnvio.EnPreparacion)
                    {
                        Almacen.Encolar(envio);
                    }
                    else if (estado == EstadoEnvio.EnTransito)
                    {
                        Vehiculo vehiculo =
                            BuscarVehiculoPorPlaca(
                                envio.PlacaVehiculo);

                        if (vehiculo != null)
                            vehiculo.Carga.Apilar(envio);
                    }

                    // Todos los envíos se registran en el árbol.
                    Registro.Insertar(envio);

                    lista.Add(envio);
                }
            }

            return lista;
        }

        // Lee la tabla HistorialEnvio y agrega cada evento a la LISTA SIMPLE
        // de historial de su envío (en orden de fecha). Es lo que se ve en Rastreo.
        private static void CargarHistorial(
            SqlConnection conexion, List<Envio> envios)
        {
            string consulta =
                "SELECT CodigoEnvio, Fecha, Estado, Ubicacion, " +
                "Observacion, PendienteSincronizar " +
                "FROM HistorialEnvio ORDER BY CodigoEnvio, Fecha";

            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            using (SqlDataReader lector = comando.ExecuteReader())
            {
                while (lector.Read())
                {
                    string codigo =
                        lector["CodigoEnvio"].ToString();

                    Envio envio =
                        BuscarEnvioPorCodigo(envios, codigo);

                    if (envio == null)
                        continue;   // Evento de un envío que no existe: se ignora

                    EstadoEnvio estado =
                        ConvertirEstado(lector["Estado"].ToString());

                    string ubicacion =
                        lector["Ubicacion"] == DBNull.Value
                            ? ""
                            : lector["Ubicacion"].ToString();

                    string observacion =
                        lector["Observacion"] == DBNull.Value
                            ? ""
                            : lector["Observacion"].ToString();

                    EventoRastreo evento = new EventoRastreo(
                        estado, ubicacion, observacion);

                    evento.Fecha =
                        Convert.ToDateTime(lector["Fecha"]);

                    evento.PendienteSincronizar =
                        Convert.ToBoolean(
                            lector["PendienteSincronizar"]);

                    envio.Historial.AgregarAlFinal(evento);
                }
            }
        }

        // Lee la tabla ParadaRuta (ordenada por vehículo y número de parada)
        // y arma la LISTA DOBLE de paradas de cada vehículo.
        private static void CargarParadas(
            SqlConnection conexion, List<Envio> envios)
        {
            string consulta =
                "SELECT PlacaVehiculo, CodigoEnvio, Orden " +
                "FROM ParadaRuta ORDER BY PlacaVehiculo, Orden";

            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            using (SqlDataReader lector = comando.ExecuteReader())
            {
                while (lector.Read())
                {
                    string placa = lector["PlacaVehiculo"].ToString();
                    string codigo = lector["CodigoEnvio"].ToString();

                    Vehiculo vehiculo = BuscarVehiculoPorPlaca(placa);
                    Envio envio = BuscarEnvioPorCodigo(envios, codigo);

                    // Solo se agregan envíos que están "En reparto"
                    // y que pertenecen a ese vehículo (evita datos inconsistentes)
                    if (vehiculo != null &&
                        envio != null &&
                        envio.Estado == EstadoEnvio.EnReparto &&
                        envio.PlacaVehiculo == placa)
                    {
                        vehiculo.Ruta.AgregarAlFinal(envio);
                    }
                }
            }
        }

        // =========================================================
        //  ESCRITURA EN SQL SERVER
        //  Regla de todo el sistema: PRIMERO se guarda en SQL y,
        //  solo si salió bien, se modifica la memoria (estructuras).
        //  Así la pantalla nunca muestra algo que no está en la base.
        // =========================================================

        // RECEPCIÓN: registra un envío nuevo.
        // Pasos: guarda remitente y destinatario → guarda el envío (SQL le da un Id) →
        // con ese Id se genera la guía (ej. LIM-ARE-000007) → primer evento del historial.
        // Todo va en una TRANSACCIÓN: si algo falla, se deshace todo.
        public static void RegistrarEnvio(Envio envio)
        {
            DateTime ahora = DateTime.Now;
            string ubicacion = envio.SedeOrigen.Nombre;
            string observacion = "Envío registrado en recepción";

            using (SqlConnection conexion = CrearConexion())
            {
                conexion.Open();
                using (SqlTransaction tx = conexion.BeginTransaction())
                {
                    try
                    {
                        envio.Remitente.Id = GuardarPersona(conexion, tx, envio.Remitente);
                        envio.Destinatario.Id = GuardarPersona(conexion, tx, envio.Destinatario);

                        envio.Id = InsertarEnvio(conexion, tx, envio, ahora);
                        envio.GenerarCodigo();                       // LIM-ARE-000007
                        ActualizarCodigo(conexion, tx, envio);

                        InsertarHistorial(conexion, tx, envio.Codigo,
                            EstadoEnvio.Registrado, ahora, ubicacion, observacion);

                        tx.Commit();                                 // Confirma: se guarda todo
                    }
                    catch
                    {
                        tx.Rollback();                               // Algo falló: no se guarda nada
                        throw;                                       // El formulario muestra el error
                    }
                }
            }

            // SQL guardó todo: ahora sí entra a la cola de recepción y al árbol
            envio.CambiarEstado(EstadoEnvio.Registrado, ubicacion, observacion);
            Recepcion.Encolar(envio);
            Registro.Insertar(envio);
        }

        // RECEPCIÓN → ALMACÉN: el primero de la cola de recepción (el más antiguo)
        // sale y entra al final de la cola del almacén.
        // Devuelve "" si se pudo, o el motivo si no.
        public static string EnviarAAlmacen()
        {
            Envio frente = Recepcion.VerFrente();   // Se mira sin sacarlo
            if (frente == null)
                return "No hay envíos en la cola de recepción.";

            if (Almacen.Cantidad >= Almacen.Capacidad)
                return "El almacén está lleno.";

            // Primero SQL (si falla, lanza excepción y nada se mueve)
            CambiarEstado(frente, EstadoEnvio.EnPreparacion,
                "Almacén " + frente.SedeOrigen.Nombre, "Ingresó al almacén");

            Almacen.Encolar(Recepcion.Desencolar());   // Sale de una cola y entra a la otra
            return "";
        }

        // ALMACÉN → VEHÍCULO: el primero de la cola del almacén se sube al vehículo
        // y queda en el TOPE de su pila.
        // Devuelve "" si se pudo, o el motivo si no.
        public static string DespacharA(Vehiculo vehiculo)
        {
            if (vehiculo == null)
                return "Seleccione un vehículo.";

            Envio frente = Almacen.VerFrente();
            if (frente == null)
                return "El almacén está vacío.";

            // Se revisa ANTES de sacarlo: si no entra, se queda en el almacén.
            // Se cuenta la pila y también las paradas, porque siguen físicamente en el vehículo.
            decimal pesoActual = PesoEnVehiculo(vehiculo);
            if (pesoActual + frente.PesoKg > vehiculo.CapacidadKg)
                return "El paquete " + frente.Codigo + " (" + frente.PesoKg + " kg) excede la capacidad de " +
                       vehiculo.Placa + ".\nCarga actual: " + pesoActual +
                       " de " + vehiculo.CapacidadKg + " kg.";

            frente.PlacaVehiculo = vehiculo.Placa;
            try
            {
                CambiarEstado(frente, EstadoEnvio.EnTransito,
                    "Vehículo " + vehiculo.Placa, "Cargado en el vehículo");
            }
            catch
            {
                frente.PlacaVehiculo = null;   // Si SQL falló, se deshace la placa en memoria
                throw;
            }

            vehiculo.Carga.Apilar(Almacen.Desencolar());   // Sale del almacén y entra a la pila
            return "";
        }

        // Peso total dentro del vehículo. Se suman las DOS estructuras, porque
        // los paquetes con parada asignada siguen físicamente en el vehículo:
        //   pila (por asignar) + lista (paradas de la ruta)
        public static decimal PesoEnVehiculo(Vehiculo vehiculo)
        {
            decimal total = vehiculo.Carga.PesoActual;

            Envio[] paradas = vehiculo.Ruta.ObtenerEnvios();
            for (int i = 0; i < paradas.Length; i++)
                total += paradas[i].PesoKg;

            return total;
        }

        // =========================================================
        //  RUTAS (pila del vehículo ↔ lista de paradas)
        //
        //  Cada vehículo tiene dos estructuras:
        //    Carga = PILA  → paquetes subidos al vehículo que aún no tienen parada
        //    Ruta  = LISTA DOBLE → paradas de reparto, en el orden en que se entregan
        //
        //  Misma regla de siempre, en 2 pasos:
        //    1. Se arma en una COPIA cómo quedará la ruta y se guarda en SQL.
        //    2. Solo si SQL guardó bien, se cambian la pila y la lista reales.
        // =========================================================

        // PILA → RUTA: el paquete del TOPE de la pila pasa a ser una parada.
        // codigoReferencia = null  → va al final de la ruta
        // codigoReferencia = guía  → va justo después de esa parada
        // Devuelve "" si se pudo, o el motivo si no.
        public static string AsignarTope(Vehiculo vehiculo, string codigoReferencia)
        {
            // Validaciones: hay vehículo, hay paquete en la pila y la parada de referencia existe
            if (vehiculo == null)
                return "Seleccione un vehículo.";

            Envio tope = vehiculo.Carga.VerTope();   // Solo se mira, todavía no se saca
            if (tope == null)
                return "No hay paquetes en el vehículo pendientes de asignar.";

            if (codigoReferencia != null && !vehiculo.Ruta.Contiene(codigoReferencia))
                return "No se encontró la parada de referencia.";

            string ubicacion = "Ruta " + vehiculo.Placa;
            string observacion = "Asignado a la ruta de reparto";

            // 1. Copia de la ruta actual + el paquete en su nueva posición → se guarda en SQL
            List<Envio> nuevaRuta = new List<Envio>(vehiculo.Ruta.ObtenerEnvios());
            int posicion = codigoReferencia == null
                ? nuevaRuta.Count                                  // Al final
                : PosicionDe(nuevaRuta, codigoReferencia) + 1;     // Una después de la referencia
            nuevaRuta.Insert(posicion, tope);

            GuardarCambioRuta(vehiculo.Placa, nuevaRuta, tope, EstadoEnvio.EnReparto, ubicacion, observacion);

            // 2. SQL guardó bien: ahora sí el paquete sale de la pila y entra a la lista
            if (codigoReferencia == null)
                vehiculo.Ruta.AgregarAlFinal(tope);
            else
                vehiculo.Ruta.InsertarDespues(codigoReferencia, tope);

            vehiculo.Carga.Desapilar();                                        // Sale de la pila
            tope.CambiarEstado(EstadoEnvio.EnReparto, ubicacion, observacion); // Estado e historial en memoria
            return "";
        }

        // Atajo usado por "Entregar tope" en Carga del vehículo: manda el tope al final de la ruta
        public static string EntregarTope(Vehiculo vehiculo)
        {
            return AsignarTope(vehiculo, null);
        }

        // RUTA → PILA: la parada se elimina de la lista y el paquete vuelve al TOPE de la pila,
        // quedando otra vez en "Paquetes por asignar". No se revisa el peso porque
        // el paquete nunca salió del vehículo: solo cambia de estructura.
        public static string QuitarParada(Vehiculo vehiculo, string codigo)
        {
            if (vehiculo == null)
                return "Seleccione un vehículo.";

            Envio envio = Registro.Buscar(codigo);   // El árbol encuentra el envío por su guía
            if (envio == null || !vehiculo.Ruta.Contiene(codigo))
                return "La parada no pertenece a la ruta de este vehículo.";

            string ubicacion = "Vehículo " + vehiculo.Placa;
            string observacion = "Retirado de la ruta, vuelve al vehículo";

            // 1. Se guarda en SQL cómo queda la ruta sin esa parada
            GuardarCambioRuta(vehiculo.Placa, RutaSin(vehiculo, codigo), envio,
                EstadoEnvio.EnTransito, ubicacion, observacion);

            // 2. SQL guardó bien: sale de la lista y vuelve arriba de la pila
            vehiculo.Ruta.EliminarParada(codigo);
            vehiculo.Carga.Apilar(envio);
            envio.CambiarEstado(EstadoEnvio.EnTransito, ubicacion, observacion);
            return "";
        }

        // Guarda 3 cosas juntas en una TRANSACCIÓN (o se guardan todas o ninguna):
        //   1. El nuevo estado del envío (tabla Envio)
        //   2. Un evento en su historial (tabla HistorialEnvio)
        //   3. La ruta completa del vehículo en el orden recibido (tabla ParadaRuta)
        private static void GuardarCambioRuta(string placa, List<Envio> paradas, Envio envio,
            EstadoEnvio estado, string ubicacion, string observacion)
        {
            DateTime ahora = DateTime.Now;

            using (SqlConnection conexion = CrearConexion())
            {
                conexion.Open();
                using (SqlTransaction tx = conexion.BeginTransaction())
                {
                    try
                    {
                        ActualizarEstadoSQL(conexion, tx, envio, estado, ahora);
                        InsertarHistorial(conexion, tx, envio.Codigo, estado, ahora, ubicacion, observacion);
                        GuardarRuta(conexion, tx, placa, paradas);
                        tx.Commit();
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
        }

        // Borra las paradas guardadas del vehículo y las vuelve a escribir en el orden recibido.
        // Es más simple que mover números: la columna Orden siempre queda 1, 2, 3...
        private static void GuardarRuta(SqlConnection conexion, SqlTransaction tx,
            string placa, List<Envio> paradas)
        {
            using (SqlCommand borrar = new SqlCommand(
                "DELETE FROM ParadaRuta WHERE PlacaVehiculo = @placa", conexion, tx))
            {
                borrar.Parameters.AddWithValue("@placa", placa);
                borrar.ExecuteNonQuery();
            }

            for (int i = 0; i < paradas.Count; i++)
            {
                using (SqlCommand insertar = new SqlCommand(
                    "INSERT INTO ParadaRuta (PlacaVehiculo, CodigoEnvio, Orden) VALUES (@placa, @cod, @orden)",
                    conexion, tx))
                {
                    insertar.Parameters.AddWithValue("@placa", placa);
                    insertar.Parameters.AddWithValue("@cod", paradas[i].Codigo);
                    insertar.Parameters.AddWithValue("@orden", i + 1);
                    insertar.ExecuteNonQuery();
                }
            }
        }

        // Posición (0, 1, 2...) de una guía dentro de la ruta, o -1 si no está
        private static int PosicionDe(List<Envio> paradas, string codigo)
        {
            for (int i = 0; i < paradas.Count; i++)
            {
                if (paradas[i].Codigo == codigo)
                    return i;
            }

            return -1;
        }

        // Copia de la ruta actual sin la parada indicada (la lista real no se toca)
        private static List<Envio> RutaSin(Vehiculo vehiculo, string codigo)
        {
            List<Envio> paradas = new List<Envio>(vehiculo.Ruta.ObtenerEnvios());
            paradas.RemoveAt(PosicionDe(paradas, codigo));
            return paradas;
        }

        // =========================================================
        //  RASTREO
        // =========================================================

        // Marca como ENTREGADO un envío que está en reparto:
        // sale de la ruta del vehículo y queda solo en el árbol (para poder consultarlo).
        public static string MarcarEntregado(Envio envio, string observacion)
        {
            if (envio.Estado != EstadoEnvio.EnReparto)
                return "Solo se puede entregar un envío que está En reparto (estado actual: " + envio.Estado + ").";

            Vehiculo vehiculo = BuscarVehiculoPorPlaca(envio.PlacaVehiculo);
            if (vehiculo == null || !vehiculo.Ruta.Contiene(envio.Codigo))
                return "No se encontró el envío en la ruta de su vehículo.";

            string ubicacion = envio.SedeDestino.Nombre;
            if (string.IsNullOrWhiteSpace(observacion))
                observacion = "Entregado al destinatario";   // Texto por defecto

            // 1. Se guarda en SQL cómo queda la ruta sin esa parada
            GuardarCambioRuta(vehiculo.Placa, RutaSin(vehiculo, envio.Codigo), envio,
                EstadoEnvio.Entregado, ubicacion, observacion);

            // 2. SQL guardó bien: deja de ser parada
            vehiculo.Ruta.EliminarParada(envio.Codigo);
            envio.CambiarEstado(EstadoEnvio.Entregado, ubicacion, observacion);
            return "";
        }

        // Registra una INCIDENCIA en el historial (retraso, daño, etc.).
        // El paquete NO cambia de estructura ni de estado: sigue en la cola, pila o ruta donde estaba;
        // solo se agrega un evento a su historial.
        public static string RegistrarIncidencia(Envio envio, string observacion)
        {
            if (envio == null)
                return "Seleccione un envío.";

            if (string.IsNullOrWhiteSpace(observacion))
                return "Describa la incidencia en el campo Observación.";

            DateTime ahora = DateTime.Now;
            string ubicacion = "Rastreo";

            // 1. SQL
            using (SqlConnection conexion = CrearConexion())
            {
                conexion.Open();

                using (SqlTransaction tx = conexion.BeginTransaction())
                {
                    try
                    {
                        InsertarHistorial(conexion, tx, envio.Codigo,
                            EstadoEnvio.Incidencia, ahora, ubicacion, observacion);

                        tx.Commit();
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }

            // 2. Memoria: el evento se agrega al final de la lista de historial del envío
            EventoRastreo evento = new EventoRastreo(
                EstadoEnvio.Incidencia,
                ubicacion,
                observacion);

            evento.Fecha = ahora;
            evento.PendienteSincronizar = false;   // Ya está guardado en la base

            envio.Historial.AgregarAlFinal(evento);

            return "";
        }

        // PUNTO ÚNICO para cambiar el estado de un envío existente.
        // En una transacción: actualiza la tabla Envio y agrega el evento a HistorialEnvio.
        // Luego actualiza el envío en memoria.
        public static void CambiarEstado(Envio envio, EstadoEnvio estado,
            string ubicacion, string observacion)
        {
            DateTime ahora = DateTime.Now;

            using (SqlConnection conexion = CrearConexion())
            {
                conexion.Open();
                using (SqlTransaction tx = conexion.BeginTransaction())
                {
                    try
                    {
                        ActualizarEstadoSQL(conexion, tx, envio, estado, ahora);
                        InsertarHistorial(conexion, tx, envio.Codigo,
                            estado, ahora, ubicacion, observacion);
                        tx.Commit();
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }

            envio.CambiarEstado(estado, ubicacion, observacion);
        }

        // =========================================================
        //  MÉTODOS PRIVADOS DE APOYO (consultas SQL pequeñas)
        //  Reciben la conexión y la transacción ya abiertas, para que
        //  formen parte de la misma operación "todo o nada".
        // =========================================================

        // UPDATE del estado, la fecha y la placa del envío en la tabla Envio
        private static void ActualizarEstadoSQL(SqlConnection conexion,
            SqlTransaction tx, Envio envio, EstadoEnvio estado, DateTime fecha)
        {
            string consulta =
                "UPDATE Envio SET Estado = @estado, " +
                "FechaActualizacion = @fecha, PlacaVehiculo = @placa " +
                "WHERE Id = @id";

            // Los @parámetros evitan errores con comillas y la inyección SQL
            using (SqlCommand comando = new SqlCommand(consulta, conexion, tx))
            {
                comando.Parameters.AddWithValue("@estado", estado.ToString());
                comando.Parameters.AddWithValue("@fecha", fecha);
                comando.Parameters.AddWithValue("@placa", ValorONulo(envio.PlacaVehiculo));
                comando.Parameters.AddWithValue("@id", envio.Id);
                comando.ExecuteNonQuery();
            }
        }

        // Guarda una persona y devuelve su Id.
        // Si ya existe alguien con ese DNI, se reutiliza y se actualizan su nombre y teléfono;
        // si no existe, se inserta. Así no se duplican personas.
        private static int GuardarPersona(SqlConnection conexion,
            SqlTransaction tx, Persona persona)
        {
            string buscar = "SELECT Id FROM Persona WHERE NumeroDocumento = @doc";

            using (SqlCommand comando = new SqlCommand(buscar, conexion, tx))
            {
                comando.Parameters.AddWithValue("@doc", persona.NumeroDocumento);
                object id = comando.ExecuteScalar();   // Devuelve el Id, o null si no hay nadie

                if (id != null)
                {
                    string actualizar =
                        "UPDATE Persona SET Nombres = @nom, Telefono = @tel WHERE Id = @id";

                    using (SqlCommand cmd = new SqlCommand(actualizar, conexion, tx))
                    {
                        cmd.Parameters.AddWithValue("@nom", persona.Nombres);
                        cmd.Parameters.AddWithValue("@tel", ValorONulo(persona.Telefono));
                        cmd.Parameters.AddWithValue("@id", Convert.ToInt32(id));
                        cmd.ExecuteNonQuery();
                    }

                    return Convert.ToInt32(id);
                }
            }

            // No existía: se inserta. OUTPUT INSERTED.Id devuelve el Id que SQL le asignó
            string insertar =
                "INSERT INTO Persona (TipoDocumento, NumeroDocumento, Nombres, Telefono) " +
                "OUTPUT INSERTED.Id " +
                "VALUES (@tipo, @doc, @nom, @tel)";

            using (SqlCommand comando = new SqlCommand(insertar, conexion, tx))
            {
                comando.Parameters.AddWithValue("@tipo", persona.TipoDocumento);
                comando.Parameters.AddWithValue("@doc", persona.NumeroDocumento);
                comando.Parameters.AddWithValue("@nom", persona.Nombres);
                comando.Parameters.AddWithValue("@tel", ValorONulo(persona.Telefono));
                return Convert.ToInt32(comando.ExecuteScalar());
            }
        }

        // Inserta el envío y devuelve el Id que le asignó SQL.
        // La guía real necesita ese Id (LIM-ARE-000007), así que primero
        // se guarda un código temporal único y luego ActualizarCodigo lo reemplaza.
        private static int InsertarEnvio(SqlConnection conexion,
            SqlTransaction tx, Envio envio, DateTime fecha)
        {
            string consulta =
                "INSERT INTO Envio (Codigo, ClaveSeguridad, SedeOrigenId, SedeDestinoId, " +
                "RemitenteId, DestinatarioId, Tipo, Descripcion, PesoKg, Precio, " +
                "ModalidadPago, FechaRegistro, FechaActualizacion, Estado) " +
                "OUTPUT INSERTED.Id " +
                "VALUES (@cod, @clave, @ori, @des, @rem, @dst, @tipo, @desc, @peso, " +
                "@precio, @pago, @fecha, @fecha, @estado)";

            using (SqlCommand comando = new SqlCommand(consulta, conexion, tx))
            {
                // Código temporal: "TMP" + 17 caracteres al azar (20 en total, único)
                comando.Parameters.AddWithValue("@cod",
                    "TMP" + Guid.NewGuid().ToString("N").Substring(0, 17));
                comando.Parameters.AddWithValue("@clave", envio.ClaveSeguridad);
                comando.Parameters.AddWithValue("@ori", envio.SedeOrigen.Id);
                comando.Parameters.AddWithValue("@des", envio.SedeDestino.Id);
                comando.Parameters.AddWithValue("@rem", envio.Remitente.Id);
                comando.Parameters.AddWithValue("@dst", envio.Destinatario.Id);
                comando.Parameters.AddWithValue("@tipo", envio.Tipo.ToString());
                comando.Parameters.AddWithValue("@desc", ValorONulo(envio.Descripcion));
                comando.Parameters.AddWithValue("@peso", envio.PesoKg);
                comando.Parameters.AddWithValue("@precio", envio.Precio);
                comando.Parameters.AddWithValue("@pago", envio.ModalidadPago.ToString());
                comando.Parameters.AddWithValue("@fecha", fecha);
                comando.Parameters.AddWithValue("@estado", EstadoEnvio.Registrado.ToString());

                return Convert.ToInt32(comando.ExecuteScalar());
            }
        }

        // Cambia el código temporal por la guía real del envío
        private static void ActualizarCodigo(SqlConnection conexion,
            SqlTransaction tx, Envio envio)
        {
            string consulta = "UPDATE Envio SET Codigo = @cod WHERE Id = @id";

            using (SqlCommand comando = new SqlCommand(consulta, conexion, tx))
            {
                comando.Parameters.AddWithValue("@cod", envio.Codigo);
                comando.Parameters.AddWithValue("@id", envio.Id);
                comando.ExecuteNonQuery();
            }
        }

        // Agrega una fila a HistorialEnvio (un evento de rastreo: qué pasó, cuándo y dónde)
        private static void InsertarHistorial(SqlConnection conexion,
            SqlTransaction tx, string codigo, EstadoEnvio estado,
            DateTime fecha, string ubicacion, string observacion)
        {
            string consulta =
                "INSERT INTO HistorialEnvio (CodigoEnvio, Fecha, Estado, Ubicacion, Observacion) " +
                "VALUES (@cod, @fecha, @estado, @ubic, @obs)";

            using (SqlCommand comando = new SqlCommand(consulta, conexion, tx))
            {
                comando.Parameters.AddWithValue("@cod", codigo);
                comando.Parameters.AddWithValue("@fecha", fecha);
                comando.Parameters.AddWithValue("@estado", estado.ToString());
                comando.Parameters.AddWithValue("@ubic", ValorONulo(ubicacion));
                comando.Parameters.AddWithValue("@obs", ValorONulo(observacion));
                comando.ExecuteNonQuery();
            }
        }

        // Texto vacío o null de C# → NULL de SQL (para no guardar textos vacíos)
        private static object ValorONulo(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
                return DBNull.Value;
            return valor;
        }

        // =========================================================
        //  PERSONAS (validaciones del formulario de Ingreso)
        // =========================================================

        // Busca una persona por su DNI directamente en la base.
        // Lo usa Ingreso para autocompletar nombre y teléfono. Devuelve null si no está registrada.
        public static Persona BuscarPersonaPorDni(string dni)
        {
            string consulta =
                "SELECT Id, TipoDocumento, NumeroDocumento, Nombres, Telefono " +
                "FROM Persona WHERE NumeroDocumento = @dni";

            using (SqlConnection conexion = CrearConexion())
            {
                conexion.Open();

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@dni", dni);

                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        if (!lector.Read())
                            return null;   // No hay ninguna fila con ese DNI

                        Persona persona = new Persona();
                        persona.Id = Convert.ToInt32(lector["Id"]);
                        persona.TipoDocumento = lector["TipoDocumento"].ToString();
                        persona.NumeroDocumento = lector["NumeroDocumento"].ToString();
                        persona.Nombres = lector["Nombres"].ToString();
                        persona.Telefono = lector["Telefono"] == DBNull.Value
                            ? ""
                            : lector["Telefono"].ToString();
                        return persona;
                    }
                }
            }
        }

        // ¿El teléfono ya pertenece a OTRA persona (otro DNI)?
        // Devuelve el nombre de esa persona, o null si el teléfono está libre.
        // Evita que dos personas distintas tengan el mismo número.
        public static string TelefonoDeOtraPersona(string telefono, string dniPropio)
        {
            string consulta =
                "SELECT TOP 1 Nombres FROM Persona " +
                "WHERE Telefono = @tel AND NumeroDocumento <> @dni";

            using (SqlConnection conexion = CrearConexion())
            {
                conexion.Open();

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@tel", telefono);
                    comando.Parameters.AddWithValue("@dni", dniPropio);

                    object nombre = comando.ExecuteScalar();
                    return nombre == null ? null : nombre.ToString();
                }
            }
        }

        // =========================================================
        //  TARIFAS
        // =========================================================

        // Busca el precio del trayecto origen → destino (precio base + precio por kg).
        // Devuelve null si ese trayecto no tiene tarifa registrada.
        public static Tarifa BuscarTarifa(int origenId, int destinoId)
        {
            if (origenId <= 0 || destinoId <= 0 || origenId == destinoId)
                return null;

            string consulta = @"
        SELECT SedeOrigenId, SedeDestinoId, PrecioBase, PrecioPorKg
        FROM Tarifa
        WHERE SedeOrigenId = @origen
          AND SedeDestinoId = @destino";

            using (SqlConnection conexion = CrearConexion())
            {
                conexion.Open();

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@origen", origenId);
                    comando.Parameters.AddWithValue("@destino", destinoId);

                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        if (lector.Read())
                        {
                            Tarifa tarifa = new Tarifa();

                            tarifa.SedeOrigenId =
                                Convert.ToInt32(lector["SedeOrigenId"]);

                            tarifa.SedeDestinoId =
                                Convert.ToInt32(lector["SedeDestinoId"]);

                            tarifa.PrecioBase =
                                Convert.ToDecimal(lector["PrecioBase"]);

                            tarifa.PrecioPorKg =
                                Convert.ToDecimal(lector["PrecioPorKg"]);

                            return tarifa;
                        }
                    }
                }
            }

            return null;
        }

        // =========================================================
        //  LOGIN
        // =========================================================

        // Revisa si existe un usuario con ese nombre y contraseña.
        // COLLATE Latin1_General_CS_AS hace que la contraseña distinga mayúsculas y minúsculas.
        // Devuelve true si los datos son correctos.
        public static bool ValidarUsuario(string usuario, string contrasena)
        {
            string consulta = "SELECT COUNT(*) FROM Usuario " +
                              "WHERE Usuario = @usuario " +
                              "AND Contrasena = @contrasena COLLATE Latin1_General_CS_AS";

            using (SqlConnection conexion = CrearConexion())
            {
                conexion.Open();

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@usuario", usuario);
                    comando.Parameters.AddWithValue("@contrasena", contrasena);

                    int cantidad = Convert.ToInt32(comando.ExecuteScalar());   // Cuántos usuarios coinciden
                    return cantidad > 0;
                }
            }
        }
    }
}