using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebService1.Entity1_2.Models;
using WebService1.Entity1_2.Repositories;

namespace WebService1.Entity1_2.Commands
{
    public class HouseholdCommand
    {
        private readonly IValidator<HouseholdGoods> _validator;
        private readonly IProductRepository<HouseholdGoods> _repos;

        public void Post(HouseholdGoods product)
        {
            if (_validator.Validate(product).IsValid)
            {
                _repos.Post(product);
            }
            return;
        }

        public void Put(HouseholdGoods product)
        {
            if (_validator.Validate(product).IsValid)
            {
                _repos.Update(product);
            }
            return;
        }

        public void Delete(int id)
        {
            if (id > 0)
            {
                _repos.Delete(id);
            }
        }

        public HouseholdGoods Get(int id)
        {
            if (id <= 0)
            {
                return null;
            }
            return _repos.Get(id);

        }

        public IEnumerable<HouseholdGoods> GetAll()
        {
            return _repos.GetAll();
        }
    }
}
