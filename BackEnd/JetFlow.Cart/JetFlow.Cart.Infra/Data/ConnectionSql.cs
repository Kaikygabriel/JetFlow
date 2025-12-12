using System.Data;
using System.Data.Common;
using JetFlow.Cart.Infra.Data.Contracts;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace JetFlow.Cart.Infra.Data;

public class ConnectionSql : IConnectionSql
{
    private readonly IConfiguration _configuration;
    private SqlConnection _connection ;

    public ConnectionSql(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public SqlConnection CreateSqlConnection()
    {
        return _connection=_connection ?? new SqlConnection(_configuration["ConnectionString:DefaultConnection"]!) ;
    }
}