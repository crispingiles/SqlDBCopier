using System;

namespace WBSoft.SqlDBCopier.Core
{
    public class DeleteCommand : ICommand
    {
        public DeleteCommand(SqlObject o)
        {
            Object = o;
        }

        private SqlObject Object { get; }

        public string CommandText
        {
            get
            {
                string typeName;
                switch (Object.ObjectType)
                {
                    case ObjectType.Table:
                        typeName = "TABLE";
                        break;
                    case ObjectType.View:
                        typeName = "VIEW";
                        break;
                    case ObjectType.SqlStoredProcedure:
                        typeName = "PROCEDURE";
                        break;
                    case ObjectType.SqlInlineTableValuedFunction:
                    case ObjectType.SqlScalarFunction:
                    case ObjectType.SqlTableValuedFunction:
                        typeName = "FUNCTION";
                        break;
                    default:
                        throw new ApplicationException($"Unable to map ObjectType {Object.ObjectType} to type to use in drop statement");
                }

                return $"DROP {typeName} {Object.Name}{Environment.NewLine}GO" ; //TODO:Check schema
            }
        }
    }
}