using Core.Entities.Dtos.Slider;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation.Slider
{
    public class EditSliderDtoValidator : AbstractValidator<EditSliderDto>
    {
        public EditSliderDtoValidator()
        {

        }
    }
}
