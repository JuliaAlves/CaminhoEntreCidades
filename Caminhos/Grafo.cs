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
        public class LigacaoCidades : IComparable<LigacaoCidades>
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
            /// <param name="dist">Distância</param>
            /// <param name="vel">Velocidade</param>
            public LigacaoCidades(int dist, int vel)
            {
                Distancia = dist;
                VelocidadeMedia = vel;
            }

            /// <summary>
            /// Compara uma ligação a outra
            /// </summary>
            /// <param name="ligacao">Outra ligação</param>
            /// <returns>menor que 0 se for menor, 0 se for igual e maior que 0 se for maior</returns>
            public int CompareTo(LigacaoCidades ligacao)
            {
                return Distancia / VelocidadeMedia - ligacao.Distancia / ligacao.VelocidadeMedia;
            }
        }

        internal void Inserir(string cid1, string cid2, int dist, int velo)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Matriz das ligações
        /// </summary>
        LigacaoCidades[,] matriz;
        private List<string> cidades;

        public Grafo(List<string> cidades)
        {
            this.cidades = cidades;
        }
    }
}
