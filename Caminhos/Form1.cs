using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caminhos
{
    public partial class Form1 : Form
    {
        Grafo grafo;
        Dictionary<string, PointF> coordenadas;
        string[][] caminhos;

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
                string cid1 = linha.Substring(0, 15).Trim();
                string cid2 = linha.Substring(15, 15).Trim();

                if (!cidades.Contains(cid1))
                    cidades.Add(cid1);

                if (!cidades.Contains(cid2))
                    cidades.Add(cid2);
            }

            grafo = new Grafo(cidades);
            arq.BaseStream.Seek(0, SeekOrigin.Begin);
            arq.ReadLine();

            while((linha = arq.ReadLine()) != null)
            {
                string cid1 = linha.Substring(0, 15).Trim();
                string cid2 = linha.Substring(15, 15).Trim();
                int dist = Convert.ToInt32(linha.Substring(31, 4));
                int velo = Convert.ToInt32(linha.Substring(36));
                grafo.InserirLigacao(cid1,cid2,dist, velo);
            }

            arq.Close();

            arq = new StreamReader("coordenadas.txt");
            coordenadas = new Dictionary<string, PointF>();

            while ((linha = arq.ReadLine()) != null)
            {
                string cid = linha.Substring(0, 15).Trim();
                float x = (float)Convert.ToDouble(linha.Substring(15, 4));
                float y = (float)Convert.ToDouble(linha.Substring(23));
                coordenadas.Add(cid, new PointF(x, y));
            }

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
            if (lsbCaminhos.SelectedItem == null)
                return;

            Graphics g = e.Graphics;
            RectangleF bounds = g.ClipBounds;

            string anterior = null;
            float ax = 0, ay = 0, bx, by;

            string[] caminho = ((string)lsbCaminhos.SelectedItem).Split(',');
            foreach (string atual in caminho)
            {
                bx = coordenadas[atual].X * bounds.Width;
                by = coordenadas[atual].Y * bounds.Height;

                if (anterior != null)
                {
                    Pen pen;
                    if (grafo.GetVelocidadeMedia(anterior, atual) <= 200)
                        pen = new Pen(Color.Orange);
                    else
                        pen = new Pen(Color.Purple);
                    pen.Width = 4;

                    g.DrawLine(pen, ax, ay, bx, by);

                    pen.Dispose();
                }

                ax = bx;
                ay = by;
                anterior = atual;
            }
        }

        /// <summary>
        /// Clique no botão procurar
        /// </summary>
        private void btnProcurar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOrigem.Text))
            {
                SystemSounds.Exclamation.Play();
                txtOrigem.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDestino.Text))
            {
                SystemSounds.Exclamation.Play();
                txtDestino.Focus();
                return;
            }

            try
            {
                caminhos = grafo.ProcurarCaminhos(txtOrigem.Text, txtDestino.Text).OrderBy((string[] caminho) =>
                {
                    return grafo.Peso(caminho);
                }).ToArray();

                if (caminhos == null)
                    MessageBox.Show("Não existe caminho entre essas cidades, desculpe.", "Ooops", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    lsbCaminhos.Items.Clear();
                    foreach (string[] caminho in caminhos)
                        lsbCaminhos.Items.Add(string.Join(",", caminho));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("A cidade especificada não existe", "Ooops", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            pictureBox1.Invalidate();
        }

        /// <summary>
        /// Evento de seleção de item na listBox
        /// Redesenha a pictureBox para mostrar o caminho no mapa
        /// </summary>
        private void lsbCaminhos_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }
    }
}
