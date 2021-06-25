using Core.Entities.Dtos.Home;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation.Home
{
    public class CreateHomeMetaTagGalleryDtoValidator : AbstractValidator<CreateHomeMetaTagGalleryDto>
    {
        public CreateHomeMetaTagGalleryDtoValidator()
        {
            RuleFor(x => x.Order).NotEmpty().WithMessage("Order bos ola bilmez");
        }
    }
}
