using MidnightLizard.Commons.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MidnightLizard.Commons.Domain.Interfaces
{
    public interface IIdentified<TId> where TId : DomainEntityId
    {
        TId Id { get; }
    }
}
