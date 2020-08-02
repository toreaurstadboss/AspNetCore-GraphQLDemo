using GraphQL.Types;

namespace AspNetCore_GraphQLDemo.GraphQL.Types
{
    public class LowercaseDirective : DirectiveGraphType
    {
        public LowercaseDirective() : base("lowercase", new DirectiveLocation[] { DirectiveLocation.Field })
        {

        }
    }
}
