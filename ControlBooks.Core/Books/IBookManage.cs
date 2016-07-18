using System;
using System.Threading.Tasks;
using Abp.Domain.Services;


namespace ControlBooks.Books
{
    public interface IBookManage : IDomainService
    {

            Task<Book> Create(Book input);
            Task<Book> Update(Book input);

            void Delete(Guid id);
    }
}