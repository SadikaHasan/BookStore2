using System.ComponentModel.DataAnnotations;

namespace BookStore.Models.Models
{
    public record Book
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public Guid AuthorId { get; set; }

        public DateTime ReleaseDate { get; set; }

       
    }
}
