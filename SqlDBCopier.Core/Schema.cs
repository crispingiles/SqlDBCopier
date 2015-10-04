using System.Collections.Generic;
using System.Linq;

namespace WBSoft.SqlDBCopier.Core
{
    /// <summary>
    /// Contains information about the schema of a database
    /// </summary>
    public class Schema
    {
        public Schema(
            IReadOnlyList<SqlObject> objects, 
            IReadOnlyList<SqlExpressionDependency> expressionDependencies, 
            IReadOnlyList<ForeignKey> foreignKeys, 
            IReadOnlyList<SqlModule> modules)
        {
            Objects = objects;
            ExpressionDependencies = expressionDependencies;
            ForeignKeys = foreignKeys;
            Modules = modules;
        }

        IReadOnlyList<SqlObject> Objects { get; }

        IReadOnlyList<SqlExpressionDependency> ExpressionDependencies { get; }

        IReadOnlyList<ForeignKey> ForeignKeys { get; }

        IReadOnlyList<SqlModule> Modules { get; }
    }
}
