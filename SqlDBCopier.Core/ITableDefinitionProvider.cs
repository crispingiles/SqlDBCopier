using System.Collections.Generic;

namespace WBSoft.SqlDBCopier.Core
{
    /// <summary>
    /// Used to retrieve the definition of a table
    /// </summary>
    public interface ITableDefinitionProvider
    {
        IReadOnlyList<TableDefinition> GetDefinitions(ISqlConnectionProvider sqlConnectionProvider);
    }
}