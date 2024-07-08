using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DataAccess
    {
        public string ConnectionString { get; private set; }

        public DynamicParameters Parameters { get; set; } = new DynamicParameters();

        public DataAccess() {
            IConfiguration configuration = new ConfigurationBuilder().Build();
            ConnectionString = configuration.GetConnectionString("DBConnection") ?? string.Empty;
        }

        public IEnumerable<T> ReturnList<T>(string ProcedureName) {
            using (SqlConnection con = new SqlConnection(ConnectionString)) { 
                con.Open();
                return con.Query<T>(ProcedureName, param: Parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
