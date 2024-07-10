using BookStore.Models.Models;
using BookStore.Models.Models.Users;

namespace BookStore.DL.InMemoryDb
{
    public static class StaticData
    {
        public static Dictionary<Guid, Book> KafkaBooks = new Dictionary<Guid, Book>();  
        public static List<Book> Books = new List<Book>()
        {
            new Book()
            {
                Id = Guid.NewGuid(),
                Title = "Book 1",
                AuthorId = Guid.NewGuid(),
                ReleaseDate = new DateTime(2011, 01,11)
            },
            new Book()
            {
                Id = Guid.NewGuid(),
                Title = "Book 2",
                AuthorId = Guid.NewGuid(),
                ReleaseDate = new DateTime(2014, 04,14)
            },
            new Book()
            {
                Id = Guid.NewGuid(),
                Title = "Book 3",
                AuthorId = Guid.NewGuid(),
                ReleaseDate = new DateTime(2012, 02,12)
            },
            new Book()
            {
                Id = 4,
                Title = "Book 4",
                AuthorId = 4,
                ReleaseDate = new DateTime(2013, 03,13)
            }
        };

        public static List<Author> AuthorsData = new List<Author>()
        {
            new Author()
            {
                Id = 1,
                Name = "Name 1",
                BirthDay = DateTime.Now
            },
            new Author()
            {
                Id = 2,
                Name = "Name 2",
                BirthDay = DateTime.Now
            },
            new Author()
            {
                Id = 3,
                Name = "Name 3",
                BirthDay = DateTime.Now
            },
        };
    }
}