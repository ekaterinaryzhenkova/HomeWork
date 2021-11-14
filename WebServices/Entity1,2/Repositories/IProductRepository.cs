using System.Collections.Generic;

namespace WebService1.Entity1_2.Repositories
{
    public interface IProductRepository<T>
    {
        IEnumerable<T> GetAll();
        List<T> Create();
        T Get(int id);
        T Post(T product);
        T Update(T product);
        void Delete(int id);
    }
}
