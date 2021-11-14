using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebService1.Entity1_2.Models;
using WebService1.Entity1_2.Repositories;

namespace WebService1.Entity1_2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StationaryController : ControllerBase
    {
        private readonly IProductRepository<Stationary> repos;
        public StationaryController(IProductRepository<Stationary> stationary)
        {
            repos = stationary;
        }
      
       
        [HttpGet]
        public IEnumerable<Stationary> GetAll()
        {
            return repos.GetAll();
        }

        [HttpGet("{id}")] 
        public Stationary Get(int id)
        {
            return repos.Get(id);
        }
        
        [HttpPost] 
        public Stationary Post([FromBody] Stationary product)
        {
            return repos.Post(product);
          
        }

        [HttpPut]
        public Stationary Put([FromBody] Stationary product)
        {
            repos.Update(product);
            return product; 
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repos.Delete(id);      
        }
    }
}
