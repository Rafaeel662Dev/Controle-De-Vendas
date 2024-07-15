using Ae___Controle_de_Vendas.Classes.Outros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace Ae___Controle_de_Vendas.Formulários
{
    public partial class frmCaixa : Form
    {
        public frmCaixa()
        {
            InitializeComponent();
        }


        Venda venda = new Venda();
        NotaFiscal nota = new NotaFiscal();
        Cliente cliente = new Cliente();
        Usuario usuario = new Usuario();
        Item item = new Item();
        Produto produto = new Produto();
        decimal precototal = 0;
        DataTable dataTable;
        int VendaId = 0;

        private void frmVenda_Load(object sender, EventArgs e)
        {
            txtPrecoProduto.Text = $"R$ {produto.Preco.ToString("N2")}";
            dataTable = produto.Consultar();
            dataTable.Clear();
            dataTable.Columns.Add("Quantidade", typeof(int));
            dataTable.Columns.Add("Total", typeof(string));
            dataTable.Columns.Add("Categoria", typeof(string));
        }


        private void PreencherClasses()
        {

        }


        private string VerificarCampos()
        {
            string msgErrror = string.Empty;
            if (string.IsNullOrEmpty(cliente.CPF))
            {
                msgErrror = "Cliente Não Encontrado \n";
            }
            if (produto.Codigo == 0)
            {
                msgErrror += "Código Invalido!!! \n";
            }
            if (string.IsNullOrEmpty(txtQuantidade.Text))
            {
                msgErrror += "Campo Quantidade Invalído!!!\n";
            }
            return msgErrror;
        }


        private void AdicionarItem()
        {

            if(produto.Id == 0)
            {
                MessageBox.Show("Produto Inválido!","Caixa - Produto", MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return;
            }

            if (cliente.Id == 0)
            {
                MessageBox.Show("Cliente Inexistente!", "Caixa - Produto", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            try
            {
                string erro = VerificarCampos();
                if (!string.IsNullOrEmpty(erro))
                {
                    MessageBox.Show(erro, "Preenchimento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Supondo que você já tenha um DataTable existente ou cria um novo
                // Adicione as colunas necessárias ao DataTable (supondo que seu DataTable já tenha colunas definidas)


                // Adicionar uma nova linha para representar um produto
                //grdDados.Columns[0].Visible = false;
                //grdDados.Columns["Preco"].DefaultCellStyle.Format = "C2";
                DataRow novaLinha = dataTable.NewRow();
                novaLinha["Id"] = produto.Id;
                novaLinha["CategoriaId"] = produto.CategoriaId;
                novaLinha["Codigo"] = produto.Codigo;
                novaLinha["Nome"] = produto.Nome;
                novaLinha["Preco"] = produto.Preco;
                novaLinha["Quantidade"] = Convert.ToInt32(txtQuantidade.Text);
                novaLinha["Categoria"] = produto.getCategorias(produto.CategoriaId);
                novaLinha["Total"] = Convert.ToInt32(txtQuantidade.Text) * produto.Preco;



                // Adicionar a nova linha ao DataTable
                dataTable.Rows.Add(novaLinha);

                // Atualizar a fonte de dados da grade
                grdDados.DataSource = null; // Limpar a fonte de dados atual (opcional)
                grdDados.DataSource = dataTable; // Atribuir o DataTable atualizado à grade

                grdDados.Columns["CategoriaId"].Visible = false;
                grdDados.Columns["Id"].Visible = false;

                // Ajustar largura das colunas automaticamente
                //grdDados.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                grdDados.Columns[2].Width = 400;

                precototal += produto.Preco * Convert.ToInt32(txtQuantidade.Text);
                lblValor.Text = precototal.ToString("C");
                txtQuantidade.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void RemoverItem()
        {

        }

        private void GravarVenda()
        {

        }

        private void txtCPF_TextChanged(object sender, EventArgs e)
        {


        }

        private void txtCodigoProduto_TextChanged(object sender, EventArgs e)
        {

        }

        private void limparProduto()
        {
            produto = new Produto();

            txtNomeProduto.Clear();

            txtCodigoProduto.Clear();
            txtPrecoProduto.Text = $"R$ {produto.Preco.ToString("N2")}";
        }

        private void PreencherProduto()
        {
            produto = new Produto();
            produto.Codigo = Convert.ToInt32(txtCodigoProduto.Text);
            produto.ConsultarCodigo();
            txtPrecoProduto.Text = $"R$ {produto.Preco.ToString("N2")}";
            txtNomeProduto.Text = produto.Nome.ToString();
        }

        private void txtCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            cliente = new Cliente();
            cliente.CPF = txtCPF.Text;
            cliente.Consultar();

            if (cliente.Nome == "AVULSO")
            {
                return;
            }
            if (txtCPF.Text.Length == 11 && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }

            if (cliente.Nome == "Avulso")
            {
                cliente = new Cliente();
                return;
            }
            txtNomeCliente.Text = cliente.Nome;
        }

        private void txtCodigoProduto_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Global.SomenteNumeros(e.KeyChar, (sender as TextBox).Text);
        }



        private void txtQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Global.SomenteNumeros(e.KeyChar, (sender as TextBox).Text);
        }

        private void checkAvulso_CheckedChanged(object sender, EventArgs e)
        {
            if (checkAvulso.Checked)
            {
                txtCPF.Enabled = false;
                cliente = new Cliente();
                cliente.CPF = "00000000000";
                cliente.Consultar();
                txtNomeCliente.Text = cliente.Nome;
                txtCPF.Text = cliente.CPF;

            }
            else
            {
                cliente = new Cliente();
                txtCPF.Text = string.Empty;
                cliente.Consultar();
                txtNomeCliente.Text = cliente.Nome;
                txtCPF.Enabled = true;
                txtCPF.Focus();
            }
        }

        private void txtCodigoProduto_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCodigoProduto.Text))
            {
                PreencherProduto();
                return;
            }
            else
            {
                limparProduto();
            }
        }

        private void btnCalculadora_Click(object sender, EventArgs e)
        {
            AbrirCalculadora();
        }

        private void AbrirCalculadora()
        {
            try
            {
                string calculadoraPath = @"C:\Windows\System32\calc.exe";

                if (System.IO.File.Exists(calculadoraPath))
                {
                    Process.Start(calculadoraPath);
                }
                else
                {
                    MessageBox.Show("A calculadora não foi encontrada.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao abrir a calculadora: " + ex.Message);
            }
        }

        private void txtCPF_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            AdicionarItem();
        }

        private void txtCodigoProduto_Click(object sender, EventArgs e)
        {
            limparProduto();
        }



        private void grdDados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblValor_Click(object sender, EventArgs e)
        {
        }


        private void grdDados_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Verifica se a célula é das colunas 3 ou 5 e se o valor não é nulo ou DBNull
            if ((e.ColumnIndex == 3 || e.ColumnIndex == 6) && e.Value != null && e.Value != DBNull.Value)
            {
                // Tenta converter o valor da célula para decimal
                if (decimal.TryParse(e.Value.ToString(), out decimal valor))
                {
                    // Formata o valor para moeda brasileira
                    e.Value = valor.ToString("C");

                    // Indica que a formatação foi aplicada
                    e.FormattingApplied = true;
                }
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            DataGridViewRow s = ObterLinhaSelecionada();
            if (s != null)
            {
                DialogResult result = MessageBox.Show("Tem certeza que deseja cancelar o item?", "Cancelamento Item", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    decimal convertido = Global.ConverterDinheiroParaDecimal("" + s.Cells["Total"].Value);
                    decimal total = convertido;

                    if (precototal - total < 0)
                    {
                        precototal = 0;
                    }
                    else
                    {
                        precototal = precototal - total;
                    }

                    lblValor.Text = precototal.ToString("C");

                    grdDados.Rows.Remove(ObterLinhaSelecionada());
                }
            }
            else
            {
                MessageBox.Show("Nenhum Item Foi Selecionado!", "Cancelar Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private DataGridViewRow ObterLinhaSelecionada()
        {
            if (grdDados.SelectedRows.Count > 0)
            {
                return grdDados.SelectedRows[0];
            }
            else
            {
                return null;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnFinalizarVenda_Click(object sender, EventArgs e)
        {
            frmPagamento f = new frmPagamento();

            if (grdDados.RowCount == 0) {
                MessageBox.Show("A Venda Não Contém Nenhum Item");
                return;
            }

            if (f.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    venda = new Venda();
                    venda.Cliente = cliente;

                    usuario = new Usuario();
                    usuario.Id = Global.IdUsuarioLogado;
                    usuario.Consultar();

                    venda.Preco = precototal;
                    venda.FormaPagamentoId = frmPagamento.ObterFormaPagamentoId();
                    venda.StatusId = 3;
                    VendaId = venda.Gravar();

                    percorrerItens();

                    MessageBox.Show("Venda Realizada!" + " \n Codigo: " + venda.Id,"Caixa - Amor Em Caldas", MessageBoxButtons.OK,MessageBoxIcon.Information);
                    LimparListaItens();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }



                GravarVenda();
            }
        }

        private void LimparListaItens()
        {
            dataTable.Rows.Clear();
            grdDados.DataSource = dataTable;
            lblValor.Text = "R$ 0,00"; 
            precototal = 0; 
            limparProduto();

            if(checkAvulso.Checked)
            {
                checkAvulso.Checked = false;
                
            }
            txtNomeCliente.Clear();
            txtCPF.Clear();
            cliente = new Cliente();
            txtQuantidade.Clear();
        }



        public void percorrerItens()
        {
            try
            {
                for (int i = 0; i < grdDados.Rows.Count; i++)
                {
                    DataGridViewRow linha = grdDados.Rows[i];

                    if (!linha.IsNewRow)
                    {
                       
                        int id = Convert.ToInt32(linha.Cells["Id"].Value);
                        int categoriaId = Convert.ToInt32(linha.Cells["CategoriaId"].Value);
                        int codigo = Convert.ToInt32(linha.Cells["Codigo"].Value);
                        string nome = Convert.ToString(linha.Cells["Nome"].Value);
                        int quantidade = Convert.ToInt32(linha.Cells["Quantidade"].Value);
                        decimal total = Convert.ToDecimal(linha.Cells["Total"].Value);

                       
                        Item novoItem = new Item
                        {
                            Quantidade = quantidade,
                            Preco = total,
                            VendaId = VendaId,
                            ProdutoId = id
                        };

               
                        novoItem.Gravar();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao percorrer itens: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }



            }
