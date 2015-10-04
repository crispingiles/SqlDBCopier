using System.Collections.Generic;

namespace WBSoft.SqlDBCopier.Core
{
    public interface ISqlModuleProvider
    {
        IReadOnlyList<SqlModule> GetModules(ISqlConnectionProvider sqlConnectionProvider);
    }
}