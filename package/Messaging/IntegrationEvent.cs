using MidnightLizard.Commons.Domain.Model;

namespace MidnightLizard.Commons.Domain.Messaging
{
    /// <summary>
    /// Integration event - to be used by other bounded contexts
    /// </summary>
    /// <typeparam name="TAggregateId">aggregate id type</typeparam>
    public abstract class IntegrationEvent<TAggregateId> : DomainEvent<TAggregateId>
        where TAggregateId : DomainEntityId
    {
        protected IntegrationEvent() : base() { }

        public IntegrationEvent(TAggregateId aggregateId) : base(aggregateId) { }
    }
}
