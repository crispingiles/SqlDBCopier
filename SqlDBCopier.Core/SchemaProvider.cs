namespace WBSoft.SqlDBCopier.Core
{
    public class SchemaProvider : ISchemaProvider
    {
        public SchemaProvider(
            ISqlObjectProvider sqlObjectProvider, 
            ISqlExpressionDependencyProvider sqlExpressionDependencyProvider, 
            IForeignKeyProvider foreignKeyProvider, 
            ISqlModuleProvider sqlModuleProvider, 
            ITableDefinitionProvider tableDefinitionProvider, IColumnProvider columnProvider)
        {
            SqlObjectProvider = sqlObjectProvider;
            SqlExpressionDependencyProvider = sqlExpressionDependencyProvider;
            ForeignKeyProvider = foreignKeyProvider;
            SqlModuleProvider = sqlModuleProvider;
            TableDefinitionProvider = tableDefinitionProvider;
            ColumnProvider = columnProvider;
        }

        private ISqlObjectProvider SqlObjectProvider { get; }

        private ISqlExpressionDependencyProvider SqlExpressionDependencyProvider { get; }

        private IForeignKeyProvider ForeignKeyProvider { get; }

        private ISqlModuleProvider SqlModuleProvider { get; }

        private ITableDefinitionProvider TableDefinitionProvider { get; }

        private IColumnProvider ColumnProvider { get; }

        public Schema GetSchema(ISqlConnectionProvider sqlConnectionProvider)
        {
            var objects = SqlObjectProvider.GetSqlObjects(sqlConnectionProvider);
            var sqlExpressionDependencies = SqlExpressionDependencyProvider.GetExpressionDependencies(sqlConnectionProvider);
            var foreignKeys = ForeignKeyProvider.GetForeignKeys(sqlConnectionProvider);
            var modules = SqlModuleProvider.GetModules(sqlConnectionProvider);
            var tableDefinitions = TableDefinitionProvider.GetDefinitions(sqlConnectionProvider);
            var columns = ColumnProvider.GetColumns(sqlConnectionProvider);

            return new Schema(
                objects, 
                sqlExpressionDependencies, 
                foreignKeys, 
                modules,
                tableDefinitions,
                columns);
        }
    }
}