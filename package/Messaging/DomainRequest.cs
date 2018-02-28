using MediatR;
using MidnightLizard.Commons.Domain.Model;
using MidnightLizard.Commons.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MidnightLizard.Commons.Domain.Messaging
{
    public abstract class DomainRequest<TAggregateId> : DomainMessage<TAggregateId>
        where TAggregateId : DomainEntityId
    {
    }
}
