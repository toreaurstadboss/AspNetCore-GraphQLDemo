using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;

namespace AspNetCore_GraphQLDemo.GraphQL.Types
{
    public class MountainInputType : InputObjectGraphType
    {

        public MountainInputType()
        {
            Name = "mountainInput";
            Field<StringGraphType>("county");
            Field<StringGraphType>("muncipiality");
            Field<StringGraphType>("officialName");
            Field<StringGraphType>("referencePoint");
            Field<StringGraphType>("comments");
            Field<StringGraphType>("metresAboveSeaLevel");
            Field<StringGraphType>("primaryFactor");
        }
    }
}
