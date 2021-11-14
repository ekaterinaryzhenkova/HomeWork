using System.Collections.Generic;
using WebService1.Entity3.Models;

namespace WebService1.Entity3.Repositories
{
    public interface IBookRepository
    {
        void Post(Book i);
        void Put(Book i);
        void Delete(int id);

    }
}
