using System;

namespace Store.Domain.Models
{
   public class User 
    {

        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string Name { get; set;}

    }
}
