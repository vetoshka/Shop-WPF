namespace Store.Domain.Models
{
    public class User : DomainObject
    {

        public string Email { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public bool IsAdministrator { get; set; }

    }
}
