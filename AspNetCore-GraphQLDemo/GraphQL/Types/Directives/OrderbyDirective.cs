using GraphQL.Types;

namespace AspNetCore_GraphQLDemo.GraphQL.Types.Directives
{
    public class OrderbyDirective : DirectiveGraphType
    {
        public OrderbyDirective() : base("sort", new DirectiveLocation[] { DirectiveLocation.Field })
        {
            Description = "Sorts the query by provided field";
            Arguments = new QueryArguments(new QueryArgument<SortDirection>
            {
                Name = "direction",
                Description = "Sorts by a field"

            });

        }

        public enum SortDir
        {
            asc,
            desc
        }

        public class SortDirection : EnumerationGraphType<SortDir>
        {
            public SortDirection()
            {
                AddValue(new EnumValueDefinition { Name = "asc", Description = "Ascending", Value=1 });
                AddValue(new EnumValueDefinition { Name = "desc", Description = "Descending", Value =-1 });
            }
        }
    }   
   
}
