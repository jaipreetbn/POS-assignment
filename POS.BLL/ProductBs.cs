using POS.BOL;
using POS.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.BLL
{
    public class ProductBs
    {
        private ProductDb _db;
        public ProductBs()
        {
            _db = new ProductDb();
        }
        public void AddProduct(Product item)
        {
            _db.Save(item);
        }

        public Product Get(char productCode)
        {
            return _db.Find(productCode);
        }

        public IEnumerable<Product> GetAll()
        {
            return _db.FindAll();
        }
    }
}
