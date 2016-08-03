using Derek.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Derek.Web.Services
{
    public class TemplateService : BaseService, ITemplateService
    {
        private string GetTemplateFiles(string templatePath)
        {
            string messageHtml = File.ReadAllText(templatePath);
            return messageHtml;
        }

        public string GetTemplateContents(string templateName)
        {
            string templateContents = null;
            string templatePath = null;

            if (templateName == "sendmessage.html")
            {
                templatePath = HttpContext.Current.Server.MapPath("~/Scripts/sabio/ContactUs/SendMessage.html");
            }

            else if (templateName == "sendemailconfirmation.html")
            {
                templatePath = HttpContext.Current.Server.MapPath("~/Scripts/sabio/ContactUs/SendEmailConfirmation.html");
            }

            else
            {
                templatePath = HttpContext.Current.Server.MapPath("~/Scripts/sabio/ContactUs/PasswordResetToken.html");
            }
            templateContents = GetTemplateFiles(templatePath);
            return templateContents;
        }
    }
}