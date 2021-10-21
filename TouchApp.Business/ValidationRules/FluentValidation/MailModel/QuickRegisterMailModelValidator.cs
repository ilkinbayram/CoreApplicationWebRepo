using Core.Extensions;
using FluentValidation;
using TouchApp.Business.ExternalServices.Mail.ModelAcceptor;

namespace TouchApp.Business.ValidationRules.FluentValidation.MailModel
{
    public class QuickRegisterMailModelValidator : AbstractValidator<QuickRegisterMailRequestModel>
    {
        public QuickRegisterMailModelValidator()
        {
            var givenGenericType = this.GetType().BaseType.GetGenericArguments()[0];
            var dictionary = ModelInfoExtensions.GetNameDictionary(givenGenericType);

            RuleFor(x => x.FromEmail).NotEmpty().WithMessage("MustNotBeEmptyRule.FluentValidationContraint".Translate(dictionary["FromEmail"])).EmailAddress().WithMessage("EmailConstraintValidation.NotSupportedEmailLocalization".Translate());
        }
    }
}
