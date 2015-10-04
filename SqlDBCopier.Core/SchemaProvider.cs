namespace WBSoft.SqlDBCopier.Core
{
    public class SchemaProvider : ISchemaProvider
    {
        public SchemaProvider(
            ISqlObjectProvider sqlObjectProvider, 
            ISqlExpressionDependencyProvider sqlExpressionDependencyProvider, 
            IForeignKeyProvider foreignKeyProvider, 
            ISqlModuleProvider sqlModuleProvider)
        {
            SqlObjectProvider = sqlObjectProvider;
            SqlExpressionDependencyProvider = sqlExpressionDependencyProvider;
            ForeignKeyProvider = foreignKeyProvider;
            SqlModuleProvider = sqlModuleProvider;
        }

        private ISqlObjectProvider SqlObjectProvider { get; }

        private ISqlExpressionDependencyProvider SqlExpressionDependencyProvider { get; }

        private IForeignKeyProvider ForeignKeyProvider { get; }

        private ISqlModuleProvider SqlModuleProvider { get; }

        public Schema GetSchema(ISqlConnectionProvider sqlConnectionProvider)
        {
            var objects = SqlObjectProvider.GetSqlObjects(sqlConnectionProvider);
            var sqlExpressionDependencies = SqlExpressionDependencyProvider.GetExpressionDependencies(sqlConnectionProvider);
            var foreignKeys = ForeignKeyProvider.GetForeignKeys(sqlConnectionProvider);
            var modules = SqlModuleProvider.GetModules(sqlConnectionProvider);

            return new Schema(
                objects, 
                sqlExpressionDependencies, 
                foreignKeys, 
                modules);
        }
    }
}