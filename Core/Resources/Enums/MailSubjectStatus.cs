using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Resources.Enums
{
    public enum MailSubjectStatus
    {
        AccountConfirmationMail = 1,
        ChangePasswordRequest = 2,
        DeleteAccountRequest = 3,
        InformAboutDeletedAccount = 4,
        AccountCreatedByAdmin = 5,
        OrderFileUpload = 6,
        OrderGiftCompleted = 7
    }
}
