using System.Diagnostics;

namespace WBSoft.SqlDBCopier.Core
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class TableDefinition
    {
        public TableDefinition(int objectId, string definition)
        {
            ObjectId = objectId;
            Definition = definition;
        }

        public int ObjectId { get; }

        public string Definition { get; }


        private string DebuggerDisplay => $"{ObjectId}, {Definition}";
    }
}