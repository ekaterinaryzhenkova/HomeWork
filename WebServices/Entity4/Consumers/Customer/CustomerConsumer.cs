using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebService2.Requests;
using WebService2.Response;

namespace WebService1.Entity4.Consumers
{
    public class CustomerConsumer  : IConsumer<CustomerRequest>
    {
        public async Task Consume(ConsumeContext<CustomerRequest> context)
        {
            await context.RespondAsync(new CustomerResponse
            {
                Name = "Василий",
                Age = 36
            });
        }
    }
}
