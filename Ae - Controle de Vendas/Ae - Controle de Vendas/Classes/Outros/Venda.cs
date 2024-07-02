using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;

namespace Ae___Controle_de_Vendas.Classes.Outros
{
    public class Venda
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Cliente Cliente { get; set; }
        public int FormaPagamentoId { get; set; }

        AcessoBD acesso = new AcessoBD();
        DataTable dt = new DataTable();
        List<SqlParameter> parameters = new List<SqlParameter>();
        string sql = string.Empty;

        public Venda()
        {
            Id = 0;
            Date = DateTime.MinValue;
            Cliente = new Cliente();
            FormaPagamentoId = 0;
        }

        public int Gravar()
        {
            try
            {
                parameters.Clear();

                if (Id == 0)
                {
                    sql = "INSERT INTO tblVenda (ClienteId, FuncionarioId, FormaPagamentoId) ";
                    sql += "VALUES (@clienteId, @usuarioId, @formaPagamentoId); SELECT SCOPE_IDENTITY();";

                    // Formatar a data conforme necessário para o SQL Server
                    //string dataFormatada = data.ToString("yyyy-MM-dd HH:mm:ss.fff");
                    string dataHoraAtual = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

                    parameters.Add(new SqlParameter("@clienteId", Cliente.Id));
                    parameters.Add(new SqlParameter("@usuarioId", Global.IdUsuarioLogado));
                    parameters.Add(new SqlParameter("@formaPagamentoId", FormaPagamentoId));

                    Id = acesso.Executar(parameters, sql); // Executa o INSERT e retorna o ID inserido

                    return Id; // Retorna o ID inserido
                }
                else
                {
                    sql = "UPDATE tblVenda SET ";
                    
                    sql += "ClienteId = @clienteId, ";
                    sql += "UsuarioId = @usuarioId, ";
                    sql += "FormaPagamentoId = @formaPagamentoId ";
                    sql += "WHERE Id = @id;";

                    // Formatar a data conforme necessário para o SQL Server
                    string dataHoraAtual = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    parameters.Add(new SqlParameter("@id", Id));
                    parameters.Add(new SqlParameter("@clienteId", Cliente.Id));
                    parameters.Add(new SqlParameter("@usuarioId", Global.IdUsuarioLogado));
                    parameters.Add(new SqlParameter("@formaPagamentoId", FormaPagamentoId));

                    acesso.Executar(sql, parameters); // Executa o UPDATE

                    return Id; // Retorna o ID atualizado
                }
            }
            catch (Exception ex)
            {
                // Aqui você pode adicionar um tratamento mais específico para a exceção, se necessário
                throw new Exception("Erro ao gravar venda: " + ex.Message);
            }
        }
    
public void Consultar()
        {
            try
            {
                parameters.Clear();
                sql = "SELECT Id,ClienteId, UsuarioId, FormaPagamentoId ";
                sql += "FROM tblVenda ";

                if (Id != 0)
                {
                    sql += "WHERE Id = @id;";
                    parameters.Add(new SqlParameter("@id", Id));
                }


                dt = acesso.Consultar(sql, parameters);

                if (dt.Rows.Count > 0)
                {
                    Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                    Cliente.Id = Convert.ToInt32(dt.Rows[0]["ClienteId"]);
                    FormaPagamentoId = Convert.ToInt32(dt.Rows[0]["FormaPagamentoId"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
