using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebService1.Entity4.DbModels;
using WebService1.Entity4.DTO;

namespace WebService1.Entity4.Mappers
{
    public interface IPhoneNumbersMapper
    {
        IEnumerable<PhoneNumberDTO> ConvertAll(IEnumerable<DbPhoneNumber> numbers);
        PhoneNumberDTO Convertobj(DbPhoneNumber dbnumber);

    }
}
