using Core.Entities.Dtos.User;
using FluentValidation;
using FluentValidation.Validators;

namespace Business.ValidationRules.FluentValidation.User
{
    public class CreateUserValidator : AbstractValidator<CreateManagementUserDto>
    {
        public CreateUserValidator()
        {
          
            RuleFor(p => p.FirstName).NotEmpty().WithMessage("Ad bos ola bilmez");
            RuleFor(p => p.LastName).NotEmpty().WithMessage("Soyad bos ola bilmez");
            RuleFor(p => p.PhoneNumberPrefix).NotEmpty().WithMessage("Telefon standarti bos ola bilmez");
            RuleFor(a => a.PhoneNumber).MinimumLength(9).WithMessage("telefon minimum 9 xarakter ola bilər").MaximumLength(30).WithMessage("telefon maksimum 30 xarakter ola bilər");
            RuleFor(a => a.Email).EmailAddress(EmailValidationMode.AspNetCoreCompatible).WithMessage("Duzgun bir email yazin");
            RuleFor(p => p.ProfilePhotoPath).NotEmpty().WithMessage("Profile sekli bos ola bilmez");
            RuleFor(p => p.WallpaperPath).NotEmpty().WithMessage("Wallpaper  sekli bos ola bilmez");
        }
    }
}
