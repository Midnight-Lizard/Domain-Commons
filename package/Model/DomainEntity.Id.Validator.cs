using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MidnightLizard.Commons.Domain.Model
{
    public class DomainEntityIdValidator<T> : AbstractValidator<DomainEntityId<T>>
        where T : IComparable, IComparable<T>, IEquatable<T>
    {
        public DomainEntityIdValidator()
        {
            RuleFor(id => id.Value).NotEmpty();
        }
    }
}
