using MidnightLizard.Commons.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MidnightLizard.Commons.Domain.Model
{
    public class AggregateSnapshot<TAggregate, TAggregateId>
        where TAggregate : AggregateRoot<TAggregateId>
        where TAggregateId : DomainEntityId
    {
        public TAggregate Aggregate { get; }
        public DateTime RequestTimestamp { get; set; }

        public AggregateSnapshot(TAggregate aggregate, DateTime requestTimestamp)
        {
            Aggregate = aggregate;
            RequestTimestamp = requestTimestamp;
        }
    }
}
