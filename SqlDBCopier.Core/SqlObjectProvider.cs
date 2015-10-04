using System.Collections.Generic;
using System.Data.SqlClient;

namespace WBSoft.SqlDBCopier.Core
{
    public class SqlObjectProvider : ISqlObjectProvider
    {
        public IReadOnlyList<SqlObject> GetSqlObjects(ISqlConnectionProvider sqlConnectionProvider)
        {
            using (var conn = sqlConnectionProvider.GetOpenConnection())
            {
                const string cmdText = @"SELECT s.name, s.object_id, s.parent_object_id, s.type 
FROM sys.objects s 
WHERE s.is_ms_shipped = 0";

                var cmd = new SqlCommand { CommandText = cmdText, Connection = conn };
                var result = new List<SqlObject>();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(
                            new SqlObject(
                                reader.GetString(0),
                                reader.GetInt32(1),
                                reader.GetInt32(2),
                                ObjectTypeUtil.GetObjectType(reader.GetString(3))
                                ));
                    }
                }
                return result;
            }
        }
    }
}