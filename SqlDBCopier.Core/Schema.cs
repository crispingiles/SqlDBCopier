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
            IReadOnlyList<SqlModule> modules, 
            IReadOnlyList<TableDefinition> tableDefinitions)
        {
            Objects = objects;
            ExpressionDependencies = expressionDependencies;
            ForeignKeys = foreignKeys;
            Modules = modules;
            TableDefinitions = tableDefinitions;
        }

        public IReadOnlyList<SqlObject> Objects { get; }

        public IReadOnlyList<SqlExpressionDependency> ExpressionDependencies { get; }

        public IReadOnlyList<ForeignKey> ForeignKeys { get; }

        public IReadOnlyList<SqlModule> Modules { get; }

        /// <summary>
        /// These are populated via the same code SSMS uses
        /// </summary>
        public IReadOnlyList<TableDefinition> TableDefinitions { get; }
    }
}
