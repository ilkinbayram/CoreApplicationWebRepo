using Newtonsoft.Json;

namespace TouchApp.Business.ExternalServices.Mail.MailTemplateModels.SendGrid
{
    public class QuickRegisterMailTemplate
    {
        public QuickRegisterMailTemplate()
        {
            Welcome_Quick_Register = "";
            Less_Contact_Description = "";
            Below_Link_Define = "";
            Link_To_Telegram_Localize = "";
            Link_To_Whatsapp_Localize = "";
            Subject_Mail = "";
        }

        [JsonProperty("Welcome_Quick_Register")]
        public string Welcome_Quick_Register { get; set; }

        [JsonProperty("Less_Contact_Description")]
        public string Less_Contact_Description { get; set; }

        [JsonProperty("Below_Link_Define")]
        public string Below_Link_Define { get; set; }

        [JsonProperty("Link_To_Telegram_Localize")]
        public string Link_To_Telegram_Localize { get; set; }

        [JsonProperty("Link_To_Whatsapp_Localize")]
        public string Link_To_Whatsapp_Localize { get; set; }

        [JsonProperty("Subject_Mail")]
        public string Subject_Mail { get; set; }
    }
}
