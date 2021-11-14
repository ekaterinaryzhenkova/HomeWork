using System.Collections.Generic;
using WebService1.Entity4.DbModels;
using WebService1.Entity4.DTO;

namespace WebService1.Entity4.Commands
{
    public interface IPhoneNumberCommand
    {
        IEnumerable<PhoneNumberDTO> GetAll();
        PhoneNumberDTO Get(int id);
        void Post(DbPhoneNumber i);
        void Put(DbPhoneNumber i);
        void Delete(int id);
    }
}
