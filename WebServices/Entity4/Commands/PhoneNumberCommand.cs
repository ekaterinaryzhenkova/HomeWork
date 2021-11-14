using System.Collections.Generic;
using WebService1.Entity4.DbModels;
using WebService1.Entity4.DTO;
using WebService1.Entity4.Mappers;
using WebService1.Entity4.Repositories;

namespace WebService1.Entity4.Commands
{
    public class PhoneNumberCommand : IPhoneNumberCommand
    {
        private readonly IPhoneNumberRepository _repos;
        private readonly IPhoneNumbersMapper _map;

        public PhoneNumberCommand(IPhoneNumberRepository repos, IPhoneNumbersMapper map)
        {
            _repos = repos;
            _map = map;
        }

        public PhoneNumberDTO Get(int id)
        {
            //validator
            DbPhoneNumber dbnumber = _repos.Get(id);
            if (dbnumber is not null)
            {
                PhoneNumberDTO numberdto = _map.Convertobj(dbnumber);
                return numberdto;
            }
            return null;
        }

        public IEnumerable<PhoneNumberDTO> GetAll()
        {
            IEnumerable<DbPhoneNumber> dbnumbers = _repos.GetAll();
            if (dbnumbers is not null)
            {
                IEnumerable<PhoneNumberDTO> numbersdto = _map.ConvertAll(dbnumbers);
                return numbersdto;
            }
            return null;
        }

        public void Post(DbPhoneNumber number)
        {
            _repos.Post(number);
        }

        public void Put(DbPhoneNumber number)
        {
            _repos.Put(number);
        }

        public void Delete(int id)
        {
            _repos.Delete(id);
        }
    }
}

