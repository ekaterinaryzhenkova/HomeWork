using FluentAssertions.Common;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebService2.Requests;
using WebService2.Response;

namespace WebService2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<CustomerResponse> Get([FromServices] IRequestClient<CustomerRequest> request, [FromQuery] int id)
        {
            return (await request.GetResponse<CustomerResponse>(new CustomerRequest() {Id = id})).Message;
        }

    /*    [HttpGet]
        public async Task<IEnumerable<CustomerResponse>> GetAll([FromServices] IRequestClient<GetAllCustomerRequest> request)
        {
            return await request.GetResponse<GetAllCustomerResponse>(new GetAllCustomerRequest()).Message;
        }
    */
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

