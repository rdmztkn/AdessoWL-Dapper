using AdessoWL.Domain.Constants;
using AdessoWL.Domain.Entities;
using FluentValidation;
using System.Drawing;

namespace AdessoWL.Application.Validations.Common
{
    public static class TeamRules
    {
        public static IRuleBuilderOptions<T, string> CheckTeamName<T>(this IRuleBuilder<T, string> ruleBuilder) where T: Team
        {
            return ruleBuilder
                .NotEmpty().WithMessage(ValidationMessages.Team_Name_Length_Error)
                .MinimumLength(3).WithMessage(ValidationMessages.Team_Name_Length_Error)
                .MaximumLength(70).WithMessage(ValidationMessages.Team_Name_Length_Error);

        }

        public static IRuleBuilderOptions<T, int> CheckTeamCountryId<T>(this IRuleBuilder<T, int> ruleBuilder) where T : Team
        {
            return ruleBuilder
                .NotEmpty().WithMessage(ValidationMessages.Team_Country_Id_Cannot_Be_Empty)
                .GreaterThan(0).WithMessage(ValidationMessages.Team_Country_Id_Cannot_Be_Empty);

        }
    }
}
