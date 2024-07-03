using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ae___Controle_de_Vendas.Classes.Outros
{


    public class Produto
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int CategoriaId { get; set; }

        public Produto()
        {
            Id = 0;
            Codigo = 0;
            Nome = string.Empty;
            Preco = 0;
            CategoriaId = 0;
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

                sql = "SELECT Id,Codigo,Nome,Preco,CategoriaId \n";
                sql += "From tblProduto \n";

                if (Id != 0)
                {
                    sql += "where Id = @id \n";
                    parameters.Add(new SqlParameter("@id", Id));
                }
                else if (Codigo != 0)
                {
                    sql += "where Codigo LIKE @codigo";
                    parameters.Add(new SqlParameter("@codigo", Codigo.ToString() + "%"));
                }
                else if (Nome != string.Empty)
                {
                    sql += "where Nome LIKE @nome";
                    parameters.Add(new SqlParameter("@nome", Nome.ToString() + "%"));
                }

                dt = acesso.Consultar(sql, parameters);

                if (Id != 0 || (Nome != string.Empty && dt.Rows.Count > 0) || (Codigo != 0 && dt.Rows.Count > 0))
                {
                    Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                    Codigo = Convert.ToInt32(dt.Rows[0]["Codigo"]);
                    Nome = dt.Rows[0]["Nome"].ToString();
                    Preco = Convert.ToDecimal(dt.Rows[0]["Preco"]);
                    CategoriaId = Convert.ToInt32(dt.Rows[0]["CategoriaId"]);
                }

                return dt;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        public DataTable ConsultarCodigo()
        {


            try
            {

                parameters.Clear();

                sql = "SELECT Id,Codigo,Nome,Preco,CategoriaId \n";
                sql += "From tblProduto \n";

               
                 if (Codigo != 0)
                {
                    sql += "where Codigo = @codigo";
                    parameters.Add(new SqlParameter("@codigo", Codigo));
                }
                

                dt = acesso.Consultar(sql, parameters);

                if (Id != 0 || (Codigo != 0 && dt.Rows.Count > 0))
                {
                    Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                    Codigo = Convert.ToInt32(dt.Rows[0]["Codigo"]);
                    Nome = dt.Rows[0]["Nome"].ToString();
                    Preco = Convert.ToDecimal(dt.Rows[0]["Preco"]);
                    CategoriaId = Convert.ToInt32(dt.Rows[0]["CategoriaId"]);
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
                parameters.Clear();

                if (Id != 0)
                {
                    sql = "UPDATE tblProduto SET Codigo = @codigo, Nome = @nome, Preco = @preco, CategoriaId = @categoriaId ";
                    sql += "WHERE Id = @id;";
                }
                else
                {
                    sql = "INSERT INTO tblProduto (Codigo, Nome, Preco, CategoriaId) ";
                    sql += "VALUES (@codigo, @nome, @preco, @categoriaId);";
                }

                parameters.Add(new SqlParameter("@codigo", Codigo));
                parameters.Add(new SqlParameter("@nome", Nome));
                parameters.Add(new SqlParameter("@preco", Preco));
                parameters.Add(new SqlParameter("@categoriaId", CategoriaId));

                if (Id != 0)
                {
                    parameters.Add(new SqlParameter("@id", Id));
                }

                acesso.Executar(sql, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao gravar o produto: " + ex.Message);
            }
        }


        public DataTable getCategorias()
        {
            parameters.Clear();
            try
            {
                string sql = "SELECT Id, Descricao FROM tblCategoria \n";
                return new AcessoBD().Consultar(sql, new List<SqlParameter>());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string getCategorias(int id)
        {
            parameters.Clear();
            try
            {
                string sql = "SELECT Id, Descricao FROM tblCategoria WHERE Id = @Id";

                // Limpar os parâmetros anteriores e adicionar o novo parâmetro corretamente
                parameters.Add(new SqlParameter("@Id", id)); // Corrigido para @Id e utilizando o valor 'id'

                // Criar uma instância do acesso ao banco de dados
                AcessoBD ac = new AcessoBD();

                // Executar a consulta e obter o resultado
                DataTable resultado = ac.Consultar(sql, parameters);

                // Verificar se há resultados
                if (resultado.Rows.Count > 0)
                {
                    // Aqui você pode manipular os resultados conforme necessário
                    int categoriaId = Convert.ToInt32(resultado.Rows[0]["Id"]);
                    string descricao = Convert.ToString(resultado.Rows[0]["Descricao"]);

                    // Exemplo de retorno da descrição da categoria
                    return descricao;
                }
                else
                {
                    // Caso não encontre nenhuma categoria com o ID especificado
                    return "Categoria não encontrada";
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter categoria: " + ex.Message);
            }
        }


    }
}