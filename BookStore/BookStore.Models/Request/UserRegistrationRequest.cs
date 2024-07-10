namespace BookStore.Models.Request
{
    public class UserRegistrationRequest
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
    }
}
