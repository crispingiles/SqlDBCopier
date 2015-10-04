using System.Diagnostics;

namespace WBSoft.SqlDBCopier.Core
{
    /// <summary>
    /// Represents an entry in the sys.objects table
    /// </summary>
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class SqlObject
    {
        public SqlObject(string name, int objectId, int parentObjectId, ObjectType objectType)
        {
            Name = name;
            ObjectId = objectId;
            ObjectType = objectType;
            ParentObjectId = parentObjectId;
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
        /// Non-zero for constraints, triggers etc.  Will point to a parent table or similar
        /// </summary>
        public int ParentObjectId { get; }

        /// <summary>
        /// The type of the object
        /// </summary>
        public ObjectType ObjectType { get; }

        private string DebuggerDisplay => $"{Name}, {ObjectId}, {ObjectType}";
    }
}