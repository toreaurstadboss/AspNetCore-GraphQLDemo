using System.Threading.Tasks;
using GraphQL;
using GraphQL.Instrumentation;
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
            RegisterDirective(new LowercaseDirective());

            

            var builder = new FieldMiddlewareBuilder();
            builder.Use<LowercaseFieldsMiddleware>();
            builder.ApplyTo(this);


            //builder.Use(next =>
            //{

            //    return context =>
            //    {
            //        return next(context).ContinueWith(x =>
            //        {
            //            var c = context;
            //            if (c.FieldAst.Directives.Count > 1)
            //            {

            //            }

            //            var result = x.Result;
            //            return result;
            //        });
            //    };
            //});
            //builder.ApplyTo(this);

            //builder.Use<CustomGraphQlExecutor<MountainSchema>>();
            //builder.ApplyTo(this);
        }

    }

    public class LowercaseDirective : DirectiveGraphType
    {
        public LowercaseDirective() : base("lowercase", new DirectiveLocation[] { DirectiveLocation.Field })
        {
            
        }
    }

    // field middleware
    public class LowercaseFieldsMiddleware
    {
        public async Task<object> Resolve(ResolveFieldContext context, FieldMiddlewareDelegate next)
        {
            var result = await next(context);
            var directive = context.FieldAst.Directives.Find("lowercase");
            // check if directive exists, check argument values, etc.
            return directive != null ? result?.ToString().ToLower() : result;
        }
    }

    public class SortingDirective : DirectiveGraphType
    {
        public SortingDirective() : base("toUpperCase", new [] {  DirectiveLocation.Field})
        {

            
        }

    }
}
