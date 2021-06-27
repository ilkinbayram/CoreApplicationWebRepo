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
        }

        private bool CannotBeZero(int? parentCategoryId)
        {
            return parentCategoryId != 0;
        }
    }
}
