using System.Collections.Generic;
using System.Threading.Tasks;
using WebService1.Entity4.DbModels;
using WebService1.Entity4.DTO;

namespace WebService1.Entity4.Commands
{
    public interface ICustomerCommand
    {
        Task<IEnumerable<CustomerDTO>> GetAll();
        Task<CustomerDTO> Get(int id);
        Task Delete(int id);
        Task Put(DbCustomer customer);
        Task Post(DbCustomer customer);
    }
}
