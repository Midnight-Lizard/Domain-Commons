using MidnightLizard.Commons.Domain.Interfaces;
using MidnightLizard.Commons.Domain.Messaging;
using System.Collections.Generic;
using System.Linq;

namespace MidnightLizard.Commons.Domain.Model
{
    public abstract class AggregateRoot<TAggregateId> : DomainEntity<TAggregateId>, IEventSourced<TAggregateId>
        where TAggregateId : DomainEntityId
    {
        private readonly List<DomainEvent<TAggregateId>> pendingEvents = new List<DomainEvent<TAggregateId>>();

        public virtual int Generation { get; protected set; }
        private bool isNew;
        public virtual bool IsNew()
        {
            return this.isNew;
        }

        public abstract void Reduce(EventSourcedDomainEvent<TAggregateId> @event, UserId userId);

        public AggregateRoot() { }

        public AggregateRoot(TAggregateId aggregateId)
        {
            this.Id = aggregateId;
            this.isNew = true;
        }

        public virtual IEnumerable<DomainEvent<TAggregateId>> ReleaseEvents()
        {
            var events = this.pendingEvents.ToArray();
            this.pendingEvents.Clear();
            return events;
        }

        public virtual void AddDomainEvent(DomainEvent<TAggregateId> @event, UserId userId)
        {
            switch (@event)
            {
                case EventSourcedDomainEvent<TAggregateId> eventSourced:
                {
                    @event.Generation = this.Generation + 1;
                    this.Reduce(eventSourced, userId);
                    this.Generation = @event.Generation;
                    this.pendingEvents.Add(@event);
                    this.isNew = false;
                    break;
                }

                case FailedDomainEvent<TAggregateId> failed:
                case IntegrationEvent<TAggregateId> integration:
                {
                    @event.Generation = this.Generation;
                    this.pendingEvents.Add(@event);
                    break;
                }

                default:
                    break;
            }
        }

        public virtual void ReplayEventSourcedDomainEvents(IEnumerable<(EventSourcedDomainEvent<TAggregateId> @event, UserId userId)> eventsWithUsers)
        {
            if (eventsWithUsers != null)
            {
                foreach (var (@event, userId) in eventsWithUsers)
                {
                    this.Reduce(@event, userId);
                    this.Generation = @event.Generation;
                }
                if (eventsWithUsers.Count() > 0)
                {
                    this.isNew = false;
                }
            }
        }
    }
}
