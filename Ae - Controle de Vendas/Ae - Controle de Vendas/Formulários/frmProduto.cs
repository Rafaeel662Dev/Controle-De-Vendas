using Ae___Controle_de_Vendas.Classes.Outros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ae___Controle_de_Vendas.Formulários
{
    public partial class frmProduto : Form
    {

        public bool load = false;
        public Produto produto = new Produto();


        public frmProduto()
        {
            InitializeComponent();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }


        private void LimparCampos()
        {
            produto = new Produto();
            txtCodigo.Clear();
            txtPesquisa.Clear();
            txtNome.Clear();
            maskPreco.Clear();
            cboCategoria.SelectedIndex = -1;
            txtPesquisa.Focus();
            CarregarGridCategoria();

        }

        private void PreencherClasse()
        {

            produto.Codigo = Convert.ToInt32(txtCodigo.Text);
            produto.Nome = txtNome.Text;
            decimal precoConvertido = ConverterMoedaParaDecimal(maskPreco.Text);
            produto.Preco = Convert.ToDecimal(precoConvertido);
            produto.CategoriaId = Convert.ToInt32(cboCategoria.SelectedValue);


        }


        private  decimal ConverterMoedaParaDecimal(string valorMoeda)
        {
            // Definir a cultura para o Brasil para garantir que o formato de moeda seja reconhecido corretamente
            CultureInfo culturaBrasileira = new CultureInfo("pt-BR");

            // Remover caracteres não numéricos e converter para um formato compatível com decimal
            string valorNumerico = valorMoeda
                .Replace("R$", "") // Remover o símbolo da moeda, se presente
                .Replace(".", "")  // Remover separadores de milhar
                .Replace(".", ""); // Substituir vírgula por ponto para o separador decimal

            // Converter a string para decimal utilizando a cultura brasileira
            decimal valorDecimal;
            if (!decimal.TryParse(valorNumerico, NumberStyles.Currency, culturaBrasileira, out valorDecimal))
            {
                throw new ArgumentException("Valor de moeda inválido: " + valorMoeda);
            }

            return valorDecimal;
        }


        private void ConvertMask(MaskedTextBox mask)
        {
            string valorTexto = mask.Text;

            valorTexto = valorTexto.Replace("R$", "").Replace(" ", "").Replace(".", "").Trim();

            valorTexto = valorTexto.Replace(",", ".");

            if (decimal.TryParse(valorTexto, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal preco))
            {
                produto.Preco = preco;
            }
            else
            {
                // Tratar o caso em que a conversão falha (valor inválido)
                MessageBox.Show("Valor de preço inválido.");
            }
        }

        private void PreencherFormulario()
        {
            txtNome.Text = produto.Nome;
            txtCodigo.Text = produto.Codigo.ToString();
            maskPreco.Text = produto.Preco.ToString("C");
            

            cboCategoria.SelectedValue = produto.CategoriaId;
        }


        private void CarregarCategorias()
        {
            try
            {
                DataTable dt = produto.getCategorias();


                cboCategoria.DataSource = dt;


                cboCategoria.DisplayMember = "Descricao";
                cboCategoria.ValueMember = "Id";
                cboCategoria.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao carregar as permissões: " + ex.Message);
            }
        }

        private string ValidarCampos()
        {
            string msgError = string.Empty;

	
            if (txtNome.Text == String.Empty)
            {
                msgError = "Preencha o Campo Nome \n";
            }

            if (txtCodigo.Text == String.Empty) {
                msgError += "Preencha o Campo Codigo \n";
            }

            if (maskPreco.Text == string.Empty)
            {
                msgError += "Preencha o Campo Preço";
            }
            else { 
                
            }

            if (cboCategoria.SelectedIndex == -1)
            {
                msgError += "Preencha A Categoria \n";
            }


            return msgError;
        }

        private string verificarExistencia()
        {

            string msg = string.Empty;

            try
            {
                Produto existe = new Produto();
                existe.Codigo = Convert.ToInt32(txtCodigo.Text);
                existe.Consultar();

                if (produto.Id == 0 && existe.Id != 0 ||
                        produto.Id != 0 && existe.Id != 0 && produto.Id != existe.Id)
                {
                    msg = "Codigo já existente \n";
                }

                existe = new Produto();
                existe.Nome = txtNome.Text;
                existe.Consultar();


                if (produto.Id == 0 && existe.Id != 0 ||
                        produto.Id != 0 && existe.Id != 0 && produto.Id != existe.Id)
                {
                    msg += "Nome já existente";
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            return msg;
        }

        private void CarregarGridCategoria()
        {
            try
            {
                grdDados.DataSource = produto.Consultar();

                grdDados.Columns[0].Visible = false;
                grdDados.Columns[4].Visible = false;

                grdDados.Columns[1].Width = 100;
                grdDados.Columns[2].Width = 400;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro-->" + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmProduto_Load(object sender, EventArgs e)
        {
            load = true;
            maskPreco.TextAlign = HorizontalAlignment.Left;
            maskPreco.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            grdDados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            CarregarGridCategoria();
            CarregarCategorias();



            maskPreco.Text = produto.Preco.ToString("C");
            if (grdDados.Columns.Count > 0)
    {
        grdDados.Columns[grdDados.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
    }

            Usuario user = new Usuario();
            user.Id = Global.IdUsuarioLogado;
            user.Consultar();
            if(user.PermissaoId == 3)
            {
                desabilitarCampos();
            } 
        }

        private void desabilitarCampos()
        {
            btnGravar.Enabled = false;
            txtNome.Enabled = false;
            txtCodigo.Enabled = false;
            maskPreco.Enabled = false;
            cboCategoria.Enabled = false;
        }


        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                string campos = ValidarCampos();
                string existe = verificarExistencia();


                if (campos != string.Empty)
                {
                    MessageBox.Show(campos, "Erro de Preenchimento",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (existe != string.Empty) {

                    MessageBox.Show(existe, "Erro de Preenchimento",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;


                }


                PreencherClasse();
                produto.Gravar();
                MessageBox.Show("Produto Adicionado/Alterado Com Sucesso!", "Cadastro Produto", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao gravar o produto: " + ex.Message);
            } 
            
        }


        private void grdDados_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 3 && e.Value != null && e.Value != DBNull.Value)
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal valor))
                {
                    e.Value = valor.ToString("C"); 
                    
                    e.FormattingApplied = true;
                }
            }
        }

        private void lblCategoria_Click(object sender, EventArgs e)
        {

        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            produto = new Produto();
            if (rdbNome.Checked)
            {
                produto.Nome = txtPesquisa.Text;
                CarregarGridCategoria();
            } else if (rdbCodigo.Checked)
            {
                if(txtPesquisa.Text.Length > 1) 
                produto.Codigo = Convert.ToInt32(txtPesquisa.Text);
                CarregarGridCategoria();
            }
        }

        private void txtPesquisa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (rdbCodigo.Checked)
            {
                e.Handled = Global.SomenteNumeros(e.KeyChar, (sender as TextBox).Text);
            }
        }

        private void lblCodigo_Click(object sender, EventArgs e)
        {

        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblPreco_Click(object sender, EventArgs e)
        {

        }

        private void grdDados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try {
                if (grdDados.SelectedRows.Count > 0)
                {

                    int produtoId = Convert.ToInt32(grdDados.SelectedRows[0].Cells[0].Value);
                    produto = new Produto();
                    produto.Id = produtoId;

                    produto.Consultar();
                    
                    PreencherFormulario();
                }
            }  catch (Exception ex) { 
                MessageBox.Show("Erro-->" + ex.Message, "Erro",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbNome_CheckedChanged(object sender, EventArgs e)
        {
            LimparCampos();
            CarregarGridCategoria();
        }

        private void maskPreco_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void grdDados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void maskPreco_TextChanged_1(object sender, EventArgs e)
        {
            
        }

        private void maskPreco_KeyPress(object sender, KeyPressEventArgs e)
        {
            //.Handled = Global.SomenteNumeros(e.KeyChar, (sender as TextBox).Text);

        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Global.SomenteNumeros(e.KeyChar, (sender as TextBox).Text);
        }
    }
}
