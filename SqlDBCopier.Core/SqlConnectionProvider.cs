using System.Data.SqlClient;

namespace WBSoft.SqlDBCopier.Core
{
    public class SqlConnectionProvider : ISqlConnectionProvider
    {
        public SqlConnectionProvider(string connectionString)
        {
            ConnectionString = connectionString;
        }

        private string ConnectionString { get; }

        public SqlConnection GetOpenConnection()
        {
            var connection = new SqlConnection(ConnectionString);
            connection.Open();
            return connection;
        }
    }
}