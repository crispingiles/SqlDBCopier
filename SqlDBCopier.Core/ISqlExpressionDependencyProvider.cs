using System.Collections.Generic;

namespace WBSoft.SqlDBCopier.Core
{
    public interface ISqlExpressionDependencyProvider
    {
        IReadOnlyList<SqlExpressionDependency> GetExpressionDependencies(ISqlConnectionProvider sqlConnectionProvider);
    }
}