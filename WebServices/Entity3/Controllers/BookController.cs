using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebService1.Entity3.Models;
using WebService1.Entity3.Commands;

namespace WebService1.Entity3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookCommand _command;
        public BookController(IBookCommand command)
        {
            _command = command;
        }

        [HttpGet]
        public List<Book> GetAll()
        {
            return (List<Book>)_command.GetAll();
        }

        [HttpGet("{id}")]
        public Book Get(int id)
        {
            return _command.Get(id);
        }

        [HttpPost]
        public void Post([FromBody] Book book)
        {
            _command.Post(book);
        }

        [HttpPut]
        public void Put([FromBody]Book book)
        {
            _command.Put(book);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _command.Delete(id);
        }
    }
}
