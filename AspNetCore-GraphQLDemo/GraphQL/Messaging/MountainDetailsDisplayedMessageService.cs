using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace AspNetCore_GraphQLDemo.GraphQL.Messaging
{
    public class MountainDetailsDisplayedMessageService
    {
        private readonly ISubject<MountainDetailsMessage> _messageStream = new ReplaySubject<MountainDetailsMessage>(1);

        public MountainDetailsMessage AddMountainDetailsMessage(int id)
        {
            var message = new MountainDetailsMessage
            {
                Id = id
            };
            _messageStream.OnNext(message);
            return message;
        }

        public IObservable<MountainDetailsMessage> GetMessages()
        {
            return _messageStream.AsObservable();
        }

    }
}
