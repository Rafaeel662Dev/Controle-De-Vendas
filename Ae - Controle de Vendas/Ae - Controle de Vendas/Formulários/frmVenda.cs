using Ae___Controle_de_Vendas.Classes.Outros;
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
    public partial class frmVenda : Form
    {
        public frmVenda()
        {
            InitializeComponent();
        }

        Venda v = new Venda();
        Cliente cliente = new Cliente();
        Usuario usuario = new Usuario();
        DataTable formaPagamento = frmPagamento.getFormaPagamento();
        Item item = new Item();
        NotaFiscal NotaFiscal = new NotaFiscal();
        Produto produto = new Produto();
        DataTable dt = new DataTable();

        private bool load = false;

        private void frmVenda_Load(object sender, EventArgs e)
        {
          

            CarregarGridVenda();
            grdVenda.Columns[0].Width = 90;
            grdVenda.Columns[1].Width = 150;
            grdVenda.Columns[2].Width = 150;
            load = true;
        }

        private void PreencherFormulário()
        {

        }

        

        private void CarregarGridVenda()
        {
            dt = new DataTable();
            dt = v.Consultar();

            dt.Columns.Add("N. Venda", typeof(int));
            dt.Columns.Add("Cliente", typeof(string));
            dt.Columns.Add("Funcionario", typeof(string));
            dt.Columns.Add("F. Pagamento", typeof(string));
            dt.Columns.Add("Nota", typeof(string));

            for (int i =0; i < dt.Rows.Count; i++)
            {
                cliente = new Cliente();
                cliente.Id = Convert.ToInt32(dt.Rows[i]["ClienteId"].ToString());
                cliente.Consultar();

                usuario = new Usuario();
                usuario.Id = Convert.ToInt32(dt.Rows[i]["FuncionarioId"].ToString());
                usuario.Consultar();

                

                dt.Rows[i]["N. Venda"] = dt.Rows[i]["Id"];
                dt.Rows[i]["Cliente"] = cliente.Nome;
                dt.Rows[i]["Funcionario"] = usuario.Nome;
                dt.Rows[i]["F. Pagamento"] = "Ajustar!";

            }

            dt.Columns.Remove("Id");
            dt.Columns.Remove("ClienteId");
            dt.Columns.Remove("FuncionarioId");
            dt.Columns.Remove("FormaPagamentoId");

            //dt.Rows[0]["NomeCliente"] = cliente.Nome;

            grdVenda.DataSource = dt;
        }

        private DataGridViewRow ObterLinhaSelecionada()
        {
            if (grdVenda.SelectedRows.Count > 0)
            {
                return grdVenda.SelectedRows[0];
            }
            else
            {
                return null;
            }
        }

        private void CarregarGridItensVenda()
        {
            DataGridViewRow s = ObterLinhaSelecionada();
            item = new Item();
            item.VendaId = Convert.ToInt32(s.Cells["N. Venda"].Value);
           



            DataTable dt = item.ConsultarItens();
            dt.Columns.Add("Produto", typeof(string));
            dt.Columns.Add("Quant.", typeof(int));
            dt.Columns.Add("Valor", typeof(decimal));


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                produto = new Produto();
                produto.Id = Convert.ToInt32(dt.Rows[i]["ProdutoId"].ToString());
                produto.Consultar();
                dt.Rows[i]["Produto"] = produto.Nome;
                dt.Rows[i]["Quant."] = dt.Rows[i]["Quantidade"];
                dt.Rows[i]["Valor"] = dt.Rows[i]["Preco"];

            }

            grdItems.DataSource = dt;
            grdItems.Columns[0].Visible = false;
            grdItems.Columns[1].Visible = false;
            grdItems.Columns[2].Visible = false;
            grdItems.Columns[3].Visible = false;
            grdItems.Columns[4].Visible = false;


            grdItems.Columns[5].Width = 200;
            grdItems.Columns[6].Width = 50;

        }


        private void LimparCampos()
        {

        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPesquisa_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void grdVenda_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CarregarGridItensVenda();
        }

        private void grdItems_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((e.ColumnIndex == 4 || e.ColumnIndex == 7) && e.Value != null && e.Value != DBNull.Value)
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
    }
}
