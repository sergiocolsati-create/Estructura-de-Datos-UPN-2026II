using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Shalom
{
    internal static class Sistema
    {
        // CONEXIÓN A SQL SERVER
        private static readonly string cadenaConexion =
            @"Data Source=localhost;Initial Catalog=ShalomDB;Integrated Security=True;";

        public static SqlConnection CrearConexion()
        {
            return new SqlConnection(cadenaConexion);
        }

        // ESTRUCTURAS DE DATOS
        public static ColaEnvios Recepcion = new ColaEnvios();
        public static ColaEnvios Almacen = new ColaEnvios(50);
        public static ArbolEnvios Registro = new ArbolEnvios();

        // CATÁLOGOS
        public static Sede[] Sedes = new Sede[0];
        public static Vehiculo[] Vehiculos = new Vehiculo[0];

        // TARIFAS
        public static decimal PrecioBase { get; private set; }
        public static decimal PrecioPorKg { get; private set; }

        // BUSCAR SEDE POR ID
        public static Sede BuscarSedePorId(int id)
        {
            for (int i = 0; i < Sedes.Length; i++)
            {
                if (Sedes[i].Id == id)
                    return Sedes[i];
            }

            return null;
        }

        // BUSCAR VEHÍCULO POR PLACA
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

        // CARGAR LOS DATOS DESDE SQL SERVER
        public static void CargarDatosSQL()
        {
            // Reiniciar estructuras para evitar duplicados.
            Recepcion = new ColaEnvios();
            Almacen = new ColaEnvios(50);
            Registro = new ArbolEnvios();

            using (SqlConnection conexion = CrearConexion())
            {
                conexion.Open();

                CargarSedes(conexion);
                CargarVehiculos(conexion);
                CargarTarifa(conexion);

                List<Persona> personas = CargarPersonas(conexion);
                List<Envio> envios = CargarEnvios(conexion, personas);

                CargarHistorial(conexion, envios);
                CargarParadas(conexion, envios);
            }
        }

        // CARGAR SEDES
        private static void CargarSedes(SqlConnection conexion)
        {
            List<Sede> lista = new List<Sede>();

            string consulta =
                "SELECT Id, Codigo, Nombre, Ciudad, Direccion " +
                "FROM Sede ORDER BY Id";

            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            using (SqlDataReader lector = comando.ExecuteReader())
            {
                while (lector.Read())
                {
                    Sede sede = new Sede();

                    sede.Id = Convert.ToInt32(lector["Id"]);
                    sede.Codigo = lector["Codigo"].ToString();
                    sede.Nombre = lector["Nombre"].ToString();
                    sede.Ciudad = lector["Ciudad"].ToString();

                    sede.Direccion =
                        lector["Direccion"] == DBNull.Value
                            ? ""
                            : lector["Direccion"].ToString();

                    lista.Add(sede);
                }
            }

            Sedes = lista.ToArray();
        }

        // CARGAR VEHÍCULOS
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

        // CARGAR TARIFA
        private static void CargarTarifa(SqlConnection conexion)
        {
            string consulta =
                "SELECT TOP 1 PrecioBase, PrecioPorKg " +
                "FROM Tarifa ORDER BY Id";

            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            using (SqlDataReader lector = comando.ExecuteReader())
            {
                if (lector.Read())
                {
                    PrecioBase =
                        Convert.ToDecimal(lector["PrecioBase"]);

                    PrecioPorKg =
                        Convert.ToDecimal(lector["PrecioPorKg"]);
                }
                else
                {
                    throw new Exception(
                        "No hay tarifas registradas en SQL Server.");
                }
            }
        }

        // CARGAR PERSONAS
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

        // BUSCAR PERSONA POR ID
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

        // CONVERTIR EL ESTADO DE SQL A C#
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

        // BUSCAR ENVÍO POR CÓDIGO
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

        // CARGAR ENVÍOS Y DISTRIBUIRLOS EN LAS ESTRUCTURAS
        private static List<Envio> CargarEnvios(
            SqlConnection conexion, List<Persona> personas)
        {
            List<Envio> lista = new List<Envio>();

            // Ya no se consultan dimensiones ni fechas opcionales
            // que hemos decidido retirar del modelo C#.
            string consulta =
                "SELECT Id, Codigo, ClaveSeguridad, " +
                "SedeOrigenId, SedeDestinoId, RemitenteId, DestinatarioId, " +
                "Tipo, Descripcion, PesoKg, Precio, ModalidadPago, " +
                "FechaRegistro, FechaActualizacion, Estado, PlacaVehiculo " +
                "FROM Envio ORDER BY Id";

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

                    // Tipo de paquete
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

                    // Modalidad de pago
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

                    envio.FijarEstadoDesdeSQL(
                        estado,
                        Convert.ToDateTime(
                            lector["FechaActualizacion"]));

                    // Distribuir según el estado actual.
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

        // CARGAR HISTORIAL DE TRAZABILIDAD
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
                        continue;

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

        // CARGAR LAS PARADAS DE LAS RUTAS
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
                    string placa =
                        lector["PlacaVehiculo"].ToString();

                    string codigo =
                        lector["CodigoEnvio"].ToString();

                    Vehiculo vehiculo =
                        BuscarVehiculoPorPlaca(placa);

                    Envio envio =
                        BuscarEnvioPorCodigo(envios, codigo);

                    if (vehiculo != null && envio != null)
                        vehiculo.Ruta.AgregarAlFinal(envio);
                }
            }
        }
        // =========================================================
        //  ESCRITURA EN SQL SERVER
        //  Regla: primero se guarda en SQL; solo si salió bien
        //  se modifica la memoria (estructuras). Así nunca quedan
        //  datos distintos entre el formulario y la base.
        // =========================================================

        // RECEPCIÓN: registra un envío nuevo.
        // SQL asigna el Id, con él se genera el código, se guarda el
        // primer evento del historial y recién entra a la cola.
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

                        tx.Commit();                                 // Todo o nada
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }

            // SQL guardó todo: ahora sí se actualiza la memoria
            envio.CambiarEstado(EstadoEnvio.Registrado, ubicacion, observacion);
            Recepcion.Encolar(envio);
            Registro.Insertar(envio);
        }

        // RECEPCIÓN → ALMACÉN (desencolar de una cola y encolar en la otra).
        // Devuelve "" si se pudo, o el motivo si no.
        public static string EnviarAAlmacen()
        {
            Envio frente = Recepcion.VerFrente();
            if (frente == null)
                return "No hay envíos en la cola de recepción.";

            if (Almacen.Cantidad >= Almacen.Capacidad)
                return "El almacén está lleno.";

            // Primero SQL (si falla, lanza excepción y nada se mueve)
            CambiarEstado(frente, EstadoEnvio.EnPreparacion,
                "Almacén " + frente.SedeOrigen.Nombre, "Ingresó al almacén");

            Almacen.Encolar(Recepcion.Desencolar());
            return "";
        }
        // ALMACÉN → PILA DEL VEHÍCULO (desencolar y apilar).
        // Devuelve "" si se pudo, o el motivo si no.
        public static string DespacharA(Vehiculo vehiculo)
        {
            if (vehiculo == null)
                return "Seleccione un vehículo.";

            Envio frente = Almacen.VerFrente();
            if (frente == null)
                return "El almacén está vacío.";

            // Se revisa ANTES de desencolar: si no entra, se queda en el almacén
            if (vehiculo.Carga.PesoActual + frente.PesoKg > vehiculo.CapacidadKg)
                return "El paquete " + frente.Codigo + " (" + frente.PesoKg + " kg) excede la capacidad de " +
                       vehiculo.Placa + ".\nCarga actual: " + vehiculo.Carga.PesoActual +
                       " de " + vehiculo.CapacidadKg + " kg.";

            frente.PlacaVehiculo = vehiculo.Placa;
            try
            {
                CambiarEstado(frente, EstadoEnvio.EnTransito,
                    "Vehículo " + vehiculo.Placa, "Cargado en el vehículo");
            }
            catch
            {
                frente.PlacaVehiculo = null;   // Si SQL falló, se deshace en memoria
                throw;
            }

            vehiculo.Carga.Apilar(Almacen.Desencolar());
            return "";
        }

        // PILA → RUTA: el paquete del TOPE (último cargado) sale primero
        // y pasa a ser la siguiente parada de la ruta del vehículo.
        // Devuelve "" si se pudo, o el motivo si no.
        public static string EntregarTope(Vehiculo vehiculo)
        {
            if (vehiculo == null)
                return "Seleccione un vehículo.";

            Envio tope = vehiculo.Carga.VerTope();
            if (tope == null)
                return "La pila del vehículo está vacía.";

            DateTime ahora = DateTime.Now;
            string ubicacion = "Ruta " + vehiculo.Placa;
            string observacion = "Salió del vehículo para reparto";

            using (SqlConnection conexion = CrearConexion())
            {
                conexion.Open();
                using (SqlTransaction tx = conexion.BeginTransaction())
                {
                    try
                    {
                        ActualizarEstadoSQL(conexion, tx, tope, EstadoEnvio.EnReparto, ahora);
                        InsertarHistorial(conexion, tx, tope.Codigo,
                            EstadoEnvio.EnReparto, ahora, ubicacion, observacion);

                        // Nueva parada al final de la ruta de ese vehículo
                        string consulta =
                            "INSERT INTO ParadaRuta (PlacaVehiculo, CodigoEnvio, Orden) " +
                            "VALUES (@placa, @cod, " +
                            "(SELECT ISNULL(MAX(Orden), 0) + 1 FROM ParadaRuta WHERE PlacaVehiculo = @placa))";

                        using (SqlCommand comando = new SqlCommand(consulta, conexion, tx))
                        {
                            comando.Parameters.AddWithValue("@placa", vehiculo.Placa);
                            comando.Parameters.AddWithValue("@cod", tope.Codigo);
                            comando.ExecuteNonQuery();
                        }

                        tx.Commit();
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }

            // SQL guardó todo: se actualiza la memoria
            tope.CambiarEstado(EstadoEnvio.EnReparto, ubicacion, observacion);
            vehiculo.Carga.Desapilar();               // Pila: sale el tope (LIFO)
            vehiculo.Ruta.AgregarAlFinal(tope);       // Lista: nueva parada al final
            return "";
        }

        // PUNTO ÚNICO para cambiar el estado de un envío existente:
        // actualiza la tabla Envio y agrega el evento a HistorialEnvio.
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
                        string consulta =
                            "UPDATE Envio SET Estado = @estado, " +
                            "FechaActualizacion = @fecha, PlacaVehiculo = @placa " +
                            "WHERE Id = @id";

                        using (SqlCommand comando = new SqlCommand(consulta, conexion, tx))
                        {
                            comando.Parameters.AddWithValue("@estado", estado.ToString());
                            comando.Parameters.AddWithValue("@fecha", ahora);
                            comando.Parameters.AddWithValue("@placa", ValorONulo(envio.PlacaVehiculo));
                            comando.Parameters.AddWithValue("@id", envio.Id);
                            comando.ExecuteNonQuery();
                        }

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

        // ---------- Métodos privados de apoyo ----------

        // Si la persona ya existe (mismo DNI) se reutiliza y se actualizan
        // sus datos; si no existe, se inserta. Devuelve su Id.
        private static void ActualizarEstadoSQL(SqlConnection conexion,
           SqlTransaction tx, Envio envio, EstadoEnvio estado, DateTime fecha)
        {
            string consulta =
                "UPDATE Envio SET Estado = @estado, " +
                "FechaActualizacion = @fecha, PlacaVehiculo = @placa " +
                "WHERE Id = @id";

            using (SqlCommand comando = new SqlCommand(consulta, conexion, tx))
            {
                comando.Parameters.AddWithValue("@estado", estado.ToString());
                comando.Parameters.AddWithValue("@fecha", fecha);
                comando.Parameters.AddWithValue("@placa", ValorONulo(envio.PlacaVehiculo));
                comando.Parameters.AddWithValue("@id", envio.Id);
                comando.ExecuteNonQuery();
            }
        }
        private static int GuardarPersona(SqlConnection conexion,
            SqlTransaction tx, Persona persona)
        {
            string buscar = "SELECT Id FROM Persona WHERE NumeroDocumento = @doc";

            using (SqlCommand comando = new SqlCommand(buscar, conexion, tx))
            {
                comando.Parameters.AddWithValue("@doc", persona.NumeroDocumento);
                object id = comando.ExecuteScalar();

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

        // Inserta el envío con un código temporal y devuelve el Id que asignó SQL
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
                // Temporal (20 caracteres): el código real necesita el Id
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

        // Texto vacío o null de C# → NULL de SQL
        private static object ValorONulo(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
                return DBNull.Value;
            return valor;
        }

    }
}
