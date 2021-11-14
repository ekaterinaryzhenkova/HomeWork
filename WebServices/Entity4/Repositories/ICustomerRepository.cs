using System.Collections.Generic;
using WebService1.Entity4.DbModels;

namespace WebService1.Entity4.Repositories
{
    public interface ICustomerRepository
    {
         IEnumerable<DbCustomer> GetAll();
         DbCustomer Get(int id);
         void Post(DbCustomer i);
         void Put(DbCustomer i);
         void Delete(int id);
     /*}
        GetCustomerResponse Get(Guid id);
        DeleteCustomerResponse Delete(Guid id);
        PostCustomerResponse Post(Customer user);
        PutCustomerResponse Put(Customer user);
        GetAllCustomerResponse GetAll();*/

    }
}
