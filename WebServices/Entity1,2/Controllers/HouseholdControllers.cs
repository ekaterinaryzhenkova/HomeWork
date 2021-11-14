using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using WebService1.Entity1_2.Models;
using WebService1.Entity1_2.Repositories;
using WebService1.Entity1_2.Commands;

namespace WebService1.Entity1_2.Controllers
{
    public class HouseholdControllers
    {
        [ApiController]
        [Route("api/[controller]")]
        public class HouseholdController : ControllerBase
        {

            private readonly IHouseholdCommand _com;

            public HouseholdController(IHouseholdCommand product)
            {
                _com = product;
            }

            [HttpGet]
            public IEnumerable<HouseholdGoods> GetAll()
            {
                IEnumerable<HouseholdGoods> lst = _com.GetAll();
                return lst;
            }

            [HttpGet("{id}")]
            public HouseholdGoods Get(int id)
            {
                return _com.Get(id);

            }

            [HttpPost]
            public void Post([FromBody] HouseholdGoods product)
            {
                 _com.Post(product);
            }

            [HttpPut]
            public void Put([FromBody] HouseholdGoods product)
            {
                _com.Put(product);
            }

            [HttpDelete("{id}")]
            public void Delete(int id)
            {
                _com.Delete(id);
            }
        }
    }
}
