using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Security.Cryptography;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Ae___Controle_de_Vendas.Classes.Outros
{
    public class Venda
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public int FormaPagamentoId { get; set; }
        public Usuario Usuario { get; set; }
        public decimal Preco { get; set; }
        public int StatusId { get; set; }
        

        AcessoBD acesso = new AcessoBD();
        DataTable dt = new DataTable();
        List<SqlParameter> parameters = new List<SqlParameter>();
        string sql = string.Empty;

        public Venda()
        {
            Id = 0;
            Cliente = new Cliente();
            FormaPagamentoId = 0;
            Preco = 0;
            StatusId = 0;
            Usuario = new Usuario();
        }

        public DataTable getStatusVenda()
        {
            parameters.Clear();
            try
            {
                string sql = "SELECT Id, Descricao FROM tblStatusVenda \n";
                return new AcessoBD().Consultar(sql, new List<SqlParameter>());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public  void alterarStatusVenda(int idStatus)
        {
            parameters.Clear();

            sql = "UPDATE tblVenda SET StatusVendaId = @status WHERE ID = @id ";
            parameters.Add(new SqlParameter("@status", idStatus));
            parameters.Add(new SqlParameter("@id", Id));


            acesso.Executar(sql,parameters);

        }

        public string getStatusDescricao(int idDescription)
        {
            string status = string.Empty;


            
            if(Id != 0)
            {

                sql = "SELECT Id, Descricao FROM tblStatusVenda WHERE Id = @id";

                parameters.Clear();

                parameters.Add(new SqlParameter("@id", idDescription));


                dt = acesso.Consultar(sql, parameters);
                if (dt.Rows.Count > 0)
                {
                    // Obtém a descrição do status
                    status = dt.Rows[0]["Descricao"].ToString();
                }

            }

            return status;
        }

        

        public int Gravar()
        {
            try
            {
                parameters.Clear();

                if (Id == 0)
                {
                    sql = "INSERT INTO tblVenda (ClienteId, FuncionarioId, FormaPagamentoId,StatusVendaId,PRECO) ";
                    sql += "VALUES (@clienteId, @usuarioId, @formaPagamentoId,@StatusId,@PRECO); SELECT SCOPE_IDENTITY();";

                    
                    parameters.Add(new SqlParameter("@clienteId", Cliente.Id));
                    parameters.Add(new SqlParameter("@usuarioId", Global.IdUsuarioLogado));
                    parameters.Add(new SqlParameter("@formaPagamentoId", FormaPagamentoId));
                    parameters.Add(new SqlParameter("@PRECO", Preco));
                    parameters.Add(new SqlParameter("@StatusId", StatusId));

                    Id = acesso.Executar(parameters, sql); 

                    return Id; 
                }
                else
                {
                    sql = "UPDATE tblVenda SET ";

                    sql += "ClienteId = @clienteId, ";
                    sql += "UsuarioId = @usuarioId, ";
                    sql += "FormaPagamentoId = @formaPagamentoId, ";
                    sql += "PRECO = @preco,";
                    sql += "StatusVendaId = @StatusId ";
                    sql += "WHERE Id = @id;";

                    parameters.Add(new SqlParameter("@id", Id));
                    parameters.Add(new SqlParameter("@clienteId", Cliente.Id));
                    parameters.Add(new SqlParameter("@usuarioId", Global.IdUsuarioLogado));
                    parameters.Add(new SqlParameter("@formaPagamentoId", FormaPagamentoId));
                    parameters.Add(new SqlParameter("@preco", Preco));
                    parameters.Add(new SqlParameter("@StatusId", StatusId));

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
                sql = "SELECT Id,ClienteId, FuncionarioId, FormaPagamentoId,PRECO,StatusVendaId ";
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
                    StatusId = Convert.ToInt32(dt.Rows[0]["StatusVendaId"]);
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    
    //public DataTable ConsultarInner()
    //{
    //    try
    //    {
    //        parameters.Clear();
    //        sql = "SELECT Id,ClienteId, FuncionarioId, FormaPagamentoId ";
    //        sql += "FROM tblVenda ";

    //        if (Id != 0)
    //        {
    //            sql += "WHERE Id = @id;";
    //            parameters.Add(new SqlParameter("@id", Id));
    //        }


    //        dt = acesso.Consultar(sql, parameters);

    //        if (dt.Rows.Count > 0)
    //        {
    //            Id = Convert.ToInt32(dt.Rows[0]["Id"]);
    //            Cliente.Id = Convert.ToInt32(dt.Rows[0]["ClienteId"]);
    //            Usuario.Id = Convert.ToInt32(dt.Rows[0]["FuncionarioId"]);
    //            FormaPagamentoId = Convert.ToInt32(dt.Rows[0]["FormaPagamentoId"]);
    //        }

    //        return dt;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw new Exception(ex.Message);
    //    }
    //}
}
}
