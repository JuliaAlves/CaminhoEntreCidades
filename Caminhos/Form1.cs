using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caminhos
{
    public partial class Form1 : Form
    {
        Grafo distancias;
        public Form1()
        {
            InitializeComponent();
        }

        private void LerArquivo()
        {
            StreamReader arq = new StreamReader("caminhos.txt");
            string linha = "";
            arq.ReadLine();
            List<string> cidades = new List<string>();
            while ((linha = arq.ReadLine()) != null)
            {
                string cid1 = linha.Substring(0, 16);
                string cid2 = linha.Substring(16, 16);

                if (!cidades.Contains(cid1))
                    cidades.Add(cid1);

                if (!cidades.Contains(cid2))
                    cidades.Add(cid2);
            }

            distancias = new Grafo(cidades);
            arq.BaseStream.Seek(0, SeekOrigin.Begin);

            while((linha = arq.ReadLine()) != null)
            {
                string cid1 = linha.Substring(0, 16);
                string cid2 = linha.Substring(16, 16);
                int dist = Convert.ToInt32(linha.Substring(32,4));
                int velo = Convert.ToInt32(linha.Substring(36, 4));
                distancias.Inserir(cid1,cid2,dist, velo);
            }

            arq.Close();
        }
    }
}
