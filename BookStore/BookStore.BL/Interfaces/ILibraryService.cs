using BookStore.Models.Request;
using BookStore.Models.Responses;

namespace BookStore.BL.Interfaces
{
    public interface ILibraryService
    {
        Task<GetBooksByAuthorResponse?>
            GetBooksByAuthor(GetBooksByAuthorRequest request);
    }
}
