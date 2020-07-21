namespace AspNetCore_GraphQLDemo.GraphQL.Messaging
{
    public class MountainAddedMessage
    {
        public int Id { get; set; }
        public string County { get; set; }
        public string Muncipiality { get; set; }
        public string OfficialName { get; set; }
        public string ReferencePoint { get; set; }
        public string Comments { get; set; }
        public string MetresAboveSeaLevel { get; set; }
        public string PrimaryFactor { get; set; }
    }
}
