using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intento
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ingrese la dimensión de la matriz: ");
            int dimensionMatriz = Convert.ToInt32(Console.ReadLine());

            int[,] matriz = new int[dimensionMatriz, dimensionMatriz];

            Random rnd = new Random();

            for (int a = 0; a <= dimensionMatriz - 1; a++)
            {
                for (int b = 0; b <= dimensionMatriz - 1; b++)
                {
                    //Console.Write("[{0}],[{1}]", a, b);
                    //matriz[a, b] = Convert.ToInt16(Console.ReadLine());
                    matriz[a, b] = rnd.Next(1, 10);
                }
            }

            Console.WriteLine();

            // Algoritmo de Fuerza bruta
            Console.WriteLine("Algoritmo de Fuerza Bruta:");
            FBAlgoritm fbAlgoritm = new FBAlgoritm(matriz);
            fbAlgoritm.Work();
            Console.ReadLine();

            Console.WriteLine();

            // Algoritmo de Dijkstra
            Console.WriteLine("Algoritmo de Dijkstra:");
            DAlgoritm dAlgoritm = new DAlgoritm(matriz);
            dAlgoritm.Work();
            Console.ReadLine();
        }
    }
}
