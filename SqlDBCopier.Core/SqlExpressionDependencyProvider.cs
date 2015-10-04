using System.Collections.Generic;
using System.Data.SqlClient;

namespace WBSoft.SqlDBCopier.Core
{
    public class SqlExpressionDependencyProvider : ISqlExpressionDependencyProvider
    {
        public IReadOnlyList<SqlExpressionDependency> GetExpressionDependencies(ISqlConnectionProvider sqlConnectionProvider)
        {
            using (var conn = sqlConnectionProvider.GetOpenConnection())
            {
                const string cmdText =
                    @"SELECT d.referencing_id, d.referencing_minor_id, d.referenced_id, d.referenced_minor_id 
FROM sys.sql_expression_dependencies d 
WHERE d.referencing_class = 1 and d.referenced_class = 1";

                var cmd = new SqlCommand {CommandText = cmdText, Connection = conn};
                var result = new List<SqlExpressionDependency>();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new SqlExpressionDependency(
                            reader.GetInt32(0), 
                            reader.GetInt32(1),
                            reader.GetInt32(2), 
                            reader.GetInt32(3)));
                    }
                }
                return result;
            }
        }
    }
}