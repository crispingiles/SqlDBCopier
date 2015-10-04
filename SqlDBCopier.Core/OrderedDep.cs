namespace WBSoft.SqlDBCopier.Core
{
    internal class OrderedDep
    {
        public OrderedDep(int referencingId, int referencedId)
        {
            ReferencingId = referencingId;
            ReferencedId = referencedId;
        }

        public int ReferencingId { get; }

        public int ReferencedId { get; }

        public override bool Equals(object obj)
        {
            var o = obj as OrderedDep;
            if (o == null)
                return false;
            return ReferencingId == o.ReferencingId && ReferencedId == o.ReferencedId;
        }

        public override int GetHashCode()
        {
            return ReferencingId ^ ReferencedId;
        }
    }
}