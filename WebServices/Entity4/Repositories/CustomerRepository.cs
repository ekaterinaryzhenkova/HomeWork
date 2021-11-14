using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebService1.Entity4.DbModels;

namespace WebService1.Entity4.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private InfoContext db;
        public CustomerRepository(InfoContext context)
        {
            db = context;
        }
        public IEnumerable<DbCustomer> GetAll()
        {
            return db.Customers.Include(x => x.Numbers).ToList();
        }

        public DbCustomer Get(int id)
        {
            return db.Customers.Include(x => x.Numbers).FirstOrDefault(x => x.Id == id);
        }

        public void Put(DbCustomer customer)
        {
            var upcustomer = db.Customers.FirstOrDefault(x => x.Id == customer.Id);
            if(upcustomer is not null)
            {
                upcustomer.Name = customer.Name;
                upcustomer.Age = customer.Age;
                db.SaveChanges();
            }
        }

        public void Post(DbCustomer customer)
        {
            db.Add(customer);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var customer = db.Customers.FirstOrDefault(x => x.Id == id);

            if (customer is not null)
            {
                db.Customers.Remove(customer);
                db.SaveChanges();
            }
        }
    }
}
