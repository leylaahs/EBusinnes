﻿using Microsoft.AspNetCore.Identity;

namespace E_business.Models
{
    public class Appuser:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
