using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ae___Controle_de_Vendas.Classes.Outros
{
    public class Endereco
    {
        public int Id { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        public int CidadeId { get; set; }

        public Endereco()
        {
            Logradouro = string.Empty;
            Numero = string.Empty;
            Complemento = string.Empty;
            Bairro = string.Empty;
            CEP = string.Empty;
            CidadeId = 0;
        }



        AcessoBD acesso = new AcessoBD();
        DataTable dt = new DataTable();
        List<SqlParameter> parameters = new List<SqlParameter>();
        string sql = string.Empty;



        public void Consultar(int id)
        {
            try
            {
                parameters.Clear();
                sql = "select Id, Endereco, Numero, Complemento, \n";
                sql += "Bairro, CEP, CidadeId \n";
                sql += "from tblEndereco \n";
                sql += "where Id = @id";


                parameters.Add(new SqlParameter("@id", id));

                dt = acesso.Consultar(sql, parameters);

                if (dt.Rows.Count > 0)
                {
                    Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                    Logradouro = dt.Rows[0]["endereco"].ToString();
                    Numero = dt.Rows[0]["numero"].ToString();
                    Complemento = dt.Rows[0]["complemento"].ToString();
                    Bairro = dt.Rows[0]["bairro"].ToString();
                    CEP = dt.Rows[0]["CEP"].ToString();
                    CidadeId = Convert.ToInt32(dt.Rows[0]["CidadeId"]);

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public int Gravar()
        {
            AcessoBD acesso = new AcessoBD();
            List<SqlParameter> parameters = new List<SqlParameter>();

            try
            {
                string sql;
                parameters.Clear();

                if (Id == 0)
                {
                    sql = "INSERT INTO tblEndereco \n";
                    sql += "(endereco, numero, complemento, bairro, CEP, cidadeId) \n";
                    sql += "VALUES (@endereco, @numero, @complemento, @bairro, @CEP, @cidadeId); \n";
                    sql += "SELECT SCOPE_IDENTITY();";

                    parameters.Add(new SqlParameter("@endereco", Logradouro));
                    parameters.Add(new SqlParameter("@numero", Numero));
                    parameters.Add(new SqlParameter("@complemento", Complemento));
                    parameters.Add(new SqlParameter("@bairro", Bairro));
                    parameters.Add(new SqlParameter("@CEP", CEP));
                    parameters.Add(new SqlParameter("@cidadeId", CidadeId));

                                return acesso.Executar(parameters, sql);
                }
                else
                {
                    // Lógica para atualização do endereço, se necessário
                    sql = "UPDATE tblEndereco \n";
                    sql += "SET \n";
                    sql += "endereco = @endereco, \n";
                    sql += "numero = @numero, \n";
                    sql += "complemento = @complemento, \n";
                    sql += "bairro = @bairro, \n";
                    sql += "CEP = @CEP, \n";
                    sql += "cidadeId = @cidadeId \n";
                    sql += "WHERE id = @id; \n";

                    parameters.Add(new SqlParameter("@id", Id));
                    parameters.Add(new SqlParameter("@endereco", Logradouro));
                    parameters.Add(new SqlParameter("@numero", Numero));
                    parameters.Add(new SqlParameter("@complemento", Complemento));
                    parameters.Add(new SqlParameter("@bairro", Bairro));
                    parameters.Add(new SqlParameter("@CEP", CEP));
                    parameters.Add(new SqlParameter("@cidadeId", CidadeId));

                    // Executa o comando SQL para atualizar os dados (se necessário)
                    acesso.Executar(sql, parameters);

                    // Retorna o ID atualizado
                    return Id;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}