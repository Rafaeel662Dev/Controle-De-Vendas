namespace Ae___Controle_de_Vendas.Formulários
{
    partial class frmPrincipal
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuSistema = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLogar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDesconectar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEncerrar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuConsulta = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuProdutos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUsuario = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVendas = new System.Windows.Forms.ToolStripMenuItem();
            this.frmVenda = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblPermissao = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblServidor = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTempo = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2);
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSistema,
            this.mnuConsulta,
            this.mnuVendas});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1030, 29);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuSistema
            // 
            this.mnuSistema.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuLogar,
            this.mnuDesconectar,
            this.mnuEncerrar});
            this.mnuSistema.Image = global::Ae___Controle_de_Vendas.Properties.Resources.SistemaIcone;
            this.mnuSistema.Name = "mnuSistema";
            this.mnuSistema.Size = new System.Drawing.Size(93, 25);
            this.mnuSistema.Text = "Sistema";
            // 
            // mnuLogar
            // 
            this.mnuLogar.Image = global::Ae___Controle_de_Vendas.Properties.Resources.iconLogin;
            this.mnuLogar.Name = "mnuLogar";
            this.mnuLogar.Size = new System.Drawing.Size(165, 26);
            this.mnuLogar.Text = "Logar";
            this.mnuLogar.Click += new System.EventHandler(this.mnuLogar_Click);
            // 
            // mnuDesconectar
            // 
            this.mnuDesconectar.Enabled = false;
            this.mnuDesconectar.Image = global::Ae___Controle_de_Vendas.Properties.Resources.LogoffOK;
            this.mnuDesconectar.Name = "mnuDesconectar";
            this.mnuDesconectar.Size = new System.Drawing.Size(165, 26);
            this.mnuDesconectar.Text = "Desconectar";
            this.mnuDesconectar.Click += new System.EventHandler(this.mnuDesconectar_Click_1);
            // 
            // mnuEncerrar
            // 
            this.mnuEncerrar.Image = global::Ae___Controle_de_Vendas.Properties.Resources.Fechar;
            this.mnuEncerrar.Name = "mnuEncerrar";
            this.mnuEncerrar.Size = new System.Drawing.Size(165, 26);
            this.mnuEncerrar.Text = "Encerrar";
            this.mnuEncerrar.Click += new System.EventHandler(this.mnuEncerrar_Click);
            // 
            // mnuConsulta
            // 
            this.mnuConsulta.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuClientes,
            this.MnuProdutos,
            this.mnuUsuario});
            this.mnuConsulta.Enabled = false;
            this.mnuConsulta.Image = global::Ae___Controle_de_Vendas.Properties.Resources.ConsultaIcon;
            this.mnuConsulta.Name = "mnuConsulta";
            this.mnuConsulta.Size = new System.Drawing.Size(175, 25);
            this.mnuConsulta.Text = "Cadastro / Consulta";
            // 
            // MnuClientes
            // 
            this.MnuClientes.Image = global::Ae___Controle_de_Vendas.Properties.Resources.Cliente;
            this.MnuClientes.Name = "MnuClientes";
            this.MnuClientes.Size = new System.Drawing.Size(143, 26);
            this.MnuClientes.Text = "Clientes";
            this.MnuClientes.Click += new System.EventHandler(this.MnuClientes_Click);
            // 
            // MnuProdutos
            // 
            this.MnuProdutos.Image = global::Ae___Controle_de_Vendas.Properties.Resources.produto;
            this.MnuProdutos.Name = "MnuProdutos";
            this.MnuProdutos.Size = new System.Drawing.Size(143, 26);
            this.MnuProdutos.Text = "Produtos";
            this.MnuProdutos.Click += new System.EventHandler(this.MnuProdutos_Click);
            // 
            // mnuUsuario
            // 
            this.mnuUsuario.Image = global::Ae___Controle_de_Vendas.Properties.Resources.Usuario;
            this.mnuUsuario.Name = "mnuUsuario";
            this.mnuUsuario.Size = new System.Drawing.Size(143, 26);
            this.mnuUsuario.Text = "Usuários";
            this.mnuUsuario.Visible = false;
            this.mnuUsuario.Click += new System.EventHandler(this.frmUsuario_Click);
            // 
            // mnuVendas
            // 
            this.mnuVendas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.frmVenda});
            this.mnuVendas.Enabled = false;
            this.mnuVendas.Image = global::Ae___Controle_de_Vendas.Properties.Resources._1f4b2;
            this.mnuVendas.Name = "mnuVendas";
            this.mnuVendas.Size = new System.Drawing.Size(89, 25);
            this.mnuVendas.Text = "Vendas";
            this.mnuVendas.Click += new System.EventHandler(this.mnuVendas_Click);
            // 
            // frmVenda
            // 
            this.frmVenda.Image = global::Ae___Controle_de_Vendas.Properties.Resources.Venda;
            this.frmVenda.Name = "frmVenda";
            this.frmVenda.Size = new System.Drawing.Size(190, 26);
            this.frmVenda.Text = "Realizar Vendas";
            this.frmVenda.Click += new System.EventHandler(this.frmVenda_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Transparent;
            this.statusStrip1.BackgroundImage = global::Ae___Controle_de_Vendas.Properties.Resources.MicrosoftTeams_image__1_;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblUsuario,
            this.lblPermissao,
            this.lblServidor,
            this.lblTempo});
            this.statusStrip1.Location = new System.Drawing.Point(0, 536);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1030, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblUsuario
            // 
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(253, 17);
            this.lblUsuario.Spring = true;
            this.lblUsuario.Text = "Usuario:";
            // 
            // lblPermissao
            // 
            this.lblPermissao.Name = "lblPermissao";
            this.lblPermissao.Size = new System.Drawing.Size(253, 17);
            this.lblPermissao.Spring = true;
            this.lblPermissao.Text = "Permissao:";
            // 
            // lblServidor
            // 
            this.lblServidor.Name = "lblServidor";
            this.lblServidor.Size = new System.Drawing.Size(253, 17);
            this.lblServidor.Spring = true;
            this.lblServidor.Text = "Servidor:";
            // 
            // lblTempo
            // 
            this.lblTempo.Name = "lblTempo";
            this.lblTempo.Size = new System.Drawing.Size(253, 17);
            this.lblTempo.Spring = true;
            this.lblTempo.Text = "Tempo: 00:00:00";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImage = global::Ae___Controle_de_Vendas.Properties.Resources.Apresentação_Cardápio_Agenda_Páscoa;
            this.ClientSize = new System.Drawing.Size(1030, 558);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Amor Em Caldas - Vendas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.VisibleChanged += new System.EventHandler(this.frmPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuConsulta;
        private System.Windows.Forms.ToolStripMenuItem mnuVendas;
        private System.Windows.Forms.ToolStripMenuItem mnuSistema;
        private System.Windows.Forms.ToolStripMenuItem MnuClientes;
        private System.Windows.Forms.ToolStripMenuItem MnuProdutos;
        private System.Windows.Forms.ToolStripMenuItem mnuUsuario;
        private System.Windows.Forms.ToolStripMenuItem frmVenda;
        private System.Windows.Forms.ToolStripMenuItem mnuLogar;
        private System.Windows.Forms.ToolStripMenuItem mnuDesconectar;
        private System.Windows.Forms.ToolStripMenuItem mnuEncerrar;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblUsuario;
        private System.Windows.Forms.ToolStripStatusLabel lblPermissao;
        private System.Windows.Forms.ToolStripStatusLabel lblServidor;
        private System.Windows.Forms.ToolStripStatusLabel lblTempo;
        private System.Windows.Forms.Timer timer1;
    }
}