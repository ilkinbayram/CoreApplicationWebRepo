using Core.Resources.Enums;

namespace Core.Utilities.UsableModel
{
    public class AlertResult
    {
        public AlertStatus Status { get; set; }
        public string AlertColor { get; set; }
        public string AlertMessage { get; set; }
    }
}
