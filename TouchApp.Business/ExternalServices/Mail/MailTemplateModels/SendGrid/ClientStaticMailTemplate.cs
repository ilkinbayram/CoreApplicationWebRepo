using Newtonsoft.Json;

namespace TouchApp.Business.ExternalServices.Mail.MailTemplateModels.SendGrid
{
    public class ClientStaticMailTemplate
    {
        public ClientStaticMailTemplate()
        {
            Client_Subject = "";
            Client_Email = "";
            Client_Full_Name = "";
            Client_Just_Name = "";
            Client_Just_Surname = "";
            Client_Gender = "";
            Client_Age = "";
            Client_Birthdate = "";
            Client_Description = "";
            Client_Phone = "";
            Client_Address = "";
            Client_Selected_Course_Id = "";
            Client_Selected_Course_Name = "";
            Client_Selected_Group_Id = "";
            Client_Selected_Group_Name = "";
            Client_Language_Id = "";
        }

        [JsonProperty("Client_Subject")]
        public string Client_Subject { get; set; }

        [JsonProperty("Client_Email")]
        public string Client_Email { get; set; }

        [JsonProperty("Client_Full_Name")]
        public string Client_Full_Name { get; set; }

        [JsonProperty("Client_Just_Name")]
        public string Client_Just_Name { get; set; }

        [JsonProperty("Client_Just_Surname")]
        public string Client_Just_Surname { get; set; }

        [JsonProperty("Client_Gender")]
        public string Client_Gender { get; set; }

        [JsonProperty("Client_Age")]
        public string Client_Age { get; set; }

        [JsonProperty("Client_BirthdateEmail")]
        public string Client_Birthdate { get; set; }

        [JsonProperty("Client_Description")]
        public string Client_Description { get; set; }

        [JsonProperty("Client_Phone")]
        public string Client_Phone { get; set; }

        [JsonProperty("Client_Address")]
        public string Client_Address { get; set; }

        [JsonProperty("Client_Selected_Course_Id")]
        public string Client_Selected_Course_Id { get; set; }

        [JsonProperty("Client_Selected_Course_Name")]
        public string Client_Selected_Course_Name { get; set; }

        [JsonProperty("Client_Selected_Group_Id")]
        public string Client_Selected_Group_Id { get; set; }

        [JsonProperty("Client_Selected_Group_Name")]
        public string Client_Selected_Group_Name { get; set; }

        [JsonProperty("Client_Language_Id")]
        public string Client_Language_Id { get; set; }
    }
}
