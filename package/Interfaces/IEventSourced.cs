﻿using MidnightLizard.Commons.Domain.Messaging;
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
        IEnumerable<DomainEvent<TAggregateId>> ReleaseEvents();
        void AddDomainEvent(DomainEvent<TAggregateId> @event, UserId userId);
        void ReplayEventSourcedDomainEvents(IEnumerable<(EventSourcedDomainEvent<TAggregateId> @event, UserId userId)> eventsWithUsers);
        void Reduce(EventSourcedDomainEvent<TAggregateId> @event, UserId userId);
    }
}
