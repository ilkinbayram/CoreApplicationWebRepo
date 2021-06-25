using Core.Entities.Dtos.Home;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation.Home
{
    public class CreateHomeMetaTagLanguageDtoValidator : AbstractValidator<CreateHomeMetaTagLangDto>
    {
        public CreateHomeMetaTagLanguageDtoValidator()
        {
            RuleFor(x => x.LanguageId).NotEmpty().WithMessage("LanguageID Bos Ola Bilmez");
            RuleFor(x => x.MetaTitle).NotEmpty().WithMessage("MetaTitle : Basliq Bos Ola Bilmez");
            RuleFor(x => x.MetaDescription).MaximumLength(4000).WithMessage("Description Maximum 4000 simvol olmalidir");
        }
    }
}
