using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebService1.Entity4.Commands;
using WebService1.Entity4.DbModels;
using WebService1.Entity4.DTO;

namespace WebService1.Entity4.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController
    {
        private readonly ICustomerCommand  _command;
        public CustomerController(ICustomerCommand command)
        {
            _command = command;
        }

        [HttpGet]
        public async Task<IEnumerable<CustomerDTO>> GetAll()
        {
            IEnumerable<CustomerDTO> customers = await _command.GetAll();
            return customers;

        }

        [HttpGet("{id}")]
        public async Task<CustomerDTO> Get(int id)
        {
            return await _command.Get(id);
        }

        [HttpPost]
        public async Task Post([FromBody] DbCustomer customer)
        {
            await _command.Post(customer);
        }

        [HttpPut]
        public async Task Put([FromBody] DbCustomer customer)
        {
            await _command.Put(customer);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _command.Delete(id);
        }
    }
}

