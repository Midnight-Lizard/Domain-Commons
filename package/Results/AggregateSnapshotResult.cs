using MidnightLizard.Commons.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MidnightLizard.Commons.Domain.Results
{
    public class AggregateSnapshotResult<TAggregate, TAggregateId> : DomainResult
        where TAggregate : AggregateRoot<TAggregateId>
        where TAggregateId : DomainEntityId
    {
        public AggregateSnapshot<TAggregate, TAggregateId> AggregateSnapshot { get; }

        public AggregateSnapshotResult() { }

        public AggregateSnapshotResult(AggregateSnapshot<TAggregate, TAggregateId> aggregateSnapshot)
        {
            AggregateSnapshot = aggregateSnapshot;
        }

        public AggregateSnapshotResult(string errorMessage) : base(errorMessage)
        {

        }

        public AggregateSnapshotResult(Exception ex) : base(ex)
        {
        }

        public AggregateSnapshotResult(bool hasError, Exception ex, string errorMessage) : base(hasError, ex, errorMessage)
        {
        }
    }
}
