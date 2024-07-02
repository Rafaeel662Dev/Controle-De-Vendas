using Ae___Controle_de_Vendas.Classes.Outros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ae___Controle_de_Vendas.Formulários
{
    public partial class frmUsuario : Form
    {
        public frmUsuario()
        {
            InitializeComponent();
        }

        bool load = false;
        Usuario user = new Usuario();


 


        private void frmUsuario_Load(object sender, EventArgs e)
        {
            CarregarEstados();
            CarregarGridUsuario();
            CarregarPermissoes();
            cboCidade.Enabled = false;
            grdDados.ReadOnly = true;  
            grdDados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            load = true;
        }

        private void CarregarGridUsuario()
        {
            try
            {
                grdDados.DataSource = user.Consultar();

                grdDados.Columns[0].Visible = false;
               // grdDados.Columns[8].Visible = false;
                grdDados.Columns[6].Visible = false;
                grdDados.Columns[7].Visible = false;
                grdDados.Columns[8].Visible = false;
                grdDados.Columns[9].Visible = false;
                grdDados.Columns[10].Visible = false;
                //grdDados.Columns[11].Visible = false;

                grdDados.Columns[1].Width = 200;
                grdDados.Columns[2].Width = 450;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            user = new Usuario();
            if (rdbNome.Checked)
            {
                user.Nome = txtPesquisa.Text;
                CarregarGridUsuario();
            }
            else if (rdbCPF.Checked)
            {
                user.CPF = txtPesquisa.Text;
                CarregarGridUsuario();
            }


        }

        private void LimparCampos()
        {
            user = new Usuario();
            txtPesquisa.Text = string.Empty;
            txtNome.Text = string.Empty;
            txtCelular.Text = string.Empty;
            rdbMasculino.Checked = true;
            rdbFeminino.Checked = false;
            txtCPF.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtSenha.Text = string.Empty;
            rdbAtivo.Checked = true;
            rdbDesativado.Checked = false;  
            txtEndereco.Text = string.Empty;
            txtNumero.Text = string.Empty;
            txtComplemento.Text = string.Empty;
            txtBairro.Text = string.Empty;
            txtUsuario.Text = string.Empty;
            cboCidade.SelectedIndex = -1;
            cboCidade.SelectedIndex = -1;
            cboEstado.SelectedIndex = -1;
            cboPermissao.SelectedIndex = -1;
            txtCEP.Text = string.Empty;
            txtPesquisa.Focus();

            cboCidade.Enabled = false;
        }

        private string ValidarPreenchimento()
        {
            try
            {
                string msgErro = string.Empty;
                if (txtUsuario.Text == string.Empty)
                {
                    msgErro = "Preencha o Usuário.\n";
                }

                else
                {
                    Usuario u = new Usuario();
                    u.Login = txtUsuario.Text;
                    u.Consultar();
                    if (user.Id == 0 && u.Id != 0 ||
                        user.Id != 0 && u.Id != 0 && user.Id != u.Id)
                    {
                        msgErro += "Usuário já existente.\n";
                    }
                }

                if (txtNome.Text == string.Empty)
                {
                    msgErro += "Preencha o NOME.\n";
                }

                if (txtCelular.Text == string.Empty)
                {
                    msgErro += "Preencha o Celular.\n";
                }
                if (txtEmail.Text == string.Empty)
                {
                    msgErro += "Preencha o campo E-MAIL\n";
                }
                else
                {
                    try
                    {
                        MailAddress ma = new MailAddress(txtEmail.Text);
                    }
                    catch
                    {
                        msgErro += "Campo EMAIL inválido.\n";
                    }
                }
                if (txtSenha.Text == string.Empty)
                {
                    msgErro += "Preencha a SENHA.\n";
                }
                if (cboPermissao.SelectedIndex == -1)
                {
                    msgErro += "Selecione o campo Permissao.\n";
                }

                if (txtEndereco.Text == string.Empty)
                {
                    msgErro += "Preencha o campo ENDEREÇO\n";
                }
                if (txtNumero.Text == string.Empty)
                {
                    msgErro += "Preencha o campo NÚMERO.\n";
                }
                if (txtBairro.Text == string.Empty)
                {
                    msgErro += "Preencha o campo BAIRRO.\n";
                }
                if (txtCEP.Text == string.Empty)
                {
                    msgErro += "Preencha o campo CEP.\n";
                }
                if (cboCidade.SelectedIndex == -1)
                {
                    msgErro += "Selecione o campo CIDADE.\n";
                }
                if (cboEstado.SelectedIndex == -1)
                {
                    msgErro += "Selecione o campo ESTADO.\n";
                }
                if(txtCPF.Text == String.Empty || txtCPF.Text.Length < 11)
                {
                    msgErro += "CPF INVALIDO!.\n";
                }

                if(cboPermissao.SelectedIndex == -1)
                {
                    msgErro += "Selecione o campo Permissão.\n";
                }

                if(!rdbMasculino.Checked && !rdbFeminino.Checked)
                {
                    msgErro += "Selecione o campo Sexo.\n";
                }

                return msgErro;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    

        private void txtCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Global.SomenteNumeros(e.KeyChar, (sender as TextBox).Text);
        }

        private void txtCEP_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Global.SomenteNumeros(e.KeyChar, (sender as TextBox).Text);
        }

        private void txtPesquisa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (rdbCPF.Checked)
            {
                e.Handled = Global.SomenteNumeros(e.KeyChar, (sender as TextBox).Text);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void rdbCPF_CheckedChanged(object sender, EventArgs e)
        {
            CarregarGridUsuario();
        }

        private void CarregarPermissoes()
        {
            try
            {
                DataTable dt = user.getPermissions();

                
                cboPermissao.DataSource = dt;

            
                cboPermissao.DisplayMember = "Descricao";
                cboPermissao.ValueMember = "Id";
                cboPermissao.SelectedIndex = -1; 
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao carregar as permissões: " + ex.Message);
            }
        }
        private void PreencherFormulario()
        {
            
            txtNome.Text = user.Nome;
            txtCelular.Text = user.Telefone;
            if(user.SexoId != 1)
            {
                rdbFeminino.Checked = true;
            } else
            {
                rdbMasculino.Checked = true;
            }

            txtCPF.Text = user.CPF;
            txtEmail.Text = user.Email;
            txtSenha.Text = user.Password;
            txtUsuario.Text = user.Login;
            rdbAtivo.Checked = user.Ativo;
            rdbDesativado.Checked = !user.Ativo;

            Endereco end = user.Endereco;
            end.Consultar(user.EnderecoId);


      
            txtEndereco.Text = end.Logradouro;
            txtNumero.Text = end.Numero;
            txtComplemento.Text = end.Complemento;
            txtBairro.Text = end.Bairro;
            txtCEP.Text = end.CEP;
            int codigoEstado = Global.ConsultarEstado(end.CidadeId);
            cboEstado.SelectedValue = codigoEstado;
            cboCidade.SelectedValue = end.CidadeId;
            cboPermissao.SelectedValue = user.PermissaoId;
        }
        private void grdDados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grdDados.SelectedRows.Count > 0)
                {
                    int userId = Convert.ToInt32(grdDados.SelectedRows[0].Cells[0].Value);
                    user = new Usuario();
                    user.Id = userId;
                    user.Consultar();
                    PreencherFormulario();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Erro",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPesquisa.Text = ex.Message;
            }
        }



        private void CarregarEstados()
        {
            try
            {
                cboEstado.DataSource = Global.ConsultarEstados();
                cboEstado.DisplayMember = "Estado";
                cboEstado.ValueMember = "Id";
                cboEstado.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Erro",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void CarregarCidades()
        {
            if (!load)
            {
                return;
            }

            try
            {
                int estado = Convert.ToInt32(cboEstado.SelectedValue);
                cboCidade.DataSource = Global.ConsultarCidades(estado);
                
                cboCidade.DisplayMember = "Cidade";
                cboCidade.ValueMember = "Id";
                cboCidade.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Erro",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void cboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboCidade.Enabled = true;
            CarregarCidades();
        }



	

        private void PreencherClasses()
        {
	    
	    user.Endereco.Logradouro = txtEndereco.Text;
        user.Endereco.Numero = txtNumero.Text;
        user.Endereco.Complemento = txtComplemento.Text;
        user.Endereco.Bairro = txtBairro.Text;
        user.Endereco.CEP = txtCEP.Text;
        user.Endereco.CidadeId = Convert.ToInt32(cboCidade.SelectedValue);


        user.Nome = txtUsuario.Text;
        user.Telefone = txtCelular.Text;
        user.CPF = txtCPF.Text;
        user.Email = txtEmail.Text;
        user.Login = txtUsuario.Text;
        if (user.Password != txtSenha.Text)
        {
        user.Password = Global.Criptografar(txtSenha.Text);
        }
        user.PermissaoId = Convert.ToInt32(cboPermissao.SelectedValue);
        user.Ativo = rdbAtivo.Checked;
        user.SexoId = rdbMasculino.Checked ? 1 : 2;
      }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {
                string mensagemErro = ValidarPreenchimento();
                if (mensagemErro != string.Empty)
                {
                    MessageBox.Show(mensagemErro, "Erro de Preenchimento",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                PreencherClasses();
                int idEndereco = user.Endereco.Gravar();
                
                user.EnderecoId = idEndereco;
                
                user.Gravar();
                MessageBox.Show("Usuario Adicionado/Alterado Com Sucesso!","Cadastro Usuário",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Erro",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpar_Click_1(object sender, EventArgs e)
        {
            LimparCampos();
        }
    }
}
