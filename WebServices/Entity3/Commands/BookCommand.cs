using WebService1.Entity3.Models;
using WebService1.Entity3.Repositories;
using System.Collections.Generic;
using WebService1.Entity3.Mappers;

namespace WebService1.Entity3.Commands
{
    public class BookCommand : IBookCommand
    {
        private readonly IBookRepository _repos;
        private readonly IBookMapper _map;

        public BookCommand(IBookRepository repos, IBookMapper map)
        {
            _repos = repos;
            _map = map;
        }

        public Book Get(int id)
        {
            Book book = _map.GetBook(id);
            return book;
        }
        
        public IEnumerable<Book> GetAll()
        {
            List<Book> books = _map.GetAllBooks();
            return books;
        }

        public void Post(Book book)
        {
            _repos.Post(book);
        }

        public void Put(Book book)
        {
            _repos.Put(book);
        }

        public void Delete(int id)
        {
            _repos.Delete(id);
        }
    }
}
