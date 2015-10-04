using System.Collections.Generic;
using System.Text;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Sdk.Sfc;
using Microsoft.SqlServer.Management.Smo;

namespace WBSoft.SqlDBCopier.Core
{
    /// <summary>
    /// Used to retrieve the definition of a table
    /// </summary>
    /// <remarks>No way of getting this via the sys tables</remarks>
    public class TableDefinitionProvider : ITableDefinitionProvider
    {

        public System.Collections.Generic.IReadOnlyList<TableDefinition> GetDefinitions(ISqlConnectionProvider sqlConnectionProvider)
        {
            var conn = sqlConnectionProvider.GetConnection();
            var dbName = conn.Database;
            var serverConnection = new ServerConnection(conn);
            var server = new Server(serverConnection);
            var scripter = new Scripter(server);
            scripter.Options.ScriptDrops = false;
            scripter.Options.WithDependencies = false;
            scripter.Options.NoCollation = true;

            var db = server.Databases[dbName];
            var results = new List<TableDefinition>();

            foreach (Table table in db.Tables)
            {
                if (table.IsSystemObject)
                    continue;
                var id = table.ID;
                var definitions = scripter.Script(new Urn[] {table.Urn});
                var sb = new StringBuilder();
                foreach (var definition in definitions)
                {
                    sb.AppendLine(definition);
                }
                var flattened = sb.ToString();
                results.Add(new TableDefinition(id, flattened));
            }

            return results;
        }

    }
}
