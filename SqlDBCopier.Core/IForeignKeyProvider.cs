using System.Collections.Generic;

namespace WBSoft.SqlDBCopier.Core
{
    public interface IForeignKeyProvider
    {
        IReadOnlyList<ForeignKey> GetForeignKeys(ISqlConnectionProvider sqlConnectionProvider);
    }
}