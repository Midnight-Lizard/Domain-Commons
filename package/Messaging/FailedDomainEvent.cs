using MidnightLizard.Commons.Domain.Model;

namespace MidnightLizard.Commons.Domain.Messaging
{
    public class FailedDomainEvent<TAggregateId> : DomainEvent<TAggregateId>
        where TAggregateId : DomainEntityId
    {
        protected FailedDomainEvent() { }

        public FailedDomainEvent(TAggregateId aggregateId) : base(aggregateId)
        {
        }
    }
}