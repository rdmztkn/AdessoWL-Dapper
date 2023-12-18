using AdessoWL.Domain.Constants;
using AdessoWL.Domain.Entities;
using FluentValidation;

namespace AdessoWL.Application.Validations.Common
{
    public static class CountriesRules
    {

        public static IRuleBuilderOptions<T, string> CheckCountryName<T>(this IRuleBuilder<T, string> ruleBuilder) where T : Country
        {
            return ruleBuilder
                .NotEmpty().WithMessage(ValidationMessages.Country_Name_Length_Error)
                .MinimumLength(0).WithMessage(ValidationMessages.Country_Name_Length_Error)
                .MaximumLength(30).WithMessage(ValidationMessages.Country_Name_Length_Error);
        }

        //ICountryRepository countryRepository

    }
}
