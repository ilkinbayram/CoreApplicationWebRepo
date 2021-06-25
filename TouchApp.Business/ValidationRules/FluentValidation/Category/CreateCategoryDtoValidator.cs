using Business.Constants;
using Core.Entities.Dtos.Category;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation.Category
{
    public class CreateCategoryDtoValidator : AbstractValidator<CreateCategoryDto>
    {
        /// <summary>
        /// kateqriya yoxlanış modeli
        /// </summary>
        public CreateCategoryDtoValidator()
        {
            RuleFor(a => a.CategoryLanguages).NotEmpty().WithMessage("CategoryLangs boş olmamalıdır");
            RuleFor(a => a.ParentCategoryId).Must(CannotBeZero).WithMessage(ValidationMessages.ParentCategoryIdCannotBeZero);
            RuleForEach(x => x.CategoryLanguages).SetValidator(new CreateCategoryLangDtoValidator());
            RuleForEach(x => x.CategoryFeatures).SetValidator(new CreateCategoryFeaturedDtoValidator());
        }

        private bool CannotBeZero(int? parentCategoryId)
        {
            return parentCategoryId != 0;
        }
    }
}
