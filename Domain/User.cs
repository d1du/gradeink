using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Derek.Web.Domain
{
    public class User : BaseUser
    {
        public int Period { get; set; }

        public string Email { get; set; }

    }
}