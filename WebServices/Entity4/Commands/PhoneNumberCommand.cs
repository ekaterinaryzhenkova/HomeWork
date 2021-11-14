using FluentValidation;
using System.Collections.Generic;
using WebService1.Entity4.DbModels;
using WebService1.Entity4.DTO;
using WebService1.Entity4.Mappers;
using WebService1.Entity4.Repositories;

namespace WebService1.Entity4.Commands
{
    public class PhoneNumberCommand : IPhoneNumberCommand
    {
        private readonly IValidator<DbPhoneNumber> _validator;
        private readonly IPhoneNumberRepository _repos;
        private readonly IPhoneNumbersMapper _map;

        public PhoneNumberCommand(IPhoneNumberRepository repos, IPhoneNumbersMapper map, IValidator<DbPhoneNumber> validator)
        {
            _repos = repos;
            _map = map;
            _validator = validator;
        }

        public PhoneNumberDTO Get(int id)
        {
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
            if (!_validator.Validate(number).IsValid)
            {
                return;
            }
            _repos.Post(number);
        }

        public void Put(DbPhoneNumber number)
        {
            if (!_validator.Validate(number).IsValid)
            {
                return;
            }
            _repos.Put(number);
        }

        public void Delete(int id)
        {
            if (id > 0)
            {
                _repos.Delete(id);
            }
        }
    }
}

