using MidnightLizard.Commons.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MidnightLizard.Commons.Domain.Model
{
    public class DomainEntity<TId> : IIdentified<TId>
        where TId : DomainEntityId
    {
        public virtual TId Id { get; protected set; }
    }
}
