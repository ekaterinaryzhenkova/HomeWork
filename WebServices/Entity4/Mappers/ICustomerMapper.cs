using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebService1.Entity4.DbModels;
using WebService1.Entity4.DTO;

namespace WebService1.Entity4.Mappers
{
    public interface ICustomerMapper
    {
        IEnumerable<CustomerDTO> ConvertAll(IEnumerable<DbCustomer> customerss);
        CustomerDTO Convertobj(DbCustomer dbnumber);
    }
}
