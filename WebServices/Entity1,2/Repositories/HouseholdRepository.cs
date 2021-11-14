using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Linq;
using WebService1.Entity1_2.Models;

namespace WebService1.Entity1_2.Repositories
{
    public class HouseholdRepository : IProductRepository<HouseholdGoods>
    {
        public static List<HouseholdGoods> _products;
        private readonly IMemoryCache _cache;
        public HouseholdRepository(IMemoryCache cache)
        {
            _cache = cache;
        }
        public List<HouseholdGoods> Create()
        {
            _products = new List<HouseholdGoods>()
            {
                 new HouseholdGoods { Id = 1, Name = "Mug", Price = 100 },
                 new HouseholdGoods { Id = 2, Name = "Thermos", Price = 799},
                 new HouseholdGoods { Id = 3, Name = "Glue", Price = 40}
            };

            return _products;
        }

        public HouseholdGoods Get(int id)
        {
            if (_products == null)
            {
                Create();
            }
            var product = _products.FirstOrDefault(p => p.Id == id);
            return product;
        }
        public IEnumerable<HouseholdGoods> GetAll()
        {
            if (_products == null)
            {
                Create();
                foreach(var item in _products)
                {
                    _cache.Set(item.Id, item);
                }
            }

            return _products;
        }

        public HouseholdGoods Post(HouseholdGoods product)
        {
            _products.Add(product);
            _cache.Set(product.Id, product);
            return product;
        }

        public HouseholdGoods Update(HouseholdGoods product)
        {
            _cache.Set(product.Id, product);
            var editproduct = _products.FirstOrDefault(x => x.Id == product.Id);
            if (editproduct is not null) //?
            {
                editproduct.Name = product.Name;
                editproduct.Price = product.Price;
            }
            return editproduct;
        }
        public void Delete(int id)
        {
            _cache.Remove(id);
            var deleteproduct = _products.FirstOrDefault(x => x.Id == id);
            if (deleteproduct != null)
            {
                _products.Remove(deleteproduct);
            }
        }
    }
}
