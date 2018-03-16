using MediatR;
using MidnightLizard.Commons.Domain.Model;
using MidnightLizard.Commons.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MidnightLizard.Commons.Domain.Messaging
{
    public interface ITransportMessage<out TMessage> : IRequest<DomainResult>
        where TMessage : BaseMessage
    {
        Guid Id { get; }
        TMessage Payload { get; }
        Guid CorrelationId { get; }
        DateTime RequestTimestamp { get; }
        DateTime? EventTimestamp { get; }
        UserId UserId { get; }
        Type DeserializerType { get; set; }
    }

    public interface ITransportMessage<out TMessage, out TAggregateId> : ITransportMessage<TMessage>
        where TAggregateId : DomainEntityId
        where TMessage : DomainMessage<TAggregateId>
    {
        TAggregateId AggregateId { get; }
    }

    public class TransportMessage<TMessage, TAggregateId> : ITransportMessage<TMessage, TAggregateId>
        where TAggregateId : DomainEntityId
        where TMessage : DomainMessage<TAggregateId>
    {
        public Guid Id { get => this.Payload.Id; }
        public TAggregateId AggregateId { get => this.Payload.AggregateId; }

        public UserId UserId { get; }

        public TMessage Payload { get; }
        public Guid CorrelationId { get; }
        public DateTime RequestTimestamp { get; }
        public DateTime? EventTimestamp { get; }
        public Type DeserializerType { get; set; }

        public TransportMessage(TMessage message, Guid correlationId, UserId userId, DateTime requestTimestamp, DateTime? eventTimestamp = null)
        {
            Payload = message;
            CorrelationId = correlationId;
            RequestTimestamp = requestTimestamp;
            EventTimestamp = eventTimestamp;
            UserId = userId;
        }
    }
}
