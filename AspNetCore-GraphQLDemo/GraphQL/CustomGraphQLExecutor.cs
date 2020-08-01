//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Threading;
//using System.Threading.Tasks;
//using GraphQL;
//using GraphQL.Execution;
//using GraphQL.Instrumentation;
//using GraphQL.Server;
//using GraphQL.Server.Internal;
//using GraphQL.Types;
//using GraphQL.Validation;
//using Microsoft.Extensions.Options;

//namespace AspNetCore_GraphQLDemo.GraphQL
//{

//    public class CustomGraphQlExecutor<TSchema> : DefaultGraphQLExecuter<TSchema>
//        where TSchema : ISchema
//    {
//        private readonly GraphQLOptions options;

//        public CustomGraphQlExecutor(
//            TSchema schema,
//            IDocumentExecuter documentExecuter,
//            IOptions<GraphQLOptions> options,
//            IEnumerable<IDocumentExecutionListener> listeners,
//            IEnumerable<IValidationRule> validationRules)
//            : base(schema, documentExecuter, options, listeners, validationRules) =>
//            this.options = options.Value;

//        protected override ExecutionOptions GetOptions(
//            string operationName,
//            string query,
//            Inputs variables,
//            object context,
//            CancellationToken cancellationToken)
//        {
//            var options = base.GetOptions(operationName, query, variables, context, cancellationToken);

//            if (this.options.SetFieldMiddleware)
//            {
//                options.FieldMiddleware.Use<MountainGraphQlSortingMiddleware>();
//            }

//            return options;
//        }
//    }

//    public class MountainGraphQlSortingMiddleware
//    {
//        public async Task<object> Resolve(
//            ResolveFieldContext context,
//            FieldMiddlewareDelegate next)
//        {
//            var metadata = new Dictionary<string, object>
//            {
//                {"typeName", context.ParentType.Name},
//                {"fieldName", context.FieldName}
//            };



//            using (context.Metrics.Subject("field", context.FieldName, metadata))
//            {
//                return await next(context);
//            }
//        }
//    }
//}
