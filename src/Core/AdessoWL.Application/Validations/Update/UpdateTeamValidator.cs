using AdessoWL.Application.Validations.Common;
using AdessoWL.Domain.Entities;
using FluentValidation;

namespace AdessoWL.Application.Validations.Update
{
    public class UpdateTeamValidator : AbstractValidator<Team>
    {
        public UpdateTeamValidator()
        {
            RuleFor(p => p.Id).CheckIdentifierNumber();
            RuleFor(p => p.Name).CheckTeamName();
        }
    }
}
