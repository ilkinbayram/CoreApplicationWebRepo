using Core.Entities.Concrete.Base;
using Core.Resources.Enums;

namespace Core.Entities.Concrete
{
    public class QuestionVariation : BaseEntity, IEntity
    {
        public QuestionVariation()
        {
            ModelType = ProjectModelType.QuestionVariation;
        }

        public string VariationToken { get; set; }
        public string DefinitionKey { get; set; }
        public string OptionKey { get; set; }
        public bool IsTrue { get; set; }

        public long QuestionId { get; set; }

        public virtual Question Question { get; set; }
    }
}
