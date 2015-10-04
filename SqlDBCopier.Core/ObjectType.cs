namespace WBSoft.SqlDBCopier.Core
{
    /// <summary>
    /// The type of the object in the database
    /// </summary>
    public enum ObjectType
    {
        Unknown = 0,
        AggregateFunction = 1,
        CheckConstraint = 2,
        DefaultConstraint = 3,
        ForeignKeyConstraint = 4,
        SqlScalarFunction = 5,
        AssemblyScalarFunction = 6,
        AssemblyTableValuedFunction = 7,
        SqlInlineTableValuedFunction = 8,
        InternalTable = 9,
        SqlStoredProcedure = 10,
        AssemblyStoredProcedure = 11,
        PlanGuide = 12,
        PrimaryKeyConstraint = 13,
        Rule = 14,
        ReplicationFilterProcedure = 15,
        SystemBaseTable = 16,
        Synonym = 17,
        SequenceObject = 18,
        ServiceQueue = 19,
        AssemblyDMLTrigger = 20,
        SqlTableValuedFunction = 21,
        SqlDMLTrigger = 22,
        TableType = 23,
        Table = 24,
        UniqueConstraint = 25,
        View = 26,
        ExtendedStoredProcedure = 27
    }
}