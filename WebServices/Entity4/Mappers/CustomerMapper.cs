using System.Collections.Generic;
using System.Linq;
using WebService1.Entity4.DbModels;
using WebService1.Entity4.DTO;

namespace WebService1.Entity4.Mappers
{
    public class CustomerMapper : ICustomerMapper
    {
        private readonly IPhoneNumbersMapper _map;
        public CustomerMapper(IPhoneNumbersMapper map)
        {
            _map = map;
        }
        public IEnumerable<CustomerDTO> ConvertAll(IEnumerable<DbCustomer> customers)
        {
            var result = customers.Select(x =>
            new CustomerDTO
            {
                Name = x.Name,
                Age = x.Age,
                Numbers = _map.ConvertAll(x.Numbers),
            }).ToList();
            return result;
        }

        public CustomerDTO Convertobj(DbCustomer dbcustomer)
        {
            return new CustomerDTO { Age = dbcustomer.Age, Name = dbcustomer.Name };
        }
      /*  public IEnumerable<string> ConvertAll(IEnumerable<DbPhoneNumber> numbers)
        {
            List<string> res = new List<string>();
            foreach(var item in numbers)
            {
                (numbers.Number).Add
            }
            return result;
        }*/
    }
}
