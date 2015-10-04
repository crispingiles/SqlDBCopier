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
            var prodSampleConnectionStr = ConfigurationManager.AppSettings["prodDBConnectionString"];
            var prodSampleConnectionProvider = new SqlConnectionProvider(prodSampleConnectionStr);
            var schemaProvider = new SchemaProvider(
                new SqlObjectProvider(), 
                new SqlExpressionDependencyProvider(),
                new ForeignKeyProvider(),
                new SqlModuleProvider()
                );

            var schema = schemaProvider.GetSchema(prodSampleConnectionProvider);
            return 0;
        }
    }
}
