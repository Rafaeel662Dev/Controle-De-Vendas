using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Ae___Controle_de_Vendas.Classes.Outros
{
    public class Item
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
        public int VendaId { get; set; }
        public int ProdutoId { get; set; }

        AcessoBD acesso = new AcessoBD();
        DataTable dt = new DataTable();
        List<SqlParameter> parameters = new List<SqlParameter>();
        string sql = string.Empty;

        public Item()
        {
            Id = 0;
            Quantidade = 0;
            Preco = 0;
            VendaId = 0;
            ProdutoId = 0;
        }

        public void Gravar()
        {
            try
            {
                parameters.Clear();

                if (Id == 0)
                {
                    sql = "INSERT INTO tblItens (Quantidade, Preco, VendaId, ProdutoId) ";
                    sql += "VALUES (@quantidade, @preco, @vendaId, @produtoId);";

                    parameters.Add(new SqlParameter("@quantidade", Quantidade));
                    parameters.Add(new SqlParameter("@preco", Preco));
                    parameters.Add(new SqlParameter("@vendaId", VendaId));
                    parameters.Add(new SqlParameter("@produtoId", ProdutoId));

                    Id = acesso.Executar(parameters, sql);
                }
                else
                {
                    sql = "UPDATE tblItens SET ";
                    sql += "Quantidade = @quantidade, ";
                    sql += "Preco = @preco, ";
                    sql += "VendaId = @vendaId, ";
                    sql += "ProdutoId = @produtoId ";
                    sql += "WHERE Id = @id;";

                    parameters.Add(new SqlParameter("@id", Id));
                    parameters.Add(new SqlParameter("@quantidade", Quantidade));
                    parameters.Add(new SqlParameter("@preco", Preco));
                    parameters.Add(new SqlParameter("@vendaId", VendaId));
                    parameters.Add(new SqlParameter("@produtoId", ProdutoId));

                    acesso.Executar(sql, parameters);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Consultar()
        {
            try
            {
                parameters.Clear();
                sql = "SELECT Id, Quantidade, Preco, VendaId, ProdutoId ";
                sql += "FROM tblItem ";

                if (Id != 0)
                {
                    sql += "WHERE Id = @id;";
                    parameters.Add(new SqlParameter("@id", Id));
                }

                dt = acesso.Consultar(sql, parameters);

                if (dt.Rows.Count > 0)
                {
                    Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                    Quantidade = Convert.ToInt32(dt.Rows[0]["Quantidade"]);
                    Preco = Convert.ToDecimal(dt.Rows[0]["Preco"]);
                    VendaId = Convert.ToInt32(dt.Rows[0]["VendaId"]);
                    ProdutoId = Convert.ToInt32(dt.Rows[0]["ProdutoId"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
