using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intento
{
    class Algoritm
    {
        private int repeats;
        private int cantNodos;
        private List<int> nodos;
        private List<string> listadoCaminos;
        public int minDistance;
        private int[,] matrizNodos;

        public Algoritm(int[,] matriz)
        {
            matrizNodos = matriz;
            cantNodos = Convert.ToInt32(Math.Sqrt(matriz.Length));

            // Calculo la cantidad de veces que voy a repetir la búsqueda del camino más óptimo. 
            // En un grafo de "n" nodos, hay (n-1)!/2 caminos posibles. Se divide por 2 porque hay caminos inversos -duplicados-.
            repeats = Factorial(cantNodos - 1);

            minDistance = Int32.MaxValue;
        }

        public void Work()
        {
            // Cargo una lista de todos los nodos, menos el raíz.
            nodos = new List<int>();
            for (int k = 1; k < cantNodos; k++)
                nodos.Add(k);

            string[] nodosEnString = new string[cantNodos - 1];
            int contador = 0;
            foreach (int nodo in nodos)
            {
                nodosEnString[contador] = nodo.ToString();
                contador++;
            }

            ProcesarCaminos(nodosEnString, "", cantNodos - 1, cantNodos - 1);

            //Random random = new Random();

            //listadoCaminos = new List<string>();

            // En cada iteración busco un camino Random y hallo su longitud total.
            //for (int i = 0; i < repeats; i++)
            //{
            //    // Copio la lista de nodos, para ir recorriéndola y sacando los nodos a procesar.
            //    List<int> nodosSinProcesar = nodos.ToList();

            //    List<int> camino = new List<int>();
            //camino.Add(0);

            //int nodosRestantes;

            //// De forma random voy seleccionando nodos y armando el camino. 
            //for (int n = 1; n < cantNodos; n++)
            //{
            //    nodosRestantes = cantNodos - n;

            //    // Selecciono el nodo, lo agrego al camino y lo elimino de la lista de nodos sin procesar. 
            //    int indiceNodoSeleccionado = random.Next(nodosRestantes);
            //    camino.Add(nodosSinProcesar[indiceNodoSeleccionado]);
            //    nodosSinProcesar.RemoveAt(indiceNodoSeleccionado);
            //}

            //camino.Add(0);

            //if (listadoCaminos.Exists(l => l.SequenceEqual(camino)))
            //{
            //    i--;
            //    continue;
            //}
            //else
            //    listadoCaminos.Add(camino);
            //}

            //int count = 1;
            //foreach (List<int> unCamino in listadoCaminos)
            //{
            //    string msj = "El camino es: ";
            //    foreach (int nodo in unCamino)
            //        msj += nodo + ", ";

            //    msj = msj.Trim().TrimEnd(',') + ". Iteración " + count + " de " + repeats;
            //    Console.WriteLine(msj);

            //    count++;
            //}

        }

        private void ProcesarCaminos(string[] nodos, string caminoAux, int n, int length)
        {
            if (n == 0)
                EvaluarCamino("0, " + caminoAux.Trim().TrimEnd(',') + ", 0");
            else
            {
                for (int i = 0; i < length; i++)
                {
                    if (!caminoAux.Contains(nodos[i]))
                    { // Controla que no haya repeticiones
                        ProcesarCaminos(nodos, caminoAux + nodos[i] + ", ", n - 1, length);
                    }
                }
            }
        }

        private void EvaluarCamino(string camino)
        {
            string[] nodos = camino.Split(',');
            int totalDistance = 0;
            for (int i = 0; i < nodos.Length - 1; i++)
                totalDistance += matrizNodos[Convert.ToInt16(nodos[i]), Convert.ToInt16(nodos[i + 1])];

            if (totalDistance < minDistance)
            {
                minDistance = totalDistance;
                Console.WriteLine("Camino: " + camino + ". Distancia: " + totalDistance);
            }
                
        }

        private int Factorial(int number)
        {
            int factorial = 1;

            for (int counter = 1; counter <= number; counter++)
                factorial = factorial * counter;

            return factorial;
        }
    }
}
