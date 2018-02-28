using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using MidnightLizard.Testing.Utilities;
using System.Threading.Tasks;

namespace MidnightLizard.Commons.Domain.Model
{
    public class DomainEntityIdSpec
    {
        public class ValidatorSpec : DomainEntityIdSpec
        {
            private readonly DomainEntityIdValidator<Guid> guidValidator = new DomainEntityIdValidator<Guid>();

            [It(nameof(DomainEntityIdValidator<Guid>))]
            public void Should_fail_when_value_is_default()
            {
                var defaultGuid = new DomainEntityId<Guid>(default);
                guidValidator.ShouldHaveValidationErrorFor(x => x.Value, defaultGuid);
            }
        }
    }
}
