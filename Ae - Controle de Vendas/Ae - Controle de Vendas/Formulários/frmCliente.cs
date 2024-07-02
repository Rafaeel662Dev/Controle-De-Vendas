using Ae___Controle_de_Vendas.Classes.Outros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ae___Controle_de_Vendas.Formulários
{
    public partial class frmCliente : Form
    {

        Cliente cliente = new Cliente();
        Endereco end = new Endereco();
        bool load = false;

        public frmCliente()
        {
            InitializeComponent();
        }

        private void frmCliente_Load(object sender, EventArgs e)
        {
            CarregarEstados();
            
            grdDados.ReadOnly = true;
            grdDados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            cboCidade.Enabled = false;
            load = true;
            CarregarGridCliente();

        }


        private void rdbNome_CheckedChanged(object sender, EventArgs e)
        {
            CarregarGridCliente();
            LimparCampos();

        }


        private void LimparCampos()
        {
            cliente = new Cliente();

            txtPesquisa.Text = string.Empty;
            txtNome.Text = string.Empty;
            txtCelular.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtCEP.Text = string.Empty;
            txtCPF.Text = string.Empty;
            txtEndereco.Text = string.Empty;
            txtNumero.Text = string.Empty;
            txtComplemento.Text = string.Empty;
            txtBairro.Text = string.Empty;
            cboEstado.SelectedIndex = -1;
            cboCidade.SelectedIndex = -1;
            cboCidade.Enabled = false;
            txtPesquisa.Focus();
            CarregarGridCliente();
        }

        private void LimitarCaracteres()
        {
            string msgError = string.Empty;
            if (txtNome.Text.Length > 80)
            {
                msgError = "Nome do Produto e Maior que 80 Caracteres";
            }
            if (txtCelular.Text.Length > 50)
            {
                msgError = "Celular e maior que 50 caracteres ";
            }
            if (txtEmail.Text.Length > 100)
            {
                msgError = "E-mail e maior que 100 caracteres ";
            }
            if (txtCEP.Text.Length > 20)
            {
                msgError = "CEP e maior que 20 caracteres ";
            }
            if (txtEndereco.Text.Length > 80)
            {
                msgError = "Endereço e maior que 80 caracteres ";
            }
            if (txtComplemento.Text.Length > 80)
            {
                msgError = "Complemento e maior que 80 caracteres ";
            }
            if (txtBairro.Text.Length > 60)
            {
                msgError = "Complemento e maior que 60 caracteres ";
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

     

        private void CarregarGridCliente()
        {
            try
            {
              
                grdDados.DataSource = cliente.Consultar();

                grdDados.Columns[0].Visible = false;
                grdDados.Columns[5].Visible = false;
                grdDados.Columns[6].Visible = false;
                grdDados.Columns[7].Visible = false;

                grdDados.Columns[1].Width = 100;
                grdDados.Columns[2].Width = 450;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

private void PreencherFormulario()
{
    txtNome.Text = cliente.Nome;
    txtCelular.Text = cliente.Telefone;
    txtCPF.Text = cliente.CPF;
    txtEmail.Text = cliente.Email;
    if (cliente.SexoId == 1)
    {
        rdbMasculino.Checked = true;
    }
    else
    {
        rdbFeminino.Checked = true;
    }

    Endereco end = cliente.Endereco;
    end.Consultar(cliente.EnderecoId);

    txtEndereco.Text = end.Logradouro;
    txtNumero.Text = end.Numero;
    txtComplemento.Text = end.Complemento;
    txtBairro.Text = end.Bairro;
    txtCEP.Text = end.CEP;

    int codigoEstado = Global.ConsultarEstado(end.CidadeId);
    cboEstado.SelectedValue = codigoEstado;
    cboCidade.SelectedValue = end.CidadeId;
}



        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            if (rdbNome.Checked)
            {
                cliente.Nome = txtPesquisa.Text;
                CarregarGridCliente();
            }
            else if (rdbCPF.Checked)
            {
                cliente.CPF = txtPesquisa.Text;
                CarregarGridCliente();
            }
        }

public void PreencherClasse()
{
    cliente.Endereco.Logradouro = txtEndereco.Text;
    cliente.Endereco.Numero = txtNumero.Text;
    cliente.Endereco.Complemento = txtComplemento.Text;
    cliente.Endereco.Bairro = txtBairro.Text;
    cliente.Endereco.CEP = txtCEP.Text;
    cliente.Endereco.CidadeId = Convert.ToInt32(cboCidade.SelectedValue);

    cliente.Nome = txtNome.Text;
    cliente.CPF = txtCPF.Text;
    cliente.Telefone = txtCelular.Text;
    cliente.Email = txtEmail.Text;
    cliente.SexoId = rdbMasculino.Checked ? 1 : 2;
}


        private void txtPesquisa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (rdbCPF.Checked)
            {
                e.Handled = Global.SomenteNumeros(e.KeyChar, (sender as TextBox).Text);
            }
        }

        private void txtCEP_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Global.SomenteNumeros(e.KeyChar, (sender as TextBox).Text);
        }
        private void txtCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Global.SomenteNumeros(e.KeyChar, (sender as TextBox).Text);
        }

        private void cboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarCidades();
            cboCidade.Enabled = true;
        }

        private string ValidarPreenchimento()
        {
            string msgError = string.Empty;

            if(txtEndereco.Text == string.Empty)
            {
                msgError = "Campo Logradouro Não Preenchido \n";
            }

            if(txtNumero.Text == string.Empty)
            {
                msgError += "Campo Numero Não Preenchido \n";
            }

            if(txtBairro.Text == string.Empty)
            {
                msgError += "Campo Bairro Não Preenchido \n";
            }

            if(txtCEP.Text == string.Empty)
            {
                msgError += "Campo CEP Não Preenchido \n";
            }

            if (cboEstado.SelectedIndex == -1)
            {
                msgError += "Campo Estado Não Selecionado \n";
            }

            if (cboCidade.SelectedIndex == -1)
            {
                msgError += "Campo Cidade Não Selecionado \n";
            }

            if(txtNome.Text == string.Empty)
            {
                msgError += "Campo Nome Não Preenchido \n";
            }
            if (txtCelular.Text == string.Empty)
            {
                msgError += "Campo Celular  Não Preenchido \n";
            }
                if (txtEmail.Text == string.Empty)
                {
                    msgError += "Preencha o campo E-MAIL\n";
                }
                else
                {
                    try
                    {
                        MailAddress ma = new MailAddress(txtEmail.Text);
                    }
                    catch
                    {
                        msgError += "Campo EMAIL inválido.\n";
                    }
              	}
            if (!rdbMasculino.Checked && !rdbFeminino.Checked)
            {
                msgError += "Selecione o campo Sexo.\n";
            }



            return msgError;
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

                PreencherClasse();

                int idEndereco = cliente.Endereco.Gravar();
           
                cliente.EnderecoId = idEndereco;
                if(cliente.Nome == "AVULSO")
                {
                    MessageBox.Show("O Cliente AVULSO não pode ser editado!","Cliente",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
                cliente.Gravar();
                LimparCampos();
                CarregarGridCliente();
                MessageBox.Show("Cliente Adicionado/Alterado Com Sucesso!", "Cadastro Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grdDados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grdDados.SelectedRows.Count > 0)
                {
                    int clientId = Convert.ToInt32(grdDados.SelectedRows[0].Cells[0].Value);
                    cliente = new Cliente();
                    cliente.Id = clientId;
                    cliente.Consultar();

                    PreencherFormulario();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Erro",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void groupBoxEndereco_Enter(object sender, EventArgs e)
        {

        }
    }
}
