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
            IReadOnlyList<SqlExpressionDependency> expressionDependencies)
        {
            Objects = objects;
            ExpressionDependencies = expressionDependencies;
        }

        IReadOnlyList<SqlObject> Objects { get; }

        IReadOnlyList<SqlExpressionDependency> ExpressionDependencies { get; }
    }
}
