using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouchApp.Business.ExternalServices.Mail
{
    public class SendGridMailRequest
    {
        public string ToEmail { get; set; }
        public string FromEmail { get; set; }
        public string ToName { get; set; }
        public string FromName { get; set; }
        public string BodyJson { get; set; }
    }
}
