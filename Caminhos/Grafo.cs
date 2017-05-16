using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caminhos
{
    /// <summary>
    /// Classe de grafo para as cidades
    /// </summary>
    class Grafo
    {
        /// <summary>
        /// Estrutura para uma ligação entre cidades
        /// </summary>
        public class LigacaoCidades
        {
            int distancia;
            int velocidadeMedia;

            /// <summary>
            /// Distância entre as duas cidades
            /// </summary>
            public int Distancia
            {
                get { return distancia; }
                set
                {
                    if (value <= 0)
                        throw new Exception("Distância inválida");
                    distancia = value;
                }
            }

            /// <summary>
            /// Velocidade média do percurso
            /// </summary>
            public int VelocidadeMedia
            {
                get { return velocidadeMedia; }
                set
                {
                    if (value < 0)
                        throw new Exception("Velocidade inválida");
                    velocidadeMedia = value;
                }
            }

            /// <summary>
            /// Construtor
            /// </summary>
            /// <param name="dist"></param>
            /// <param name="vel"></param>
            public LigacaoCidades(int dist, int vel)
            {
                Distancia = dist;
                VelocidadeMedia = vel;
            }
        }
    }
}
