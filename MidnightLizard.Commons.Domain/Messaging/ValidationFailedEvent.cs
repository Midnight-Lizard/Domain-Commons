using FluentValidation.Results;
using MidnightLizard.Commons.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MidnightLizard.Commons.Domain.Messaging
{
    public abstract class ValidationFailedEvent<TAggregateId> : DomainEvent<TAggregateId>
        where TAggregateId : DomainEntityId
    {
        public List<(string PropertyName, string ErrorMessage)> ValidationErrors { get; private set; }

        protected ValidationFailedEvent() { }

        public ValidationFailedEvent(TAggregateId aggregateId, ValidationResult validationResult) : base(aggregateId)
        {
            ValidationErrors = validationResult.Errors.Select(e => (e.PropertyName, e.ErrorMessage)).ToList();
        }
    }
}
