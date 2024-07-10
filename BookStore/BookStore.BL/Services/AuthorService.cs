using BookStore.BL.Interfaces;
using BookStore.DL.Interfaces;
using BookStore.Models.Models.Users;

namespace BookStore.BL.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<List<Author>> GetAll()
        {
            return await _authorRepository.GetAll();
        }

        public async Task<Author> GetById(int id)
        {
            return await _authorRepository.GetById(id);
        }

        public async Task Add(Author author)
        {
            await _authorRepository.Add(author);
        }

        public async Task Remove(int id)
        {
            await _authorRepository.Remove(id);
        }
    }
}
