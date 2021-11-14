using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebService1.Entity1_2.Models;

namespace WebService1.Entity1_2.Commands
{
    interface IStationaryCommand
    {
        public void Post(Stationary product);
        public void Put(Stationary product);
        public void Delete(int id);
        public IEnumerable<Stationary> GetAll();
        public Stationary Get(int id);
    }
}
