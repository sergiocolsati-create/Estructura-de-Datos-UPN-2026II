using System;
using System.Collections.Generic;

namespace GRAFOS
{
    // Clase que aplica el algoritmo de Floyd-Warshall sobre un objeto grafo.
    // Calcula la distancia más corta entre TODOS los pares de vértices.
    public class FloydWarshall
    {
        private grafo g;              // grafo de trabajo
        private int n;                // cantidad de vértices reales
        private int[,] distancias;    // matriz de distancias mínimas (resultado)
        private int[,] siguiente;     // para reconstruir el camino: siguiente[i,j] = próximo vértice al ir de i a j

        public FloydWarshall(grafo grafo)
        {
            g = grafo;
            n = g.cantidadVertices();
        }

        // Ejecuta el algoritmo y devuelve la matriz de distancias mínimas
        public int[,] Ejecutar()
        {
            int[,] original = g.obtenerMatriz();
            distancias = new int[n, n];
            siguiente = new int[n, n];

            // PASO 1: Copiar la matriz de adyacencia (para no modificar la original)
            // y preparar la matriz "siguiente".
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    distancias[i, j] = original[i, j];

                    // Si hay arista directa, el siguiente paso de i hacia j es j
                    if (original[i, j] != grafo.Inf && i != j)
                        siguiente[i, j] = j;
                    else
                        siguiente[i, j] = -1;   // -1 = no hay camino (aún)
                }
            }

            // PASO 2: Programación dinámica.
            // k = vértice intermedio que se "prueba" como puente.
            // Para cada par (i, j) se pregunta: ¿es más corto ir de i a j pasando por k?
            for (int k = 0; k < n; k++)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        // Solo se compara si existen los tramos i->k y k->j
                        if (distancias[i, k] != grafo.Inf && distancias[k, j] != grafo.Inf)
                        {
                            int pasandoPorK = distancias[i, k] + distancias[k, j];

                            if (pasandoPorK < distancias[i, j])
                            {
                                distancias[i, j] = pasandoPorK;     // se guarda la distancia menor
                                siguiente[i, j] = siguiente[i, k];  // el camino ahora sale hacia k
                            }
                        }
                    }
                }
            }

            return distancias;
        }

        // Devuelve el camino más corto entre dos ciudades, ej: "Trujillo -> Lima -> Cusco"
        public string ObtenerCamino(string origen, string destino)
        {
            List<string> vertices = g.obtenerVertices();
            int i = vertices.IndexOf(origen);
            int j = vertices.IndexOf(destino);

            if (i == -1 || j == -1) return "Vértice no encontrado.";
            if (siguiente[i, j] == -1) return "No existe camino.";

            string camino = vertices[i];
            while (i != j)
            {
                i = siguiente[i, j];            // avanzar al siguiente vértice
                camino += " -> " + vertices[i];
            }
            return camino;
        }

        // Imprime cualquier matriz n x n con los nombres de los vértices como encabezado
        public static void ImprimirMatriz(int[,] m, List<string> vertices)
        {
            int n = vertices.Count;

            Console.Write("\t\t");
            foreach (string v in vertices) Console.Write(v + "\t");
            Console.WriteLine();

            for (int i = 0; i < n; i++)
            {
                Console.Write(vertices[i] + "\t\t");
                for (int j = 0; j < n; j++)
                {
                    if (m[i, j] == grafo.Inf)
                        Console.Write("Inf\t");
                    else
                        Console.Write(m[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}