using System;
using System.Collections.Generic;

namespace GRAFOS
{
    public class grafo
    {
        public const int Inf = int.MaxValue / 2;

        private List<string> vertices;
        private int[,] matriz;
        private int capacidad;

        public grafo(int capacidadMaxima = 10)
        {
            capacidad = capacidadMaxima;
            vertices = new List<string>();
            matriz = new int[capacidad, capacidad];

            for (int i = 0; i < capacidad; i++)
                for (int j = 0; j < capacidad; j++)
                    matriz[i, j] = (i == j) ? 0 : Inf;
        }

        public void agregarVertice(string nombre)
        {
            if (vertices.Count >= capacidad)
            {
                Console.WriteLine("No se pueden agregar más vértices.");
                return;
            }
            if (vertices.Contains(nombre))
            {
                Console.WriteLine("El vértice " + nombre + " ya existe.");
                return;
            }
            vertices.Add(nombre);
        }

        public void agregarArista(string origen, string destino, int peso, bool dirigido = false)
        {
            int i = vertices.IndexOf(origen);
            int j = vertices.IndexOf(destino);
            if (i == -1 || j == -1)
            {
                Console.WriteLine("Vértice no encontrado.");
                return;
            }
            matriz[i, j] = peso;
            if (!dirigido) matriz[j, i] = peso;
        }

        public List<string> obtenerVertices()
        {
            return vertices;
        }

        public int cantidadVertices()
        {
            return vertices.Count;
        }

        public int[,] obtenerMatriz()
        {
            return matriz;
        }
    }
}