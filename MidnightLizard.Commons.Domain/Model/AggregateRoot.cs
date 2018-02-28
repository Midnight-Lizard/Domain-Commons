using MidnightLizard.Commons.Domain.Interfaces;
using MidnightLizard.Commons.Domain.Messaging;
using MidnightLizard.Commons.Domain.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace MidnightLizard.Commons.Domain.Model
{
    public abstract class AggregateRoot<TAggregateId> : DomainEntity<TAggregateId>, IEventSourced<TAggregateId>
        where TAggregateId : DomainEntityId
    {
        private readonly List<DomainEvent<TAggregateId>> pendingEvents = new List<DomainEvent<TAggregateId>>();

        public virtual int Generation { get; protected set; }
        private bool isNew;
        public virtual bool IsNew() => isNew;
        public abstract Version LatestVersion();

        public abstract void Reduce(DomainEvent<TAggregateId> @event);

        public AggregateRoot() { }

        public AggregateRoot(TAggregateId aggregateId)
        {
            Id = aggregateId;
            this.isNew = true;
        }

        public virtual IEnumerable<DomainEvent<TAggregateId>> ReleaseEvents()
        {
            var events = this.pendingEvents.ToArray();
            this.pendingEvents.Clear();
            return events;
        }

        public virtual void AddDomainEvent(DomainEvent<TAggregateId> @event)
        {
            @event.Generation = this.Generation + 1;
            this.Reduce(@event);
            this.Generation = @event.Generation;
            this.pendingEvents.Add(@event);
            this.isNew = false;
        }

        public virtual void ReplayDomainEvents(IEnumerable<DomainEvent<TAggregateId>> events)
        {
            foreach (var @event in events)
            {
                this.Reduce(@event);
                this.Generation = @event.Generation;
            }
        }
    }
}
