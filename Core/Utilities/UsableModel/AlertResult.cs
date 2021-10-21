using Core.Resources.Enums;
using System.Collections.Generic;

namespace Core.Utilities.UsableModel
{
    public class AlertResult
    {
        public AlertResult()
        {
            AlertMessages = new List<string>();
        }

        public AlertStatus Status { get; set; }
        public bool IsComplexMessage { get; set; }
        public string AlertColor { get; set; }
        public List<string> AlertMessages { get; set; }
    }
}
