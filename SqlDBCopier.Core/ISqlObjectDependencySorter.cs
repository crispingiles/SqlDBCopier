using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WBSoft.SqlDBCopier.Core
{
    /// <summary>
    /// Used to order sql objects so we can script dropping and creating tables in a safe manner
    /// </summary>
    public interface ISqlObjectDependencySorter
    {
        /// <summary>
        /// Get a list of objects, where the first object can depend on anything to the right and so on, until the last element doesn't depend upon anything
        /// </summary>
        IReadOnlyList<SqlObject> OrderByDependency(
            IEnumerable<SqlObject> objects,
            IEnumerable<SqlExpressionDependency> expressionDependencies);

    }
}
