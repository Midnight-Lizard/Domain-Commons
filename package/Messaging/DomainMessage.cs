using MediatR;
using MidnightLizard.Commons.Domain.Model;
using MidnightLizard.Commons.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MidnightLizard.Commons.Domain.Messaging
{
    public abstract class DomainMessage<TAggregateId> : BaseMessage
        where TAggregateId : DomainEntityId
    {
        public virtual TAggregateId AggregateId { get; protected set; }
    }
}
