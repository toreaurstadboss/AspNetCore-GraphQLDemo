using GraphQL;
using GraphQL.Types;

namespace AspNetCore_GraphQLDemo.GraphQL.Types
{
    public class MountainSchema : Schema
    {

        public MountainSchema(IDependencyResolver resolver)  : base(resolver)
        {
            Query = resolver.Resolve<MountainQuery>();
        }

    }
}
