using System.Collections.Generic;
using WebService1.Entity3.Models;

namespace WebService1.Entity3.Commands
{
    public interface IBookCommand
    {
        IEnumerable<Book> GetAll();
        Book Get(int id);
        void Post(Book i);
        void Put(Book i);
        void Delete(int id);
    }
}