namespace Caminhos
{
    partial class FormGrafo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lsbCaminhos = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnProcurar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdTempo = new System.Windows.Forms.RadioButton();
            this.rdDist = new System.Windows.Forms.RadioButton();
            this.rdPreco = new System.Windows.Forms.RadioButton();
            this.cbDestino = new System.Windows.Forms.ComboBox();
            this.cbOrigem = new System.Windows.Forms.ComboBox();
            this.lblDist = new System.Windows.Forms.Label();
            this.lblTempo = new System.Windows.Forms.Label();
            this.lblPre = new System.Windows.Forms.Label();
            this.btnRota = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::Caminhos.Properties.Resources.mapa_espanha_portugal_original;
            this.pictureBox1.Location = new System.Drawing.Point(183, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(456, 449);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Destino:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Origem:";
            // 
            // lsbCaminhos
            // 
            this.lsbCaminhos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsbCaminhos.FormattingEnabled = true;
            this.lsbCaminhos.Location = new System.Drawing.Point(11, 120);
            this.lsbCaminhos.Name = "lsbCaminhos";
            this.lsbCaminhos.Size = new System.Drawing.Size(166, 186);
            this.lsbCaminhos.TabIndex = 5;
            this.lsbCaminhos.SelectedIndexChanged += new System.EventHandler(this.lsbCaminhos_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Caminhos: ";
            // 
            // btnProcurar
            // 
            this.btnProcurar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcurar.Location = new System.Drawing.Point(102, 76);
            this.btnProcurar.Name = "btnProcurar";
            this.btnProcurar.Size = new System.Drawing.Size(75, 23);
            this.btnProcurar.TabIndex = 9;
            this.btnProcurar.Text = "Procurar";
            this.btnProcurar.UseVisualStyleBackColor = true;
            this.btnProcurar.Click += new System.EventHandler(this.btnProcurar_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdTempo);
            this.panel1.Controls.Add(this.rdDist);
            this.panel1.Controls.Add(this.rdPreco);
            this.panel1.Controls.Add(this.cbDestino);
            this.panel1.Controls.Add(this.cbOrigem);
            this.panel1.Controls.Add(this.lblDist);
            this.panel1.Controls.Add(this.lblTempo);
            this.panel1.Controls.Add(this.lblPre);
            this.panel1.Controls.Add(this.btnRota);
            this.panel1.Controls.Add(this.lsbCaminhos);
            this.panel1.Controls.Add(this.btnProcurar);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(183, 449);
            this.panel1.TabIndex = 10;
            // 
            // rdTempo
            // 
            this.rdTempo.AutoSize = true;
            this.rdTempo.Checked = true;
            this.rdTempo.Location = new System.Drawing.Point(14, 354);
            this.rdTempo.Name = "rdTempo";
            this.rdTempo.Size = new System.Drawing.Size(61, 17);
            this.rdTempo.TabIndex = 21;
            this.rdTempo.TabStop = true;
            this.rdTempo.Text = "Tempo:";
            this.rdTempo.UseVisualStyleBackColor = true;
            this.rdTempo.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // rdDist
            // 
            this.rdDist.AutoSize = true;
            this.rdDist.Location = new System.Drawing.Point(14, 333);
            this.rdDist.Name = "rdDist";
            this.rdDist.Size = new System.Drawing.Size(72, 17);
            this.rdDist.TabIndex = 20;
            this.rdDist.Text = "Distância:";
            this.rdDist.UseVisualStyleBackColor = true;
            this.rdDist.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // rdPreco
            // 
            this.rdPreco.AutoSize = true;
            this.rdPreco.Location = new System.Drawing.Point(14, 311);
            this.rdPreco.Name = "rdPreco";
            this.rdPreco.Size = new System.Drawing.Size(56, 17);
            this.rdPreco.TabIndex = 19;
            this.rdPreco.Text = "Preço:";
            this.rdPreco.UseVisualStyleBackColor = true;
            this.rdPreco.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // cbDestino
            // 
            this.cbDestino.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbDestino.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbDestino.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbDestino.FormattingEnabled = true;
            this.cbDestino.Location = new System.Drawing.Point(57, 45);
            this.cbDestino.Name = "cbDestino";
            this.cbDestino.Size = new System.Drawing.Size(120, 21);
            this.cbDestino.TabIndex = 18;
            // 
            // cbOrigem
            // 
            this.cbOrigem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbOrigem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbOrigem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbOrigem.FormattingEnabled = true;
            this.cbOrigem.Location = new System.Drawing.Point(57, 8);
            this.cbOrigem.Name = "cbOrigem";
            this.cbOrigem.Size = new System.Drawing.Size(120, 21);
            this.cbOrigem.TabIndex = 17;
            // 
            // lblDist
            // 
            this.lblDist.AutoSize = true;
            this.lblDist.Location = new System.Drawing.Point(84, 335);
            this.lblDist.Name = "lblDist";
            this.lblDist.Size = new System.Drawing.Size(0, 13);
            this.lblDist.TabIndex = 16;
            // 
            // lblTempo
            // 
            this.lblTempo.AutoSize = true;
            this.lblTempo.Location = new System.Drawing.Point(75, 356);
            this.lblTempo.Name = "lblTempo";
            this.lblTempo.Size = new System.Drawing.Size(0, 13);
            this.lblTempo.TabIndex = 14;
            // 
            // lblPre
            // 
            this.lblPre.AutoSize = true;
            this.lblPre.Location = new System.Drawing.Point(70, 313);
            this.lblPre.Name = "lblPre";
            this.lblPre.Size = new System.Drawing.Size(0, 13);
            this.lblPre.TabIndex = 12;
            // 
            // btnRota
            // 
            this.btnRota.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRota.Location = new System.Drawing.Point(102, 414);
            this.btnRota.Name = "btnRota";
            this.btnRota.Size = new System.Drawing.Size(75, 23);
            this.btnRota.TabIndex = 10;
            this.btnRota.Text = "Incluir Rota";
            this.btnRota.UseVisualStyleBackColor = true;
            this.btnRota.Click += new System.EventHandler(this.btnRota_Click);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(183, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 449);
            this.splitter1.TabIndex = 11;
            this.splitter1.TabStop = false;
            // 
            // FormGrafo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 449);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(519, 408);
            this.Name = "FormGrafo";
            this.Text = "Caminhos de Trem";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lsbCaminhos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnProcurar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Button btnRota;
        private System.Windows.Forms.Label lblTempo;
        private System.Windows.Forms.Label lblPre;
        private System.Windows.Forms.Label lblDist;
        private System.Windows.Forms.ComboBox cbOrigem;
        private System.Windows.Forms.ComboBox cbDestino;
        private System.Windows.Forms.RadioButton rdTempo;
        private System.Windows.Forms.RadioButton rdDist;
        private System.Windows.Forms.RadioButton rdPreco;
    }
}

