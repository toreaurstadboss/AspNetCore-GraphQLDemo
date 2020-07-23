using AspNetCore_GraphQLDemo.GraphQL.Messaging;
using GraphQL.Types;

namespace AspNetCore_GraphQLDemo.GraphQL.Types
{
    public class MountainDetailsDisplayedMessageType : ObjectGraphType<MountainDetailsMessage>
    {
        public MountainDetailsDisplayedMessageType()
        {
            Field(t => t.Id);
        }
    }
}
