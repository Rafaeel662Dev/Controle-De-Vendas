using Ae___Controle_de_Vendas.Classes.Outros;
using Ae___Controle_de_Vendas.Formulários;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ae___Controle_de_Vendas
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnAcessar_Click(object sender, EventArgs e)
        {


            string msg = PreencherCampos();
            if (msg != string.Empty)
            {
                MessageBox.Show(msg, "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {


                string senhaCriptografada = Global.Criptografar(txtSenha.Text);
                Usuario usuario = new Usuario();
                usuario.Login = txtUsuario.Text;

                usuario.Consultar();
                if (usuario.Id == 0)
                {
                    MessageBox.Show("Usuário e/ou Senha Inválido!!!", "Login",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                if (!usuario.Autenticar(senhaCriptografada))
                {

                    MessageBox.Show("Usuário e/ou Senha Inválido!!!", "Login",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                if (!usuario.Ativo)
                {
                    MessageBox.Show("Usuário inativo", "Login",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                MessageBox.Show($"Bem vindo {usuario.Nome}.", "Login",
                MessageBoxButtons.OK, MessageBoxIcon.Information);


                Global.IdUsuarioLogado = usuario.Id;
                DialogResult = DialogResult.OK;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro --> " + ex.Message, "Login",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void LimparCampos()
        {
            txtUsuario.Text = String.Empty;
            txtSenha.Text = String.Empty;
            txtUsuario.Focus();
        }

        public string PreencherCampos()
        {
            string msg = string.Empty;

            if(txtUsuario.Text == String.Empty)
            {
                
                msg = "Usuário Não Digitado!!\n";
            }

            if (txtSenha.Text == String.Empty)
            {
                msg += "Senha Não Digitada!!";
            }


            return msg;
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

       

    }
}
