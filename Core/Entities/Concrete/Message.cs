using Core.Entities.Concrete.Base;
using Core.Resources.Enums;




namespace Core.Entities.Concrete
{
    public class Message : BaseEntity, IEntity
    {
        public Message()
        {
            ModelType = ProjectModelType.Message;
        }

        public long MessageCode { get; set; }
    }
}
