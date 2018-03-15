using MidnightLizard.Commons.Domain.Messaging;
using MidnightLizard.Commons.Domain.Model;
using MidnightLizard.Commons.Domain.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace MidnightLizard.Commons.Domain.Interfaces
{
    public interface IEventSourced<TAggregateId> : IIdentified<TAggregateId>
        where TAggregateId : DomainEntityId
    {
        void AddDomainEvent(DomainEvent<TAggregateId> @event, UserId userId);
        IEnumerable<DomainEvent<TAggregateId>> ReleaseEvents();
        void ReplayDomainEvents(IEnumerable<(DomainEvent<TAggregateId> @event, UserId userId)> eventsWithUsers);
        void Reduce(DomainEvent<TAggregateId> @event, UserId userId);
    }
}
