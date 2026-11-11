using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRAFOS
{
    internal class Program
    {
        static void Main(string[] args)
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

            Console.WriteLine("\nVértices:");
            foreach (string verti in g.obtenerVertices())
            {
                Console.Write(verti + "  ");
            }
            Console.WriteLine();

            Console.WriteLine("\nMatriz de adyacencia:");
            int n = g.cantidadVertices();
            int[,] m = g.obtenerMatriz();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (m[i, j] == grafo.Inf)
                        Console.Write("Inf\t");
                    else
                        Console.Write(m[i, j] + "\t");
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}