using System.Data;
using Microsoft.Data.SqlClient;

namespace JetFlow.Cart.Infra.Data.Contracts;

public interface IConnectionSql
{
     SqlConnection CreateSqlConnection();
}