using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Core.Entities.Dtos;
using FluentValidation;
using FluentValidation.Validators;
using Microsoft.AspNetCore.Http;

namespace Business.ValidationRules.FluentValidation
{
    public class UserRegisterValidator : AbstractValidator<UserForRegisterDto>
    {
        public UserRegisterValidator()
        {
            RuleFor(p => p.FirstName).NotEmpty().WithMessage("Ad bos ola bilmez");
            RuleFor(p => p.LastName).NotEmpty().WithMessage("Soyad bos ola bilmez");
            //RuleFor(p => p.PhoneNumberPrefix).NotEmpty().WithMessage("Telefon standarti bos ola bilmez");
            //RuleFor(a => a.PhoneNumber).MinimumLength(9).WithMessage("telefon minimum 12 xarakter ola bilər").MaximumLength(30).WithMessage("telefon maksimum 30 xarakter ola bilər");
            RuleFor(a => a.ConfirmPassword).NotNull().WithMessage("şifre boş olmamalıdır").NotEmpty().WithMessage("şifre boş olmamalıdır").MinimumLength(3).WithMessage("sifre minimum 3 simvol ola biler").MaximumLength(30).WithMessage("şifre maximum 30 xarakter ola bilər").Equal(x => x.Password).WithMessage("Sifre ve sifre tekrari eyni olmalidir.");
            RuleFor(a => a.Email).EmailAddress(EmailValidationMode.AspNetCoreCompatible).WithMessage("Duzgun bir email yazin");
            RuleFor(p => p.Birthday).NotEmpty();
            RuleFor(x => x.Password).NotEmpty().WithMessage("Sifre Bos Ola Bilmez").Equal(x => x.ConfirmPassword).WithMessage("Sifre ile Sifre Tekrar Bir birine Beraber olmalidir");
            RuleFor(a => a).Custom((model, context) =>
            {
                if (!model.IsAgree)
                {
                    context.AddFailure("Gizlilik sertleri ile razilasin.");
                }
            });

        }

        private bool StartWithWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}