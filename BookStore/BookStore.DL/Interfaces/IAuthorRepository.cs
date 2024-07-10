using BookStore.Models.Models.Users;

namespace BookStore.DL.Interfaces
{
    public interface IAuthorRepository
    {
        Task<List<Author>> GetAll();

        Task<Author> GetById(int id);

        Task Add(Author author);

        Task Remove(int  id);
    }
}
