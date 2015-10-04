using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBSoft.SqlDBCopier.Core
{
    /// <summary>
    /// Used to create commands which will copy a schema from one database to another
    /// </summary>
    public class MigrateSchemaCommandGenerator
    {

        public List<ICommand> GetCommands(Schema fromSchema, Schema toSchema)
        {
            var allOrderedToSchemaObjects = GetObjectsOrderedByDependency(toSchema);
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

        /// <summary>
        /// Get a list of objects, where the first object can depend on anything to the right and so on, until the last element doesn't depend upon anything
        /// </summary>
        private List<SqlObject> GetObjectsOrderedByDependency(Schema schema)
        {
            var unorderedObjects = schema.Objects.ToList();
            var orderedObjects = new List<SqlObject>();
            var allOrderedDeps = new HashSet<OrderedDep>(schema.ExpressionDependencies.Select(x => new OrderedDep(x.ReferencingId, x.ReferencedId)));
            
            //Probably not the most efficient algorithm, but eh, you're not going to have lots of them
            while (unorderedObjects.Count > 0)
            {
                int i = 0;
                while (i < unorderedObjects.Count)
                {
                    var toTest = unorderedObjects[i];
                    bool dependsOnSomethingElseInList = false;
                    for (int j = 0; j < unorderedObjects.Count; j++)
                    {
                        if (i == j)
                        {
                            continue;
                        }
                        var candidateDep = unorderedObjects[j];
                        if (allOrderedDeps.Contains(new OrderedDep(toTest.ObjectId, candidateDep.ObjectId)))
                        {
                            dependsOnSomethingElseInList = true;
                            break;
                        }
                    }

                    if (!dependsOnSomethingElseInList)
                    {
                        orderedObjects.Add(toTest);
                        unorderedObjects.RemoveAt(i);
                        i = 0; //Removed something with no deps on anything else remaining, reset to start and scan through everything again
                    }
                    else
                    {
                        i++;
                    }

                }
            }

            return orderedObjects;
        }

    }
}
