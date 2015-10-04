using System.Collections.Generic;
using System.Data.SqlClient;

namespace WBSoft.SqlDBCopier.Core
{
    public class ForeignKeyProvider : IForeignKeyProvider
    {

        public IReadOnlyList<ForeignKey> GetForeignKeys(ISqlConnectionProvider sqlConnectionProvider)
        {
            using (var conn = sqlConnectionProvider.GetOpenConnection())
            {
                const string cmdText = @"SELECT f.object_id, f.parent_object_id, f.referenced_object_id 
FROM sys.foreign_keys f";
                var cmd = new SqlCommand {CommandText = cmdText, Connection = conn};
                var results = new List<ForeignKey>();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        results.Add(new ForeignKey(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2)));
                    }
                }
                return results;
            }
        }
    }
}