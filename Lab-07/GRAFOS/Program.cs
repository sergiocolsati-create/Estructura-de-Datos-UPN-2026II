using System;
using System.Collections.Generic;

namespace GRAFOS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;   // para que se vean las tildes

            // 1. Crear el grafo (parte 1, ya implementada)
            grafo g = new grafo();

            g.agregarVertice("Lima");
            g.agregarVertice("Cusco");
            g.agregarVertice("Arequipa");
            g.agregarVertice("Trujillo");

            g.agregarArista("Lima", "Cusco", 1100);
            g.agregarArista("Lima", "Arequipa", 1000);
            g.agregarArista("Lima", "Trujillo", 560);
            g.agregarArista("Arequipa", "Cusco", 520);

            List<string> vertices = g.obtenerVertices();

            // 2. Mostrar la matriz INICIAL (pesos de las aristas directas)
            Console.WriteLine("=== MATRIZ DE DISTANCIAS INICIAL ===");
            FloydWarshall.ImprimirMatriz(g.obtenerMatriz(), vertices);

            // 3. Aplicar Floyd-Warshall
            FloydWarshall fw = new FloydWarshall(g);
            int[,] resultado = fw.Ejecutar();

            // 4. Mostrar la matriz FINAL (distancias más cortas)
            Console.WriteLine("\n=== MATRIZ DE DISTANCIAS FINAL (Floyd-Warshall) ===");
            FloydWarshall.ImprimirMatriz(resultado, vertices);

            // 5. Mostrar algunos caminos reconstruidos
            Console.WriteLine("\n=== CAMINOS MÁS CORTOS ===");
            Console.WriteLine(fw.ObtenerCamino("Trujillo", "Cusco"));
            Console.WriteLine(fw.ObtenerCamino("Trujillo", "Arequipa"));
            Console.WriteLine(fw.ObtenerCamino("Cusco", "Arequipa"));

            // 6. PARTE 3: validar la implementación con casos de prueba
            Pruebas.EjecutarTodas();

            Console.ReadKey();
        }
    }
}