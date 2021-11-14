using System.Collections.Generic;
using WebService1.Entity4.DbModels;
using WebService1.Entity4.DTO;

namespace WebService1.Entity4.Commands
{
    public interface ICustomerCommand
    {
        IEnumerable<CustomerDTO> GetAll();
        CustomerDTO Get(int id);
        void Post(DbCustomer i);
        void Put(DbCustomer i);
        void Delete(int id);
    }
}
