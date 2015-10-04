using System.Collections.Generic;

namespace WBSoft.SqlDBCopier.Core
{
    public interface ISqlObjectProvider
    {
        IReadOnlyList<SqlObject> GetSqlObjects(ISqlConnectionProvider sqlConnectionProvider);
    }
}