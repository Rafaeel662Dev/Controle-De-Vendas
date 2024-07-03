using Ae___Controle_de_Vendas.Classes.Outros;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;

public class NotaFiscal
{
    public int Id { get; set; }
    public int Numero { get; private set; } // Propriedade privada para o número da nota fiscal
    public int VendaId { get; set; }
    public String CPF { get; set; }

    AcessoBD acesso = new AcessoBD();
    DataTable dt = new DataTable();
    List<SqlParameter> parameters = new List<SqlParameter>();
    string sql = string.Empty;

    public NotaFiscal()
    {
        Id = 0;
        Numero = GerarNumeroNotaFiscal();
        VendaId = 0;
        CPF = string.Empty;
    }

    private int GerarNumeroNotaFiscal()
    {
        Random random = new Random();
        int numeroNota;
        parameters.Clear();
        // Gerar um número de nota fiscal único com 4 dígitos
        do
        {
            numeroNota = random.Next(1000, 10000); // Gera um número entre 1000 e 9999
            sql = "SELECT Id FROM tblNotaFiscal WHERE Numero = @numero;";
            parameters.Clear();
            parameters.Add(new SqlParameter("@numero", numeroNota));
            dt = acesso.Consultar(sql, parameters);
        }
        while (dt.Rows.Count > 0); // Verifica se o número já existe

        return numeroNota;
    }

    public void Consultar()
    {
        try
        {
            parameters.Clear();

            sql = "SELECT Id, Numero, VendaId ";
            sql += "FROM tblNotaFiscal ";

            if (Id != 0)
            {
                sql += "WHERE Id = @id ";
                parameters.Add(new SqlParameter("@id", Id));
            }
            else if (Numero != 0)
            {
                sql += "WHERE Numero = @numero ";
                parameters.Add(new SqlParameter("@numero", Numero));
            }

            dt = acesso.Consultar(sql, parameters);

            if (dt.Rows.Count > 0)
            {
                Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                Numero = Convert.ToInt32(dt.Rows[0]["Numero"]);
                VendaId = Convert.ToInt32(dt.Rows[0]["VendaId"]);
                CPF = dt.Rows[0]["CPF"].ToString();
            }
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

            // Gerar um novo número de nota fiscal se necessário
            if (Id == 0)
            {
                Numero = GerarNumeroNotaFiscal();
            }

            // Inserir ou atualizar conforme necessário
            if (Id == 0)
            {
                sql = "INSERT INTO tblNotaFiscal (Numero, VendaId,CPF) ";
                sql += "VALUES (@numero, @vendaId,@CPF);";

                parameters.Add(new SqlParameter("@numero", Numero));
                parameters.Add(new SqlParameter("@vendaId", VendaId));
                parameters.Add(new SqlParameter("@CPF", VendaId));

                Id = acesso.Executar(parameters, sql);
            }
            else
            {
                sql = "UPDATE tblNotaFiscal SET ";
                sql += "Numero = @numero, ";
                sql += "VendaId = @vendaId ";
                sql += "CPF = @CPF ";
                sql += "WHERE Id = @id;";

                parameters.Add(new SqlParameter("@id", Id));
                parameters.Add(new SqlParameter("@numero", Numero));
                parameters.Add(new SqlParameter("@vendaId", VendaId));
                parameters.Add(new SqlParameter("@CPF", CPF));

                acesso.Executar(sql, parameters);
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
