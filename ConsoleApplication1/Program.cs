using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<Tachos> tachos = new List<Tachos>();

            //tachos.Add(new Tachos { id = 1, distancia = 3, estoyLleno = true });
            //tachos.Add(new Tachos { id = 2, distancia = 4, estoyLleno = true });
            //tachos.Add(new Tachos { id = 3, distancia = 5, estoyLleno = true });
            //tachos.Add(new Tachos { id = 4, distancia = 6, estoyLleno = true });
            //tachos.Add(new Tachos { id = 5, distancia = 2, estoyLleno = true });


            #region Dijkstra

            ObtenerDataTachos();
            DefinirEInicializarRuta();

            for (int i = 0; i < totalTachos; i++)
            {
                var tachoProx = ObtenerTachoMasCercano();
                AgregarTachoARuta(tachoProx);
                EliminarTachoDeListado();
            }

            DibujarRuta();

            #endregion


        }
    }
}
