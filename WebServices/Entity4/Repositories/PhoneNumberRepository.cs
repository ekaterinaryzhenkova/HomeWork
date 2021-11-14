using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebService1.Entity4.DbModels;

namespace WebService1.Entity4.Repositories
{
    public class PhoneNumberRepository : IPhoneNumberRepository
    {
        private InfoContext db;
        public PhoneNumberRepository(InfoContext context)
        {
            db = context;
        }
        public IEnumerable<DbPhoneNumber> GetAll()
        {
            return db.Numbers.Include(x => x.Customer).ToList();
        }

        public DbPhoneNumber Get(int id)
        {
            return  db.Numbers.Include(x => x.Customer).FirstOrDefault(x => x.PhoneId == id);
        }

        public void Put(DbPhoneNumber number)
        {
            var upnumber = db.Numbers.FirstOrDefault(x => x.PhoneId == number.PhoneId);
            if (upnumber is not null)
            {
                upnumber.Number = number.Number;
                db.SaveChanges();
            }
        }

        public void Post(DbPhoneNumber number)
        {
            db.Add(number);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var number = db.Numbers.FirstOrDefault(x => x.PhoneId == id);

            if (number is not null)
            {
                db.Numbers.Remove(number);
                db.SaveChanges();
            }
        }
    }
}
