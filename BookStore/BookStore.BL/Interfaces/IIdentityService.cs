using BookStore.Models.Responses;

namespace BookStore.BL.Interfaces
{
    public interface IIdentityService
    {
        Task<AuthenticationResult>
            RegisterAsync(string userName, string password, string email);

        Task<AuthenticationResult>
           LoginAsync(string userName, string password);

        Task LogOff();
    }
}
