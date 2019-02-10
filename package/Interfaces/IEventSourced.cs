using MidnightLizard.Commons.Domain.Messaging;
using MidnightLizard.Commons.Domain.Model;
using System.Collections.Generic;

namespace MidnightLizard.Commons.Domain.Interfaces
{
    public interface IEventSourced<TAggregateId> : IIdentified<TAggregateId>
        where TAggregateId : DomainEntityId
    {
        IEnumerable<DomainEvent<TAggregateId>> ReleaseEvents();
        void AddFailedDomainEvent(FailedDomainEvent<TAggregateId> @event);
        void AddIntegrationEvent(IntegrationEvent<TAggregateId> @event);
        void AddEventSourcedDomainEvent(EventSourcedDomainEvent<TAggregateId> @event, UserId userId);
        void ReplayEventSourcedDomainEvents(IEnumerable<(EventSourcedDomainEvent<TAggregateId> @event, UserId userId)> eventsWithUsers);
    }
}
