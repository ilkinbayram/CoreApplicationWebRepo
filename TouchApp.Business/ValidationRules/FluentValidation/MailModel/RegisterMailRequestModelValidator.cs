using Core.Extensions;
using FluentValidation;
using System.Reflection;
using TouchApp.Business.ExternalServices.Mail.ModelAcceptor;

namespace TouchApp.Business.ValidationRules.FluentValidation.MailModel
{
    public class RegisterMailRequestModelValidator : AbstractValidator<RegisterMailRequestModel>
    {
        public RegisterMailRequestModelValidator()
        {
            var givenGenericType = this.GetType().BaseType.GetGenericParameterConstraints()[0];
            var dictionary = ModelInfoExtensions.GetNameDictionary(givenGenericType);


            RuleFor(x => x.FromEmail).NotEmpty().WithMessage("MustNotBeEmptyRule.FluentValidationContraint".Translate(dictionary["FromEmail"]));
            RuleFor(x => x.Phone).NotEmpty().WithMessage("MustNotBeEmptyRule.FluentValidationContraint".Translate(dictionary["Phone"]));
            RuleFor(x => x.Name).NotEmpty().WithMessage("MustNotBeEmptyRule.FluentValidationContraint".Translate(dictionary["Name"]));
            RuleFor(x => x.Message).NotEmpty().WithMessage("MustNotBeEmptyRule.FluentValidationContraint".Translate(dictionary["Message"]));
        }
    }
}
