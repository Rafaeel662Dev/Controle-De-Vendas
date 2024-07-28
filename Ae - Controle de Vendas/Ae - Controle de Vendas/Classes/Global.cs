using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Ae___Controle_de_Vendas.Classes.Outros
{
    public static class Global
    {
        public static string Conexao = string.Empty;
        public static string Servidor = string.Empty;
        public static string Banco = string.Empty;
        public static string Usuario = string.Empty;
        public static string Password = string.Empty;
        public static string Porta = string.Empty;
        public static int IdUsuarioLogado = 0;

        public static string Criptografar(string senha)
        {
            Byte[] original;
            Byte[] criptografado;
            MD5 md5 = new MD5CryptoServiceProvider();
            original = ASCIIEncoding.Default.GetBytes(senha);
            criptografado = md5.ComputeHash(original);

            return Regex.Replace(BitConverter.ToString(criptografado), "-", "").ToLower();
        }

        public static bool CompararSenhas(string senhaOriginal, string senhaDigitada)
        {
            string hashSenhaOriginal = Criptografar(senhaDigitada);

            // Comparando os hashes para verificar se são iguais
            return hashSenhaOriginal.Equals(senhaOriginal, StringComparison.OrdinalIgnoreCase);
        }

        public static void LerAppConfig()
        {
            Servidor = ConfigurationManager.AppSettings.Get("servidor");
            Banco = ConfigurationManager.AppSettings.Get("banco");
            Usuario = ConfigurationManager.AppSettings.Get("user_azure");
            Password = ConfigurationManager.AppSettings.Get("password_azure");
            Porta = ConfigurationManager.AppSettings.Get("port");


            // String de conexão para AAD
            //Conexao = $"Data Source={Servidor};Initial Catalog={Banco};Integrated Security=true;";
            Conexao = $"Server=tcp:{Servidor},{Porta};Initial Catalog={Banco};Persist Security Info=False;User ID={Usuario};Password={Password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        }


        public static DataTable ConsultarEstados()
        {
            try
            {
                string sql = "SELECT Id, Estado FROM tblEstado \n";
                return new AcessoBD().Consultar(sql, new List<SqlParameter>());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable ConsultarCidades(int estadoId)
        {
            try
            {
                string sql = "select Id,Cidade from tblCidade \n";
                sql += "where EstadoId = @estadoId";
                DataTable dt = new DataTable();
                AcessoBD acesso = new AcessoBD();
                List<SqlParameter> lista = new List<SqlParameter>();
                lista.Add(new SqlParameter("@estadoId", estadoId));
                dt = acesso.Consultar(sql, lista);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static decimal ConverterDinheiroParaDecimal(string texto)
        {
            // Remove caracteres não numéricos
            string valorSemSimbolos = texto.Replace("R$", "").Trim(); // Remove o símbolo R$ e espaços em branco

            // Define o formato específico para o Brasil
            CultureInfo cultura = new CultureInfo("pt-BR");

            // Converte para decimal usando a cultura específica do Brasil
            decimal valorDecimal;
            if (decimal.TryParse(valorSemSimbolos, NumberStyles.Currency, cultura, out valorDecimal))
            {
                return valorDecimal;
            }
            else
            {
                throw new ArgumentException("Texto não está no formato monetário válido.");
            }
        }

        public static int ConsultarEstado(int cidadeId)
        {
            try
            {
                int estado = 0;
                string sql = "SELECT EstadoId FROM tblCidade \n";
                sql += "where Id = @Id";
                DataTable dt = new DataTable();
                AcessoBD acesso = new AcessoBD();
                List<SqlParameter> lista = new List<SqlParameter>();
                lista.Add(new SqlParameter("@Id", cidadeId));
                dt = acesso.Consultar(sql, lista);
                if (dt.Rows.Count > 0)
                {
                    estado = Convert.ToInt32(dt.Rows[0]["EstadoId"]);
                }
                return estado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static bool SomenteNumeros(char tecla, string texto)
        {
            if ((!char.IsDigit(tecla) && tecla != (char)Keys.Back))
            {
                return true;
            }
            return false;
        }

        public static void TestarConexao()
        {
            try
            {
                LerAppConfig();
                using (SqlConnection connection = new SqlConnection(Conexao))
                {
                    connection.Open();
                    MessageBox.Show("Conexão bem-sucedida!");
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
