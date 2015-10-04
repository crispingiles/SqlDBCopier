namespace WBSoft.SqlDBCopier.Core
{
    public enum ColumnType
    {
        Unknown = 0,
        Text = 34,
        UniqueIdentifier = 36,
        Date = 40,
        Time = 41,
        DateTime2 = 42,
        DateTimeOffset = 43,
        TinyInt = 48,
        SmallInt = 52,
        Int = 56,
        SmallDateTime = 58,
        Real = 59,
        Money = 60,
        DateTime = 61,
        Float = 62,
        SqlVariant = 98,
        Ntext = 99,
        Bit = 104,
        Decimal = 106,
        Numeric = 108,
        SmallMoney = 122,
        BigInt = 127,
        VarBinary = 165,
        VarChar = 167,
        Binary = 173,
        Char = 175,
        Timestamp = 189,
        NVarChar = 231,
        Sysname = 231,
        NChar = 239,
        //Deliberately omit HierarchyId, Geometry and Geography as they're rare and all have the same system type id (but diff user type ids and I cba)
        Xml = 241,
    }
}