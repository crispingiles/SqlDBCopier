namespace WBSoft.SqlDBCopier.Core
{
    public class Column
    {

        public int TableObjectId { get; set; }

        public string Name { get; set; }

        public int ColumnId { get; set; }

        public ColumnType ColumnType { get; set; }

        public int MaxLength { get; set; }

        public int Precision { get; set; }

        public int Scale { get; set; }

        public bool IsNullable { get; set; }

        public bool IsIdentity { get; set; }

        public bool IsComputed { get; set; }
    }
}
