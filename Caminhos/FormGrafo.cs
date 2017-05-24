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
    public partial class FormGrafo : Form
    {
        Dictionary<string, PointF> coordenadas;
        string[][] caminhos;

        internal Grafo Grafo { get; private set; }

        /// <summary>
        /// Construtor
        /// </summary>
        public FormGrafo()
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

            Grafo = new Grafo(cidades);
            arq.BaseStream.Seek(0, SeekOrigin.Begin);
            arq.ReadLine();

            while((linha = arq.ReadLine()) != null)
            {
                string cid1 = linha.Substring(0, 15).Trim();
                string cid2 = linha.Substring(15, 15).Trim();
                int dist = Convert.ToInt32(linha.Substring(31, 4));

                int velo = Convert.ToInt32(linha.Substring(36,4));
                double pre = Convert.ToDouble(linha.Substring(43));
                Grafo.InserirLigacao(cid1,cid2,dist, velo, pre);
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

            foreach (string cidade in coordenadas.Keys)
            {
                cbOrigem.Items.Add(cidade);
                cbDestino.Items.Add(cidade);
            }
        }

        /// <summary>
        /// Desenho do canvas
        /// </summary>
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (caminhos == null)
                return;

            Graphics g = e.Graphics;
            RectangleF bounds = g.ClipBounds;

            string anterior = null;
            float ax = 0, ay = 0, bx, by;

            // Desenha todos os caminhos em preto, pra facilitar a visualização
            // do grafo
            foreach (string[] percurso in caminhos)
            {
                foreach (string atual in percurso)
                {
                    bx = coordenadas[atual].X * bounds.Width;
                    by = coordenadas[atual].Y * bounds.Height;

                    if (anterior != null)
                        using (Pen pen = new Pen(Color.Black, 2))
                            g.DrawLine(pen, ax, ay, bx, by);

                    ax = bx;
                    ay = by;
                    anterior = atual;
                }

                anterior = null;
            }

            if (lsbCaminhos.SelectedItem == null)
                return;

            // Destaca o caminho selecionado
            string[] caminho = ((string)lsbCaminhos.SelectedItem).Split(',');
            foreach (string atual in caminho)
            {
                bx = coordenadas[atual].X * bounds.Width;
                by = coordenadas[atual].Y * bounds.Height;

                if (anterior != null)
                {
                    Pen pen;
                    if (Grafo.GetVelocidadeMedia(anterior, atual) <= 200)
                        pen = new Pen(Color.Orange);
                    else
                        pen = new Pen(Color.Purple);
                    pen.Width = 6;

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
            if (string.IsNullOrWhiteSpace(cbOrigem.Text))
            {
                SystemSounds.Exclamation.Play();
                cbOrigem.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(cbDestino.Text))
            {
                SystemSounds.Exclamation.Play();
                cbDestino.Focus();
                return;
            }

            try
            {
                caminhos = Grafo.ProcurarCaminhos(cbOrigem.Text, cbDestino.Text);

                if (caminhos == null)
                    MessageBox.Show("Não existe caminho entre essas cidades, desculpe.", "Ooops", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    caminhos = new List<string[]>(caminhos).OrderBy((string[] caminho) =>
                    {
                        return Grafo.GetTempo(caminho);
                    }).ToArray();

                    lsbCaminhos.Items.Clear();
                    foreach (string[] caminho in caminhos)
                    {
                        lsbCaminhos.Items.Add(string.Join(",", caminho));

                        if (lsbCaminhos.Items.Count == 4)
                            break;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("A cidade especificada não existe", "Ooops", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            pictureBox1.Invalidate();
        }

        /// <summary>
        /// Atualiza a list box com o caminho
        /// </summary>
        private void AtualizarLista()
        {
            caminhos = new List<string[]>(caminhos).OrderBy((string[] caminho) =>
            {
                if (rdTempo.Checked)
                    return Grafo.GetTempo(caminho);
                else if (rdDist.Checked)
                    return Grafo.GetDistancia(caminho);
                else
                    return Grafo.GetPreco(caminho);
            }).ToArray();

            lsbCaminhos.Items.Clear();
            foreach (string[] caminho in caminhos)
            {
                lsbCaminhos.Items.Add(string.Join(",", caminho));

                if (lsbCaminhos.Items.Count == 4)
                    break;
            }
        }

        /// <summary>
        /// Evento de seleção de item na listBox
        /// Redesenha a pictureBox para mostrar o caminho no mapa
        /// </summary>
        private void lsbCaminhos_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();

            if (lsbCaminhos.SelectedItem == null)
                return;

            string[] cids = ((string)lsbCaminhos.SelectedItem).Split(',');
            double preco = Grafo.GetPreco(cids),
                tempo = Grafo.GetTempo(cids),
                dist = Grafo.GetDistancia(cids);

            int horas = (int)Math.Floor(tempo), 
                minutos = (int)((tempo - horas) * 60);

            lblPre.Text = preco.ToString("C2");
            lblTempo.Text = string.Format("{0} horas e {1} minutos", horas, minutos);
            lblDist.Text = string.Format("{0} km", dist);
        }

        /// <summary>
        /// Evento de clique do mouse 
        /// </summary>
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            FormInserirCidade frmInserir = new FormInserirCidade();
            DialogResult r = frmInserir.ShowDialog(this);

            if (r == DialogResult.OK)
            {
                if (coordenadas.Keys.Contains(frmInserir.Nome))
                    MessageBox.Show(this, "A cidade já existe", "Ooops", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    Point p = new Point(e.X, e.Y);// pictureBox1.PointToClient(new Point(e.X, e.Y));
                    PointF coords = new PointF((float)p.X / pictureBox1.Width, (float)p.Y / pictureBox1.Height);
                    coordenadas.Add(frmInserir.Nome, coords);

                    using (StreamWriter writer = new StreamWriter(new FileStream("coordenadas.txt", FileMode.Append)))
                        writer.Write(
                            Environment.NewLine +
                            frmInserir.Nome.PadRight(15) +
                            Math.Round(coords.X, 3).ToString().PadRight(8) +
                            Math.Round(coords.Y, 3).ToString().PadRight(8));

                    Grafo.InserirCidade(frmInserir.Nome);
                }
            }
        }

        /// <summary>
        /// Evento de clique no botão de inserir rota
        /// </summary>
        private void btnRota_Click(object sender, EventArgs e)
        {
            new FormIncluirRota(this, coordenadas).ShowDialog(this);
        }

        /// <summary>
        /// Radio button selecionado
        /// </summary>
        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            AtualizarLista();
        }
    }
}
