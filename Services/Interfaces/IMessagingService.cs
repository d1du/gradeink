using Derek.Web.Models.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Derek.Web.Services.Interfaces
{
    public interface IMessagingService
    {
        int Insert(MessagingAddRequests model, string userId);
        int SendMessage(MessagingAddRequests model, string userId);
        void SendEmailConfirmation(string email, string callbackURL);
        void PasswordResetToken(string Email, string callbackURL);
        void createMtRqstMessage(int AddressId, MessagingAddRequests model);
    }
}