using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ControlBooks.Books.Dtos;

namespace ControlBooks.Books
{
    public interface IBookAppService : IApplicationService
    {
        Task<Book> InsertNewBook(BookDto input);
        BookDto UpdateBookDto(BookDto input);
        void DeleteBook(string input);
        Task<ListResultOutput<BookDto>> GetAllBook();
        BookDto GetDetail(string input);
    }
}