using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caminhos
{
    public partial class FormIncluirRota : Form
    {
        Dictionary<string, PointF> cidades;
        FormGrafo parent;

        public FormIncluirRota(FormGrafo parent, Dictionary<string, PointF> coo)
        {
            InitializeComponent();

            this.parent = parent;

            foreach(string str in coo.Keys)
            {
                cmbOrigem.Items.Add(str);
                cmbDestino.Items.Add(str);
            }
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if(txtDist!=null && txtPre!=null && txtVel != null)
            {
                FileStream fs = new FileStream("caminhos.txt", FileMode.Append);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine();
                sw.Write(
                    cmbOrigem.Text.PadRight(15) +
                         cmbDestino.Text.PadRight(16) +
                         txtDist.Text.PadRight(5) +
                         txtVel.Text.PadRight(7) +
                         Convert.ToDouble(txtPre.Text).ToString("00.00")
                );
                sw.Close();
                fs.Close();

                parent.Grafo.InserirLigacao(
                        cmbOrigem.Text.Trim(),
                        cmbDestino.Text.Trim(),
                        Convert.ToInt32(txtDist.Text),
                        Convert.ToInt32(txtVel.Text),
                        Convert.ToDouble(txtPre.Text)
                );

            }
            
            Close();
        }
    }
}
