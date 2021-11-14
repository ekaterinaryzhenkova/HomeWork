using System.Collections.Generic;
using WebService1.Entity4.DbModels;
using WebService1.Entity4.DTO;
using WebService1.Entity4.Mappers;
using WebService1.Entity4.Repositories;

namespace WebService1.Entity4.Commands
{
    public class CustomerCommand : ICustomerCommand
    {
        //validator
        private readonly ICustomerRepository _repos;
        private readonly ICustomerMapper _map;

        public CustomerCommand(ICustomerRepository repos, ICustomerMapper map)
        {
            _repos = repos;
            _map = map;
        }

        public CustomerDTO Get(int id)
        {
            DbCustomer dbcustomer = _repos.Get(id);
            if (dbcustomer is not null)
            {
                CustomerDTO customerdto = _map.Convertobj(dbcustomer);
                return customerdto;
            }
            return null;
        }

        public IEnumerable<CustomerDTO> GetAll()
        {
            IEnumerable<DbCustomer> dbcustomers = _repos.GetAll();
            if(dbcustomers is not null)
            {
                IEnumerable<CustomerDTO> customersDTO = _map.ConvertAll(dbcustomers);
                return customersDTO;
            }
            return null;
        }

        public void Post(DbCustomer customer)
        {
            _repos.Post(customer);
        }

        public void Put(DbCustomer customer)
        {
            _repos.Put(customer);
        }

        public void Delete(int id)
        {
            _repos.Delete(id);
        }
    }
}
