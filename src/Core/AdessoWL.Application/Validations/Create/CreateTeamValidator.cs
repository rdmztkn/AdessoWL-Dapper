using AdessoWL.Application.Validations.Common;
using AdessoWL.Domain.Entities;
using FluentValidation;

namespace AdessoWL.Application.Validations.Create
{
    public class CreateTeamValidator : AbstractValidator<Team>
    {
        public CreateTeamValidator()
        {
            RuleFor(p => p.Name).CheckTeamName();
            RuleFor(p => p.CountryId).CheckTeamCountryId();
        }
    }
}
