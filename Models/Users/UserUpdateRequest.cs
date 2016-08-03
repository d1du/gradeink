using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Derek.Web.Models.Users
{
    public class UserUpdateRequest : UserAddRequest
    {
        public int Id { get; set; }
    }
}