using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MidnightLizard.Commons.Domain.Results
{
    public class DomainValidationResult : DomainResult
    {
        public ValidationResult ValidationResult { get; }

        public DomainValidationResult(ValidationResult validationResult)
        {
            ValidationResult = validationResult;
            if (this.HasError = !validationResult.IsValid)
            {
                this.ErrorMessage = string.Join("\n", validationResult.Errors.Select(err => err.ErrorMessage));
            }
        }

        public DomainValidationResult(string errorMessage) : base(errorMessage) { }

        public DomainValidationResult(Exception ex) : base(ex) { }

        public DomainValidationResult(bool hasError, Exception ex, string errorMessage)
            : base(hasError, ex, errorMessage) { }
    }
}
