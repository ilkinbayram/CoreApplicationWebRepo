using Core.Entities.Dtos.User;
using FluentValidation;


namespace Business.ValidationRules.FluentValidation.User
{
    public class UpdateUserLanguageDtoValidator : AbstractValidator<UpdateUserLanguageDto>
    {
        public UpdateUserLanguageDtoValidator()
        {
            RuleFor(a => a.Id).NotNull().WithMessage("UserLanguageId boş ola bilməz");
            RuleFor(a => a.Description).NotNull().WithMessage("Description boş ola bilməz");
            RuleFor(a => a.LanguageId).NotNull().WithMessage("LanguageId boş ola bilməz");
        }
    }
}
