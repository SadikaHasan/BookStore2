using BookStore.DL.Interfaces;
using BookStore.Models.Configurations;
using BookStore.Models.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BookStore.DL.Repositories.Mongo
{
    public class BookMongoRepository : IBookRepository
    {
        private IOptions<MongoConfiguration> _mongoConfig;
        private readonly IMongoCollection<Book> _books;

        public BookMongoRepository(
            IOptions<MongoConfiguration> mongoConfig)
        {
            _mongoConfig = mongoConfig;

            var client =
                new MongoClient(mongoConfig.Value.ConnectionString);

            var db =
                client.GetDatabase(mongoConfig.Value.DatabaseName);

            _books = db.GetCollection<Book>("Books");
        }

        public async Task AddBook(Book book)
        {
            await _books.InsertOneAsync(book);
        }

        public async Task DeleteBook(Guid id)
        {
            await _books.DeleteOneAsync(b => 
                b.Id == id);
        }

        public async Task UpdateBook(Book book)
        {
            await _books.ReplaceOneAsync(b =>
                b.Id == book.Id, book);
        }

        public async Task<Book?> GetBook(Guid id)
        {
            var result =
                await _books.FindAsync(b => b.Id == id);

            return result.FirstOrDefault();
        }

        public async Task<List<Book>> GetAllBooks()
        {
           return await _books.
               Find(b => true).ToListAsync();
        }

        public async Task<List<Book>> GetAllBooksByAuthorId(Guid id)
        {
            return await _books
                .Find(b => b.AuthorId == id)
                .ToListAsync();
        }

        
    }
}
