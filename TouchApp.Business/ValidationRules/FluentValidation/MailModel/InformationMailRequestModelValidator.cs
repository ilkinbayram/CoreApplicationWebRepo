using Core.Extensions;
using FluentValidation;
using TouchApp.Business.ExternalServices.Mail.ModelAcceptor;

namespace TouchApp.Business.ValidationRules.FluentValidation.MailModel
{
    public class InformationMailRequestModelValidator : AbstractValidator<InformationMailRequestModel>
    {
        public InformationMailRequestModelValidator()
        {
            var givenGenericType = this.GetType().BaseType.GetGenericParameterConstraints()[0];
            var dictionary = ModelInfoExtensions.GetNameDictionary(givenGenericType);


            RuleFor(x => x.FromEmail).NotEmpty().WithMessage("MustNotBeEmptyRule.FluentValidationContraint".Translate(dictionary["FromEmail"]));
            RuleFor(x => x.Subject).NotEmpty().WithMessage("MustNotBeEmptyRule.FluentValidationContraint".Translate(dictionary["Subject"]));
            RuleFor(x => x.Name).NotEmpty().WithMessage("MustNotBeEmptyRule.FluentValidationContraint".Translate(dictionary["Name"]));
            RuleFor(x => x.Message).NotEmpty().WithMessage("MustNotBeEmptyRule.FluentValidationContraint".Translate(dictionary["Message"]));
        }
    }
}
