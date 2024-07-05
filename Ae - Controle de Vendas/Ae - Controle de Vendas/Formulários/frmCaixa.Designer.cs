namespace Ae___Controle_de_Vendas.Formulários
{
    partial class frmCaixa
    {
       
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lblNomeCliente;
        private System.Windows.Forms.TextBox txtNomeCliente;
        private System.Windows.Forms.TextBox txtCPF;
        private System.Windows.Forms.Label lblCPF;
        private System.Windows.Forms.TextBox txtCodigoProduto;
        private System.Windows.Forms.Label lblCodigoProduto;
        private System.Windows.Forms.TextBox txtNomeProduto;
        private System.Windows.Forms.Label lblNomeProduto;
        private System.Windows.Forms.TextBox txtPrecoProduto;
        private System.Windows.Forms.Label lblPrecoProduto;
        private System.Windows.Forms.TextBox txtQuantidade;
        private System.Windows.Forms.Label lblQuantidade;
        private System.Windows.Forms.Button btnIncluir;
        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.Button btnFinalizarVenda;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCaixa));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lblNomeCliente = new System.Windows.Forms.Label();
            this.txtNomeCliente = new System.Windows.Forms.TextBox();
            this.txtCPF = new System.Windows.Forms.TextBox();
            this.lblCPF = new System.Windows.Forms.Label();
            this.txtCodigoProduto = new System.Windows.Forms.TextBox();
            this.lblCodigoProduto = new System.Windows.Forms.Label();
            this.txtNomeProduto = new System.Windows.Forms.TextBox();
            this.lblNomeProduto = new System.Windows.Forms.Label();
            this.txtPrecoProduto = new System.Windows.Forms.TextBox();
            this.lblPrecoProduto = new System.Windows.Forms.Label();
            this.txtQuantidade = new System.Windows.Forms.TextBox();
            this.lblQuantidade = new System.Windows.Forms.Label();
            this.btnIncluir = new System.Windows.Forms.Button();
            this.btnRemover = new System.Windows.Forms.Button();
            this.btnFinalizarVenda = new System.Windows.Forms.Button();
            this.grpCliente = new System.Windows.Forms.GroupBox();
            this.checkAvulso = new System.Windows.Forms.CheckBox();
            this.grpProduto = new System.Windows.Forms.GroupBox();
            this.btnCalculadora = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.grpVendas = new System.Windows.Forms.GroupBox();
            this.grdDados = new System.Windows.Forms.DataGridView();
            this.lblValor = new System.Windows.Forms.Label();
            this.grpCliente.SuspendLayout();
            this.grpProduto.SuspendLayout();
            this.grpVendas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDados)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNomeCliente
            // 
            this.lblNomeCliente.AutoSize = true;
            this.lblNomeCliente.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomeCliente.Location = new System.Drawing.Point(232, 29);
            this.lblNomeCliente.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNomeCliente.Name = "lblNomeCliente";
            this.lblNomeCliente.Size = new System.Drawing.Size(100, 20);
            this.lblNomeCliente.TabIndex = 2;
            this.lblNomeCliente.Text = "Nome Cliente";
            // 
            // txtNomeCliente
            // 
            this.txtNomeCliente.Enabled = false;
            this.txtNomeCliente.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomeCliente.Location = new System.Drawing.Point(198, 54);
            this.txtNomeCliente.Margin = new System.Windows.Forms.Padding(2);
            this.txtNomeCliente.Name = "txtNomeCliente";
            this.txtNomeCliente.Size = new System.Drawing.Size(188, 27);
            this.txtNomeCliente.TabIndex = 3;
            // 
            // txtCPF
            // 
            this.txtCPF.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCPF.Location = new System.Drawing.Point(9, 54);
            this.txtCPF.Margin = new System.Windows.Forms.Padding(2);
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.Size = new System.Drawing.Size(151, 27);
            this.txtCPF.TabIndex = 1;
            this.txtCPF.TextChanged += new System.EventHandler(this.txtCPF_TextChanged_1);
            this.txtCPF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCPF_KeyPress);
            // 
            // lblCPF
            // 
            this.lblCPF.AutoSize = true;
            this.lblCPF.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCPF.Location = new System.Drawing.Point(37, 29);
            this.lblCPF.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCPF.Name = "lblCPF";
            this.lblCPF.Size = new System.Drawing.Size(83, 20);
            this.lblCPF.TabIndex = 0;
            this.lblCPF.Text = "CPF Cliente";
            // 
            // txtCodigoProduto
            // 
            this.txtCodigoProduto.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoProduto.Location = new System.Drawing.Point(18, 54);
            this.txtCodigoProduto.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoProduto.Name = "txtCodigoProduto";
            this.txtCodigoProduto.Size = new System.Drawing.Size(114, 27);
            this.txtCodigoProduto.TabIndex = 1;
            this.txtCodigoProduto.Click += new System.EventHandler(this.txtCodigoProduto_Click);
            this.txtCodigoProduto.TextChanged += new System.EventHandler(this.txtCodigoProduto_TextChanged);
            this.txtCodigoProduto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoProduto_KeyPress);
            this.txtCodigoProduto.Leave += new System.EventHandler(this.txtCodigoProduto_Leave);
            // 
            // lblCodigoProduto
            // 
            this.lblCodigoProduto.AutoSize = true;
            this.lblCodigoProduto.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigoProduto.Location = new System.Drawing.Point(23, 29);
            this.lblCodigoProduto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCodigoProduto.Name = "lblCodigoProduto";
            this.lblCodigoProduto.Size = new System.Drawing.Size(96, 20);
            this.lblCodigoProduto.TabIndex = 0;
            this.lblCodigoProduto.Text = "Cód. Produto";
            // 
            // txtNomeProduto
            // 
            this.txtNomeProduto.Enabled = false;
            this.txtNomeProduto.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomeProduto.Location = new System.Drawing.Point(166, 54);
            this.txtNomeProduto.Margin = new System.Windows.Forms.Padding(2);
            this.txtNomeProduto.Name = "txtNomeProduto";
            this.txtNomeProduto.Size = new System.Drawing.Size(188, 27);
            this.txtNomeProduto.TabIndex = 5;
            // 
            // lblNomeProduto
            // 
            this.lblNomeProduto.AutoSize = true;
            this.lblNomeProduto.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomeProduto.Location = new System.Drawing.Point(193, 32);
            this.lblNomeProduto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNomeProduto.Name = "lblNomeProduto";
            this.lblNomeProduto.Size = new System.Drawing.Size(129, 20);
            this.lblNomeProduto.TabIndex = 6;
            this.lblNomeProduto.Text = "Nome do Produto";
            // 
            // txtPrecoProduto
            // 
            this.txtPrecoProduto.Enabled = false;
            this.txtPrecoProduto.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecoProduto.Location = new System.Drawing.Point(383, 54);
            this.txtPrecoProduto.Margin = new System.Windows.Forms.Padding(2);
            this.txtPrecoProduto.Name = "txtPrecoProduto";
            this.txtPrecoProduto.Size = new System.Drawing.Size(82, 27);
            this.txtPrecoProduto.TabIndex = 0;
            // 
            // lblPrecoProduto
            // 
            this.lblPrecoProduto.AutoSize = true;
            this.lblPrecoProduto.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecoProduto.Location = new System.Drawing.Point(383, 29);
            this.lblPrecoProduto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPrecoProduto.Name = "lblPrecoProduto";
            this.lblPrecoProduto.Size = new System.Drawing.Size(67, 20);
            this.lblPrecoProduto.TabIndex = 7;
            this.lblPrecoProduto.Text = "Preço R$";
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantidade.Location = new System.Drawing.Point(505, 54);
            this.txtQuantidade.Margin = new System.Windows.Forms.Padding(2);
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Size = new System.Drawing.Size(117, 27);
            this.txtQuantidade.TabIndex = 2;
            this.txtQuantidade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantidade_KeyPress);
            // 
            // lblQuantidade
            // 
            this.lblQuantidade.AutoSize = true;
            this.lblQuantidade.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantidade.Location = new System.Drawing.Point(518, 29);
            this.lblQuantidade.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblQuantidade.Name = "lblQuantidade";
            this.lblQuantidade.Size = new System.Drawing.Size(87, 20);
            this.lblQuantidade.TabIndex = 1;
            this.lblQuantidade.Text = "Quantidade";
            // 
            // btnIncluir
            // 
            this.btnIncluir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnIncluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIncluir.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIncluir.ForeColor = System.Drawing.Color.White;
            this.btnIncluir.Location = new System.Drawing.Point(43, 251);
            this.btnIncluir.Margin = new System.Windows.Forms.Padding(2);
            this.btnIncluir.Name = "btnIncluir";
            this.btnIncluir.Size = new System.Drawing.Size(105, 32);
            this.btnIncluir.TabIndex = 3;
            this.btnIncluir.Text = "Incluir Item";
            this.btnIncluir.UseVisualStyleBackColor = false;
            this.btnIncluir.Click += new System.EventHandler(this.btnIncluir_Click);
            // 
            // btnRemover
            // 
            this.btnRemover.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnRemover.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemover.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemover.ForeColor = System.Drawing.Color.White;
            this.btnRemover.Location = new System.Drawing.Point(220, 251);
            this.btnRemover.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(105, 32);
            this.btnRemover.TabIndex = 4;
            this.btnRemover.Text = "Remover Item";
            this.btnRemover.UseVisualStyleBackColor = false;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // btnFinalizarVenda
            // 
            this.btnFinalizarVenda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnFinalizarVenda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinalizarVenda.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinalizarVenda.ForeColor = System.Drawing.Color.White;
            this.btnFinalizarVenda.Location = new System.Drawing.Point(680, 251);
            this.btnFinalizarVenda.Margin = new System.Windows.Forms.Padding(2);
            this.btnFinalizarVenda.Name = "btnFinalizarVenda";
            this.btnFinalizarVenda.Size = new System.Drawing.Size(136, 32);
            this.btnFinalizarVenda.TabIndex = 7;
            this.btnFinalizarVenda.Text = "Finalizar Venda";
            this.btnFinalizarVenda.UseVisualStyleBackColor = false;
            this.btnFinalizarVenda.Click += new System.EventHandler(this.btnFinalizarVenda_Click);
            // 
            // grpCliente
            // 
            this.grpCliente.Controls.Add(this.checkAvulso);
            this.grpCliente.Controls.Add(this.lblNomeCliente);
            this.grpCliente.Controls.Add(this.lblCPF);
            this.grpCliente.Controls.Add(this.txtCPF);
            this.grpCliente.Controls.Add(this.txtNomeCliente);
            this.grpCliente.Location = new System.Drawing.Point(2, 12);
            this.grpCliente.Name = "grpCliente";
            this.grpCliente.Size = new System.Drawing.Size(508, 100);
            this.grpCliente.TabIndex = 0;
            this.grpCliente.TabStop = false;
            this.grpCliente.Text = "Cliente";
            // 
            // checkAvulso
            // 
            this.checkAvulso.AutoSize = true;
            this.checkAvulso.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.checkAvulso.Location = new System.Drawing.Point(420, 54);
            this.checkAvulso.Name = "checkAvulso";
            this.checkAvulso.Size = new System.Drawing.Size(82, 24);
            this.checkAvulso.TabIndex = 4;
            this.checkAvulso.Text = "AVULSO";
            this.checkAvulso.UseVisualStyleBackColor = true;
            this.checkAvulso.CheckedChanged += new System.EventHandler(this.checkAvulso_CheckedChanged);
            // 
            // grpProduto
            // 
            this.grpProduto.Controls.Add(this.lblNomeProduto);
            this.grpProduto.Controls.Add(this.txtNomeProduto);
            this.grpProduto.Controls.Add(this.lblCodigoProduto);
            this.grpProduto.Controls.Add(this.txtCodigoProduto);
            this.grpProduto.Controls.Add(this.lblPrecoProduto);
            this.grpProduto.Controls.Add(this.txtPrecoProduto);
            this.grpProduto.Controls.Add(this.txtQuantidade);
            this.grpProduto.Controls.Add(this.lblQuantidade);
            this.grpProduto.Location = new System.Drawing.Point(3, 130);
            this.grpProduto.Name = "grpProduto";
            this.grpProduto.Size = new System.Drawing.Size(821, 100);
            this.grpProduto.TabIndex = 2;
            this.grpProduto.TabStop = false;
            this.grpProduto.Text = "Produto";
            // 
            // btnCalculadora
            // 
            this.btnCalculadora.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCalculadora.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalculadora.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalculadora.ForeColor = System.Drawing.Color.White;
            this.btnCalculadora.Location = new System.Drawing.Point(372, 251);
            this.btnCalculadora.Margin = new System.Windows.Forms.Padding(2);
            this.btnCalculadora.Name = "btnCalculadora";
            this.btnCalculadora.Size = new System.Drawing.Size(105, 32);
            this.btnCalculadora.TabIndex = 5;
            this.btnCalculadora.Text = "Calculadora";
            this.btnCalculadora.UseVisualStyleBackColor = false;
            this.btnCalculadora.Click += new System.EventHandler(this.btnCalculadora_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(525, 251);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(135, 32);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar Venda";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // grpVendas
            // 
            this.grpVendas.Controls.Add(this.grdDados);
            this.grpVendas.Location = new System.Drawing.Point(21, 310);
            this.grpVendas.Name = "grpVendas";
            this.grpVendas.Size = new System.Drawing.Size(794, 246);
            this.grpVendas.TabIndex = 8;
            this.grpVendas.TabStop = false;
            this.grpVendas.Text = "Vendas";
            // 
            // grdDados
            // 
            this.grdDados.AllowUserToAddRows = false;
            this.grdDados.AllowUserToDeleteRows = false;
            this.grdDados.AllowUserToResizeColumns = false;
            this.grdDados.AllowUserToResizeRows = false;
            this.grdDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDados.Location = new System.Drawing.Point(6, 19);
            this.grdDados.Name = "grdDados";
            this.grdDados.ReadOnly = true;
            this.grdDados.RowHeadersVisible = false;
            this.grdDados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdDados.Size = new System.Drawing.Size(782, 221);
            this.grdDados.TabIndex = 0;
            this.grdDados.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdDados_CellContentClick);
            this.grdDados.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdDados_CellFormatting);
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 33F);
            this.lblValor.Location = new System.Drawing.Point(516, 39);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(174, 52);
            this.lblValor.TabIndex = 1;
            this.lblValor.Text = "R$ 0.00";
            this.lblValor.Click += new System.EventHandler(this.lblValor_Click);
            // 
            // frmVenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 559);
            this.Controls.Add(this.lblValor);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnCalculadora);
            this.Controls.Add(this.grpProduto);
            this.Controls.Add(this.grpCliente);
            this.Controls.Add(this.btnFinalizarVenda);
            this.Controls.Add(this.btnRemover);
            this.Controls.Add(this.btnIncluir);
            this.Controls.Add(this.grpVendas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmVenda";
            this.Text = "Controle de Vendas - Formulário de Venda";
            this.Load += new System.EventHandler(this.frmVenda_Load);
            this.grpCliente.ResumeLayout(false);
            this.grpCliente.PerformLayout();
            this.grpProduto.ResumeLayout(false);
            this.grpProduto.PerformLayout();
            this.grpVendas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.GroupBox grpCliente;
        private System.Windows.Forms.GroupBox grpProduto;
        private System.Windows.Forms.Button btnCalculadora;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox grpVendas;
        private System.Windows.Forms.DataGridView grdDados;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.CheckBox checkAvulso;
    }
}
