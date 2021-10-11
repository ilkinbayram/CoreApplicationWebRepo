using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouchApp.Business.ExternalServices.Mail.MailTemplateModels.SendGrid
{
    public class WelcomeMailTemplate
    {
        [JsonProperty("Welcome_Message")]
        public string Welcome_Message { get; set; }

        [JsonProperty("Hello_Name")]
        public string Hello_Name { get; set; }

        [JsonProperty("Information_After_Hello_List_Header")]
        public string Information_After_Hello_List_Header { get; set; }

        [JsonProperty("List1_Text")]
        public string List1_Text { get; set; }

        [JsonProperty("List2_Text")]
        public string List2_Text { get; set; }

        [JsonProperty("List3_Text")]
        public string List3_Text { get; set; }

        [JsonProperty("Last_Information")]
        public string Last_Information { get; set; }

        [JsonProperty("Best_Regards")]
        public string Best_Regards { get; set; }

        [JsonProperty("Message_By")]
        public string Message_By { get; set; }

        [JsonProperty("Go_To_Our_Website")]
        public string Go_To_Our_Website { get; set; }

        [JsonProperty("Link_Of_Navigation")]
        public string Link_Of_Navigation { get; set; }

        [JsonProperty("SubjectMail")]
        public string SubjectMail { get; set; }
    }
}

