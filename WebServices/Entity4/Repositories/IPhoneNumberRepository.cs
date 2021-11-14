using System.Collections.Generic;
using WebService1.Entity4.DTO;
using WebService1.Entity4.DbModels;
using Models.Response;
using System;
using Modelslb;

namespace WebService1.Entity4.Repositories
{
    public interface IPhoneNumberRepository
    {
          IEnumerable<DbPhoneNumber> GetAll();
          DbPhoneNumber Get(int id);
          void Post(DbPhoneNumber i);
          void Put(DbPhoneNumber i);
          void Delete(int id);

        /*GetPhoneNumberResponse Get(Guid id);
        DeletePhoneNumberResponse Delete(Guid id);
        PostPhoneNumberResponse Post(PhoneNumber user);
        PutPhoneNumberResponse Put(PhoneNumber user);
        GetAllPhoneNumberResponse GetAll();*/

    }
}
