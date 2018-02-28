using MediatR;
using MidnightLizard.Commons.Domain.Interfaces;
using MidnightLizard.Commons.Domain.Model;
using MidnightLizard.Commons.Domain.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MidnightLizard.Commons.Domain.Messaging
{
    public abstract class DomainEvent<TAggregateId> : DomainMessage<TAggregateId>
        where TAggregateId : DomainEntityId
    {
        public int Generation { get; set; }

        protected DomainEvent() { }

        public DomainEvent(TAggregateId aggregateId)
        {
            this.Id = Guid.NewGuid();
            this.AggregateId = aggregateId;
        }
    }
}
