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
        TMessage Payload { get; }
        Guid CorrelationId { get; }
        DateTime RequestTimestamp { get; }
        Type DeserializerType { get; set; }
    }

    public class TransportMessage<TMessage, TAggregateId> : ITransportMessage<TMessage>
        where TAggregateId : DomainEntityId
        where TMessage : DomainMessage<TAggregateId>
    {
        public Guid Id { get => this.Payload.Id; }
        public TAggregateId AggregateId { get => this.Payload.AggregateId; }

        public TMessage Payload { get; }
        public Guid CorrelationId { get; }
        public DateTime RequestTimestamp { get; }
        public Type DeserializerType { get; set; }

        public TransportMessage(TMessage message, Guid correlationId, DateTime requestTimestamp)
        {
            Payload = message;
            CorrelationId = correlationId;
            RequestTimestamp = requestTimestamp;
        }
    }
}
