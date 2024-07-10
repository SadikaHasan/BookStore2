using BookStore.Models.Models;

namespace BookStore.BL.Interfaces
{
    public interface IBookService
    {
         Task<List<Book>> GetAllBooksByAuthorId(Guid authorId);

         Task AddBook(Book book);

         Task<List<Book>> GetAll();

         Task DeleteBook(Guid id);

         Task<Book?> GetBookById(Guid id);

         Task UpdateBook(Book book);
    }
}
