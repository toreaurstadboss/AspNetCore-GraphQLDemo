using AspNetCore_GraphQLDemo.GraphQL.Messaging;
using AspNetCore_GraphQLDemo.GraphQL.Types;
using Data;
using Data.Repositories;
using GraphQL;
using GraphQL.Types;

namespace AspNetCore_GraphQLDemo.GraphQL
{
    public class MountainMutation : ObjectGraphType
    {

        public MountainMutation(IMountainRepository mountainRepository, MountainMessageService mountainMessageService)
        {
            FieldAsync<MountainType>("createMountain",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<MountainInputType>> {Name = "mountain"}),
                resolve: async context =>
                {
                    var mountain = context.GetArgument<MountainInfo>("mountain");
                    await mountainRepository.AddMountain(mountain);
                    mountainMessageService.AddMountainAddedMessage(mountain);
                    return mountain;
                });

            FieldAsync<MountainType>("removeMountain",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<MountainIdInputType>> { Name = "id" }),
                resolve: async context =>
                {
                    var mountain = context.GetArgument<MountainInfo>("id");
                    await mountainRepository.RemoveMountain(mountain.Id);
                    return mountain;
                });

        }

    }
}
