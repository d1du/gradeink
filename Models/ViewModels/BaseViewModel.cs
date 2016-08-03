using Derek.Web.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Derek.Web.Models.ViewModels
{
    public class BaseViewModel
    {
        public bool IsLoggedIn { get; set; }
        public string BaseUrl { get; set; }
        public string SiteDomain { get; set; }
        public bool IsAdmin { get; set; }
        public PublicUser CurrentUser { get; set; }
    }
}