using JetFlow.Infra.DataDapper.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace JetFlow.Infra.DataDapper;

public class DbContextDapper : IDbContextDapper
{
    private readonly IConfiguration _configuration;

    public DbContextDapper(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public SqlConnection Create()
        =>  new SqlConnection(_configuration.GetConnectionString("DefaultConnection")) ;
}