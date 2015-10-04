namespace WBSoft.SqlDBCopier.Core
{
    public interface ISchemaProvider
    {
        Schema GetSchema(ISqlConnectionProvider sqlConnectionProvider);
    }
}