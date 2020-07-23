using AspNetCore_GraphQLDemo.GraphQL.Messaging;
using GraphQL.Types;

namespace AspNetCore_GraphQLDemo.GraphQL.Types
{
    public class MountainDetailsMessageType : ObjectGraphType<MountainDetailsMessage>
    {

        public MountainDetailsMessageType()
        {
            Field(t => t.Id);
        }
    }
}
