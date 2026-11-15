using System;
using System.Collections.Generic;

namespace GRAFOS
{
    internal class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            grafo g = new grafo();

            g.agregarVertice("Lima");
            g.agregarVertice("Cusco");
            g.agregarVertice("Arequipa");
            g.agregarVertice("Trujillo");

            g.agregarArista("Lima", "Cusco", 1100);
            g.agregarArista("Lima", "Arequipa", 1000);
            g.agregarArista("Lima", "Trujillo", 560);
            g.agregarArista("Arequipa", "Cusco", 520);

            List<string> ciudades = g.obtenerVertices();

            FloydWarshall floyd = new FloydWarshall(g);
            int[,] distancias = floyd.Ejecutar();

            while (true)
            {
                Console.WriteLine("\n=== RUTAS ENTRE CIUDADES ===");
                Console.WriteLine("1. Mostrar las matrices de distancias");
                Console.WriteLine("2. Consultar la ruta más corta");
                Console.WriteLine("3. Ejecutar las pruebas");
                Console.WriteLine("0. Salir");
                Console.Write("Elige una opción: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("\n=== MATRIZ INICIAL ===");
                        FloydWarshall.ImprimirMatriz(g.obtenerMatriz(), ciudades);

                        Console.WriteLine("\n=== MATRIZ DE DISTANCIAS MÍNIMAS ===");
                        FloydWarshall.ImprimirMatriz(distancias, ciudades);
                        break;

                    case "2":
                        ConsultarRuta(floyd, distancias, ciudades);
                        break;

                    case "3":
                        Pruebas.EjecutarTodas();
                        break;

                    case "0":
                    case null:
                        return;

                    default:
                        Console.WriteLine("Opción inválida. Elige un número del menú.");
                        break;
                }
            }
        }

        static void ConsultarRuta(
            FloydWarshall floyd, int[,] distancias, List<string> ciudades)
        {
            Console.WriteLine("\n=== CIUDADES DISPONIBLES ===");
            for (int i = 0; i < ciudades.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {ciudades[i]}");
            }

            Console.Write("Número de la ciudad de origen: ");
            int origen = LeerIndiceCiudad(ciudades.Count);
            if (origen == -1)
                return;

            Console.Write("Número de la ciudad de destino: ");
            int destino = LeerIndiceCiudad(ciudades.Count);
            if (destino == -1)
                return;

            int distancia = distancias[origen, destino];

            if (distancia == grafo.Inf)
            {
                Console.WriteLine("No existe camino entre esas ciudades.");
                return;
            }

            string camino = origen == destino
                ? ciudades[origen]
                : floyd.ObtenerCamino(ciudades[origen], ciudades[destino]);

            Console.WriteLine($"\nRuta: {camino}");
            Console.WriteLine($"Distancia mínima: {distancia}");
        }

        static int LeerIndiceCiudad(int cantidadCiudades)
        {
            if (int.TryParse(Console.ReadLine(), out int numero)
                && numero >= 1 && numero <= cantidadCiudades)
            {
                return numero - 1;
            }

            Console.WriteLine($"Elige un número entre 1 y {cantidadCiudades}.");
            return -1;
        }
    }
}