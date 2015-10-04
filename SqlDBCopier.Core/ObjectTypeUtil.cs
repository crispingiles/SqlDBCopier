using System;
using System.Collections.Generic;
using static WBSoft.SqlDBCopier.Core.ObjectType;

namespace WBSoft.SqlDBCopier.Core
{
    /// <summary>
    /// Used to map the 2 letter character codes to <see cref="ObjectType"/>s
    /// </summary>
    public static class ObjectTypeUtil
    {
        public static ObjectType GetObjectType(string typeCode)
        {
            if (typeCode == null)
                throw new ArgumentNullException(nameof(typeCode));
            if (typeCode.Length != 2)
                throw new ArgumentException($"typeCode must be exactly length 2 but supplied '{typeCode}'", nameof(typeCode));
            ObjectType objectType;
            if (!objectTypeMap.TryGetValue(typeCode, out objectType))
                throw new ArgumentException($"No ObjectType found matching supplied typeCode '{typeCode}'");
            return objectType;
        }

        /// <summary>
        /// Maps 2 letter character codes to <see cref="ObjectType"/>s
        /// </summary>
        private static readonly Dictionary<string, ObjectType> objectTypeMap =
            new Dictionary<string, ObjectType>(StringComparer.OrdinalIgnoreCase)
            {
                {"AF", AggregateFunction},
                {"C ", CheckConstraint },
                {"D ", DefaultConstraint },
                {"F ", ForeignKeyConstraint },
                {"FN", SqlScalarFunction },
                {"FS", AssemblyScalarFunction },
                {"FT", AssemblyTableValuedFunction },
                {"IF", SqlInlineTableValuedFunction },
                {"IT", InternalTable },
                {"P ", SqlStoredProcedure },
                {"PC", AssemblyStoredProcedure },
                {"PG", PlanGuide },
                {"PK", PrimaryKeyConstraint },
                {"R ", Rule },
                {"RF", ReplicationFilterProcedure },
                {"S ", SystemBaseTable },
                {"SN", Synonym },
                {"SO", SequenceObject },
                {"SQ", ServiceQueue },
                {"TA", AssemblyDMLTrigger },
                {"TF", SqlTableValuedFunction },
                {"TR", SqlDMLTrigger },
                {"TT", TableType },
                {"U ", Table },
                {"UQ", UniqueConstraint },
                {"V ", View },
                {"X ", ExtendedStoredProcedure }
            };
    }
}