using MassTransit;
using Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebService1.Entity4.DbModels;
using WebService1.Entity4.DTO;
using WebService1.Entity4.Mappers;
using WebService1.Entity4.Repositories;
using WebService2.Requests;

namespace WebService1.Entity4.Consumers.Customer
{
    public class GetAllCustomersConsumer //: IConsumer<GetAllCustomerRequest>
    {
        private ICustomerRepository _repos;
        private readonly ICustomerMapper _map;
        public GetAllCustomersConsumer(ICustomerRepository repos, ICustomerMapper map)
        {
            _repos = repos;
            _map = map;
        }
       /* public void GetAll(ConsumeContext<GetAllCustomerRequest> req)
        {
            var res = _repos.GetAll();
            CustomerDTO result;
            if(res is not null)
            {
               result = (CustomerDTO)_map.ConvertAll(res);
            }
            req.Respond(new GetAllCustomerResponse() { Customers = result });
        }*/
    }
    
}
