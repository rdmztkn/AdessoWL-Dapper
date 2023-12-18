using AdessoWL.Application.Validations.Common;
using AdessoWL.Domain.Entities;
using FluentValidation;

namespace AdessoWL.Application.Validations.Delete
{
    public class DeleteCountryValidator : AbstractValidator<Country>
    {
        public DeleteCountryValidator()
        {
            RuleFor(p => p.Id).CheckIdentifierNumber();
        }
    }
}