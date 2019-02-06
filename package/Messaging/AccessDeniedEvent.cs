using FluentValidation.Results;
using MidnightLizard.Commons.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MidnightLizard.Commons.Domain.Messaging
{
    public abstract class AccessDeniedEvent<TAggregateId> : FailedDomainEvent<TAggregateId>
        where TAggregateId : DomainEntityId
    {
        protected AccessDeniedEvent() { }

        public AccessDeniedEvent(TAggregateId aggregateId) : base(aggregateId)
        {
        }
    }
}
