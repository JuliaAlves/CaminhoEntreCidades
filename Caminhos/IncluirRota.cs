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
    public partial class IncluirRota : Form
    {
        public IncluirRota(Dictionary<string, PointF> coo)
        {
            InitializeComponent();

            foreach(string str in coo.Keys)
            {
                cmbOrigem.Items.Add(str);
                cmbDestinho.Items.Add(str);
            }
                
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if(txtDist!=null && txtPre!=null && txtVel != null)
            {
                FileStream fs = new FileStream("../../caminhos.txt", FileMode.Append);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine();
                sw.Write(cmbOrigem.Text.PadRight(15)+
                         cmbDestinho.Text.PadRight(16)+
                         txtDist.Text.PadRight(5)+
                         txtVel.Text.PadRight(7)+
                         txtPre.Text);
                sw.Close();
                fs.Close();
            }
            
        }
    }
}
