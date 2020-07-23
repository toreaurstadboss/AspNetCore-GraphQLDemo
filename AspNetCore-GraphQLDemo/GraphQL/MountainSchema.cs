using GraphQL;
using GraphQL.Types;

namespace AspNetCore_GraphQLDemo.GraphQL
{
    public class MountainSchema : Schema
    {

        public MountainSchema(IDependencyResolver resolver)  : base(resolver)
        {
            Query = resolver.Resolve<MountainQuery>();
            Mutation = resolver.Resolve<MountainMutation>();
            Subscription = resolver.Resolve<MountainSubscription>();
        }

    }
}
