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
        public async Task<IEnumerable<DbCustomer>> GetAll()
        {
            return await db.Customers.Include(x => x.Numbers).ToListAsync();
        }

        public async Task<DbCustomer> Get(int id)
        {
            return await db.Customers.Include(x => x.Numbers).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Put(DbCustomer customer)
        {
            var upcustomer = await db.Customers.FirstOrDefaultAsync(x => x.Id == customer.Id);
            if(upcustomer is not null)
            {
                upcustomer.Name = customer.Name;
                upcustomer.Age = customer.Age;
                await db.SaveChangesAsync();
            }
        }

        public async Task Post(DbCustomer customer)
        {
            await db.AddAsync(customer);
            await db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var customer = await db.Customers.FirstOrDefaultAsync(x => x.Id == id);

            if (customer is not null)
            {
                db.Customers.Remove(customer);
                await db.SaveChangesAsync();
            }
        }
    }
}
