using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Derek.Web.Services.Interfaces
{
    public interface ITemplateService
    {
        string GetTemplateContents(string templateName);
    }
}