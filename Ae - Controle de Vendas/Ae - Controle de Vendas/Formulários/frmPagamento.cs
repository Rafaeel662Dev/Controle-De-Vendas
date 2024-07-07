using Ae___Controle_de_Vendas.Classes.Outros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ae___Controle_de_Vendas.Formulários
{
    public partial class frmPagamento : Form
    {
        public frmPagamento()
        {
            InitializeComponent();
        }

        public static int FormaPagamentoId = 0;
        public static string CPF;

        public static int ObterFormaPagamentoId()
        {
            return FormaPagamentoId;
        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FormaPagamento_Load(object sender, EventArgs e)
        {
            try {

                CarregarCategorias();

            } catch(Exception ex) {

                MessageBox.Show(ex.Message,"Erro Forma de Pagamento",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public static DataTable getFormaPagamento()
        {

            AcessoBD acesso = new AcessoBD();
            DataTable dt = new DataTable();
            List<SqlParameter> parameters = new List<SqlParameter>();
            try
            {
                string sql = "SELECT Id, Descricao FROM tblFormaPagamento \n";
                return new AcessoBD().Consultar(sql, new List<SqlParameter>());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        private void CarregarCategorias()
        {
            try
            {
                DataTable dt = getFormaPagamento();


                CboPagamento.DataSource = dt;


                CboPagamento.DisplayMember = "Descricao";
                CboPagamento.ValueMember = "Id";
                CboPagamento.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao carregar as permissões: " + ex.Message);
            }
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            string error = ValidarCampos();

            if(error != string.Empty)
            {
                MessageBox.Show(error,"Erro de Preenchimento", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            
            FormaPagamentoId = Convert.ToInt32(CboPagamento.SelectedValue);
            CPF = txtCPF.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private string ValidarCampos()
        {
            string msgError = string.Empty;
            if(CboPagamento.SelectedIndex == -1)
            {
                msgError = "Forma de Pagamento Não Selecionada!! \n";
            }

            if(txtCPF.Text.Length > 0 && txtCPF.Text.Length != 11)
            {
                msgError += "CPF INVALIDO!";
            }
            return msgError;
        }

        private void txtCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.SomenteNumeros(e.KeyChar, (sender as TextBox).Text);
        }
    }
}
