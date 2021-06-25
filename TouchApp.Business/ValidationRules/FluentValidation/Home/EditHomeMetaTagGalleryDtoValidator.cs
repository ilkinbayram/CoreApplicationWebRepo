using Core.Entities.Dtos.Home;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation.Home
{
    public class EditHomeMetaTagGalleryDtoValidator : AbstractValidator<EditHomeMetaTagGalleryDto>
    {
        public EditHomeMetaTagGalleryDtoValidator()
        {

        }
    }
}
