using Core.Entities.Dtos.Slider;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation.Slider
{
    public class CreateSliderDtoValidator : AbstractValidator<CreateManagementSliderDto>
    {
        public CreateSliderDtoValidator()
        {
            RuleFor(x => x.TitleKey).NotEmpty().WithMessage("Order bos ola bilmez");
            RuleFor(x => x.SliderMediaSource).NotEmpty().WithMessage("SliderMediaSource bos ola bilmez");
        }
    }
}
