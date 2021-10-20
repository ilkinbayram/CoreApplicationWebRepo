using Core.Entities.Dtos.Slider;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation.Slider
{
    public class CreateSliderDtoValidator : AbstractValidator<CreateManagementSliderDto>
    {
        public CreateSliderDtoValidator()
        {
            RuleFor(x => x.MainTitleKey).NotEmpty().WithMessage("Order bos ola bilmez");
            RuleFor(x => x.SliderMediaSource).NotEmpty().WithMessage(x=>string.Format("", x.SliderMediaSource));
        }
    }
}
