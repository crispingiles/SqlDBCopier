namespace WBSoft.SqlDBCopier.Core
{
    public class SchemaProvider : ISchemaProvider
    {
        public SchemaProvider(
            ISqlObjectProvider sqlObjectProvider, 
            ISqlExpressionDependencyProvider sqlExpressionDependencyProvider)
        {
            SqlObjectProvider = sqlObjectProvider;
            SqlExpressionDependencyProvider = sqlExpressionDependencyProvider;
        }

        private ISqlObjectProvider SqlObjectProvider { get; }

        private ISqlExpressionDependencyProvider SqlExpressionDependencyProvider { get; }

        public Schema GetSchema(ISqlConnectionProvider sqlConnectionProvider)
        {
            var objects = SqlObjectProvider.GetSqlObjects(sqlConnectionProvider);
            var sqlExpressionDependencies = SqlExpressionDependencyProvider.GetExpressionDependencies(sqlConnectionProvider);

            return new Schema(objects, sqlExpressionDependencies);
        }
    }
}