using System;
using System.Collections.Generic;

namespace GRAFOS
{
    // PARTE 3: Casos de prueba para VALIDAR la implementación de Floyd-Warshall.
    // Cada prueba compara la matriz que calcula el programa contra la matriz
    // esperada (calculada a mano / validada con IA) y muestra CORRECTO o ERROR.
    public static class Pruebas
    {
        static int I = grafo.Inf;   // abreviatura para "no hay camino"

        public static void EjecutarTodas()
        {
            Console.WriteLine("\n\n========== PARTE 3: VALIDACIÓN CON CASOS DE PRUEBA ==========");
            Prueba1_CiudadesPeru();
            Prueba2_GrafoDirigido();
            Prueba3_CaminoIndirectoMasCorto();
            Prueba4_VerticeAislado();
        }

        // ---------------------------------------------------------------
        // Prueba 1: el grafo del laboratorio (no dirigido).
        // Trujillo no tiene ruta directa a Cusco ni a Arequipa:
        // el algoritmo debe encontrar el camino pasando por Lima.
        // ---------------------------------------------------------------
        static void Prueba1_CiudadesPeru()
        {
            grafo g = new grafo();
            g.agregarVertice("Lima");
            g.agregarVertice("Cusco");
            g.agregarVertice("Arequipa");
            g.agregarVertice("Trujillo");
            g.agregarArista("Lima", "Cusco", 1100);
            g.agregarArista("Lima", "Arequipa", 1000);
            g.agregarArista("Lima", "Trujillo", 560);
            g.agregarArista("Arequipa", "Cusco", 520);

            int[,] esperado =
            {
                {    0, 1100, 1000,  560 },
                { 1100,    0,  520, 1660 },
                { 1000,  520,    0, 1560 },
                {  560, 1660, 1560,    0 }
            };

            FloydWarshall fw = new FloydWarshall(g);
            Verificar("Prueba 1 - Ciudades del Perú (no dirigido)", fw.Ejecutar(), esperado, g.obtenerVertices());
            VerificarCamino(fw, "Trujillo", "Cusco", "Trujillo -> Lima -> Cusco");
        }

        // ---------------------------------------------------------------
        // Prueba 2: grafo DIRIGIDO (A->B no es lo mismo que B->A).
        // Caso clásico usado para enseñar Floyd-Warshall.
        // ---------------------------------------------------------------
        static void Prueba2_GrafoDirigido()
        {
            grafo g = new grafo();
            g.agregarVertice("A");
            g.agregarVertice("B");
            g.agregarVertice("C");
            g.agregarVertice("D");
            g.agregarArista("A", "B", 3, true);
            g.agregarArista("A", "D", 7, true);
            g.agregarArista("B", "A", 8, true);
            g.agregarArista("B", "C", 2, true);
            g.agregarArista("C", "A", 5, true);
            g.agregarArista("C", "D", 1, true);
            g.agregarArista("D", "A", 2, true);

            int[,] esperado =
            {
                { 0, 3, 5, 6 },
                { 5, 0, 2, 3 },
                { 3, 6, 0, 1 },
                { 2, 5, 7, 0 }
            };

            FloydWarshall fw = new FloydWarshall(g);
            Verificar("Prueba 2 - Grafo dirigido", fw.Ejecutar(), esperado, g.obtenerVertices());
            // A->D directo cuesta 7, pero A->B->C->D cuesta 3+2+1 = 6
            VerificarCamino(fw, "A", "D", "A -> B -> C -> D");
        }

        // ---------------------------------------------------------------
        // Prueba 3: existe arista directa, pero el camino indirecto es más corto.
        // X-Y directo = 10 ; X-Z-Y = 3 + 4 = 7  -> debe quedar 7
        // ---------------------------------------------------------------
        static void Prueba3_CaminoIndirectoMasCorto()
        {
            grafo g = new grafo();
            g.agregarVertice("X");
            g.agregarVertice("Y");
            g.agregarVertice("Z");
            g.agregarArista("X", "Y", 10);
            g.agregarArista("X", "Z", 3);
            g.agregarArista("Z", "Y", 4);

            int[,] esperado =
            {
                { 0, 7, 3 },
                { 7, 0, 4 },
                { 3, 4, 0 }
            };

            FloydWarshall fw = new FloydWarshall(g);
            Verificar("Prueba 3 - Camino indirecto más corto que el directo", fw.Ejecutar(), esperado, g.obtenerVertices());
            VerificarCamino(fw, "X", "Y", "X -> Z -> Y");
        }

        // ---------------------------------------------------------------
        // Prueba 4: vértice aislado (sin aristas).
        // Su distancia hacia los demás debe seguir siendo Inf (sin camino).
        // ---------------------------------------------------------------
        static void Prueba4_VerticeAislado()
        {
            grafo g = new grafo();
            g.agregarVertice("Lima");
            g.agregarVertice("Ica");
            g.agregarVertice("Puno");          // no se conecta con nadie
            g.agregarArista("Lima", "Ica", 300);

            int[,] esperado =
            {
                {   0, 300, I },
                { 300,   0, I },
                {   I,   I, 0 }
            };

            FloydWarshall fw = new FloydWarshall(g);
            Verificar("Prueba 4 - Vértice aislado", fw.Ejecutar(), esperado, g.obtenerVertices());
            VerificarCamino(fw, "Lima", "Puno", "No existe camino.");
        }

        // Compara la matriz obtenida con la esperada, celda por celda
        static void Verificar(string nombre, int[,] obtenido, int[,] esperado, List<string> vertices)
        {
            int n = vertices.Count;
            bool correcto = true;

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (obtenido[i, j] != esperado[i, j])
                        correcto = false;

            Console.WriteLine("\n--- " + nombre + " ---");
            FloydWarshall.ImprimirMatriz(obtenido, vertices);
            Console.WriteLine(correcto ? "Resultado: CORRECTO" : "Resultado: ERROR (no coincide con lo esperado)");
        }

        // Compara el camino reconstruido con el esperado
        static void VerificarCamino(FloydWarshall fw, string origen, string destino, string esperado)
        {
            string camino = fw.ObtenerCamino(origen, destino);
            string estado = (camino == esperado) ? "CORRECTO" : "ERROR";
            Console.WriteLine("Camino " + origen + " a " + destino + ": " + camino + "  [" + estado + "]");
        }
    }
}