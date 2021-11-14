using System.Collections.Generic;
using System.Linq;
using WebService1.Entity4.DbModels;
using WebService1.Entity4.DTO;

namespace WebService1.Entity4.Mappers
{
    public class PhoneNumbersMapper : IPhoneNumbersMapper
    {
        public IEnumerable<PhoneNumberDTO> ConvertAll(IEnumerable<DbPhoneNumber> numbers)
        {
            var result = numbers.Select(x =>
            new PhoneNumberDTO
            {
               Number  = x.Number,
               Customer = new CustomerDTO { Age = x.Customer.Age, Name = x.Customer.Name }
        }).ToList();
            return result;
        }

        //public IEnumerable<PhoneNumberDTO> Convert(IEnumerable<DbPhoneNumber> numbers)
        //{
        //    var result = numbers.Select(x =>
        //    new PhoneNumberDTO
        //    {
        //        Number = x.Number,
        //    }).ToList();
        //    return result;
        //}

        public PhoneNumberDTO Convertobj(DbPhoneNumber dbnumber)
        {
            return new PhoneNumberDTO { Number = dbnumber.Number };
        }
    }
}

