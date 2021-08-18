using POS.BOL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace POS.DAL
{
    public class ProductDb
    {
        private List<Product> _lstProductPrice;
        public ProductDb()
        {
            _lstProductPrice = new List<Product>();
        }

        public void Save(Product item)
        {
            _lstProductPrice.Add(item);
        }
        public Product Find(char productCode)
        {
            return _lstProductPrice.Where(x => x.ProductCode == productCode).FirstOrDefault();
        }

        public IEnumerable<Product> FindAll()
        {
            return _lstProductPrice;
        }

    }
}
