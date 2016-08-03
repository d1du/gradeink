using Derek.Web.Models.Messaging;
using Derek.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI.WebControls;

namespace Derek.Web.Services
{//rapidrentrqst is messagerequest
    public class MessagingService : BaseService
    {
        private readonly ITemplateService _templateService;

        public MessagingService(ITemplateService templateService)
        {
            _templateService = templateService;
        }

        private static string sendGridKey = ConfigurationManager.AppSettings["SendGridKey"];

        //public int Insert(MessagingAddRequests model, string userId)
        //{
        //    int id = 0;

        //    DataProvider.ExecuteNonQuery(GetConnection, "dbo.Messaging_Insert"
        //       , inputParamMapper: delegate (SqlParameterCollection paramCollection)

        //       {
        //           paramCollection.AddWithValue("@UserId", userId);
        //           paramCollection.AddWithValue("@TypeId", model.Title);
        //           paramCollection.AddWithValue("@Name", model.Name);
        //           paramCollection.AddWithValue("@Email", model.Email);
        //           paramCollection.AddWithValue("@Message", model.Message);

        //           SqlParameter p = new SqlParameter("@Id", System.Data.SqlDbType.Int);
        //           p.Direction = System.Data.ParameterDirection.Output;

        //           paramCollection.Add(p);

        //       }, returnParameters: delegate (SqlParameterCollection param)

        //       {
        //           int.TryParse(param["@id"].Value.ToString(), out id);
        //       }
        //       );
        //    return id;
        //}

        //public int SendMessage(MessagingAddRequests model, string userId)
        //{
        //    MessageRequest message = new MessageRequest();

        //    int messageId = Insert(model, userId);

        //    MailDefinition md = new MailDefinition();

        //    string templateName = "sendmessage.html";

        //    message.From = model.Name + model.Email;

        //    message.Subject = "Inquiry Type: " + model.Title;

        //    message.To = model.Email;

        //    string templateContent = _templateService.GetTemplateContents(templateName);

        //    string replaceHtml = templateContent.Replace("model.Email", model.Email).Replace("model.Name", model.Name).Replace("model.Message", model.Message);

        //    message.Html = replaceHtml;

        //    createMessage(message);

        //    return messageId;
        //}

        //public void SendEmailConfirmation(string Email, string callbackUrl)
        //{
        //    MessageRequest message = new MessageRequest();

        //    string templateName = "sendemailconfirmation.html";

        //    message.From = "support@RapidRents.dev";

        //    message.Subject = "Confirm your Account";

        //    message.To = Email;

        //    string templateContent = _templateService.GetTemplateContents(templateName);

        //    string replaceConfirm = templateContent.Replace("callBackURL", callbackUrl);

        //    message.Html = replaceConfirm;

        //    createMessage(message);

        //}

        //public void PasswordResetToken(string Email, string callbackUrl)
        //{
        //    MessageRequest message = new MessageRequest();

        //    string templateName = "passwordresettoken.html";

        //    message.From = "support@RapidRents.la";

        //    message.Subject = "Password Reset";

        //    message.To = Email;

        //    string templateContent = _templateService.GetTemplateContents(templateName);

        //    string replacePswrdToken = templateContent.Replace("callBackUrl", callbackUrl);

        //    message.Html = replacePswrdToken;

        //    createMessage(message);
        //}


        //private void createMessage(MessageRequest message)
        //{
        //    SendGridMessage myMessage = new SendGridMessage();

        //    myMessage.From = new MailAddress(message.From);

        //    myMessage.AddTo(message.To);

        //    myMessage.Subject = message.Subject;

        //    myMessage.Html = message.Html;

        //    var transportWeb = new SendGrid.Web(sendGridKey);

        //    transportWeb.DeliverAsync(myMessage);
        //}

    }
}