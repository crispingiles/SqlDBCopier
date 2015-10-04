using System.Diagnostics;

namespace WBSoft.SqlDBCopier.Core
{
    /// <summary>
    /// Represents an entry in the sys.objects table
    /// </summary>
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class SqlObject
    {
        public SqlObject(string name, int objectId, ObjectType objectType)
        {
            Name = name;
            ObjectId = objectId;
            ObjectType = objectType;
        }

        /// <summary>
        /// The name of the object
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The id of the object in the database
        /// </summary>
        public int ObjectId { get; }

        /// <summary>
        /// The type of the object
        /// </summary>
        public ObjectType ObjectType { get; }

        private string DebuggerDisplay => $"{Name}, {ObjectId}, {ObjectType}";
    }
}