using Data.Repositories;
using GraphQL.Types;

namespace AspNetCore_GraphQLDemo.GraphQL.Types
{
    public class MountainQuery : ObjectGraphType
    {
        public MountainQuery(IMountainRepository mountainRepository)
        {
            Field<ListGraphType<MountainType>>("mountains",
                resolve: context => mountainRepository.GetAll()
                );

        }



    }
}