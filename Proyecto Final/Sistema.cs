using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Shalom
{
    internal static class Sistema
    {
        // CONEXIÓN A SQL SERVER
        private static readonly string cadenaConexion =
            @"Data Source=localhost;Initial Catalog=ShalomDB;Integrated Security=True;";// Es importante actualizar la direccion de la conexion a BD en SSMS

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

                    // Solo los envíos en reparto pertenecen a una ruta
                    if (vehiculo != null && envio != null &&
                        envio.Estado == EstadoEnvio.EnReparto)
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

        // =========================================================
        //  RUTAS (pila del vehículo ↔ lista de paradas)
        // =========================================================

        // PILA → RUTA: el TOPE de la pila (último cargado, LIFO) pasa a ser una parada.
        // codigoReferencia = null  → se agrega al final de la ruta
        // codigoReferencia = guía  → se inserta después de esa parada
        // Devuelve "" si se pudo, o el motivo si no.
        public static string AsignarTope(Vehiculo vehiculo, string codigoReferencia)
        {
            if (vehiculo == null)
                return "Seleccione un vehículo.";

            Envio tope = vehiculo.Carga.VerTope();
            if (tope == null)
                return "No hay paquetes en el vehículo pendientes de asignar.";

            // 1. Memoria: se mueve de la pila a la lista
            if (codigoReferencia == null)
            {
                vehiculo.Ruta.AgregarAlFinal(tope);
            }
            else if (!vehiculo.Ruta.InsertarDespues(codigoReferencia, tope))
            {
                return "No se encontró la parada de referencia.";
            }
            vehiculo.Carga.Desapilar();

            // 2. SQL: estado, historial y el nuevo orden de la ruta
            try
            {
                GuardarCambioRuta(vehiculo, tope, EstadoEnvio.EnReparto,
                    "Ruta " + vehiculo.Placa, "Asignado a la ruta de reparto");
            }
            catch
            {
                CargarDatosSQL();   // Si SQL falló, la memoria vuelve a ser igual a la base
                throw;
            }

            tope.CambiarEstado(EstadoEnvio.EnReparto,
                "Ruta " + vehiculo.Placa, "Asignado a la ruta de reparto");
            return "";
        }

        // Atajo usado por "Entregar tope" en Carga del vehículo: tope al final de la ruta
        public static string EntregarTope(Vehiculo vehiculo)
        {
            return AsignarTope(vehiculo, null);
        }

        // RUTA → PILA: la parada se elimina y el paquete vuelve al TOPE del vehículo,
        // quedando otra vez en "Paquetes por asignar".
        public static string QuitarParada(Vehiculo vehiculo, string codigo)
        {
            if (vehiculo == null)
                return "Seleccione un vehículo.";

            Envio envio = Registro.Buscar(codigo);
            if (envio == null || !vehiculo.Ruta.Contiene(codigo))
                return "La parada no pertenece a la ruta de este vehículo.";

            if (vehiculo.Carga.PesoActual + envio.PesoKg > vehiculo.CapacidadKg)
                return "No hay espacio en el vehículo para devolver el paquete " + codigo + ".";

            // 1. Memoria: sale de la lista y vuelve a la pila
            vehiculo.Ruta.EliminarParada(codigo);
            vehiculo.Carga.Apilar(envio);

            // 2. SQL
            try
            {
                GuardarCambioRuta(vehiculo, envio, EstadoEnvio.EnTransito,
                    "Vehículo " + vehiculo.Placa, "Retirado de la ruta, vuelve al vehículo");
            }
            catch
            {
                CargarDatosSQL();
                throw;
            }

            envio.CambiarEstado(EstadoEnvio.EnTransito,
                "Vehículo " + vehiculo.Placa, "Retirado de la ruta, vuelve al vehículo");
            return "";
        }

        // Guarda en una transacción: estado del envío, evento del historial
        // y la ruta completa del vehículo en su orden actual.
        private static void GuardarCambioRuta(Vehiculo vehiculo, Envio envio,
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
                        GuardarRuta(conexion, tx, vehiculo);
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

        // Reescribe ParadaRuta con el orden actual de la lista doble.
        // Así "Insertar después" y "Eliminar" quedan bien numerados (1, 2, 3...).
        private static void GuardarRuta(SqlConnection conexion, SqlTransaction tx, Vehiculo vehiculo)
        {
            using (SqlCommand borrar = new SqlCommand(
                "DELETE FROM ParadaRuta WHERE PlacaVehiculo = @placa", conexion, tx))
            {
                borrar.Parameters.AddWithValue("@placa", vehiculo.Placa);
                borrar.ExecuteNonQuery();
            }

            Envio[] paradas = vehiculo.Ruta.ObtenerEnvios();
            for (int i = 0; i < paradas.Length; i++)
            {
                using (SqlCommand insertar = new SqlCommand(
                    "INSERT INTO ParadaRuta (PlacaVehiculo, CodigoEnvio, Orden) VALUES (@placa, @cod, @orden)",
                    conexion, tx))
                {
                    insertar.Parameters.AddWithValue("@placa", vehiculo.Placa);
                    insertar.Parameters.AddWithValue("@cod", paradas[i].Codigo);
                    insertar.Parameters.AddWithValue("@orden", i + 1);
                    insertar.ExecuteNonQuery();
                }
            }
        }

        // =========================================================
        //  RASTREO
        // =========================================================

        // Marca como ENTREGADO un envío que está en reparto:
        // sale de la ruta del vehículo y queda solo en el árbol.
        public static string MarcarEntregado(Envio envio, string observacion)
        {
            if (envio.Estado != EstadoEnvio.EnReparto)
                return "Solo se puede entregar un envío que está En reparto (estado actual: " + envio.Estado + ").";

            Vehiculo vehiculo = BuscarVehiculoPorPlaca(envio.PlacaVehiculo);
            if (vehiculo == null)
                return "No se encontró el vehículo del envío.";

            string ubicacion = envio.SedeDestino.Nombre;
            if (string.IsNullOrWhiteSpace(observacion))
                observacion = "Entregado al destinatario";

            vehiculo.Ruta.EliminarParada(envio.Codigo);   // Lista doble: deja de ser parada

            try
            {
                GuardarCambioRuta(vehiculo, envio, EstadoEnvio.Entregado, ubicacion, observacion);
            }
            catch
            {
                CargarDatosSQL();
                throw;
            }

            envio.CambiarEstado(EstadoEnvio.Entregado, ubicacion, observacion);
            return "";
        }

        // Registra una INCIDENCIA en el historial (retraso, daño, etc.).
        // El paquete NO cambia de estructura: sigue en la cola, pila o ruta donde estaba.
        public static string RegistrarIncidencia(Envio envio, string observacion)
        {
            if (string.IsNullOrWhiteSpace(observacion))
                return "Describa la incidencia en el campo Observación.";

            DateTime ahora = DateTime.Now;
            string ubicacion = "Rastreo";

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

            // Solo se agrega el evento; el estado del envío no cambia
            envio.Historial.AgregarAlFinal(
                new EventoRastreo(EstadoEnvio.Incidencia, ubicacion, observacion));
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

        // ---------- Métodos privados de apoyo ----------

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

        // Si la persona ya existe (mismo DNI) se reutiliza y se actualizan
        // sus datos; si no existe, se inserta. Devuelve su Id.
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

        public static Tarifa BuscarTarifa(int origenId, int destinoId)
        {
            string consulta = @"
        SELECT SedeOrigenId, SedeDestinoId, PrecioBase, PrecioPorKg
        FROM logistica.TarifaTrayecto
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
    }
}