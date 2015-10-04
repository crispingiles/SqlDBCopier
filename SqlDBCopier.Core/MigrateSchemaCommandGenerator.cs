using System;
using System.Collections.Generic;
using System.Linq;

namespace WBSoft.SqlDBCopier.Core
{
    /// <summary>
    /// Used to create commands which will copy a schema from one database to another
    /// </summary>
    public class MigrateSchemaCommandGenerator
    {
        public MigrateSchemaCommandGenerator(ISqlObjectDependencySorter sqlObjectDependencySorter)
        {
            SqlObjectDependencySorter = sqlObjectDependencySorter;
        }

        private ISqlObjectDependencySorter SqlObjectDependencySorter;

        public List<ICommand> GetCommands(Schema fromSchema, Schema toSchema)
        {
            var allOrderedToSchemaObjects = SqlObjectDependencySorter.OrderByDependency(toSchema.Objects, toSchema.ExpressionDependencies);
            var droppableToSchemaObjects = allOrderedToSchemaObjects.Where(x => x.ParentObjectId == 0).Reverse().ToList();
            var commands = new List<ICommand>();
            foreach (var toSchemaObject in droppableToSchemaObjects)
            {
                var deleteCommand = new DeleteCommand(toSchemaObject);
                commands.Add(deleteCommand);
            }

            var creatableFromSchemaObjects = fromSchema.Objects.Where(IsCreatable).ToList();
            foreach (var fromSchemaObject in creatableFromSchemaObjects)
            {
                string definition;
                if (fromSchemaObject.ObjectType == ObjectType.Table)
                {
                    definition = fromSchema.TableDefinitions.FirstOrDefault(f => f.ObjectId == fromSchemaObject.ObjectId).Definition;
                }
                else
                {
                    definition = fromSchema.Modules.FirstOrDefault(f => f.ObjectId == fromSchemaObject.ObjectId).Definition;
                }

                commands.Add(new CreateCommand {CommandText = definition + Environment.NewLine + "GO"});
            }
            return commands;
        }

        private bool IsCreatable(SqlObject sqlObject)
        {
            switch (sqlObject.ObjectType)
            {
                case ObjectType.SqlInlineTableValuedFunction:
                case ObjectType.SqlScalarFunction:
                case ObjectType.SqlTableValuedFunction:
                case ObjectType.SqlStoredProcedure:
                case ObjectType.View:
                case ObjectType.SqlDMLTrigger:
                case ObjectType.Table:
                case ObjectType.TableType:
                    return true;
                default:
                    return false;
            }
        }
    }
}
