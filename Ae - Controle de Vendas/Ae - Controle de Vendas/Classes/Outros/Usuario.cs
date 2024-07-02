
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Transactions;

namespace Ae___Controle_de_Vendas.Classes.Outros
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string CPF { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool Ativo { get; set; }
        public Endereco Endereco { get; set; }
        public int PermissaoId { get; set; }
        public int SexoId { get; set; }
        public int EnderecoId { get; set; }



        public Usuario()
        {
            Id = 0;
            Nome = string.Empty;
            Email = string.Empty;
            Telefone = string.Empty;
            CPF = string.Empty;
            Login = string.Empty;
            Password = string.Empty;
            Ativo = false;
            Endereco = new Endereco();
            SexoId = 0;
            PermissaoId = 0;
            EnderecoId = 0;
            
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
                sql = "SELECT Id, Nome,Email,Telefone,CPF,Usuario,Senha,Ativo,SexoId,EnderecoId,PermissaoId FROM tblFuncionario";

                if (Id != 0)
                {
                    sql += " WHERE Id = @Id";
                    parameters.Add(new SqlParameter("@id", Id));
                }
                else if (!string.IsNullOrEmpty(Login))
                {
                    sql += " WHERE Usuario = @usuario";
                    parameters.Add(new SqlParameter("@usuario", Login));
                }
                else if (!string.IsNullOrEmpty(Nome))
                {
                    sql += " WHERE Nome LIKE @Nome";
                    parameters.Add(new SqlParameter("@Nome", '%' + Nome + '%'));
                } else if(!string.IsNullOrEmpty(CPF))
                {
                    sql += " WHERE CPF LIKE @CPF";
                    parameters.Add(new SqlParameter("@CPF", '%' + CPF + '%'));
                }

                dt = acesso.Consultar(sql, parameters);

                if ((Id != 0 || !string.IsNullOrEmpty(Login)) && dt.Rows.Count == 1)
                {
                    Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                    Nome = dt.Rows[0]["Nome"].ToString();
                    Email = dt.Rows[0]["Email"].ToString();
                    Telefone = dt.Rows[0]["Telefone"].ToString();
                    CPF = dt.Rows[0]["CPF"].ToString();
                    Login = dt.Rows[0]["Usuario"].ToString();
                    Password = dt.Rows[0]["Senha"].ToString();
                    Ativo = Convert.ToBoolean(dt.Rows[0]["Ativo"]);
                    SexoId = Convert.ToInt32(dt.Rows[0]["SexoId"]);
                    PermissaoId = Convert.ToInt32(dt.Rows[0]["PermissaoId"]);
                    EnderecoId = Convert.ToInt32(dt.Rows[0]["EnderecoId"]);
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Autenticar(string senha)
        {
            return senha == Password;
        }

        public DataTable getPermissions()
        {

            try
            {
                string sql = "SELECT Id, Descricao FROM tblPermissao \n";
                return new AcessoBD().Consultar(sql, new List<SqlParameter>());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public string getPermissionUser(int userId)
        {
            try
            {
                string sql = "SELECT p.Descricao " +
                             "FROM tblFuncionario AS f " +
                             "INNER JOIN tblPermissao AS p ON f.PermissaoId = p.Id " +
                             "WHERE f.Id = @FuncionarioId;";

                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@FuncionarioId", userId));

                DataTable dt = new AcessoBD().Consultar(sql, parameters);

                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["Descricao"].ToString();
                }
                else
                {
                    throw new Exception($"Permissão não encontrada para o usuário com Id {userId}.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter permissão do usuário: " + ex.Message);
            }
        }

        public string getSexo()
        {
            string sx = string.Empty;

            if(SexoId == 1)
            {
                sx = "Masculino";
            } else if (SexoId == 2) {
                sx = "Feminino";
            }

            return sx;
        }

        public void Gravar()
        {
            try
            {
                using (TransactionScope transacao = new TransactionScope())
                {
                    List<SqlParameter> parameters = new List<SqlParameter>();

                    if (Id == 0)
                    {
                        // Inserção de novo funcionário
                        string sql = "INSERT INTO tblFuncionario (Nome, Email, Telefone, CPF, Usuario, Senha, Ativo, SexoId, EnderecoId, PermissaoId) ";
                        sql += "VALUES (@nome, @email, @telefone, @cpf, @usuario, @senha, @ativo, @sexoId, @enderecoId, @permissaoId);";

                        parameters.Add(new SqlParameter("@nome", Nome));
                        parameters.Add(new SqlParameter("@email", Email));
                        parameters.Add(new SqlParameter("@telefone", Telefone));
                        parameters.Add(new SqlParameter("@cpf", CPF));
                        parameters.Add(new SqlParameter("@usuario", Login));
                        parameters.Add(new SqlParameter("@senha", Password));
                        parameters.Add(new SqlParameter("@ativo", Ativo));
                        parameters.Add(new SqlParameter("@sexoId", SexoId));
                        parameters.Add(new SqlParameter("@enderecoId", EnderecoId));
                        parameters.Add(new SqlParameter("@permissaoId", PermissaoId));

                        Id = acesso.Executar(parameters, sql);
                    }
                    else
                    {
                        // Atualização de funcionário existente
                        string sql = "UPDATE tblFuncionario SET ";
                        sql += "Nome = @nome, ";
                        sql += "Email = @email, ";
                        sql += "Telefone = @telefone, ";
                        sql += "CPF = @cpf, ";
                        sql += "Usuario = @usuario, ";
                        sql += "Senha = @senha, ";
                        sql += "Ativo = @ativo, ";
                        sql += "SexoId = @sexoId, ";
                        sql += "EnderecoId = @enderecoId, ";
                        sql += "PermissaoId = @permissaoId ";
                        sql += "WHERE Id = @id;";

                        parameters.Add(new SqlParameter("@nome", Nome));
                        parameters.Add(new SqlParameter("@email", Email));
                        parameters.Add(new SqlParameter("@telefone", Telefone));
                        parameters.Add(new SqlParameter("@cpf", CPF));
                        parameters.Add(new SqlParameter("@usuario", Login));
                        parameters.Add(new SqlParameter("@senha", Password));
                        parameters.Add(new SqlParameter("@ativo", Ativo));
                        parameters.Add(new SqlParameter("@sexoId", SexoId));
                        parameters.Add(new SqlParameter("@enderecoId", EnderecoId));
                        parameters.Add(new SqlParameter("@permissaoId", PermissaoId));
                        parameters.Add(new SqlParameter("@id", Id));

                        acesso.Executar(sql, parameters);
                    }

                    transacao.Complete();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao gravar funcionário: " + ex.Message);
            }
        }





    }

}
