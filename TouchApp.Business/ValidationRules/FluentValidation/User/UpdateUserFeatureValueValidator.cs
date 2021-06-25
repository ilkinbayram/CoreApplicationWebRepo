using Core.Entities.Dtos.User;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation.User
{
    public class UpdateUserFeatureValueValidator : AbstractValidator<UpdateUserFeatureValue>
    {
        public UpdateUserFeatureValueValidator()
        {
            RuleFor(p => p.CategoryFeatureId).NotEmpty().WithMessage("CategoryFeatureId bos ola bilmez");
            RuleFor(p => p.FeatureValueId).NotEmpty().WithMessage("FeatureValueId bos ola bilmez");
        }
    }
}
