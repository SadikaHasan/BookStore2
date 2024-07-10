using AspNetCore.Identity.MongoDbCore.Models;

namespace BookStore.Models.Models.Users
{
    public class IdentityUser : MongoIdentityUser<Guid>
    {
        public IdentityUser()
        {
            
        }

        public IdentityUser(string userName, string password) : base(userName, password)
        {
            
        }
        public string AuthorId { get; set; } = String.Empty;
    }
}
