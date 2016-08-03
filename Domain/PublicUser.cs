using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Derek.Web.Domain
{
    public class PublicUser
    {
        public PublicUser(IdentityUser user)
        {
            this.UserName = user.UserName;
            this.Email = user.Email;
            this.Id = user.Id;
        }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Id { get; set; }
    }
}