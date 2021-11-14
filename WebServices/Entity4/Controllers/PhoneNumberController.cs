using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebService1.Entity4.Commands;
using WebService1.Entity4.DbModels;
using WebService1.Entity4.DTO;

namespace WebService1.Entity4.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PhoneNumberController
    {
        private readonly IPhoneNumberCommand _command;
        public PhoneNumberController(IPhoneNumberCommand command)
        {
            _command = command;
        }

        [HttpGet]
        public IEnumerable<PhoneNumberDTO> GetAll()
        {
            IEnumerable<PhoneNumberDTO> numbers = _command.GetAll();
            return numbers;

        }

        [HttpGet("{id}")]
        public PhoneNumberDTO Get(int id)
        {
            return _command.Get(id);
        }

        [HttpPost]
        public void Post([FromBody] DbPhoneNumber number)
        {
            _command.Post(number);
        }

        [HttpPut]
        public void Put([FromBody] DbPhoneNumber number)
        {
            _command.Put(number);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _command.Delete(id);
        }
    }
}
