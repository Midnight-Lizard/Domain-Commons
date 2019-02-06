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
    /// Dispatches domain events to the events queue
    /// </summary>
    /// <typeparam name="TAggregateId">Type of Aggregate ID to wich this event is related</typeparam>
    public interface IDomainEventDispatcher<TAggregateId>
        where TAggregateId : DomainEntityId
    {
        Task<DomainResult> DispatchEvent(ITransportMessage<DomainEvent<TAggregateId>, TAggregateId> transportEvent);
    }
}
