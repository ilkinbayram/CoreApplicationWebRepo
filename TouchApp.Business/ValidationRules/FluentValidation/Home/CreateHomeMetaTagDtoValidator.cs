using Core.Entities.Dtos.Home;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation.Home
{
    public class CreateHomeMetaTagDtoValidator : AbstractValidator<CreateHomeMetaTagDto>
    {
        public CreateHomeMetaTagDtoValidator()
        {
            RuleFor(x => x.HomeMetaTagLanguages).NotEmpty().WithMessage("Meta Tag Langs Bos olmamalidir");
            RuleForEach(x => x.HomeMetaTagLanguages).SetValidator(new CreateHomeMetaTagLanguageDtoValidator());
            RuleForEach(x => x.HomeMetaTagGalleries).SetValidator(new CreateHomeMetaTagGalleryDtoValidator());
        }
    }
}
