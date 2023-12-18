using AdessoWL.Application.Validations.Common;
using AdessoWL.Domain.Entities;
using FluentValidation;

namespace AdessoWL.Application.Validations.Update
{
    public class UpdateCountryValidator : AbstractValidator<Country>
    {
        public UpdateCountryValidator()
        {
            RuleFor(p => p.Id).CheckIdentifierNumber();
            RuleFor(p => p.Name).CheckCountryName();
        }
    }
}
