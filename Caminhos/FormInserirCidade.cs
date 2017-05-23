using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caminhos
{
    public partial class FormInserirCidade : Form
    {
        /// <summary>
        /// Nome da cidade a ser criada
        /// </summary>
        public string Nome
        {
            get
            {
                return txtNomeCidade.Text.Trim();
            }
        }

        /// <summary>
        /// Construtor
        /// </summary>
        public FormInserirCidade()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Evento de clique no botão OK
        /// </summary>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Nome))
            {
                txtNomeCidade.Focus();
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// Evento de clique no botão cancelar
        /// </summary>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
