using AdessoWL.Application.Validations.Common;
using AdessoWL.Domain.Entities;
using FluentValidation;

namespace AdessoWL.Application.Validations.Create
{
    public class CreateCountryValidator:AbstractValidator<Country>
    {
        public CreateCountryValidator()
        {
            RuleFor(p => p.Name).CheckCountryName();
        }
    }
}
