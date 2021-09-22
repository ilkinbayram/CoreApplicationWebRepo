using Core.Entities.Concrete.Base;
using Core.Resources.Enums;



namespace Core.Entities.Concrete
{
    public class Localization : BaseEntity, IEntity
    {
        public Localization()
        {
            ModelType = ProjectModelType.Localization;
        }

        public string Key { get; set; }
        public string Translate { get; set; }
        public short Project_oid { get; set; }
        public short Lang_oid { get; set; }
    }
}
