using System.Collections.Generic;
using System.IO;
using System.Linq;
using WebService1.Entity1_2.Models;

namespace WebService1.Entity1_2.Repositories
{
    public class StationaryRepository : IProductRepository<Stationary>
    {
        public static List<Stationary> _products;
        public List<Stationary> Create()
        {
            _products = new List<Stationary>()
            {
                 new Stationary { Id = 1, Name = "Pen", Price = 10 },
                 new Stationary { Id = 2, Name = "Pencil", Price = 20},
                 new Stationary { Id = 3, Name = "Notebook", Price = 30}
            };

            return _products;
        }
        public Stationary Get(int id)
        {
            if (_products == null)
            {
                Create();
            }
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return null;
            }
            return product;
        }
        public IEnumerable<Stationary> GetAll()
        {
            if (_products == null)
            {
                Create();
            }

            return _products;
        }

        public Stationary Post(Stationary product)
        {
            if (_products == null)
            {
                Create();
            }
            if (IsEmptyFile())
            {
                CreateFileStationary();
            }

            _products.Add(product);
            AddtoFileStationary(product);
            return product;

        }

        public Stationary Update(Stationary product)
        {
            if (_products == null)
            {
                Create();
            }

            if(IsEmptyFile())
            {
                CreateFileStationary();
            }

            var editproduct = _products.FirstOrDefault(x => x.Id == product.Id);
            if (editproduct != null)
            {
                editproduct.Name = product.Name;
                editproduct.Price = product.Price;
                UpdateFileStationary(_products);
            }

            return editproduct;
        }
        public void Delete(int id)
        {
            var deleteproduct = _products.FirstOrDefault(x => x.Id == id);
            if (deleteproduct != null)
            {
                _products.Remove(deleteproduct);
                DeleteFileStationary(_products);
            }
        }

        public void CreateFileStationary()
        {
            using (StreamWriter tw = new StreamWriter(@"C:\File\Stationary.txt"))
            {
                foreach (var item in _products)
                {
                    tw.WriteLine(string.Format("Id: {0}, Name: {1}, Price:{2}", item.Id, item.Name, item.Price.ToString()));
                }
            }
        }
        public void AddtoFileStationary(Stationary item)
        {
            using (StreamWriter tw = new StreamWriter(@"C:\File\Stationary.txt", true))
            {
                tw.WriteLine(string.Format("Id: {0}, Name: {1}, Price:{2}", item.Id, item.Name, item.Price.ToString()));
            }
        }
        public void UpdateFileStationary(List<Stationary> stationaryobj)
        {
            using (StreamWriter tw = new StreamWriter(@"C:\File\Stationary.txt", false))
            {
                foreach (var item in stationaryobj)
                {
                    tw.WriteLine(string.Format("Id: {0}, Name: {1}, Price:{2}", item.Id, item.Name, item.Price.ToString()));
                }
            }
        }
        public void DeleteFileStationary(List<Stationary> _products)
        {
            using (StreamWriter tw = new StreamWriter(@"C:\File\Stationary.txt", false))
            {
                foreach (var item in _products)
                {
                    tw.WriteLine(string.Format("Id: {0}, Name: {1}, Price:{2}", item.Id, item.Name, item.Price.ToString()));
                }
            }
        }

        public bool IsEmptyFile()
        {
            if(new FileInfo(@"C:\File\Stationary.txt").Length == 0)
            {
                return true;
            }
            return false;
        }
    }
}
