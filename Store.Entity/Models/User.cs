﻿using System;

namespace Store.Domain.Models
{
   public class User 
    {

        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string Name { get; set;}
        public string PasswordHash { get; set; }
        public  DateTimeOffset DatedJoined { get; set; }
    }
}
