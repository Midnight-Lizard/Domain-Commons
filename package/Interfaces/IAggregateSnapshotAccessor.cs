using MidnightLizard.Commons.Domain.Results;
using MidnightLizard.Commons.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MidnightLizard.Commons.Domain.Interfaces
{
    public interface IAggregateSnapshotAccessor<TAggregate, TAggregateId>
        where TAggregateId : DomainEntityId
        where TAggregate : AggregateRoot<TAggregateId>
    {
        Task Save(AggregateSnapshot<TAggregate, TAggregateId> aggregate);

        Task<AggregateSnapshot<TAggregate, TAggregateId>> Read(TAggregateId id);
    }
}
