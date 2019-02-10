using MidnightLizard.Commons.Domain.Messaging;
using MidnightLizard.Commons.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MidnightLizard.Commons.Domain.Results
{
    public class DomainEventsResult<TAggregateId> : DomainResult
        where TAggregateId : DomainEntityId
    {
        public IEnumerable<ITransportMessage<EventSourcedDomainEvent<TAggregateId>, TAggregateId>> Events { get; }

        public DomainEventsResult() { }

        public DomainEventsResult(IEnumerable<ITransportMessage<EventSourcedDomainEvent<TAggregateId>, TAggregateId>> events)
        {
            Events = events;
        }

        public DomainEventsResult(string errorMessage) : base(errorMessage) { }

        public DomainEventsResult(Exception ex) : base(ex) { }

        public DomainEventsResult(bool hasError, Exception ex, string errorMessage)
            : base(hasError, ex, errorMessage, DomainProblemLevel.Infrastructure) { }
    }
}
