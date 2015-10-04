namespace WBSoft.SqlDBCopier.Core
{
    /// <summary>
    /// Contains the definition for procedures, views, etc. (but not tables)
    /// </summary>
    public class SqlModule
    {
        public SqlModule(int objectId, string definition)
        {
            ObjectId = objectId;
            Definition = definition;
        }

        public int ObjectId { get; }

        public string Definition { get; }
    }
}