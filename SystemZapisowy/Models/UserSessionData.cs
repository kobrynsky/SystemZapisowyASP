using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SystemZapisowy.Models
{
    public class UserSessionData
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
    }
}