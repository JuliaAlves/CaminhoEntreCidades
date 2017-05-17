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
        class LigacaoCidades : IComparable<LigacaoCidades>
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

        /// <summary>
        /// Matriz das ligações
        /// </summary>
        LigacaoCidades[,] matriz;
        private List<string> cidades;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="cidades">Lista de cidades</param>
        public Grafo(List<string> cidades)
        {
            this.cidades = cidades;
            matriz = new LigacaoCidades[cidades.Count, cidades.Count];
        }

        /// <summary>
        /// Insere uma ligação
        /// </summary>
        /// <param name="cid1">Cidade de onde se sai</param>
        /// <param name="cid2">Cidade para onde se vai</param>
        /// <param name="dist">Distância</param>
        /// <param name="velo">Velocidade média</param>
        public void Inserir(string cid1, string cid2, int dist, int velo)
        {
            int i1 = cidades.IndexOf(cid1);
            int i2 = cidades.IndexOf(cid2);

            if (i1 < 0 || i2 < 0 || i1 == i2)
                throw new Exception("Operação inválida");

            matriz[i1, i2] = new LigacaoCidades(dist, velo);
        }

        /// <summary>
        /// Obtém uma ligação entre duas cidades
        /// </summary>
        /// <param name="cid1">Cidade de origem</param>
        /// <param name="cid2">Destino</param>
        /// <returns>Um objeto LigacaoCidades para a ligação ou null caso ela não exista</returns>
        private LigacaoCidades Ligacao(string cid1, string cid2)
        {
            int i1 = cidades.IndexOf(cid1);
            int i2 = cidades.IndexOf(cid2);

            if (i1 < 0 || i2 < 0 || i1 == i2)
                throw new Exception("Operação inválida");

            return matriz[i1, i2];
        }

        /// <summary>
        /// Obtém a distância entre duas cidades
        /// </summary>
        /// <param name="cid1">Cidade de origem</param>
        /// <param name="cid2">Destino</param>
        /// <returns>A distância entre as cidades ou -1 caso elas não tenham ligação</returns>
        public int Distancia(string cid1, string cid2)
        {
            return Ligacao(cid1, cid2)?.Distancia ?? -1;
        }

        /// <summary>
        /// Obtém a velocidade média do percurso entre duas cidades
        /// </summary>
        /// <param name="cid1">Cidade de origem</param>
        /// <param name="cid2">Destino</param>
        /// <returns>A velocidade média no percurso entre as cidades ou -1 
        /// caso elas não tenham ligação</returns>
        public int VelocidadeMedia(string cid1, string cid2)
        {
            return Ligacao(cid1, cid2)?.VelocidadeMedia ?? -1;
        }
        
        /// <summary>
        /// Obtém a lista de cidades para as quais uma outra cidade tem caminhos de saída
        /// </summary>
        /// <param name="cidade">Cidade de origem</param>
        /// <returns>Uma lista com o nome das cidades conectadas</returns>
        public List<string> Saidas(string cidade)
        {
            int i = cidades.IndexOf(cidade);
            if (i < 0)
                throw new Exception("Operação inválida");

            List<string> r = new List<string>();
            for (int j = 0; j < cidades.Count; j++)
                if (matriz[i, j] != null)
                    r.Add(cidades[j]);

            return r;
        }
    }
}
