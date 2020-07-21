using Data;
using GraphQL.Types;

namespace AspNetCore_GraphQLDemo.GraphQL.Types
{
    public class MountainType : ObjectGraphType<MountainInfo>
    {

        public MountainType()
        {
            Field(x => x.Id);
            Field(x => x.County);
            Field(x => x.Muncipiality);
            Field(x => x.OfficialName);
            Field(x => x.ReferencePoint);
            Field(x => x.CalculatedMetresAboveSeaLevel);
            Field(x => x.CalculatedPrimaryFactor);
        }

    }
}
