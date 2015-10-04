using System.Diagnostics;

namespace WBSoft.SqlDBCopier.Core
{
    /// <summary>
    /// Represents a dependency on a user defined entity in the current database.
    /// </summary>
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class SqlExpressionDependency
    {
        public SqlExpressionDependency(int referencingId, int referencingMinorId, int referencedId, int referencedMinorId)
        {
            ReferencingId = referencingId;
            ReferencingMinorId = referencingMinorId;
            ReferencedId = referencedId;
            ReferencedMinorId = referencedMinorId;
        }

        /// <summary>
        /// The id of the referencing entity
        /// </summary>
        public int ReferencingId { get; }

        /// <summary>
        /// The column id when the referencing entity is a column
        /// </summary>
        public int ReferencingMinorId { get; }

        /// <summary>
        /// The id of the referenced entity.  Always null for cross server and cross database references
        /// </summary>
        public int ReferencedId { get; }

        /// <summary>
        /// The column id when the referencing entity is a column.
        /// </summary>
        public int ReferencedMinorId { get; }

        private string DebuggerDisplay => $"{ReferencingId}, {ReferencedId}";
    }
}