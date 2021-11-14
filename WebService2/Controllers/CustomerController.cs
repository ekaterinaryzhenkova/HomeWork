using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebService2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    { 

        [HttpGet]
        public void GetAll()
        {
            

        }

        [HttpGet("{id}")]
        public void Get(int id)
        {
            
        }

        [HttpPost]
        public void Post()
        {
            
        }

        [HttpPut]
        public void Put()
        {
           
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            
        }
    }
}

