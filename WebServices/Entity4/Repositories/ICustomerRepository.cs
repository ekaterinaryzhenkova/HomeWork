using System.Collections.Generic;
using System.Threading.Tasks;
using WebService1.Entity4.DbModels;

namespace WebService1.Entity4.Repositories
{
    public interface ICustomerRepository
    {
         Task<IEnumerable<DbCustomer>> GetAll();
         Task<DbCustomer> Get(int id);
         Task Post(DbCustomer i);
         Task Put(DbCustomer i);
         Task Delete(int id);
    }
}
