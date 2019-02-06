﻿using MidnightLizard.Commons.Domain.Model;

namespace MidnightLizard.Commons.Domain.Messaging
{
    public class EventSourcedDomainEvent<TAggregateId> : DomainEvent<TAggregateId>
        where TAggregateId : DomainEntityId
    {
        protected EventSourcedDomainEvent() { }

        public EventSourcedDomainEvent(TAggregateId aggregateId) : base(aggregateId)
        {
        }
    }
}
