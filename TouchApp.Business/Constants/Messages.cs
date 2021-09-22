namespace Business.Constants
{
    public static class Messages
    {
        // TODO : Messages

        public static string ProductAdded = "Ürün başarıyla eklendi";
        public static string ProductDeleted = "Ürün başarıyla silindi";
        public static string ProductUpdated = "Ürün başarıyla güncellendi";
        public static string BusinessDataWasNotFOUND = "Data was not found";

        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError="Şifre hatalı";
        public static string SuccessfulLogin="Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated="Access token başarıyla oluşturuldu";

        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string ProductNameAlreadyExists = "Ürün ismi zaten mevcut";

        public static string NotUserRegistered = "Qeydiyyatdan kecirilmedi";

        public static string BusinessDataAdded = "Data Added";
        public static string BusinessDataWasNotAdded = "Data Was Not Added";
        public static string BusinessDataUpdated = "Data Updated";
        public static string BusinessDataWasNotUpdated = "Data Was Not Updated";
        public static string BusinessDataDeleted = "Data Deleted";
        public static string BusinessDataWasNotDeleted = "Data Was Not Deleted";

        public static string AgreeWithTheConditions = "Please Accept The Terms & Conditions"; 

        public static string DeletableDataWasNotFound = "Deletable data was not detected!";

        public static string FeatureNotExist = "Feature you are looking for does not exist";

        public static string MailConfirmationBody = "Please Click and Confirm Your Registration By Link. Your Link: {0}";
        public static string MailOrderRequestBody = "Hi, Dear {0}! Please Read The Description and create a gift: *Description: {1}*. Mail Creator is : *{3} {4}*. Requirement From You: *{5}*. If you are ready, Please Click the link and go to the file upload page. Your Link: {2}";
        public static string MailOrderReadyBody = "Hi, Dear {1} {2}! Congratulations! Your Gift File Completed! Link: {0}";
        public static string MailPasswordRecoverBody = "Please Click and Go To The Password Changing Page. Your Link: {0}";

        public static string PasswordRecoveryWasFailed = "Password Recovery Was Failed";

        public static string URL_Container_RegisterConfirm = "{0}?token={1}&expirationMinute={2}";
        public static string URL_Container_File_Upload_Redirect = "{0}?token={1}";
        public static string URL_Container_RecoverPassword = "{0}?token={1}&expirationMinute={2}";


        public static string AdminCreatedUserMailMessage = "Congratulations! Your MVP Account Created By Admin. This mail is your login email. Your Password is: {0}";

        public static string NotSentEmailPassword = "Not sent to email password but user created";

        public static class ErrorMessages
        {
            public static string CallbackUrlIsRequired = "Callback url is required";
            public static string InvalidCallbackUrl = "Please send valid url as CallbackUrl";
            public static string SearchValueCannotBeEmpty = "Search value can not be empty";
            public static string UserIdCannotBeNull = "User id can not be null or its default value";
            public static string CategoryIdCannotBeNull = "Category id can not be null or its default value";

            public static string NOT_ADDED_AND_ROLLED_BACK => "DataAddOperationRolledBackNotCompleted.LocalizationError";
        }

        public static class WarningMessages
        {
            public static string NOT_SUPPORTED_FileContentType => "NotSupportedFileContentType.LocalizationWarning";
        }
    }
}
