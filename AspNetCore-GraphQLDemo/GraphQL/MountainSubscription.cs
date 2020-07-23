using AspNetCore_GraphQLDemo.GraphQL.Messaging;
using AspNetCore_GraphQLDemo.GraphQL.Types;
using GraphQL.Resolvers;
using GraphQL.Types;

namespace AspNetCore_GraphQLDemo.GraphQL
{
    public class MountainSubscription : ObjectGraphType
    {
        public MountainSubscription(MountainDetailsDisplayedMessageService mountainDetailsDisplayedMessageService)
        {
            Name = "Subscription";
            AddField(new EventStreamFieldType
            {
                Name = "detailsDisplayed",
                Type = typeof(MountainDetailsMessageType),
                Resolver = new FuncFieldResolver<MountainDetailsMessage>(c => c.Source as MountainDetailsMessage),
                Subscriber = new EventStreamResolver<MountainDetailsMessage>(c => mountainDetailsDisplayedMessageService.GetMessages())
            });
        }
    }
}
