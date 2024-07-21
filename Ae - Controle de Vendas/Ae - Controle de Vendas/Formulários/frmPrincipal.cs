using Ae___Controle_de_Vendas.Classes.Outros;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ae___Controle_de_Vendas.Formulários
{
    public partial class frmPrincipal : Form
    {


        
        public frmPrincipal()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            this.MdiChildActivate += FrmPrincipal_MdiChildActivate;
        }

        DateTime login;
        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            Left = 0;
            Top = 0;
            Width = Screen.PrimaryScreen.WorkingArea.Width;
            Height = Screen.PrimaryScreen.WorkingArea.Height;
            desabilitarMenus();
        }




        private void FrmPrincipal_MdiChildActivate(object sender, EventArgs e)
        {
            
            foreach (Form childForm in this.MdiChildren)
            {
                childForm.StartPosition = FormStartPosition.CenterParent;
                childForm.MinimizeBox = false; 
                childForm.MaximizeBox = false; 
            }
        }



        private void resetLblStrip()
        {
            lblPermissao.Text = "Permissão: ";
            lblServidor.Text = "Servidor: ";
            lblTempo.Text = "Tempo: 00:00:00";
            lblUsuario.Text = "Usuário: ";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           TimeSpan ts = DateTime.Now - login;
           lblTempo.Text =
               $"Tempo: {ts.Hours.ToString("00")}:" +
               $"{ts.Minutes.ToString("00")}:" +
               $"{ts.Seconds.ToString("00")}";
        }
        private void AbrirForm(Form form)
        {
            
            foreach (Form filho in this.MdiChildren)
            {
                if (filho.Name == form.Name)
                {
                    filho.Activate();
                    filho.StartPosition = FormStartPosition.CenterScreen;
                    return;
                }
            }
            form.MdiParent = this;
            form.Show();

        }


        private void mnuSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Deseja encerrar a aplicação?",
                "Amor Em Caldas", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }


        private void MnuClientes_Click(object sender, EventArgs e)
        {
            AbrirForm(new frmCliente());
        }

        private void MnuProdutos_Click(object sender, EventArgs e)
        {
            AbrirForm(new frmProduto());
        }

        private void frmUsuario_Click(object sender, EventArgs e)
        {
            AbrirForm(new frmUsuario());
        }

        private void frmVenda_Click(object sender, EventArgs e)
        {
            AbrirForm(new frmCaixa());
        }

        private void frmCancelar_Click(object sender, EventArgs e)
        {
        }

        private void frmPrincipal_Activated(object sender, EventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            frmLogin.ShowDialog();
        }

        private void mnuLogar_Click(object sender, EventArgs e)
        {
            frmLogin s = new frmLogin();
            //s.ShowDialog();
            if (s.ShowDialog()== DialogResult.OK)
            {
                HabilitarMenus();
            }
        }


        private void Fecharforms()
        {
            foreach (Form filho in this.MdiChildren)
            {
             filho.Close();
            }
        }

        private void desabilitarMenus()
        {
            timer1.Enabled = false;
            mnuConsulta.Enabled = false;
            mnuVendas.Enabled = false;
            mnuUsuario.Visible = false;
            mnuDesconectar.Enabled = false;
            mnuLogar.Enabled = true;
            mnuVenda.Visible = false;
        }

        private void HabilitarMenus()
        {
            
            mnuConsulta.Enabled = true;
            mnuVendas.Enabled = true;

            mnuDesconectar.Enabled = true;
            mnuLogar.Enabled = false;

            Usuario user = new Usuario();
            user.Id = Global.IdUsuarioLogado;
            user.Consultar();

            if (user.PermissaoId == 1)
            {
              mnuUsuario.Visible = true;
              mnuVenda.Visible = true;
            }

            timer1.Enabled = true;
            login = DateTime.Now;

            lblUsuario.Text = $"Usuário: {user.Nome}";
            lblServidor.Text = $"Servidor: {Global.Servidor}";
            lblPermissao.Text = $"Permissão: {user.getPermissionUser(user.Id)}";


        }
        
        private void mnuDesconectar_Click_1(object sender, EventArgs e)
        {
           
            Global.IdUsuarioLogado = 0;

            
            DialogResult dialogResult = MessageBox.Show("Tem Certeza que deseja deslogar?", "Login", MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.OK)
            {
                desabilitarMenus();
                Fecharforms();
                resetLblStrip();
                
            }
        }

        private void mnuEncerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

      

        private void mnuVenda_Click(object sender, EventArgs e)
        {
             AbrirForm(new frmExibirVendas());
        }

    }
}
