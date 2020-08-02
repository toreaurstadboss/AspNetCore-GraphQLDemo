using System.Threading.Tasks;
using GraphQL.Instrumentation;
using GraphQL.Types;



namespace AspNetCore_GraphQLDemo.GraphQL
{
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
}