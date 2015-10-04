using System.Collections.Generic;
using System.Linq;

namespace WBSoft.SqlDBCopier.Core
{
    /// <summary>
    /// Used to order sql objects so we can script dropping and creating tables in a safe manner
    /// </summary>
    public class SqlObjectDependencySorter : ISqlObjectDependencySorter
    {
        /// <summary>
        /// Get a list of objects, where the first object can depend on anything to the right and so on, until the last element doesn't depend upon anything
        /// </summary>
        public IReadOnlyList<SqlObject> OrderByDependency(
            IEnumerable<SqlObject> objects,
            IEnumerable<SqlExpressionDependency> expressionDependencies)
        {
            var unorderedObjects = objects.ToList();
            var orderedObjects = new List<SqlObject>();
            var allOrderedDeps = new HashSet<OrderedDep>(expressionDependencies.Select(x => new OrderedDep(x.ReferencingId, x.ReferencedId)));

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