namespace BookStore.Models.Responses
{
    public class AuthenticationResult
    {
        public string Token { get; set; }

        public bool IsSuccess { get; set; }

        public IEnumerable<string> Errors { get; set; }
    }
}
