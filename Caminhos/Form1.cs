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
        Dictionary<string, PointF> coordenadas;

        /// <summary>
        /// Construtor
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Lê o grafo do arquivo
        /// </summary>
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

            arq = new StreamReader("coordenadas.txt");

            arq.Close();
        }

        /// <summary>
        /// Carregamento do form
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            LerArquivo();
        }

        /// <summary>
        /// Desenho do canvas
        /// </summary>
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g = e.Graphics)
            {
                RectangleF bounds = g.ClipBounds;
                foreach (KeyValuePair<string, PointF> kvp in coordenadas)
                {
                    float ax = kvp.Value.X * bounds.Width,
                        ay = kvp.Value.Y * bounds.Height; 
                    g.FillEllipse(
                        new SolidBrush(Color.Black), 
                        ax, 
                        ay, 
                        8, 8
                    );

                    foreach (string cidade in distancias.Saidas(kvp.Key))
                    {
                        float bx = coordenadas[cidade].X * bounds.Width,
                                by = coordenadas[cidade].Y * bounds.Height;

                        Pen pen;
                        if (distancias.VelocidadeMedia(kvp.Key, cidade) <= 200)
                            pen = new Pen(Color.Orange);
                        else
                            pen = new Pen(Color.Purple);
                        g.DrawLine(pen, ax, ay, bx, by);

                        pen.Dispose();
                    }
                }
            }
        }
    }
}
