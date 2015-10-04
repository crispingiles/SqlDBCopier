using System.Collections.Generic;
using System.Data.SqlClient;

namespace WBSoft.SqlDBCopier.Core
{
    public class SqlModuleProvider : ISqlModuleProvider
    {
        public IReadOnlyList<SqlModule> GetModules(ISqlConnectionProvider sqlConnectionProvider)
        {
            const string cmdText = @"SELECT m.object_id, m.definition 
FROM sys.sql_modules m";
            using (var conn = sqlConnectionProvider.GetOpenConnection())
            {
                var cmd = new SqlCommand {CommandText = cmdText, Connection = conn};
                var results = new List<SqlModule>();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        results.Add(new SqlModule(reader.GetInt32(0), reader.GetString(1)));
                    }
                }
                return results;
            }
        }
    }
}