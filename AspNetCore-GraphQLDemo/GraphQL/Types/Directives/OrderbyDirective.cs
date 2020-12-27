using GraphQL.Types;

namespace AspNetCore_GraphQLDemo.GraphQL.Types.Directives
{

    public enum SortDir
    {
        ASC = 1,
        DESC = -1
    }

    public class SortDirectionInputValue : InputObjectGraphType
    {
        public SortDirectionInputValue()
        {
            Name = "id";
            Field<IdGraphType>("id");

        }

    }


    public class OrderbyDirective : DirectiveGraphType
    {
        public OrderbyDirective() : base("sort", new DirectiveLocation[] { DirectiveLocation.Field })
        {
            Description = "Sorts the query by provided field";
            Arguments = new QueryArguments(new QueryArgument<SortDirectionInputValue>
            {
                Name = "id"
            });


            //Arguments = new QueryArguments(new QueryArgument<NonNullGraphType<SortDirectionInputValue>>
            //{
            //    Name = "sort"
            //});

        }



        public class SortDirection : EnumerationGraphType<SortDir>
        {
            public SortDirection()
            {
                AddValue(new EnumValueDefinition { Name = "ASC", Description = "Ascending", Value = 1 });
                AddValue(new EnumValueDefinition { Name = "DESC", Description = "Descending", Value = -1 });
            }
        }
    }   
   
}
