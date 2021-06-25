using Core.Resources.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ExternalServices.Mail
{
    public class MailUtilityHelper
    {
        public static string GetMailSubject(MailSubjectStatus status)
        {
            string result = null;
            switch (status)
            {
                case MailSubjectStatus.AccountConfirmationMail:
                    result = "Account Confirmation By Email";
                    break;
                case MailSubjectStatus.ChangePasswordRequest:
                    result = "Change Your Password By Email";
                    break;
                case MailSubjectStatus.DeleteAccountRequest:
                    result = "Do You Want To Delete Your Account Permanently ?";
                    break;
                case MailSubjectStatus.InformAboutDeletedAccount:
                    result = "Your Account Is Deleted By Administration";
                    break;
                case MailSubjectStatus.AccountCreatedByAdmin:
                    result = "Your Account Created By Admin";
                    break;
                case MailSubjectStatus.OrderFileUpload:
                    result = "Order File Upload";
                    break;
                case MailSubjectStatus.OrderGiftCompleted:
                    result = "Order Completed!";
                    break;
                default:
                    break;
            }
            return result;
        }
    }
}
