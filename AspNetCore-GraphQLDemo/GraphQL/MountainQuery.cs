using AspNetCore_GraphQLDemo.GraphQL.Types;
using Data;
using Data.Repositories;
using GraphQL.Types;

namespace AspNetCore_GraphQLDemo.GraphQL
{
    public class MountainQuery : ObjectGraphType
    {
        public MountainQuery(IMountainRepository mountainRepository)
        {
            Field<ListGraphType<MountainType>>("mountains",
                resolve: context => mountainRepository.GetAll()
                );
            FieldAsync<MountainType>("mountain",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<MountainIdInputType>> {Name = "id"}),
                resolve: async context =>
                {
                    var mountain = context.GetArgument<MountainInfo>("id");
                    var mountainFromDb = await mountainRepository.GetById(mountain.Id);
                    return mountainFromDb;
                });

        }



    }
}