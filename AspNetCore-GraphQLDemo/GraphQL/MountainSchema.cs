using AspNetCore_GraphQLDemo.GraphQL.Types;
using AspNetCore_GraphQLDemo.GraphQL.Types.Directives;
using GraphQL;
using GraphQL.Instrumentation;
using GraphQL.Types;

namespace AspNetCore_GraphQLDemo.GraphQL
{
    public class MountainSchema : Schema
    {

        public MountainSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<MountainQuery>();
            Mutation = resolver.Resolve<MountainMutation>();
            Subscription = resolver.Resolve<MountainSubscription>();
            RegisterDirective(new LowercaseDirective());
            RegisterDirective(new OrderbyDirective());

            var builder = new FieldMiddlewareBuilder();
            builder.Use<LowercaseFieldsMiddleware>();
            builder.ApplyTo(this);

            builder.Use(next =>
            {

                return context =>
                {
                    return next(context).ContinueWith(x =>
                    {
                        var c = context;                      
                        var result = x.Result;

                        result = OrderbyQuery.OrderIfNecessary(context, result);

                        return result;
                    });
                };
            });
            builder.ApplyTo(this);

            //builder.Use<CustomGraphQlExecutor<MountainSchema>>();
            //builder.ApplyTo(this);
        }

    }
}

