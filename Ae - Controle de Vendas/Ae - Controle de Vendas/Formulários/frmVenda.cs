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
            DataTable dt = new DataTable();
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

        private void CarregarGridItensVenda()
        {

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
    }
}
