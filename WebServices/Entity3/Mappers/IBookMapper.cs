using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebService1.Entity3.Models;

namespace WebService1.Entity3.Mappers
{
    public interface IBookMapper
    {
        List<Book> GetAllBooks();
        Book GetBook(int Id);
    }
}
