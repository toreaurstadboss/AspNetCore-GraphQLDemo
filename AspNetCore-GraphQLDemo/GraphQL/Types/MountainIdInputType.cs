using GraphQL.Types;

namespace AspNetCore_GraphQLDemo.GraphQL.Types
{
    public class MountainIdInputType : InputObjectGraphType
    {
        public MountainIdInputType()
        {
            Name = "id";
            Field<IdGraphType>("id");
        }
    }
}
