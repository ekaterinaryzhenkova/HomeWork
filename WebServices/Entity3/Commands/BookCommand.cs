using WebService1.Entity3.Models;
using WebService1.Entity3.Repositories;
using System.Collections.Generic;
using WebService1.Entity3.Mappers;
using FluentValidation;

namespace WebService1.Entity3.Commands
{
    public class BookCommand : IBookCommand
    {
        private readonly IValidator<Book> _validator;
        private readonly IBookRepository _repos;
        private readonly IBookMapper _map;

        public BookCommand(IBookRepository repos, IBookMapper map, IValidator<Book> validator)
        {
            _repos = repos;
            _map = map;
            _validator = validator;
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
            if (!_validator.Validate(book).IsValid)
            {
                return;
            }
            _repos.Post(book);
        }

        public void Put(Book book)
        {
            if (!_validator.Validate(book).IsValid)
            {
                return;
            }
            _repos.Put(book);
        }

        public void Delete(int id)
        {
            if (id > 0)
            {
                _repos.Delete(id);
            }
        }
    }
}
