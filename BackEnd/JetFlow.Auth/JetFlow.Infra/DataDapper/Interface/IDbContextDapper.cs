using Microsoft.Data.SqlClient;

namespace JetFlow.Infra.DataDapper.Interface;

public interface IDbContextDapper
{
    SqlConnection Create();
}