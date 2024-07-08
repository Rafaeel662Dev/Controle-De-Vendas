using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Security.Cryptography;

namespace Ae___Controle_de_Vendas.Classes.Outros
{
    public class Venda
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Cliente Cliente { get; set; }
        public int FormaPagamentoId { get; set; }
        public Usuario Usuario { get; set; }
        public decimal Preco { get; set; }

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
            Preco = 0;
            Usuario = new Usuario();
        }

        public int Gravar()
        {
            try
            {
                parameters.Clear();

                if (Id == 0)
                {
                    sql = "INSERT INTO tblVenda (ClienteId, FuncionarioId, FormaPagamentoId,PRECO) ";
                    sql += "VALUES (@clienteId, @usuarioId, @formaPagamentoId,@PRECO); SELECT SCOPE_IDENTITY();";

                    
                    parameters.Add(new SqlParameter("@clienteId", Cliente.Id));
                    parameters.Add(new SqlParameter("@usuarioId", Global.IdUsuarioLogado));
                    parameters.Add(new SqlParameter("@formaPagamentoId", FormaPagamentoId));
                    parameters.Add(new SqlParameter("@PRECO", Preco));

                    Id = acesso.Executar(parameters, sql); 

                    return Id; 
                }
                else
                {
                    sql = "UPDATE tblVenda SET ";

                    sql += "ClienteId = @clienteId, ";
                    sql += "UsuarioId = @usuarioId, ";
                    sql += "FormaPagamentoId = @formaPagamentoId, ";
                    sql += "PRECO = @preco ";
                    sql += "WHERE Id = @id;";

                    parameters.Add(new SqlParameter("@id", Id));
                    parameters.Add(new SqlParameter("@clienteId", Cliente.Id));
                    parameters.Add(new SqlParameter("@usuarioId", Global.IdUsuarioLogado));
                    parameters.Add(new SqlParameter("@formaPagamentoId", FormaPagamentoId));
                    parameters.Add(new SqlParameter("@preco", Preco));

                    acesso.Executar(sql, parameters); 

                    return Id; 
                }
            }
            catch (Exception ex)
            {
                
                throw new Exception("Erro ao gravar venda: " + ex.Message);
            }
        }

        public DataTable Consultar()
        {
            try
            {
                parameters.Clear();
                sql = "SELECT Id,ClienteId, FuncionarioId, FormaPagamentoId,PRECO ";
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
                    Usuario.Id = Convert.ToInt32(dt.Rows[0]["FuncionarioId"]);
                    FormaPagamentoId = Convert.ToInt32(dt.Rows[0]["FormaPagamentoId"]);
                    Preco = Convert.ToDecimal(dt.Rows[0]["PRECO"]);
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    
    public DataTable ConsultarInner()
    {
        try
        {
            parameters.Clear();
            sql = "SELECT Id,ClienteId, FuncionarioId, FormaPagamentoId ";
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
                Usuario.Id = Convert.ToInt32(dt.Rows[0]["FuncionarioId"]);
                FormaPagamentoId = Convert.ToInt32(dt.Rows[0]["FormaPagamentoId"]);
            }

            return dt;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
}
