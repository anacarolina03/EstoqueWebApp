using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Threading.Tasks;
namespace EstoqueWebApp
{
    public class TesteConexaoOdbc
    {
        public static object Teste()
        {
            using var connection = new OdbcConnection("Driver={ODBC Driver 17 for SQL Server};Server=.\\SQLEXPRESS;Database=estoque;Uid=admin;Pwd=senha;");
            connection.Open();
            using var command = connection.CreateCommand();
            command.CommandText = "select top 1 txt_descricao from produto";
            return command.ExecuteScalar();
        }
    }
}
