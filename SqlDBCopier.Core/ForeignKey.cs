namespace WBSoft.SqlDBCopier.Core
{
    /// <summary>
    /// Represents a foreign key 
    /// </summary>
    public class ForeignKey
    {
        public ForeignKey(int objectId, int parentObjectId, int referencedObjectId)
        {
            ObjectId = objectId;
            ParentObjectId = parentObjectId;
            ReferencedObjectId = referencedObjectId;
        }

        public int ObjectId { get; }
        
        public int ParentObjectId { get; }

        public int ReferencedObjectId { get; }

    }
}