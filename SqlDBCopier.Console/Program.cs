using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WBSoft.SqlDBCopier.Core;

namespace WBSoft.SqlDBCopier.Console
{
    public class Program
    {
        public static int Main(string[] args)
        {
            var prodSampleConnectionProvider = new SqlConnectionProvider(ConfigurationManager.AppSettings["prodDBConnectionString"]);
            var uatSampleConnectionProvider = new SqlConnectionProvider(ConfigurationManager.AppSettings["uatDBConnectionString"]);
            var schemaProvider = new SchemaProvider(
                new SqlObjectProvider(), 
                new SqlExpressionDependencyProvider(),
                new ForeignKeyProvider(),
                new SqlModuleProvider(),
                new TableDefinitionProvider()
                );

            var fromSchema = schemaProvider.GetSchema(prodSampleConnectionProvider);
            var toSchema = schemaProvider.GetSchema(uatSampleConnectionProvider);

            var migrateSchemaCommandGenerator = new MigrateSchemaCommandGenerator();
            var commands = migrateSchemaCommandGenerator.GetCommands(fromSchema, toSchema);

            var schemaCommand = string.Join(Environment.NewLine, commands.Select(c => c.CommandText));

            return 0;
        }
    }
}
