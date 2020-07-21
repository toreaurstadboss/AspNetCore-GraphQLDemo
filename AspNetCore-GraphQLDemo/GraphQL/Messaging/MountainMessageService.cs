using Data;
using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace AspNetCore_GraphQLDemo.GraphQL.Messaging
{
    public class MountainMessageService
    {
        private readonly ISubject<MountainAddedMessage> _messageStream = new ReplaySubject<MountainAddedMessage>(1);

        public MountainAddedMessage AddMountainAddedMessage(MountainInfo mountain)
        {
            var message = new MountainAddedMessage
            {
                Id = mountain.Id,
                Comments = mountain.Comments,
                County = mountain.County,
                MetresAboveSeaLevel = mountain.MetresAboveSeaLevel,
                Muncipiality = mountain.Muncipiality,
                OfficialName = mountain.OfficialName,
                PrimaryFactor = mountain.PrimaryFactor,
                ReferencePoint = mountain.ReferencePoint
            };
            _messageStream.OnNext(message);
            return message;
        }

        public IObservable<MountainAddedMessage> GetMessages()
        {
            return _messageStream.AsObservable();
        }

    }
}
