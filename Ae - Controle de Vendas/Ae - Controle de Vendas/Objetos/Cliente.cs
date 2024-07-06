using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;


namespace Ae___Controle_de_Vendas.Classes.Outros
{
    public class Cliente
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public int SexoId { get; set; }
        public int EnderecoId { get; set; }
        public int UsuarioId { get; set; }
        public Endereco Endereco {get; set;}

        //Aqui



        public Cliente()
        {
            Id = 0;
            Nome = string.Empty;
            CPF = string.Empty;
            Telefone = string.Empty;
            Email = string.Empty;
            SexoId = 0;
            UsuarioId = 0;
            EnderecoId = 0;
            Endereco = new Endereco();
        }


        AcessoBD acesso = new AcessoBD();
        DataTable dt = new DataTable();
        List<SqlParameter> parameters = new List<SqlParameter>();
        string sql = string.Empty;

        public DataTable Consultar()
        {
            try
            {
                parameters.Clear();
                sql = "select Id, Nome, CPF, Telefone,\n";
                sql += "Email, SexoId,EnderecoId,FuncionarioId \n";
                sql += "from tblCliente \n";
                if (Id != 0)
                {
                    sql += "where id = @id \n";
                    parameters.Add(new SqlParameter("@id", Id));
                }
                else if (CPF != string.Empty)
                {
                    sql += " WHERE CPF LIKE @CPF";
                    parameters.Add(new SqlParameter("@CPF", '%' + CPF + '%'));
                }
                else if (Nome != string.Empty)
                {
                    sql += "where nome like @nome \n";
                    parameters.Add(new SqlParameter("@nome", '%' + Nome + '%'));
                } 
                dt = acesso.Consultar(sql, parameters);


               
                if (Id != 0 || (CPF != string.Empty && dt.Rows.Count > 0))
                {
                    Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                    Nome = dt.Rows[0]["Nome"].ToString();
                    CPF = dt.Rows[0]["CPF"].ToString();
                    Telefone = dt.Rows[0]["Telefone"].ToString();
                    Email = dt.Rows[0]["Email"].ToString();
                    SexoId = Convert.ToInt32(dt.Rows[0]["SexoId"]);
                    UsuarioId = Convert.ToInt32(dt.Rows[0]["FuncionarioId"]);
                    EnderecoId = Convert.ToInt32(dt.Rows[0]["EnderecoId"]);
                }


                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public void Gravar()
        {
            try
            {
                using (TransactionScope transacao = new TransactionScope())
                {
                    parameters.Clear();
                    if (Id == 0)
                    {
                        sql = "insert into tblCliente \n";
                        sql += "(Nome, CPF, Telefone, Email, SexoId, EnderecoId, FuncionarioId)\n";
                        sql += "values \n";
                        sql += "(@nome, @CPF, @telefone, @email, @sexoId, @enderecoId, @usuarioId)";
                    }
                    else
                    {
                        sql = "update tblCliente \n";
                        sql += "set \n";
                        sql += "Nome = @nome, \n";
                        sql += "CPF = @CPF, \n";
                        sql += "Telefone  = @telefone, \n";
                        sql += "Email = @email, \n";
                        sql += "SexoId  = @sexoId, \n";
                        sql += "EnderecoId = @enderecoId, \n";
                        sql += "FuncionarioId = @usuarioId \n";
                        sql += "where Id = @id \n";
                        parameters.Add(new SqlParameter("@id", Id));

                    }

                    parameters.Add(new SqlParameter("@nome", Nome));
                    parameters.Add(new SqlParameter("@CPF", CPF));
                    parameters.Add(new SqlParameter("@telefone", Telefone));
                    parameters.Add(new SqlParameter("@email", Email));
                    parameters.Add(new SqlParameter("@sexoId", SexoId));
                    parameters.Add(new SqlParameter("@enderecoId", EnderecoId));
                    parameters.Add(new SqlParameter("@usuarioId", Global.IdUsuarioLogado));


                    if (Id == 0)
                    {
                        Id = acesso.Executar(parameters, sql);
                    }
                    else
                    {
                        acesso.Executar(sql, parameters);
                    }

                    transacao.Complete();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
