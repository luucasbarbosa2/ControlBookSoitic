using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using ControlBooks.Books;
using ControlBooks.Books.Dtos;

namespace ControlBooks.Books
{
    public class BookAppService : IBookAppService
    {
        private readonly IBookManage _bookManage;
        private readonly IRepository<Book, Guid> _bookRepository;
        private readonly IAbpSession _abpSession;

        public BookAppService(IBookManage bookManage, IRepository<Book, Guid> bookRepository, IAbpSession abpSession)
        {
            _bookManage = bookManage;
            _bookRepository = bookRepository;
            _abpSession = abpSession;
        }

        public Task<Book> InsertNewBook(BookDto input)
        {
            var book = Book.Create(
                input.Titulo,
                input.Subtitulo,
                input.Sinopse,
                input.Ano,
                input.Volume,
                input.AutorId,
                input.PublisherId,
                _abpSession.GetTenantId()
                );
            var bookResult = _bookManage.Create(book);
            return bookResult;
        }

        public BookDto UpdateBookDto(BookDto input)
        {
            var book = input.MapTo<Book>();
            var bookResult = _bookManage.Update(book);
            return bookResult.MapTo<BookDto>();
        }
    
        public void DeleteBook(string input)
        {
            var idGuid = Guid.Parse(input);
            _bookManage.Delete(idGuid);
        }

        public async Task<ListResultOutput<BookDto>> GetAllBook()
        {
            
            /*var query = "SELECT b.*, p.id, p.nome as publisherNome, a.nome as autorNome, a.sobrenome, a.idade FROM books b"+
                        "JOIN publisher p"+
                        "on b.publisher_Id = p.id"+
                        "JOIN autor a"+
                        "on b.autor_Id = a.id"+
                        "where b.isDeleted = 0 and p.isDeleted = 0 and a.isDeleted = 0";*/
            var result = await _bookRepository.GetAllListAsync();


            var list = new HashSet<BookDto>();
            foreach (var item in result)
            {
                list.AddIfNotContains(BookDto.MaptoDto(item));
            }

            return new ListResultOutput<BookDto>(list.ToList());
        }

        public BookDto GetDetail(string input)
        {
            var id = Guid.Parse(input);
            var result = _bookRepository.GetAll().FirstOrDefault(x => x.Id == id);

            return result.MapTo<BookDto>();
        }
    }
}