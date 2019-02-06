using MidnightLizard.Commons.Domain.Messaging;
using MidnightLizard.Commons.Domain.Model;
using MidnightLizard.Commons.Domain.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MidnightLizard.Commons.Domain.Interfaces
{
    /// <summary>
    /// Reads and writes event sourced domain events into events store
    /// </summary>
    /// <typeparam name="TAggregateId">Type of Aggregate ID events of wich this accessor processing</typeparam>
    public interface IDomainEventStore<TAggregateId>
        where TAggregateId : DomainEntityId
    {
        Task<DomainEventsResult<TAggregateId>> GetEvents(TAggregateId aggregateId, int sinceGeneration);
        Task<DomainResult> SaveEvent(ITransportMessage<EventSourcedDomainEvent<TAggregateId>> @event);
    }
}
