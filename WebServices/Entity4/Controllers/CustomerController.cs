using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
        public IEnumerable<CustomerDTO> GetAll()
        {
            IEnumerable<CustomerDTO> customers = _command.GetAll();
            return customers;

        }

        [HttpGet("{id}")]
        public CustomerDTO Get(int id)
        {
            return _command.Get(id);
        }

        [HttpPost]
        public void Post([FromBody] DbCustomer customer)
        {
             _command.Post(customer);
        }

        [HttpPut]
        public void Put([FromBody] DbCustomer customer)
        {
            _command.Put(customer);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _command.Delete(id);
        }
    }
}

