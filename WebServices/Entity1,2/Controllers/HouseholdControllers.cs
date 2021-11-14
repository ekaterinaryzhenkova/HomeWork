using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using WebService1.Entity1_2.Models;
using WebService1.Entity1_2.Repositories;

namespace WebService1.Entity1_2.Controllers
{
    public class HouseholdControllers
    {
        [ApiController]
        [Route("api/[controller]")]
        public class HouseholdController : ControllerBase
        {

            private readonly IProductRepository<HouseholdGoods> repos;
            private readonly IMemoryCache _cache;
            public HouseholdController(IProductRepository<HouseholdGoods> product)
            {
                repos = product;
            }

            [HttpGet]
            public IEnumerable<HouseholdGoods> GetAll()
            {
                IEnumerable<HouseholdGoods> lst = repos.GetAll();
              
                return lst;
               
            }

            [HttpGet("{id}")]
            public HouseholdGoods Get(int id)
            {
                return repos.Get(id);
            }

            [HttpPost]
            public HouseholdGoods Post([FromBody] HouseholdGoods product)
            {
                var entry = _cache.CreateEntry("Householdproduct");
                return repos.Post(product);
            }

            [HttpPut]
            public HouseholdGoods Put([FromBody] HouseholdGoods product)
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
}
