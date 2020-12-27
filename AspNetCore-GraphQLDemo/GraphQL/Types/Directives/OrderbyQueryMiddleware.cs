using GraphQL.Language.AST;
using GraphQL.Types;
using System.Collections.Generic;
using System.Linq;
using GraphQL;
using static AspNetCore_GraphQLDemo.GraphQL.Types.Directives.OrderbyDirective;
using Field = GraphQL.Language.AST.Field;

namespace AspNetCore_GraphQLDemo.GraphQL.Types.Directives
{
    public static class OrderbyQuery
    {
        public static object OrderIfNecessary(ResolveFieldContext context, object inputData)
        {
            if (context.Operation == null || context.Operation.OperationType != 0)
            {
                return inputData; 
            }
            var selectionSet = context.Operation.SelectionSet.Selections.SelectMany(sel => sel.Children).OfType<SelectionSet>().FirstOrDefault();
            if (selectionSet == null || selectionSet?.Selections.Any() != true)
                return inputData;
            var sortingFields = new Dictionary<Field, SortDir>();
            foreach (var field in selectionSet.Selections)
            {
                var f = field as Field;
                if (f == null)
                    continue;
                var sortDirective = f.Directives.FirstOrDefault(d => d.Name == "sort");
                if (sortDirective == null)
                    continue;
                sortingFields[f] = sortDirective.Arguments.FirstOrDefault(a => a.Name == "direction")?.Value?.Value?.ToString() == "desc" ? SortDir.desc : SortDir.asc;
            }

            if (sortingFields.Any())
            {
                var castedInputData = (inputData as IEnumerable<object>);
                if (castedInputData == null)
                {
                    return inputData; 
                }
                var sortedInputData = new List<object>();

                foreach (var element in castedInputData)
                {
                    sortedInputData.Add(element);
                }

                var sortField = sortingFields.First();

                sortedInputData.Sort((x, y) =>
                {
            
                    var propInfo = x.GetType().GetProperties().FirstOrDefault(p => p.Name.ToLower() == sortField.Key.Name.ToLower());
                    var xSortValue = propInfo.GetValue(x);
                    var ySortValue = propInfo.GetValue(y);
                    int sortComparison = 0;
                    if (propInfo.PropertyType == typeof(int))
                    {
                        sortComparison = (int)xSortValue < (int)ySortValue ? -1 : (int)xSortValue == (int)ySortValue ? 0 : 1;
                    }
                    if (propInfo.PropertyType == typeof(double))
                    {
                        sortComparison = (double)xSortValue < (double)ySortValue ? -1 : (double)xSortValue == (double)ySortValue ? 0 : 1;
                    }
                    if (sortField.Value == SortDir.desc)
                    {
                        sortComparison *= -1;
                    }
                    return sortComparison;

                });

                return sortedInputData;


            }

            return inputData;

        }
    }
}
