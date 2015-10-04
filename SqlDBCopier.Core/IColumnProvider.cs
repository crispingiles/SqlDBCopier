using System.Collections.Generic;

namespace WBSoft.SqlDBCopier.Core
{
    public interface IColumnProvider
    {
        IReadOnlyList<Column> GetColumns(ISqlConnectionProvider sqlConnectionProvider);
    }
}