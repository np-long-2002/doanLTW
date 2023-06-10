﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Doan.Indentity
{
    public class AppUser : IdentityUser 
    {
        public DateTime? Birthday { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
    }
}