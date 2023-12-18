using AdessoWL.Application.Validations.Common;
using AdessoWL.Domain.Entities;
using FluentValidation;

namespace AdessoWL.Application.Validations.Delete
{
    public class DeleteTeamValidator : AbstractValidator<Team>
    {
        public DeleteTeamValidator()
        {
            RuleFor(p => p.Id).CheckIdentifierNumber();
        }
    }
}
