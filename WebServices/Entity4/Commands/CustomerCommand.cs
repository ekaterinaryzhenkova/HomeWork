using FluentValidation;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebService1.Entity4.DbModels;
using WebService1.Entity4.DTO;
using WebService1.Entity4.Mappers;
using WebService1.Entity4.Repositories;

namespace WebService1.Entity4.Commands
{
    public class CustomerCommand : ICustomerCommand
    {
        private readonly IValidator<DbCustomer> _validator;
        private readonly ICustomerRepository _repos;
        private readonly ICustomerMapper _map;

        public CustomerCommand(ICustomerRepository repos, ICustomerMapper map, IValidator<DbCustomer> validator)
        {
            _repos = repos;
            _map = map;
            _validator = validator;
        }

        public async Task<CustomerDTO> Get(int id)
        {
            DbCustomer dbcustomer = await _repos.Get(id);
            if (dbcustomer is not null)
            {
                CustomerDTO customerdto = _map.Convertobj(dbcustomer);
                return customerdto;
            }
            return null;
        }

        public async Task<IEnumerable<CustomerDTO>> GetAll()
        {
            IEnumerable<DbCustomer> dbcustomers = await _repos.GetAll();
            if(dbcustomers is not null)
            {
                IEnumerable<CustomerDTO> customersDTO = _map.ConvertAll(dbcustomers);
                return customersDTO;
            }
            return null;
        }

        public async Task Post(DbCustomer customer)
        {
            var result = _validator.Validate(customer);
            if (!result.IsValid)
            {
                return;
            }
            await _repos.Post(customer);
        }

        public async Task Put(DbCustomer customer)
        {
            var result = _validator.Validate(customer);
            if (!result.IsValid)
            {
                return;
            }
           await _repos.Put(customer);
        }

        public async Task Delete(int id)
        {
            if (id > 0)
            {
              await _repos.Delete(id);
            }
        }
    }
}
