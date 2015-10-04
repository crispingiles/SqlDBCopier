namespace WBSoft.SqlDBCopier.Core
{
    public class SchemaProvider : ISchemaProvider
    {
        public SchemaProvider(
            ISqlObjectProvider sqlObjectProvider, 
            ISqlExpressionDependencyProvider sqlExpressionDependencyProvider, 
            IForeignKeyProvider foreignKeyProvider)
        {
            SqlObjectProvider = sqlObjectProvider;
            SqlExpressionDependencyProvider = sqlExpressionDependencyProvider;
            ForeignKeyProvider = foreignKeyProvider;
        }

        private ISqlObjectProvider SqlObjectProvider { get; }

        private ISqlExpressionDependencyProvider SqlExpressionDependencyProvider { get; }

        private IForeignKeyProvider ForeignKeyProvider { get; }

        public Schema GetSchema(ISqlConnectionProvider sqlConnectionProvider)
        {
            var objects = SqlObjectProvider.GetSqlObjects(sqlConnectionProvider);
            var sqlExpressionDependencies = SqlExpressionDependencyProvider.GetExpressionDependencies(sqlConnectionProvider);
            var foreignKeys = ForeignKeyProvider.GetForeignKeys(sqlConnectionProvider);

            return new Schema(objects, sqlExpressionDependencies, foreignKeys);
        }
    }
}