using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebService1.Entity1_2.Models;

namespace WebService1.Entity1_2.Commands
{
    public interface IHouseholdCommand
    {
        public void Post(HouseholdGoods product);
        public void Put(HouseholdGoods product);
        public void Delete(int id);
        public IEnumerable<HouseholdGoods> GetAll();
        public HouseholdGoods Get(int id);


    }
}
