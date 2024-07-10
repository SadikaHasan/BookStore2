using BookStore.BL.Interfaces;
using BookStore.DL.Interfaces;
using BookStore.Models.Models;

namespace BookStore.BL.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task AddBook(Book book)
        {
            await _bookRepository.AddBook(book);
        }

        public async Task<List<Book>> GetAll()
        {
           return await _bookRepository.GetAllBooks();
        }

        public async Task DeleteBook(Guid id)
        {
            await _bookRepository.DeleteBook(id);
        }

        public async Task<Book?> GetBookById(Guid id)
        {
            return await _bookRepository.GetBook(id);
        }

        public async Task UpdateBook(Book book)
        {
            await _bookRepository.UpdateBook(book);
        }

        public async Task<List<Book>> GetAllBooksByAuthorId(Guid authorId)
        {
            return await _bookRepository.GetAllBooksByAuthorId(authorId);
        }
    }
}
