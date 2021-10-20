using System.ComponentModel;

namespace TouchApp.Business.ExternalServices.Mail.ModelAcceptor
{
    public class QuickRegisterMailRequestModel
    {
        [DisplayName("FromEmail_MailProp.Localization")]
        public string FromEmail { get; set; }

        public short Lang_oid { get; set; }
    }
}
