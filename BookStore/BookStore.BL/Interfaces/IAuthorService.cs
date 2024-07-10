using BookStore.Models.Models.Users;

namespace BookStore.BL.Interfaces
{
    public interface IAuthorService
    {
        Task<List<Author>> GetAll();

        Task<Author> GetById(int id);

        Task Add(Author author);

        Task Remove(int id);
    }
}
