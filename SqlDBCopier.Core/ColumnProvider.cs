using System.Collections.Generic;
using System.Data.SqlClient;

namespace WBSoft.SqlDBCopier.Core
{
    public class ColumnProvider : IColumnProvider
    {
        public IReadOnlyList<Column> GetColumns(ISqlConnectionProvider sqlConnectionProvider)
        {
            const string cmdText = @"SELECT c.object_id, c.name, c.column_id, c.system_type_id, c.max_length, 
c.precision, c.scale, c.is_nullable, c.is_identity, c.is_computed 
FROM sys.columns c
INNER JOIN sys.tables t 
ON c.object_id = t.object_id";

            using (var conn = sqlConnectionProvider.GetOpenConnection())
            {
                var cmd = new SqlCommand { CommandText = cmdText, Connection = conn };
                var results = new List<Column>();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var column = new Column();
                        column.TableObjectId = reader.GetInt32(0);
                        column.Name = reader.GetString(1);
                        column.ColumnId = reader.GetInt32(2);
                        column.ColumnType = (ColumnType) reader.GetByte(3);
                        column.MaxLength = reader.GetInt16(4);
                        column.Precision = reader.GetByte(5);
                        column.Scale = reader.GetByte(6);
                        column.IsNullable = reader.GetBoolean(7);
                        column.IsIdentity = reader.GetBoolean(8);
                        column.IsComputed = reader.GetBoolean(9);
                        results.Add(column);
                    }
                }
                return results;
            }

        }
    }
}